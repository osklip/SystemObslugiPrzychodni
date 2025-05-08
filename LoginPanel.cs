using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SystemObslugiPrzychodni
{
    public partial class LoginPanel : Form
    {
        // Maksymalna liczba nieudanych prób
        private const int MaxFailures = 3;
        // Czas blokady konta
        private static readonly TimeSpan BlockDuration = TimeSpan.FromMinutes(5);

        // Przechowujemy w pamięci liczniki i blokady
        private static readonly Dictionary<string, int> _failCounts =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, DateTime> _lockouts =
            new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

        public LoginPanel()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string login = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // 1. Walidacja pustych pól
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ShowError("Podaj nazwę użytkownika i hasło.");
                return;
            }

            // 2. Sprawdź blokadę w pamięci
            if (_lockouts.TryGetValue(login, out var until) && until > DateTime.Now)
            {
                var rem = until - DateTime.Now;
                MessageBox.Show(
                    $"Konto zablokowane. Spróbuj za {rem.Minutes}m {rem.Seconds}s.",
                    "Konto zablokowane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 3. Pobierz hasło z bazy (tekstowe)
            using var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT password
                  FROM tbl_user
                 WHERE login = $login;
            ";
            cmd.Parameters.AddWithValue("$login", login);

            var storedPwd = cmd.ExecuteScalar() as string;
            if (storedPwd == null)
            {
                ShowError("Niepoprawny login lub hasło.");
                return;
            }

            // 4. Porównanie plaintext
            if (password != storedPwd)
            {
                RegisterFailure(login);
                return;
            }

            // 5. Udane logowanie – reset licznika i blokady
            _failCounts.Remove(login);
            _lockouts.Remove(login);

            // 6. Otwórz panel Admina
            new AdminMenuForm().Show();
            this.Hide();
        }

        private void RegisterFailure(string login)
        {
            _failCounts.TryGetValue(login, out var fails);
            fails++;
            _failCounts[login] = fails;

            if (fails >= MaxFailures)
            {
                _lockouts[login] = DateTime.Now.Add(BlockDuration);
                _failCounts[login] = 0;
                MessageBox.Show(
                    $"Konto zablokowane na {BlockDuration.TotalMinutes} minut.",
                    "Konto zablokowane",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    $"Niepoprawne hasło. Pozostało prób: {MaxFailures - fails}.",
                    "Błąd logowania",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(
                msg,
                "Błąd logowania",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private void label3_Click(object sender, EventArgs e)
        {
            using var dlg = new ForgotPasswordForm();
            dlg.ShowDialog();
        }
    }
}
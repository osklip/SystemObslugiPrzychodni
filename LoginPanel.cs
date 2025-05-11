using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace SystemObslugiPrzychodni
{
    public partial class LoginPanel : Form
    {
        private readonly IServiceProvider _sp;
        // Maksymalna liczba nieudanych prób
        private const int MaxFailures = 3;
        // Czas blokady konta
        private static readonly TimeSpan BlockDuration = TimeSpan.FromMinutes(5);

        // Przechowujemy w pamięci liczniki i blokady
        private static readonly Dictionary<string, int> _failCounts =
            new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, DateTime> _lockouts =
            new Dictionary<string, DateTime>(StringComparer.OrdinalIgnoreCase);

        public static string Currentlogin { get; set; } = string.Empty;
        public LoginPanel(IServiceProvider sp)
        {
            InitializeComponent();
            _sp = sp;
        }

        private void btnLogin_Click(object sender, EventArgs e)
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

            using var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}");
            conn.Open();

            // 3. Pobierz dane użytkownika: ID, hasło i flagę is_temp
            int userId;
            string storedPwd;
            string isTemp;
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT user_id, password, is_temp
                      FROM tbl_user
                     WHERE login = $login;";
                cmd.Parameters.AddWithValue("$login", login);
                using var rdr = cmd.ExecuteReader();
                if (!rdr.Read())
                {
                    ShowError("Niepoprawny login.");
                    return;
                }
                userId = rdr.GetInt32(0);
                storedPwd = rdr.GetString(1);
                isTemp = rdr.IsDBNull(2) ? "0" : rdr.GetString(2);
            }

            // 4. Porównanie plaintext
            if (password != storedPwd)
            {
                RegisterFailure(login);
                return;
            }

            // 5. Wymuszenie zmiany hasła jeśli tymczasowe
            if (isTemp == "1")
            {
                this.Hide();
                using var forceForm = new ForceChangePasswordForm(userId);
                if (forceForm.ShowDialog() != DialogResult.OK)
                {
                    // Użytkownik anulował zmianę → restart aplikacji
                    Application.Restart();
                    return;
                }
                // Po zmianie hasła kontynuujemy
            }

            // 6. Udane logowanie – reset licznika i blokady
            _failCounts.Remove(login);
            _lockouts.Remove(login);

            Currentlogin = login;

            UserManagement.LoadCurrentUserPermissions(login);
            // 7. Otwórz panel Admina
            new AdminMenuForm(_sp).Show();
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

        private void label4_Click(object sender, EventArgs e)
        {
            var frm = _sp.GetRequiredService<ForgotPasswordForm>();
            frm.ShowDialog();
        }
    }
}
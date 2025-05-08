using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SystemObslugiPrzychodni
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            // 1. Pobierz dane z formularza: login i e-mail
            string login = txtLogin.Text.Trim();
            string email = txtEmail.Text.Trim();

            // 2. Walidacja pustych pól
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Wypełnij pola login i e-mail.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Generowanie nowego hasła
            string newPassword = GenerateRandomPassword(8);
            int rowsAffected;

            // 4. Aktualizacja hasła w bazie i oznaczenie, że jest tymczasowe
            using (var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}"))
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE tbl_user
                       SET password = $pwd,
                           is_temp  = '1'
                     WHERE login = $login
                       AND email = $email;";
                cmd.Parameters.AddWithValue("$pwd", newPassword);
                cmd.Parameters.AddWithValue("$login", login);
                cmd.Parameters.AddWithValue("$email", email);
                rowsAffected = cmd.ExecuteNonQuery();
            }

            // 5. Komunikat zwrotny
            if (rowsAffected == 1)
            {
                MessageBox.Show(
                    $"Twoje hasło zostało zresetowane.\nNowe hasło: {newPassword}",
                    "Odzyskiwanie hasła",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Nie znaleziono użytkownika o podanym loginie i e-mailu.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Zamknij formularz bez zmiany hasła
            this.Close();
        }

        private string GenerateRandomPassword(int length)
        {
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string special = "!@#$%^&*";
            var all = upper + lower + digits + special;
            var rnd = new Random();
            var pwd = new char[length];

            // Gwarancja co najmniej jednej z każdej grupy
            pwd[0] = upper[rnd.Next(upper.Length)];
            pwd[1] = special[rnd.Next(special.Length)];
            pwd[2] = digits[rnd.Next(digits.Length)];
            for (int i = 3; i < length; i++)
                pwd[i] = all[rnd.Next(all.Length)];

            // Przetasuj tablicę
            return new string(pwd.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}

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
            // 1. Pobierz dane z formularza
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Wypełnij pole E-mail.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtID.Text.Trim(), out int userId))
            {
                MessageBox.Show("Podaj poprawny identyfikator użytkownika.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Generowanie nowego hasła
            string newPassword = GenerateRandomPassword(8);
            int rowsAffected;

            // 3. Aktualizacja hasła w bazie
            using (var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}"))
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE tbl_user
                       SET password = $pwd
                     WHERE user_id = $id
                       AND email   = $email;";
                cmd.Parameters.AddWithValue("$pwd", newPassword);
                cmd.Parameters.AddWithValue("$id", userId);
                cmd.Parameters.AddWithValue("$email", email);
                rowsAffected = cmd.ExecuteNonQuery();
            }

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
                    "Nie znaleziono użytkownika o podanym ID i E-mailu.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Zamknij formularz bez zmian
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
            // gwarancja co najmniej jednej z każdej grupy
            pwd[0] = upper[rnd.Next(upper.Length)];
            pwd[1] = special[rnd.Next(special.Length)];
            pwd[2] = digits[rnd.Next(digits.Length)];
            for (int i = 3; i < length; i++)
                pwd[i] = all[rnd.Next(all.Length)];
            // przetasuj
            return new string(pwd.OrderBy(x => rnd.Next()).ToArray());
        }
    }
}
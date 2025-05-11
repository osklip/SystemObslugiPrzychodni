using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SystemObslugiPrzychodni
{
    public partial class ChangePasswordForm : Form
    {
        private readonly string _login;
        private static readonly char[] _specialChars = { '-', '_', '!', '*', '#', '$', '&' };

        public ChangePasswordForm(string login)
        {
            InitializeComponent();
            _login = login;
            lblLogin.Text = login;

            // zablokuj przycisk, dopóki nie spełnimy wszystkich reguł
            btnChange.Enabled = false;
            // podłącz walidację „na żywo”
            txtNew.TextChanged += txtNew_TextChanged;
        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {
            var pwd = txtNew.Text;

            bool okLength = pwd.Length >= 8 && pwd.Length <= 15;
            bool okUpper = pwd.Any(char.IsUpper);
            bool okLower = pwd.Any(char.IsLower);
            bool okDigit = pwd.Any(char.IsDigit);
            bool okSpecial = pwd.Any(ch => _specialChars.Contains(ch));

            lblRuleLength.ForeColor = okLength ? Color.Green : Color.DarkRed;
            lblRuleUpper.ForeColor = okUpper ? Color.Green : Color.DarkRed;
            lblRuleLower.ForeColor = okLower ? Color.Green : Color.DarkRed;
            lblRuleDigit.ForeColor = okDigit ? Color.Green : Color.DarkRed;
            lblRuleSpecial.ForeColor = okSpecial ? Color.Green : Color.DarkRed;

            btnChange.Enabled = okLength && okUpper && okLower && okDigit && okSpecial;
        }

        private void btnChange_Click_1(object sender, EventArgs e)
        {
            // potwierdzenie
            if (MessageBox.Show(
                    "Czy na pewno chcesz zmienić hasło?",
                    "Potwierdzenie zmiany",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                ) != DialogResult.Yes)
            {
                return;
            }

            string newPwd = txtNew.Text;
            string confirmPwd = txtConfirm.Text;

            // 1) zgodność
            if (newPwd != confirmPwd)
            {
                MessageBox.Show(
                    "Podane hasła różnią się od siebie, wprowadź je ponownie.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 2) zapis do bazy i wyłączenie flagi tymczasowości
            using (var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}"))
            {
                conn.Open();
                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE tbl_user
                       SET password = $pwd,
                           is_temp  = '0'
                     WHERE login = $login;
                ";
                cmd.Parameters.AddWithValue("$pwd", newPwd);
                cmd.Parameters.AddWithValue("$login", _login);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                {
                    MessageBox.Show(
                        "Hasło zostało zmienione pomyślnie.",
                        "Sukces",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Wystąpił błąd podczas zapisu hasła.",
                        "Błąd",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Zamknij formularz bez zmiany hasła
            Close();
        }
    }
}

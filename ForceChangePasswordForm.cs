using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SystemObslugiPrzychodni
{
    public partial class ForceChangePasswordForm : Form
    {
        private readonly int _userId;
        private static readonly char[] _specialChars = { '-', '_', '!', '*', '#', '$', '&' };

        public ForceChangePasswordForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

            // Na start przycisk wyłączony, reguły walidacyjne
            btnSet.Enabled = false;
            txtNew.TextChanged += TxtNew_TextChanged;
        }

        private void TxtNew_TextChanged(object sender, EventArgs e)
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

            btnSet.Enabled = okLength && okUpper && okLower && okDigit && okSpecial;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string newPwd = txtNew.Text;
            string confirm = txtConfirm.Text;

            // 1. Walidacja niepustych
            if (string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Wypełnij oba pola.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Porównanie
            if (newPwd != confirm)
            {
                MessageBox.Show("Podane hasła różnią się od siebie, wprowadź je ponownie.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Zapis do bazy
            using var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE tbl_user
                   SET password = $pwd,
                       is_temp  = '0'
                 WHERE user_id = $id;";
            cmd.Parameters.AddWithValue("$pwd", newPwd);
            cmd.Parameters.AddWithValue("$id", _userId);
            int rows = cmd.ExecuteNonQuery();

            if (rows == 1)
            {
                MessageBox.Show("Hasło zostało ustawione.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Błąd podczas zapisu. Spróbuj ponownie.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

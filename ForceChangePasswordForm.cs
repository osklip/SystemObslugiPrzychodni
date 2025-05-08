using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SystemObslugiPrzychodni
{
    public partial class ForceChangePasswordForm : Form
    {
        private readonly int _userId;

        public ForceChangePasswordForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string newPwd = txtNew.Text;
            string confirm = txtConfirm.Text;

            // Walidacja niepustych
            if (string.IsNullOrEmpty(newPwd) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Wypełnij oba pola.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Porównanie
            if (newPwd != confirm)
            {
                MessageBox.Show("Hasła nie są zgodne.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Zasady bezpieczeństwa
            bool hasUpper = newPwd.Any(char.IsUpper);
            bool hasSpecial = newPwd.Any(ch => !char.IsLetterOrDigit(ch));
            if (!hasUpper || !hasSpecial)
            {
                MessageBox.Show(
                    "Hasło musi zawierać wielką literę i znak specjalny.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // Zapis do bazy
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
                this.Close();
            }
            else
            {
                MessageBox.Show("Błąd podczas zapisu. Spróbuj ponownie.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

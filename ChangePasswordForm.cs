using System;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace SystemObslugiPrzychodni
{
    public partial class ChangePasswordForm : Form
    {
        private readonly string _login;

        public ChangePasswordForm(string login)
        {
            InitializeComponent();
            _login = login;
            lblLogin.Text = login;
        }

        private void btnChange_Click_1(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show(
            "Czy na pewno chcesz zmienić hasło?",
            "Potwierdzenie zmiany",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
             );
            if (confirmation == DialogResult.No)
                return;

            string current = txtCurrent.Text;
            string next = txtNew.Text;
            string confirm = txtConfirm.Text;

            // 1. Walidacja niepustych
            if (string.IsNullOrEmpty(current) ||
                string.IsNullOrEmpty(next) ||
                string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Wypełnij wszystkie pola.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Potwierdzenie nowego hasła
            if (next != confirm)
            {
                MessageBox.Show("Nowe hasło i potwierdzenie nie są zgodne.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Nie może być takie samo jak stare
            if (next == current)
            {
                MessageBox.Show("Nowe hasło nie może być identyczne z poprzednim.", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Sprawdź minimalne zasady: przynajmniej jedna duża litera i co najmniej jeden znak specjalny
            bool hasUpper = next.Any(char.IsUpper);
            bool hasSpecial = next.Any(ch => !char.IsLetterOrDigit(ch));
            if (!hasUpper || !hasSpecial)
            {
                MessageBox.Show(
                    "Hasło musi zawierać przynajmniej jedną wielką literę i co najmniej jeden znak specjalny.",
                    "Błąd",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 5. Weryfikacja, czy current pasuje do bazy
            using var conn = new SqliteConnection($"Data Source={UserManagement.dbpath}");
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT password FROM tbl_user WHERE login = $login;";
                cmd.Parameters.AddWithValue("$login", _login);
                var stored = cmd.ExecuteScalar() as string;
                if (stored == null || stored != current)
                {
                    MessageBox.Show("Aktualne hasło jest niepoprawne.", "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 6. Zapisz nowe hasło
            using (var upd = conn.CreateCommand())
            {
                upd.CommandText = @"
                    UPDATE tbl_user
                       SET password = $pwd
                     WHERE login = $login;
                ";
                upd.Parameters.AddWithValue("$pwd", next);
                upd.Parameters.AddWithValue("$login", _login);
                upd.ExecuteNonQuery();
            }

            MessageBox.Show("Hasło zostało zmienione pomyślnie.", "Sukces",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

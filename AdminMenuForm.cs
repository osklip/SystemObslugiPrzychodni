using System.Windows.Forms;

namespace SystemObslugiPrzychodni
{
    public partial class AdminMenuForm : Form
    {
        private readonly IServiceProvider _sp;
        public AdminMenuForm(IServiceProvider sp)
        {
            InitializeComponent();
            _sp = sp;

            if (UserManagement.CurrentUserPermissions[0] == 0) // Je�li brak uprawnienia do dodawania
            {
                OpenAddUserFormButton.Enabled = false; // Wy��cz przycisk
            }

            if (UserManagement.CurrentUserPermissions[2] == 0) // Je�li brak uprawnienia do wyswietlania
            {
                OpenUserListFormButton.Enabled = false; // Wy��cz przycisk
            }

            if (UserManagement.CurrentUserPermissions[4] == 0) // Je�li brak uprawnienia do wyswietlania zapomnianych
            {
                btnViewForgottenUsers.Enabled = false; // Wy��cz przycisk
            }
        }

        private void OpenAddUserFormButton_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm(_sp);
            userAddForm.Show();
            this.Hide();
        }

        private void OpenUserListFormButton_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm(_sp);
            userListForm.Show();
            this.Hide();
        }

        private void btnViewForgottenUsers_Click(object sender, EventArgs e)
        {
            var form = new ForgottenUsersForm();
            form.ShowDialog();
        }
        public static class Session
        {
            public static User LoggedInUser { get; set; }
        }
        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Czy na pewno chcesz si� wylogowa�?",
                "Potwierdzenie wylogowania",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No) return;

            new LoginPanel(_sp).Show();
            this.Close();
        }


        private void button_show_dara_Click(object sender, EventArgs e)
        {
            if (Session.LoggedInUser == null)
            {
                MessageBox.Show("Brak danych o zalogowanym u�ytkowniku.");
                return;
            }

            var detailsForm = new UserDetailsFormPersonal(Session.LoggedInUser, _sp);
            detailsForm.Show(); // lub ShowDialog() je�li chcesz zablokowa� inne okna

            this.Close();
        }
    }
}

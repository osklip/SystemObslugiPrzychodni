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

        private void logoutMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Czy na pewno chcesz siê wylogowaæ?",
                "Potwierdzenie wylogowania",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No) return;

            new LoginPanel(_sp).Show();
            this.Close();
        }
    }
}

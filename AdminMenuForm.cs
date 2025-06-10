using System.Windows.Forms;

namespace SystemObslugiPrzychodni
{
    public partial class AdminMenuForm : Form
    {
        public AdminMenuForm()
        {
            InitializeComponent();
        }

        private void OpenAddUserFormButton_Click(object sender, EventArgs e)
        {
            UserAddForm userAddForm = new UserAddForm();
            userAddForm.Show();
            this.Hide();
        }

        private void OpenUserListFormButton_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm();
            userListForm.Show();
            this.Hide();
        }

        private void btnViewForgottenUsers_Click(object sender, EventArgs e)
        {
            var form = new ForgottenUsersForm();
            form.ShowDialog();
        }
    }
}

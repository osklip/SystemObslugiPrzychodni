using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemObslugiPrzychodni
{
    public partial class UserListForm : Form
    {
        public UserListForm()
        {
            InitializeComponent();
            RefreshUserList();
        }

        public void RefreshUserList()
        {
            dataGridViewUserList.DataSource = null;
            dataGridViewUserList.DataSource = UserManagement.GetAllUsers();
            HideData();
        }

        public void HideData()
        {
            dataGridViewUserList.Columns["User_id"].Visible = false;
            dataGridViewUserList.Columns["Password"].Visible = false;
            dataGridViewUserList.Columns["City"].Visible = false;
            dataGridViewUserList.Columns["Post_Code"].Visible = false;
            dataGridViewUserList.Columns["Street"].Visible = false;
            dataGridViewUserList.Columns["Street_number"].Visible = false;
            dataGridViewUserList.Columns["Apartment_number"].Visible = false;
            dataGridViewUserList.Columns["Street"].Visible = false;
            dataGridViewUserList.Columns["Pesel"].Visible = false;
            dataGridViewUserList.Columns["DateOfBirth"].Visible = false;
            dataGridViewUserList.Columns["Sex"].Visible = false;
            dataGridViewUserList.Columns["Phone"].Visible = false;
            dataGridViewUserList.Columns["Role_id"].Visible = false;
        }

        private void OpenAdminMenuFormButton_Click(object sender, EventArgs e)
        {
            AdminMenuForm form1 = new AdminMenuForm();
            form1.Show();
            this.Close();
        }

        private void FilterDataGridView()
        {
            string filterLogin = textBoxLogin.Text.Trim();
            string filterSurname = textBoxSurname.Text.Trim();
            string filterPesel = textBoxPESEL.Text.Trim();

            var filteredUsers = UserManagement.users.Where(u =>
                 (string.IsNullOrEmpty(filterLogin) || u.Login.Contains(filterLogin, StringComparison.OrdinalIgnoreCase)) &&
                 (string.IsNullOrEmpty(filterSurname) || u.Surname.Contains(filterSurname, StringComparison.OrdinalIgnoreCase)) &&
                 (string.IsNullOrEmpty(filterPesel) || u.Pesel.Contains(filterPesel))
            ).ToList();

            dataGridViewUserList.DataSource = null;
            dataGridViewUserList.DataSource = filteredUsers;
            HideData();
        }

        private void SearchUserButton_Click(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void ResetViewButton_Click(object sender, EventArgs e)
        {
            RefreshUserList();
        }

        private void OpenUserDetailsForm_Click(object sender, EventArgs e)
        {
            if (dataGridViewUserList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUserList.SelectedRows[0];

                User selectedUser = selectedRow.DataBoundItem as User;

                if (selectedUser != null)
                {
                    UserDetailsForm editForm = new UserDetailsForm(selectedUser);
                    editForm.Show();
                    this.Close();
                    //RefreshUserList();
                }
                else
                {
                    MessageBox.Show("Nie udało się pobrać danych użytkownika.");
                }
            }
            else
            {
                MessageBox.Show("Nie wybrano użytkownika.");
            }
        }

        private void UserForgetButton_Click(object sender, EventArgs e)
        {

        }
    }
}

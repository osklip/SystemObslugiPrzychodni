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
            comboBoxPerms.Items.Add("dodawanie");
            comboBoxPerms.Items.Add("edytowanie");
            comboBoxPerms.Items.Add("wyswietlanie");
            comboBoxPerms.Items.Add("zapominanie");
            comboBoxPerms.Items.Add("wyświetlanie zapomnianych");
            comboBoxPerms.Items.Add("nadawanie uprawnień");
            comboBoxPerms.Items.Add("obsługa pacjentów");
        }

        public void RefreshUserList()
        {
            dataGridViewUserList.DataSource = null;
            dataGridViewUserList.DataSource = UserManagement.GetAllUsers();
            if (UserManagement.GetAllUsers().Count == 0)
            {
                dataGridViewUserList.DataSource = null;
                MessageBox.Show("W systemie nie ma żadnych użytkowników.");
            }
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
            dataGridViewUserList.Columns["Is_active"].Visible = false;
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
            string filterName = textBoxName.Text.Trim();
            int selectedPermissionIndex = comboBoxPerms.SelectedIndex; // Pobranie wybranego uprawnienia

            // Pobranie użytkowników z ich uprawnieniami
            var usersWithPermissions = UserManagement.GetUsersWithPermissions();

            var filteredUsers = usersWithPermissions.Where(up =>
               (string.IsNullOrEmpty(filterLogin) || up.user.Login.Contains(filterLogin, StringComparison.OrdinalIgnoreCase)) &&
               (string.IsNullOrEmpty(filterSurname) || up.user.Surname.Contains(filterSurname, StringComparison.OrdinalIgnoreCase)) &&
               (string.IsNullOrEmpty(filterName) || up.user.Name.Contains(filterName, StringComparison.OrdinalIgnoreCase)) &&
               (string.IsNullOrEmpty(filterPesel) || up.user.Pesel.Contains(filterPesel)) &&
               (selectedPermissionIndex == -1 || up.permissions[selectedPermissionIndex] == 1) // Filtrowanie po uprawnieniach
            ).Select(up => up.user).ToList();

            if (filteredUsers.Count > 0)
            {
                dataGridViewUserList.DataSource = null;
                dataGridViewUserList.DataSource = filteredUsers;
                HideData();
            }
            else
            {
                dataGridViewUserList.DataSource = null;
                MessageBox.Show("Nie znaleziono użytkowników zgodnych z kryteriami wyszukiwania.");
            }
        }

        private void SearchUserButton_Click(object sender, EventArgs e)
        {
            FilterDataGridView();
        }

        private void ResetViewButton_Click(object sender, EventArgs e)
        {
            RefreshUserList();
            textBoxLogin.Text = string.Empty;
            textBoxName.Text = string.Empty;
            textBoxSurname.Text = string.Empty;
            textBoxPESEL.Text = string.Empty;
            comboBoxPerms.Text = string.Empty;
        }


        private void OpenUserDetailsForm2_Click_1(object sender, EventArgs e)
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

        private void UserListForm_Load(object sender, EventArgs e)
        {

        }

        
    }
}

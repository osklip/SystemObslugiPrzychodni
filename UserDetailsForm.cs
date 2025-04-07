using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemObslugiPrzychodni
{
    public partial class UserDetailsForm : Form
    {
        private User editedUser;
        public UserDetailsForm(User user)
        {
            InitializeComponent();
            comboBoxRole.DataSource = Role.roles;
            comboBoxRole.DisplayMember = "name";
            comboBoxRole.ValueMember = "role_id";
            comboBoxSex.Items.Add("Kobieta");
            comboBoxSex.Items.Add("Mężczyzna");
            editedUser = user;
            editedUser.User_id = user.User_id;
            labelNoweDane.Visible = false;
            textBoxLogin.Text = user.Login;
            textBoxLogin.Visible = false;
            textBoxName.Text = user.Name;
            textBoxName.Visible = false;
            textBoxSurname.Text = user.Surname;
            textBoxSurname.Visible = false;
            textBoxPostCode.Text = user.Post_Code;
            textBoxPostCode.Visible = false;
            textBoxEmail.Text = user.Email;
            textBoxEmail.Visible = false;
            textBoxCity.Text = user.City;
            textBoxCity.Visible = false;
            textBoxStreetNumber.Text = user.Street_number;
            textBoxStreetNumber.Visible = false;
            textBoxApartmentNumber.Text = user.Apartment_number;
            textBoxApartmentNumber.Visible = false;
            textBoxPhone.Text = user.Phone;
            textBoxPhone.Visible = false;
            textBoxPESEL.Text = user.Pesel;
            textBoxPESEL.Visible = false;
            comboBoxRole.Visible = false;
            comboBoxSex.Visible = false;
            dateTimePickerDateOfBirth.Value = DateTime.ParseExact(user.DateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            dateTimePickerDateOfBirth.Visible = false;
            SaveNewDetailsButton.Visible = false;
            textBoxStreet.Text = user.Street;
            textBoxStreet.Visible = false;
            labelLogin.Text = user.Login;
            labelName.Text = user.Name;
            labelSurname.Text = user.Surname;
            labelPESEL.Text = user.Pesel;
            labelSex.Text = user.Sex;
            labelPostCode.Text = user.Post_Code;
            labelCity.Text = user.City;
            labelStreetNumber.Text = user.Street_number;
            labelApartmentNumber.Text = user.Apartment_number;
            labelPhone.Text = user.Phone;
            labelStreet.Text = user.Street;
            labelDateOfBirth.Text = user.DateOfBirth;
            labelEmail.Text = user.Email;
            labelPassword.Text = user.Password;
            textBoxPassword.Text = user.Password;
            textBoxPassword.Visible = false;
            labelRole.Text = user.Role_id.ToString();
            comboBoxSex.SelectedItem = user.Sex;
        }

        private void EditUserDetailsButton_Click(object sender, EventArgs e)
        {
            labelNoweDane.Visible = true;
            textBoxLogin.Visible = true;
            textBoxName.Visible = true;
            textBoxSurname.Visible = true;
            textBoxPostCode.Visible = true;
            textBoxEmail.Visible = true;
            textBoxCity.Visible = true;
            textBoxStreetNumber.Visible = true;
            textBoxApartmentNumber.Visible = true;
            textBoxPhone.Visible = true;
            textBoxPESEL.Visible = true;
            dateTimePickerDateOfBirth.Visible = true;
            SaveNewDetailsButton.Visible = true;
            textBoxStreet.Visible = true;
            textBoxPassword.Visible=true;
            comboBoxRole.Visible = true;
            comboBoxSex.Visible = true;
        }

        private void OpenUserListFormButton_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm();
            userListForm.Show();
            this.Close();
        }

        public void SaveNewDetailsButton_Click(object sender, EventArgs e)
        {
            //walidacja "czy niepuste"
            if (string.IsNullOrWhiteSpace(textBoxLogin.Text) ||
                string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSurname.Text) ||
                string.IsNullOrWhiteSpace(textBoxCity.Text) ||
                string.IsNullOrWhiteSpace(textBoxPostCode.Text) ||
                string.IsNullOrWhiteSpace(textBoxStreet.Text) ||
                string.IsNullOrWhiteSpace(textBoxStreetNumber.Text) ||
                string.IsNullOrWhiteSpace(textBoxPESEL.Text) ||
                string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                comboBoxSex.SelectedItem == null ||
                comboBoxRole.SelectedValue == null)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.");
                return;
            }

            //unikalność loginu
            if (UserManagement.IsValueUnique(textBoxLogin.Text, "login"))
            {
                MessageBox.Show("Login już istnieje w systemie.");
            }

            //walidacja 9 cyfr w numerze telefonu
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPhone.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Numer telefonu musi zawierać dokładnie 9 cyfr.");
                return;
            }

            //walidacja 11 cyfr w numerze PESEL
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPESEL.Text, @"^\d{11}$"))
            {
                MessageBox.Show("Numer PESEL musi zawierać 11 cyfr.");
                return;
            }

            //unikalność PESEL
            if (UserManagement.IsValueUnique(textBoxPESEL.Text, "pesel"))
            {
                MessageBox.Show("Numer PESEL już istnieje w systemie.");
            }

            //walidacja formatu kodu pocztowego
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPostCode.Text, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Kod pocztowy musi być w formacie 00-000.");
                return;
            }

            //walidacja formatu adresu email
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Niepoprawny format adresu email.");
                return;
            }

            //unikalność adresu email
            if (UserManagement.IsValueUnique(textBoxEmail.Text, "email"))
            {
                MessageBox.Show("Adres email już istnieje w systemie.");
            }

            //walidacja długości adresu email
            if (textBoxEmail.Text.Length > 255)
            {
                MessageBox.Show("Niepoprawny format adresu email.");
                return;
            }

            //walidacja daty urodzenia (nie może być dalsza niż dzisiejsza data)
            if (dateTimePickerDateOfBirth.Value.Date >= DateTime.Today)
            {
                MessageBox.Show("Data urodzenia musi być wcześniejsza niż dzisiejsza data.");
                return;
            }

            try
            {
                editedUser.Login = textBoxLogin.Text;
                editedUser.Password = textBoxPassword.Text;
                editedUser.Name = textBoxName.Text;
                editedUser.Surname = textBoxSurname.Text;
                editedUser.Pesel = textBoxPESEL.Text;
                editedUser.Sex = comboBoxSex.SelectedItem.ToString();
                editedUser.Post_Code = textBoxPostCode.Text;
                editedUser.Street_number = textBoxStreetNumber.Text;
                editedUser.Apartment_number = textBoxApartmentNumber.Text;
                editedUser.Email = textBoxEmail.Text;
                editedUser.Phone = textBoxPhone.Text;
                editedUser.Street = textBoxStreet.Text;
                editedUser.DateOfBirth = DateOnly.FromDateTime(dateTimePickerDateOfBirth.Value).ToString();
                editedUser.City = textBoxCity.Text;
                UserManagement.EditUser(editedUser);
                MessageBox.Show($"Użytkownik edytowany pomyślnie.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas edytowania użytkownika: {ex.Message}");
            }
        }
    }
}

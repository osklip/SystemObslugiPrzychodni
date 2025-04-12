using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SystemObslugiPrzychodni
{
    public partial class UserAddForm : Form
    {

        public UserAddForm()
        {
            InitializeComponent();
            comboBoxSex.Items.Add("Kobieta");
            comboBoxSex.Items.Add("Mężczyzna");
        }

        private void AddUserButton_Click(object sender, EventArgs e)
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
                comboBoxSex.SelectedItem == null)
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione.");
                return;
            }

            //unikalność loginu
            if (!UserManagement.IsValueUnique(textBoxLogin.Text, "login"))
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
            if (!UserManagement.IsValueUnique(textBoxPESEL.Text, "pesel"))
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
            if (!UserManagement.IsValueUnique(textBoxEmail.Text, "email"))
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
                User newUser = new User(
                    user_id: UserManagement.GetNextUserId(),
                    login: textBoxLogin.Text,
                    password: textBoxPassword.Text,
                    name: textBoxName.Text,
                    surname: textBoxSurname.Text,
                    city: textBoxCity.Text,
                    post_code: textBoxPostCode.Text,
                    street: textBoxStreet.Text,
                    street_number: textBoxStreetNumber.Text,
                    apartment_number: textBoxApartmentNumber.Text,
                    pesel: textBoxPESEL.Text,
                    date_of_birth: DateOnly.FromDateTime(dateTimePickerDateOfBirth.Value).ToString(),
                    sex: (string)comboBoxSex.SelectedItem,
                    email: textBoxEmail.Text,
                    phone: textBoxPhone.Text,
                    role_id: 0,
                    is_active: true
                );

                UserManagement.AddUser(newUser);
                MessageBox.Show($"Użytkownik dodany pomyślnie.");
                AdminMenuForm form1 = new AdminMenuForm();
                form1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania użytkownika: {ex.Message}");
            }
        }

        private void buttonCloseForm_Click(object sender, EventArgs e)
        {
            AdminMenuForm form1 = new AdminMenuForm();
            form1.Show();
            this.Close();
        }
    }
}

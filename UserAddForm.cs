using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                MessageBox.Show("Wypełnij wszystkie wymagane pola.");
                return;
            }

            //walidacja "tylko litery" dla imienia i nazwiska
            if (!textBoxName.Text.All(char.IsLetter) || !textBoxSurname.Text.All(char.IsLetter))
            {
                MessageBox.Show("Imię i nazwisko mogą zawierać wyłącznie litery alfabetu (bez cyfr i znaków specjalnych).");
            }

            //unikalność loginu
            if (!UserManagement.IsValueUnique(textBoxLogin.Text, "login"))
            {
                MessageBox.Show("Podany login jest już zajęty. Wprowadź inny login.");
                return;
            }

            //walidacja 9 cyfr w numerze telefonu
            if (!Regex.IsMatch(textBoxPhone.Text, @"^\d{9}$"))
            {
                MessageBox.Show("Numer telefonu musi zawierać dokładnie 9 cyfr.");
                return;
            }

            //walidacja 11 cyfr w numerze PESEL
            if (!Regex.IsMatch(textBoxPESEL.Text, @"^\d{11}$") ||
                !UserManagement.ValidatorPESEL(dateTimePickerDateOfBirth.Value, textBoxPESEL.Text, comboBoxSex.SelectedItem.ToString()))
            {
                MessageBox.Show("Nieprawidłowy numer PESEL.");
                return;
            }

            //unikalność PESEL
            if (!UserManagement.IsValueUnique(textBoxPESEL.Text, "pesel"))
            {
                MessageBox.Show("Użytkownik o podanym numerze PESEL już istnieje w systemie.");
                return;
            }

            //walidacja formatu kodu pocztowego
            if (!Regex.IsMatch(textBoxPostCode.Text, @"^\d{2}-\d{3}$"))
            {
                MessageBox.Show("Kod pocztowy ma nieprawidłowy format.");
                return;
            }

            //walidacja formatu adresu email
            if (!Regex.IsMatch(textBoxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || textBoxEmail.Text.Length > 255)
            {
                MessageBox.Show("Adres e‑mail ma nieprawidłowy format.");
                return;
            }

            //unikalność adresu email
            if (!UserManagement.IsValueUnique(textBoxEmail.Text, "email"))
            {
                MessageBox.Show("Podany adres e‑mail jest już przypisany do innego użytkownika.");
                return;
            }

            //walidacja daty urodzenia (nie może być dalsza niż dzisiejsza data)
            if (dateTimePickerDateOfBirth.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Data urodzenia nie może być późniejsza niż dzisiejsza data.");
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
                MessageBox.Show("Użytkownik został pomyślnie dodany do systemu.");
                AdminMenuForm form1 = new AdminMenuForm();
                form1.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas komunikacji z serwerem");
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

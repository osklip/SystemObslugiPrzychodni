using Microsoft.VisualBasic.ApplicationServices;
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
        private readonly IServiceProvider _sp;
        public UserDetailsForm(User user, IServiceProvider sp)
        {
            InitializeComponent();
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
            comboBoxSex.SelectedItem = user.Sex;
            _sp = sp;
        }

        private void EditUserDetailsButton_Click_1(object sender, EventArgs e)
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
            textBoxPassword.Visible = true;
            comboBoxSex.Visible = true;
        }

        private void OpenUserListFormButton_Click(object sender, EventArgs e)
        {
            UserListForm userListForm = new UserListForm(_sp);
            userListForm.Show();
            this.Close();
        }

        public void SaveNewDetailsButton_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == editedUser.Login || textBoxPassword.Text == editedUser.Password ||
                textBoxName.Text == editedUser.Name || textBoxSurname.Text == editedUser.Surname ||
                textBoxCity.Text == editedUser.City || textBoxPostCode.Text == editedUser.Post_Code ||
                textBoxStreet.Text == editedUser.Street || textBoxStreetNumber.Text == editedUser.Street_number ||
                textBoxPESEL.Text == editedUser.Pesel || textBoxEmail.Text == editedUser.Email ||
                textBoxPhone.Text == editedUser.Phone || comboBoxSex.SelectedItem == editedUser.Sex)
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
                if (textBoxName.Text != editedUser.Name)
                {
                    if (textBoxName.Text.All(char.IsLetter))
                    {
                        MessageBox.Show("Imię i nazwisko mogą zawierać wyłącznie litery alfabetu (bez cyfr i znaków specjalnych).");
                        return;
                    }
                }

                if (textBoxSurname.Text != editedUser.Surname)
                {
                    if (textBoxSurname.Text.All(char.IsLetter))
                    {
                        MessageBox.Show("Imię i nazwisko mogą zawierać wyłącznie litery alfabetu (bez cyfr i znaków specjalnych).");
                        return;
                    }
                }

                //unikalność loginu
                if (editedUser.Login != textBoxLogin.Text)
                {
                    if (!UserManagement.IsValueUnique(textBoxLogin.Text, "login"))
                    {
                        MessageBox.Show("Podany login jest już zajęty. Wprowadź inny login.");
                        return;
                    }
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
                    MessageBox.Show("Nieprawidłowy numer PESEL.");
                    return;
                }

                //unikalność PESEL
                if (editedUser.Pesel != textBoxPESEL.Text)
                {
                    if (!UserManagement.IsValueUnique(textBoxPESEL.Text, "pesel"))
                    {
                        MessageBox.Show("Użytkownik o podanym numerze PESEL już istnieje w systemie.");
                        return;
                    }
                }

                //walidacja formatu kodu pocztowego
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxPostCode.Text, @"^\d{2}-\d{3}$"))
                {
                    MessageBox.Show("Kod pocztowy ma nieprawidłowy format.");
                    return;
                }

                //walidacja formatu adresu email
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") || textBoxEmail.Text.Length > 255)
                {
                    MessageBox.Show("Adres e‑mail ma nieprawidłowy format.");
                    return;
                }

                //unikalność adresu email
                if (editedUser.Email != textBoxEmail.Text)
                {
                    if (!UserManagement.IsValueUnique(textBoxEmail.Text, "email"))
                    {
                        MessageBox.Show("Podany adres e‑mail jest już przypisany do innego użytkownika.");
                        return;
                    }
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
                    MessageBox.Show($"Dane użytkownika zostały zmienione");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd podczas edytowania użytkownika: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Dane nie zostały zmienione.");
                return;
            }
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void ForgetUserButton_Click(object sender, EventArgs e)
        {


            if (editedUser != null)
            {
                var result = MessageBox.Show(
                    $"Czy na pewno chcesz zapomnieć użytkownika {editedUser.Name} {editedUser.Surname}?",
                    "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    UserManagement.ForgetUser(editedUser, 1); //po dodaniu logowania zmienic 1 na zmienna ktora odpowiada za id zalogowanego uzytkownika
                    MessageBox.Show("Użytkownik został zapomniany.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UserListForm userListForm = new UserListForm(_sp);
                    userListForm.RefreshUserList();
                    userListForm.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Nie udało się pobrać danych użytkownika.");
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserPerms userPerms = new UserPerms(editedUser);
            userPerms.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var dlg = new ChangePasswordForm(editedUser.Login);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Hasło zostało zmienione.",
                    "Informacja",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }
    }
}

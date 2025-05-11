using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Text;

namespace SystemObslugiPrzychodni
{
    public partial class UserPerms : Form
    {
        private User currentUser;
        public UserPerms(User user)
        {
            InitializeComponent();
            currentUser = user;
            userLabel.Text = user.Name + " " + user.Surname;

            int[] userPermissions = UserManagement.GetUserPerms(user.User_id); //pobranie uprawnien danego uzytkownika  

            for (int i = 1; i < 8; i++) //ustawienie checkboxow zgodnie z uprawnieniami jakie aktualnie ma  
            {
                string checkBoxName = "checkBox" + i;
                var checkBox = Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                if (checkBox != null)
                {
                    checkBox.Checked = userPermissions[i - 1] == 1;
                }
            }
        }

        
        private void button2_Click(object sender, EventArgs e) //zapisz  
        {
            int[] newPermissions = new int[7]; // Tablica do przechowywania nowych uprawnień użytkownika
            for (int i = 1; i < 8; i++) // Pobranie stanu checkboxów
            {
                string checkBoxName = "checkBox" + i;

                var checkBox = Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                if (checkBox != null)
                {
                    newPermissions[i - 1] = checkBox.Checked ? 1 : 0; // Zapisanie stanu checkboxów do tablicy
                }
            }

            // Pobranie aktualnych uprawnień użytkownika z bazy danych
            int[] currentPermissions = UserManagement.GetUserPerms(currentUser.User_id);

            // Sprawdzenie, czy nowe uprawnienia różnią się od aktualnych
            if (newPermissions.SequenceEqual(currentPermissions))
            {
                MessageBox.Show("Nie wprowadzono żadnych zmian w uprawnieniach.");
                return; // Przerwij, jeśli nie ma zmian
            }

            // Sprawdzenie, czy użytkownik próbuje zmienić swoje własne uprawnienia
            if (currentUser.Login == LoginPanel.Currentlogin)
            {
                MessageBox.Show("Nie możesz zmieniać swoich własnych uprawnień.", "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Przerwij, jeśli użytkownik próbuje zmienić swoje własne uprawnienia
            }

            bool isAllZeros = newPermissions.All(value => value == 0);
            try
            {
                if (isAllZeros)
                {
                    MessageBox.Show("Użytkownik nie ma przypisanego żadnego uprawnienia");
                }
                else
                {
                    UserManagement.UpdateUserPerms(currentUser.User_id, newPermissions); // Aktualizacja uprawnień w bazie danych
                    MessageBox.Show($"Uprawnienia zostały zedytowane");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas edytowania uprawnień: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}

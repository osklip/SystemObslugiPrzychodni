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
            int[] userPermissions = new int[7]; //tablica do przechowywania uprawnien uzytkownika
            for (int i = 1; i < 8; i++) //ustawienie checkboxow zgodnie z uprawnieniami jakie aktualnie ma  
            {
                string checkBoxName = "checkBox" + i;
                
                var checkBox = Controls.Find(checkBoxName, true).FirstOrDefault() as CheckBox;
                if (checkBox != null)
                {
                    userPermissions[i - 1] = checkBox.Checked ? 1 : 0; //zmiana uprawnien w tablicy   
                }
            }
            bool isAllZeros = userPermissions.All(value => value == 0);
            try
            {
                
                if (isAllZeros)
                {
                    MessageBox.Show("Użytkownik nie ma przypisanego żadnego uprawnienia");
                }
                else
                {
                    UserManagement.UpdateUserPerms(currentUser.User_id, userPermissions); //aktualizacja uprawnien w bazie danych  
                    MessageBox.Show($"Uprawnienia zostały nadane");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas edytowania uprawnien: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

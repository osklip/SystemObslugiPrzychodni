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
    public partial class ForgottenUsersForm : Form
    {
        public ForgottenUsersForm()
        {
            InitializeComponent();
            this.Load += ForgottenUsersForm_Load;
        }
        private void ForgottenUsersForm_Load(object sender, EventArgs e)
        {
            var forgotten = UserManagement.GetForgottenUsers();

            if (forgotten.Count == 0)
            {
                MessageBox.Show("W systemie nie występują użytkownicy zapomniani.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }

            dataGridViewForgottenUsers.DataSource = forgotten;
        }
    }
}

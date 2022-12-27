using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Repairs_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (Username.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Data !!!!");
            }
            else if (Username.Text == "admin" && Password.Text == "admin")
            {
                Customers Custform = new Customers();
                Custform.Show();
                this.Hide();
            }
            else
            {
                Username.Text = "";
                Password.Text = "";

            }
        }
    }
}

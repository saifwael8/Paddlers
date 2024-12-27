using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Login : Form
    {
        Controller controller;
        public Login()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            string type = controller.getUserType(username);

            if (password == controller.getPassword(username))
            {
                if (type == "admin") //DONE
                {
                    Admin_Welcome admin_Welcome = new Admin_Welcome();
                    admin_Welcome.Show();
                }
                else if (type == "owner") //DONE
                {
                    Owner_Welcome owner_Welcome = new Owner_Welcome(username);
                    owner_Welcome.Show();
                }
                else if ( type == "manager")
                {
                    //Manager Form

                }
                else if (type == "employee")
                {
                    //Emoloyee Form
                }
                else if (type == "client")
                {
                    //Client Form
                }

            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}

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
    public partial class SignUp : Form
    {
        Controller controller;
        public SignUp()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ownerUsername = textBox3.Text;
            string ownerPassword = textBox4.Text;
            string ownerAddress = textBox5.Text;
            string lastName = textBox6.Text;
            string firstName = textBox7.Text;
            string ownerPhoneNumber = textBox8.Text;

            if (string.IsNullOrEmpty(ownerUsername) || string.IsNullOrEmpty(ownerPassword) ||
                string.IsNullOrEmpty(ownerAddress) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(ownerPhoneNumber))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            if (controller.insertUser(ownerUsername, ownerPassword, firstName, lastName, ownerAddress, ownerPhoneNumber,"client") == 1)
            {
                MessageBox.Show("Succesfully inserted the Owner");
            }
            else
            {
                MessageBox.Show("Owner has already been inserted");
            }

        }
    }
}

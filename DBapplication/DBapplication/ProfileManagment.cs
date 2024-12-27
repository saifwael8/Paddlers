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
    public partial class ProfileManagment : Form
    {
        string username;
        Controller controller;
        public ProfileManagment(string username)
        {
            InitializeComponent();
            this.username = username;
            controller = new Controller();
            setInformation();
        }

        private void setInformation()
        {
            textBox1.Text = controller.getFirstName(username);
            textBox2.Text = controller.getLastName(username);
            textBox3.Text = controller.getAddress(username);
            textBox4.Text = controller.getPhoneNumber(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (controller.updateProfile(username, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text) == 1)
            {
                MessageBox.Show("Profile updated successfully");
            }
            else
            {
                MessageBox.Show("Profile update failed");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (controller.updatePassword(username, textBox5.Text) == 1)
            {
                MessageBox.Show("Password updated successfully");
            }
            else
            {
                MessageBox.Show("Password update failed");
            }
        }
    }
}

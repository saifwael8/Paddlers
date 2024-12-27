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
    public partial class Admin_Welcome : Form
    {
        Controller controller;
        public Admin_Welcome()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string city = textBox1.Text;
            if (city == "")
            {
                MessageBox.Show("City Field is Empty! ");
                return;
            }
            if (controller.insertCity(city) == 1)
            {
                MessageBox.Show("Succesfully inserted the City");
            }
            else
            {
                MessageBox.Show("City has already been inserted");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string companyName = textBox2.Text;
            string ownerUsername = textBox3.Text;
            string ownerPassword = textBox4.Text;
            string ownerAddress = textBox5.Text;
            string lastName = textBox6.Text;
            string firstName = textBox7.Text;
            string ownerPhoneNumber = textBox8.Text;

            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(ownerUsername) || string.IsNullOrEmpty(ownerPassword) ||
                string.IsNullOrEmpty(ownerAddress) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(firstName) ||
                string.IsNullOrEmpty(ownerPhoneNumber))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            if (controller.insertCompany(companyName) == 1)
            {
                if (controller.insertUser(ownerUsername, ownerPassword, firstName, lastName, ownerAddress, ownerPhoneNumber, companyName, "owner") == 1)
                {
                    MessageBox.Show("Succesfully inserted the Company and Owner");
                }
                else
                {
                    MessageBox.Show("Owner has already been inserted");
                    controller.deleteCompany(companyName);
                }
            }
            else
            {
                MessageBox.Show("Company has already been inserted");
            }
        }

    }
}

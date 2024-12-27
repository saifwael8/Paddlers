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
    public partial class EmployeeManagment : Form
    {
        string username;
        int company_id;
        int branch_id;
        Controller controller;
        public EmployeeManagment(string username, int company_id, int branch_id)
        {
            InitializeComponent();
            this.username = username;
            this.company_id = company_id;
            this.branch_id = branch_id;
            controller = new Controller();
            refresh();
        }

        void refresh()
        {
            comboBox1.DataSource = controller.SelectAllEmployees(branch_id);
            comboBox1.DisplayMember = "username";
            dataGridView1.DataSource = controller.SelectAllEmployees(branch_id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string fname = textBox3.Text;
            string lname = textBox4.Text;
            string address = textBox5.Text;
            string phone = textBox6.Text;
            if (username == "" || password == "" || fname == "" || lname == "" || address == "" || phone == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (controller.insertEmployee(username, password, fname, lname, address, phone, company_id, "employee", branch_id) == 1)
            {
                MessageBox.Show("Employee added successfully");
            }
            else
            {
                MessageBox.Show("Employee already exists");
            }
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username =  comboBox1.GetItemText(comboBox1.SelectedItem);
            if (controller.deleteUser(username) == 1)
            {
                MessageBox.Show("Employee deleted successfully");
            }
            else
            {
                MessageBox.Show("Employee doesn't exist");
            }
            refresh();
        }
    }
}

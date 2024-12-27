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
    public partial class Manager_Management : Form
    {
        Controller controller;
        string username;
        int company_id;
        public Manager_Management(string username, int company_id)
        {
            InitializeComponent();
            controller = new Controller();
            this.username = username;
            this.company_id = company_id;
            refresh();
        }

        void refresh()
        {
            comboBox1.DataSource = controller.SelectAllBranches(company_id);
            comboBox1.DisplayMember = "branch_name";
            comboBox2.DataSource = controller.getManagers(company_id);
            comboBox2.DisplayMember = "username";
            comboBox3.DataSource = controller.SelectAllBranches(company_id);
            comboBox3.DisplayMember = "branch_name";
            dataGridView1.DataSource = controller.getManagers(company_id);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string manager_username = textBox1.Text;
            string manager_password = textBox2.Text;
            string manager_first_name = textBox3.Text;
            string manager_last_name = textBox4.Text;
            string manager_address = textBox5.Text;
            string manager_phone_number = textBox6.Text;
            string manager_branch = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (manager_username == "" || manager_password == "" || manager_first_name == "" || manager_last_name == "" || manager_address == "" || manager_phone_number == "" || manager_branch == "")
                MessageBox.Show("Please Enter complete data");
            else
            {
                string companyName = controller.getCompanyName(username);
                int result = controller.insertUser(manager_username, manager_password, manager_first_name, manager_last_name, manager_address, manager_phone_number, companyName, "manager");
                if (result == 1)
                {
                    MessageBox.Show("Manager added successfuly");
                    controller.updateManager(manager_username, manager_branch, controller.getCompanyId(companyName));
                }
                else
                {
                    MessageBox.Show("Manager addition failed");
                }
            }
            refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (controller.deleteUser(comboBox2.GetItemText(comboBox2.SelectedItem)) == 1)
            {
                MessageBox.Show("Manager deleted successfuly");
            }
            else
            {
                MessageBox.Show("Manager deletion failed");
            }
            refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string companyName = controller.getCompanyName(username);
            int company_id = controller.getCompanyId(companyName);
            if (controller.updateManager(comboBox2.GetItemText(comboBox2.SelectedItem), comboBox3.GetItemText(comboBox3.SelectedItem), company_id) == 1)
            {
                MessageBox.Show("Manager updated successfuly");
            }
            else
            {
                MessageBox.Show("Manager update failed");
            }
            refresh();
        }
    }
}

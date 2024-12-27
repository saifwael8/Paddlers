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
    public partial class Branch_Management : Form
    {
        Controller controller;
        string username;
        int company_id;
        public Branch_Management(string username, int company_id)
        {
            InitializeComponent();
            controller = new Controller();
            this.username = username;
            this.company_id = company_id;
            refresh();
        }

        void refresh()
        {
            comboBox7.DataSource = controller.getCities();
            comboBox7.DisplayMember = "city";
            comboBox1.DataSource = controller.SelectAllBranches(company_id);
            comboBox1.DisplayMember = "branch_name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string branchName = textBox1.Text;
            string city = comboBox7.GetItemText(comboBox7.SelectedItem);
            string location = textBox3.Text;
            if (branchName == "" || city == "" || location == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            int valid = controller.InsertBranch(branchName, this.company_id, location, city);
            if (valid == 1)
            {
                MessageBox.Show("Branch Added Succesfully! ");
            }
            else
            {
                MessageBox.Show("Branch Addition Failed! ");
            }
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string branchName = comboBox1.GetItemText(comboBox1.SelectedItem);
            int result = controller.DeleteBranch(branchName, this.company_id);
            if (result == 1)
            {
                MessageBox.Show("Deleted Branch");
            }
            else
            {
                MessageBox.Show("Failed to Delete Branch");
            }
            refresh();
        }
    }
}





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
    public partial class ServiceManagment : Form
    {
        string username;
        int company_id;
        Controller controller;
        public ServiceManagment(string username, int company_id)
        {
            InitializeComponent();
            this.username = username;
            this.company_id = company_id;
            controller = new Controller();
            refresh();
        }

        void refresh()
        {
            comboBox1.DataSource = controller.SelectAllServices(company_id);
            comboBox1.DisplayMember = "service_name";
            dataGridView1.DataSource = controller.SelectAllServices(company_id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string service_Name = textBox1.Text;
            int price;
            try
            {
                price = Convert.ToInt32(textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid price");
                return;
            }
            if (service_Name == "" || price < 0)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (controller.insertService(service_Name, price, company_id) == 1)
            {
                MessageBox.Show("Service added successfully");
            }
            else
            {
                MessageBox.Show("Service already exists");
            }
            refresh(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string service_Name = comboBox1.GetItemText(comboBox1.SelectedItem);
            int price;
            try
            {
                price = Convert.ToInt32(textBox3.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid price");
                return;
            }
            if (service_Name == "" || price < 0)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (controller.updateService(service_Name, price, company_id) == 1)
            {
                MessageBox.Show("Service updated successfully");
            }
            else
            {
                MessageBox.Show("Service doesn't exist");
            }
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string service_Name = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (controller.deleteService(service_Name, company_id) == 1)
            {
                MessageBox.Show("Service deleted successfully");
            }
            else
            {
                MessageBox.Show("Service doesn't exist");
            }
            refresh();

        }
    }
}

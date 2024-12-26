using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Owner_Companies : Form
    {
        Controller controller;
        private void refreshdata( DataTable dt,ComboBox c)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            c.DataSource = dt;
            c.DisplayMember = "company_name";
        }
        public Owner_Companies()
        {
            InitializeComponent();
            controller = new Controller();
            DataTable dt1 = controller.SelectAllCompanies();
            DataTable dt2 = controller.SelectAllCompanies();
           
            refreshdata(dt1,comboBox1);
            refreshdata(dt2,comboBox2);



        }

        private void Owner_Companies_Load(object sender, EventArgs e)
        {
            controller = new Controller();
            DataTable dt = controller.SelectAllCompanies();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Empty Company name");
            else
            {
                int result = controller.UpdateCompany(comboBox1.Text, textBox1.Text);
                if (result == 0)
                {
                    MessageBox.Show("Company cannot be updated");

                }
                else
                { 
                    MessageBox.Show("Company updated successfuly");
                    DataTable dt1 = controller.SelectAllCompanies();
                    DataTable dt2 = controller.SelectAllCompanies();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text!=null)
            {
                int result = controller.DeleteCompany(comboBox2.Text);
                if (result == 0)
                {
                    MessageBox.Show("Company cannot be deleted");
                }
                else
                
                { MessageBox.Show("The Company is deleted successfully !");
                    DataTable dt1 = controller.SelectAllCompanies();
                    DataTable dt2 = controller.SelectAllCompanies();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);

                }
                
            }
            else
                MessageBox.Show("Please Select a Company you want to delete");
        }
    }
}

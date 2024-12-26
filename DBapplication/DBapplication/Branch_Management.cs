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
        private void refreshdata(DataTable dt, ComboBox c)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            c.DataSource = dt;
            c.DisplayMember = "branch_name";
          
           
        }
        public Branch_Management()
        {
            InitializeComponent();
            controller = new Controller();
            DataTable dt1 = controller.SelectAllBrancheswithdata();
            DataTable dt2 = controller.SelectAllBrancheswithdata();

            refreshdata(dt1, comboBox1);
            refreshdata(dt2, comboBox2);
            DataTable dt3 = controller.SelectAllCompanies();
            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "company_name";
            comboBox4.DataSource = dt3;
            comboBox4.DisplayMember = "company_name";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Please Enter complete data");
            else
            {
                
                int result = controller.InsertBranch(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
                if (result == 1)
                {

                    MessageBox.Show("Branch added successfuly");
                    DataTable dt1 = controller.SelectAllBrancheswithdata();
                    DataTable dt2 = controller.SelectAllBrancheswithdata();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);

                }
                else
                {
                    MessageBox.Show("Branch cannot be added ");

                }

            }
        }

        private void Branch_Management_Load(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectAllBrancheswithdata();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""  || textBox3.Text == "" || textBox4.Text == "")
            
                MessageBox.Show("Please Enter complete data");
            else
                {

                    int result = controller.UpdateBranch(comboBox1.Text,textBox1.Text,comboBox3.Text, textBox3.Text, textBox4.Text);
                    if (result == 1)
                    {

                        MessageBox.Show("Branch updated successfuly");
                        DataTable dt1 = controller.SelectAllBrancheswithdata();
                        DataTable dt2 = controller.SelectAllBrancheswithdata();
                        refreshdata(dt1, comboBox1);
                        refreshdata(dt2, comboBox2);

                    }
                    else
                    {
                        MessageBox.Show("Branch cannot be updated ");

                    }


                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
             if (comboBox2.Text != null && comboBox4.Text != null)
            {
                int result = controller.DeleteBranch(comboBox2.Text,comboBox4.Text);
                if (result == 1)
                {
                    MessageBox.Show("The Branch is deleted successfully !");
                    DataTable dt1 = controller.SelectAllBrancheswithdata();
                    DataTable dt2 = controller.SelectAllBrancheswithdata();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);
                }
                else

                {
                    MessageBox.Show("Branch cannot be deleted"); 
                }

            }
            else
                MessageBox.Show("Please Select a Branch and its company you want to delete");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Court_Management court_Management = new Court_Management();
            court_Management.Show(); 
        }
    }
    }
    



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
    public partial class Court_Management : Form
    {
        Controller controller;
        private void refreshdata(DataTable dt, ComboBox c)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            c.DataSource = dt;
            c.DisplayMember = "court_name";


        }
        public Court_Management()
        {
            InitializeComponent();
            controller = new Controller();
            comboBox3.Items.Add("Paddle Court Single");
            comboBox3.Items.Add("Paddle Court Double");
            comboBox3.Items.Add("Tennis Court Single");
            comboBox3.Items.Add("Tennis Court Double");
            comboBox4.Items.Add("Paddle Court Single");
            comboBox4.Items.Add("Paddle Court Double");
            comboBox4.Items.Add("Tennis Court Single");
            comboBox4.Items.Add("Tennis Court Double");
            comboBox5.Items.Add("Paddle Court Single");
            comboBox5.Items.Add("Paddle Court Double");
            comboBox5.Items.Add("Tennis Court Single");
            comboBox5.Items.Add("Tennis Court Double");
            DataTable dt1 = controller.SelectAllCourts();
            DataTable dt2 = controller.SelectAllCourts();
            refreshdata(dt1, comboBox1);
            refreshdata(dt2, comboBox2);
            DataTable dt3 = controller.SelectAllBranches();
            comboBox6.DataSource = dt3;
            comboBox6.DisplayMember = "branch_name";
            DataTable dt4 = controller.SelectAllCompanies();
            comboBox7.DataSource = dt4;
            comboBox7.DisplayMember = "company_name";
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox5.Text == "" || comboBox6.Text == "" || comboBox7.Text == "")
                MessageBox.Show("Please Enter complete data");
            else
            {
                int result = controller.INSERTCOURT(textBox1.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text);
                if (result == 1)
                {

                    MessageBox.Show("Court added successfuly");
                    DataTable dt1 = controller.SelectAllCourts();
                    DataTable dt2 = controller.SelectAllCourts();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);

                }
                else
                {
                    MessageBox.Show("Court cannot be added ");

                }

            }
        }

        private void Court_Management_Load(object sender, EventArgs e)
        {
            DataTable dt = controller.SelectAllCourts();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "" || comboBox3.Text == "" )

                MessageBox.Show("Please Enter complete data");
            else
            {
                int result = controller.UpdateCourt(comboBox1.Text,textBox1.Text ,comboBox3.Text);
                if (result == 1)
                {

                    MessageBox.Show("Court updated successfuly");
                    DataTable dt1 = controller.SelectAllCourts();
                    DataTable dt2 = controller.SelectAllCourts();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);

                }
                else
                {
                    MessageBox.Show("Court cannot be updated ");

                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != null && comboBox4.Text != null)
            {
                int result = controller.DeleteCourt(comboBox2.Text, comboBox4.Text);
                if (result == 1)
                {
                    MessageBox.Show("The Court is deleted successfully !");
                    DataTable dt1 = controller.SelectAllCourts();
                    DataTable dt2 = controller.SelectAllCourts();
                    refreshdata(dt1, comboBox1);
                    refreshdata(dt2, comboBox2);
                }
                else

                {
                    MessageBox.Show("Branch cannot be deleted");
                }
            }
            else
            MessageBox.Show("Select the court and its type you want to delete");
            }
    }
}

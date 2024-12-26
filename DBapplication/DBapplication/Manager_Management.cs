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
        //private void refreshdata(DataTable dt, ComboBox c)
        //{
        //    dataGridView1.DataSource = dt;
        //    dataGridView1.Refresh();
        //    c.DataSource = dt;
        //    c.DisplayMember = "company_name";
        //}
        public Manager_Management()
        {
            InitializeComponent();

            this.BackgroundImageLayout = ImageLayout.Stretch;
            //DataTable dt1 = controller.SelectAllCompanies();
            //DataTable dt2 = controller.SelectAllCompanies();

            //refreshdata(dt1, comboBox1);
            //refreshdata(dt2, comboBox2);
        }

     private void button1_Click(object sender, EventArgs e)
       {
    //        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == ""  )
    //            MessageBox.Show("Please enter complete data");
    //        else
    //        {
                
    //            int result = controller.InsertManager(textBox1.Text, textBox2.Text, textBox3.Text,textBox4.Text,textBox5.Text,textBox6.Text,textBox7.Text,textBox8.Text,textBox9.Text);
    //            if (result == 0)
    //            {
    //                MessageBox.Show("Manager cannot be added");

    //            }
    //            else
    //            {
    //                MessageBox.Show("Manger updated successfuly");
    //                //DataTable dt1 = controller.SelectAllCompanies();
    //                //DataTable dt2 = controller.SelectAllCompanies();
    //                //refreshdata(dt1, comboBox1);
    //                //refreshdata(dt2, comboBox2);

    //            }

    //        }
       }
    }
}

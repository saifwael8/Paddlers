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
        string username;
        private void refreshdata(DataTable dt, ComboBox c)
        {
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            c.DataSource = dt;
            c.DisplayMember = "court_name";
        }
        public Court_Management(string username)
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
            //DataTable dt1 = controller.SelectAllCourts();
            //DataTable dt2 = controller.SelectAllCourts();
            //refreshdata(dt1, comboBox1);
            //refreshdata(dt2, comboBox2);
            //DataTable dt3 = controller.SelectAllBranches(username);
            //comboBox6.DataSource = dt3;
            //comboBox6.DisplayMember = "branch_name";
            //DataTable dt4 = controller.SelectAllCompanies();
            //comboBox7.DataSource = dt4;
            //comboBox7.DisplayMember = "company_name";
            //this.username = username;


        }

    }
}

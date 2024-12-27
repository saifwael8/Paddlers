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
    public partial class Competition_Client : Form
    {
        string username;
        Controller controller;
        public Competition_Client(string username)
        {
            InitializeComponent();
            this.username = username;
            controller = new Controller();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = controller.getBranchCity(comboBox1.Text);
            comboBox2.DisplayMember = "branch_name";

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Owner_Welcome : Form
    {
        Controller controller;
        string username;
        int company_id;
        public Owner_Welcome(string username)
        {
            InitializeComponent();
            controller = new Controller();
            this.username = username;
            company_id = controller.getCompanyIdUsername(username);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Manager_Management manager_Management = new Manager_Management(username, company_id);
            manager_Management.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Branch_Management branch_Management = new Branch_Management(username, company_id);
            branch_Management.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProfileManagment profileManagment = new ProfileManagment(username);
            profileManagment.Show();
        }
    }
}

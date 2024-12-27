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
    public partial class Manager_Welcome : Form
    {
        string username;
        int company_id;
        int branch_id;
        Controller controller;
        public Manager_Welcome(string username)
        {
            InitializeComponent();
            controller = new Controller();
            this.username = username;
            branch_id = controller.getBranchIdUsername(username);
            company_id = controller.getCompanyIdUsername(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Court_Managment court_managment = new Court_Managment(username, company_id, branch_id);
            court_managment.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EmployeeManagment employeeManagment = new EmployeeManagment(username, company_id, branch_id);
            employeeManagment.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompetitionManagment competitionManagment = new CompetitionManagment(username, branch_id, company_id);
            competitionManagment.Show();
        }
    }
}

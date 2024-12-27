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
    public partial class Reservation_Client : Form
    {
        string username;
        Controller controller;
        public Reservation_Client(string username)
        {
            InitializeComponent();
            this.username = username;
            controller = new Controller();
            comboBox1.DataSource = controller.getCities();
            comboBox1.DisplayMember = "City";
        }

        private void Reservation_Client_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = controller.getBranchCity(comboBox1.Text);
            comboBox2.DisplayMember = "branch_name";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int branch_id = controller.getBranchIdName(comboBox2.GetItemText(comboBox2.SelectedItem));
            comboBox3.DataSource = controller.SelectAllCourts(branch_id);
            comboBox3.DisplayMember = "court_name";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int branch_id = controller.getBranchIdName(comboBox2.GetItemText(comboBox2.SelectedItem));
            int court_id = controller.getCourtId(comboBox3.GetItemText(comboBox3.SelectedItem), branch_id);
            int company_id = controller.getCompanyIdBranchId(branch_id);
            comboBox4.DataSource = controller.getSlots(court_id);
            comboBox4.DisplayMember = "time";
            comboBox5.DataSource = controller.SelectAllServices(company_id);
            comboBox5.DisplayMember = "service_name";


        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int branch_id = controller.getBranchIdName(comboBox2.GetItemText(comboBox2.SelectedItem));
            int court_id = controller.getCourtId(comboBox3.GetItemText(comboBox3.SelectedItem), branch_id);
            int company_id = controller.getCompanyIdBranchId(branch_id);
            string service_name = comboBox5.GetItemText(comboBox5.SelectedItem);
            int price = controller.getPrice(company_id, service_name);
            textBox1.Text = price.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int branch_id = controller.getBranchIdName(comboBox2.GetItemText(comboBox2.SelectedItem));
            int court_id = controller.getCourtId(comboBox3.GetItemText(comboBox3.SelectedItem), branch_id);
            int company_id = controller.getCompanyIdBranchId(branch_id);
            string service_name = comboBox5.GetItemText(comboBox5.SelectedItem);
            int service_id = controller.getService(company_id, service_name);
            string time = comboBox4.GetItemText(comboBox4.SelectedItem);
            int slot_id = controller.getSlotId(time, court_id);


            if (controller.insertReservation(username, service_id, branch_id, slot_id) ==  1) 
            {
                controller.setSlot(slot_id);
                MessageBox.Show("Succesfully inserted the Reservation");
            }
            else
            {
                MessageBox.Show("Reservation has already been inserted");
            }

        }
    }
}

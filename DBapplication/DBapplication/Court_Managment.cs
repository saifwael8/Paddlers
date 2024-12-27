using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DBapplication
{
    public partial class Court_Managment : Form
    {
        string username;
        int company_id;
        int branch_id;
        Controller controller;
        public Court_Managment(string username, int company_id, int branch_id)
        {
            InitializeComponent();
            this.username = username;
            this.company_id = company_id;
            this.branch_id = branch_id;
            controller = new Controller();
            refresh();
        }

        void refresh()
        {
            dataGridView1.DataSource = controller.SelectAllCourts(branch_id);
            comboBox3.DataSource = controller.SelectAllCourts(branch_id);
            comboBox3.DisplayMember = "court_name";
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(new string[] { "Paddle Court Single", "Paddle Court Double", "Tennis Court Single", "Tennis Court Double" });
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "Paddle Court Single", "Paddle Court Double", "Tennis Court Single", "Tennis Court Double" });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string court_name = textBox1.Text;
            string court_type = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (court_name == "" || court_type == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (controller.InsertCourt(court_name, court_type, branch_id) == 1)
            {
                MessageBox.Show("Court added successfully");
            }
            else
            {
                MessageBox.Show("Court already exists");
            }
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string court_name = comboBox3.GetItemText(comboBox3.SelectedItem);
            string court_type = comboBox2.GetItemText(comboBox2.SelectedItem);
            if (court_name == "" || court_type == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            int court_id = controller.getCourtId(court_name, branch_id);
            if(controller.UpdateCourt(court_id, court_name, court_type) == 1)
            {
                MessageBox.Show("Court updated successfully");
            }
            else
            {
                MessageBox.Show("Court does not exist");
            }
            refresh();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dateTimePicker1.Value;
            DateTime toDate = dateTimePicker2.Value;
            int court_id = controller.getCourtId(comboBox3.GetItemText(comboBox3.SelectedItem), branch_id);

            DateTime startTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 9, 0, 0);
            DateTime endTime = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);


            List<DateTime> slots = new List<DateTime>();
            DateTime slot = fromDate;

            while (slot <= toDate)
            {
                slots.Add(slot);
                slot = slot.AddHours(1);
            }

            foreach (var s in slots)
            {
                controller.InsertSlot(s, court_id);
            }

            MessageBox.Show("Slots added succesfuly");

        }
    }
}

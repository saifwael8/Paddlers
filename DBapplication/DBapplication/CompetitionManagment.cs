using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class CompetitionManagment : Form
    {
        string username;
        int branch_id;
        int company_id;
        Controller controller;
        public CompetitionManagment(string username, int branch_id, int company_id)
        {
            InitializeComponent();
            this.username = username;
            this.branch_id = branch_id;
            this.company_id = company_id;
            controller = new Controller();
            refresh();
        }

        void refresh()
        {
            dataGridView1.DataSource = controller.getCompetitions(branch_id);
            comboBox2.DataSource = controller.getCompetitions(branch_id);
            comboBox2.DisplayMember = "competition_name";
            comboBox1.DataSource = controller.SelectAllCourts(branch_id);
            comboBox1.DisplayMember = "court_name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            int MaxNumberofParticipants = 0;
            int Prize = 0;

            try
            {
                MaxNumberofParticipants = int.Parse(textBox1.Text);
                Prize = int.Parse(textBox2.Text);
                name = textBox3.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please fill all fields as integers");
                return;
            }

            if (controller.insertCompetition(name, MaxNumberofParticipants, branch_id, Prize, 0) == 1)
            {
                MessageBox.Show("Competition added successfully");
            }
            else
            {
                MessageBox.Show("Competition already exists");
            }
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string competition_name = comboBox2.GetItemText(comboBox2.SelectedItem);
            int competition_id = controller.getCompetitionId(competition_name, branch_id);
            string time = comboBox3.GetItemText(comboBox3.SelectedItem);
            int court_id = controller.getCourtId(comboBox1.GetItemText(comboBox1.SelectedItem), branch_id);
            int slot_id;
            try
            {
                slot_id = controller.getSlotId(time, court_id);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (controller.updateCompetition(competition_id, slot_id) == 1)
            {
                MessageBox.Show("Competition Slot Added successfully");
                controller.setSlot(slot_id);
            }
            else
            {
                MessageBox.Show("Competition Slot already exists");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int court_id = controller.getCourtId(comboBox1.GetItemText(comboBox1.SelectedItem), branch_id);
            comboBox3.DataSource = controller.getSlots(court_id);
            comboBox3.DisplayMember = "time";
        }
    }
}

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
    public partial class Client_Welcome : Form
    {
        string username;
        public Client_Welcome(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProfileManagment profileManagment = new ProfileManagment(username);
            profileManagment.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reservation_Client reservation_Client = new Reservation_Client(username);
            reservation_Client.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class CreateCompany : Form
    {
        Controller controller;
        public CreateCompany()
        {
            InitializeComponent();
            this.BackgroundImageLayout = ImageLayout.Stretch;
             
        }

        private void CreateCompany_Load(object sender, EventArgs e)
        {
            controller = new Controller();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
                MessageBox.Show("Empty Company name");
            else
            {
                int result = controller.InsertCompany(textBox1.Text);

                if (result == 0)
                    MessageBox.Show("Company cannot be inserted");
                else

                {
                    MessageBox.Show("Company added successfuly");

                }
            }
        }

        
    }
}

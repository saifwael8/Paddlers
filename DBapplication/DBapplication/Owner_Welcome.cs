using System;
using System.Drawing;
using System.Windows.Forms;

namespace DBapplication
{
    public partial class Owner_Welcome : Form
    {
        private Rectangle buttonOriginalRectangle;
        private Rectangle button2OriginalRectangle;
        private Rectangle button3OriginalRectangle;
        private Rectangle button4OriginalRectangle;
        private Rectangle originalFormSize;

        public Owner_Welcome()
        {
            InitializeComponent();
            // Subscribe to the Resize event
            this.Resize += new EventHandler(Owner_Welcome_Resize);
        }

        private void Owner_Welcome_Load(object sender, EventArgs e)
        {
            // Use ClientSize for accurate form dimensions
            originalFormSize = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);

            // Capture the button's original size and position
            buttonOriginalRectangle = new Rectangle(button1.Location.X, button1.Location.Y, button1.Width, button1.Height);
            button2OriginalRectangle = new Rectangle(button2.Location.X, button2.Location.Y, button2.Width, button2.Height);
            button3OriginalRectangle = new Rectangle(button3.Location.X, button3.Location.Y, button3.Width, button3.Height);
            button4OriginalRectangle = new Rectangle(button4.Location.X, button4.Location.Y, button4.Width, button4.Height);
        }

        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)this.ClientSize.Width / originalFormSize.Width;
            float yRatio = (float)this.ClientSize.Height / originalFormSize.Height;

            // Calculate new dimensions and position
            int newWidth = Math.Max((int)(r.Width * xRatio), 50);  // Minimum width
            int newHeight = Math.Max((int)(r.Height * yRatio), 20); // Minimum height
            int newX = Math.Max((int)(r.X * xRatio), 0);           // Ensure within bounds
            int newY = Math.Max((int)(r.Y * yRatio), 0);

            // Apply changes to the control
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void Owner_Welcome_Resize(object sender, EventArgs e)
        {
            // Skip resizing if original dimensions are not initialized
            if (originalFormSize.Width == 0 || originalFormSize.Height == 0)
                return;

            // Resize the button
            resizeControl(buttonOriginalRectangle, button1);
            resizeControl(button2OriginalRectangle, button2);
            resizeControl(button3OriginalRectangle, button3);
            resizeControl(button4OriginalRectangle, button4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateCompany createCompany = new CreateCompany();
            createCompany.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Owner_Companies owner_Companies = new Owner_Companies();
            owner_Companies.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Branch_Management branch_Management = new Branch_Management();
            branch_Management.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manager_Management manager_Management = new Manager_Management();
            manager_Management.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qualif
{
    public partial class frmMenu : Form
    {
        public frmDictionary Next_form3 = new frmDictionary("Abbreviations.xml",false);
        public frmTheory Next_form4 = new frmTheory();
        public frmInteractives Next_form6 = new frmInteractives();
        bool opened = false;
        public frmMenu()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            toolTip1.SetToolTip(pictureBox1, "Go to dictionaries");
            toolTip1.SetToolTip(pictureBox2, "Go to theory part");
            toolTip1.SetToolTip(pictureBox3, "Go to interactives menu");
            toolTip1.SetToolTip(label1, "Go to dictionaries");
            toolTip1.SetToolTip(label2, "Go to theory part");
            toolTip1.SetToolTip(label3, "Go to interactives menu");
            toolTip1.SetToolTip(pictureBox5, "Get a structure of work");
            pictureBox6.Visible = false;
            label1.BackColor = Color.White;
            label2.BackColor = Color.White;
            label3.BackColor = Color.White;
            pictureBox2.BackColor = Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmMenu.ActiveForm.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Next_form4.StartPosition = FormStartPosition.CenterScreen;
            Next_form4.Show();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.DarkGreen;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkGreen;
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.DarkGreen;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Next_form4.StartPosition = FormStartPosition.CenterScreen;
            Next_form4.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Next_form3.StartPosition = FormStartPosition.CenterScreen;
            Next_form3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Next_form3.StartPosition = FormStartPosition.CenterScreen;
            Next_form3.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Next_form6.StartPosition = FormStartPosition.CenterScreen;
            Next_form6.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Next_form6.StartPosition = FormStartPosition.CenterScreen;
            Next_form6.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (opened == false)
            {
                pictureBox6.Visible = true;
                pictureBox6.BringToFront();
                opened = true;
            }
            else
            {
                pictureBox6.Visible = false;
                opened = false;
           }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
            opened = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

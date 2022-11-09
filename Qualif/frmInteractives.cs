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
    public partial class frmInteractives : Form
    {
        public frmInteractives()
        {
            InitializeComponent();
        }
        public frmCrossword Next_form5 = new frmCrossword();
        public frmAbbreviator Next_form7 = new frmAbbreviator();
        public frmTest Next_form8 = new frmTest();
        public frmMove Next_form9 = new frmMove();
        private void button1_Click(object sender, EventArgs e)
        {
            Next_form5.StartPosition = FormStartPosition.CenterScreen;
            Next_form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Next_form7.StartPosition = FormStartPosition.CenterScreen;
            Next_form7.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Next_form5.StartPosition = FormStartPosition.CenterScreen;
            Next_form5.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Next_form7.StartPosition = FormStartPosition.CenterScreen;
            Next_form7.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Next_form5.StartPosition = FormStartPosition.CenterScreen;
            Next_form5.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Next_form7.StartPosition = FormStartPosition.CenterScreen;
            Next_form7.Show();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.BackColor = Color.DarkGreen;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.BackColor = Color.DarkGreen;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.BackColor = Color.White;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.BackColor = Color.White;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Next_form8.StartPosition = FormStartPosition.CenterScreen;
            Next_form8.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Next_form8.StartPosition = FormStartPosition.CenterScreen;
            Next_form8.Show();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.BackColor = Color.DarkGreen;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmInteractives.ActiveForm.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Next_form9.StartPosition = FormStartPosition.CenterScreen;
            Next_form9.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Next_form9.StartPosition = FormStartPosition.CenterScreen;
            Next_form9.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can choose an interactive from the list");
        }

        private void frmInteractives_Load(object sender, EventArgs e)
        {
        }
    }
}

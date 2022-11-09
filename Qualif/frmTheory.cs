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
    public partial class frmTheory : Form
    {
        public frmTheory()
        {
            InitializeComponent();
        }
        bool opened = false;
        private void Form4_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath;
            webBrowser1.Navigate(path + "\\theory_txt\\theory1.htm");
            toolTip1.SetToolTip(pictureBox5, "Get a tip");
            toolTip1.SetToolTip(treeView1, "Choose a paragraph");
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            pictureBox1.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ActiveForm.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = Application.StartupPath;
          if(treeView1.SelectedNode.Text== "What is an abbreviation and its history")  webBrowser1.Navigate(path + "\\theory_txt\\theory1.htm");
            if (treeView1.SelectedNode.Text == "Spheres of using abbreviations") webBrowser1.Navigate(path + "\\theory_txt\\theory2.htm");
            if (treeView1.SelectedNode.Text == "Abbreviations in modern English") webBrowser1.Navigate(path + "\\theory_txt\\theory3.htm");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (opened == false)
            {
                pictureBox1.Visible = true;
                pictureBox1.BringToFront();
                opened = true;
            }
            else
            {
                pictureBox1.Visible = false;
                opened = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            opened = false;
        }
    }
}

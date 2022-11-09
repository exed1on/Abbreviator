using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Qualif
{
    public partial class frmMove : Form
    {
        public frmMove()
        {
            InitializeComponent();
        }
        int res = 0;
        double countTime = 0;
        bool rightAnswer = false;
        int numdrops = 0;
        Point pt;


        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (numdrops < 11)
            {
                if (e.Button == MouseButtons.Left)
                    DoDragDrop(sender, DragDropEffects.Move);
            }
        }

        private void Form9_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Form9_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
            src.Location = PointToClient(new Point(e.X, e.Y));
        }

        private void label1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Label)) == sender)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
              if ((sender as TextBox).Text == "")
                  e.Effect = DragDropEffects.Move;
              else
                  e.Effect = DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
              (sender as TextBox).Text += src.Text;
            if (numdrops > 11)
            {
                textBox1.AllowDrop = false;
                textBox2.AllowDrop = false;
                textBox3.AllowDrop = false;
            }
            if (drops[numdrops].Substring(drops[numdrops].IndexOf("/")+1,3) == "acr")
            {
                res++;
                countTime = 0;
                rightAnswer = true;
                timer1.Start();
            }
            else
            {
                countTime = 0;
                rightAnswer = false;
                timer1.Start();
            }
            src.Location = new Point(600, 516);
            numdrops++;
            if (numdrops < 11)
            {
                src.Text = drops[numdrops].Substring(0, drops[numdrops].IndexOf("/"));
            }
            else src.Text = "Final score: "+res+"/12";
            label8.Text = "Score: " + res+"/12";
        }

        private void label1_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
            Label trg = sender as Label;
            if ((int)src.Tag > (int)trg.Tag)
            {
                src.Location = trg.Location;
                trg.Visible = false;
            }
            else src.Visible = false;
            src.Location = new Point(105, 439);
            numdrops++;
            label1.Text = drops[numdrops];
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
           

        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if ((sender as TextBox).Text == "")
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        string[] drops;
        private void Form9_Load(object sender, EventArgs e)
        {
            drops = File.ReadAllLines(Application.StartupPath + "\\tests\\"+"drops1.txt");
            label1.Text = drops[numdrops].Substring(0, drops[numdrops].IndexOf("/"));
            //  label2.Text = drops[1];
            //   label3.Text = drops[2];
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            toolTip1.SetToolTip(pictureBox6, "Get a tip");
            toolTip1.SetToolTip(pictureBox2, "Try again");
            toolTip1.SetToolTip(label1, "Move it to the boxes above");
        }

        private void label2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Label)) == sender)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void label2_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
            Label trg = sender as Label;
            if ((int)src.Tag > (int)trg.Tag)
            {
                src.Location = trg.Location;
                trg.Visible = false;
            }
            else src.Visible = false;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(sender, DragDropEffects.Move);
            pt = new Point(366, 439);
        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
            (sender as TextBox).Text+= src.Text;

            if (numdrops > 11)
            {
                textBox1.AllowDrop = false;
                textBox2.AllowDrop = false;
                textBox3.AllowDrop = false;
            }
            if (drops[numdrops].Substring(drops[numdrops].IndexOf("/") + 1, 3) == "abr")
            {
                res++;
                countTime = 0;
                rightAnswer = true;
                timer2.Start();
            }
            else
            {
                countTime = 0;
                rightAnswer = false;
                timer2.Start();
            }
            src.Location = new Point(600, 516);
          
                numdrops++;
            if (numdrops < 11)
            {
                src.Text = drops[numdrops].Substring(0, drops[numdrops].IndexOf("/"));
            }
            else src.Text = "Final score: " + res + "/12";
            label8.Text = "Score: " + res + "/12";
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            if ((sender as TextBox).Text == "")
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           if(rightAnswer) textBox1.BackColor = Color.Green;
            else textBox1.BackColor = Color.Red;
            countTime++;
            if (countTime == 10)
            {
                textBox1.BackColor = Color.White;
                textBox1.Text = "";
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (rightAnswer) textBox2.BackColor = Color.Green;
            else textBox2.BackColor = Color.Red;
            countTime++;
            if (countTime == 10)
            {
                textBox2.BackColor = Color.White;
                textBox2.Text = "";
                timer2.Stop();
            }
        }

        private void label3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Label)) == sender)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void label3_DragDrop(object sender, DragEventArgs e)
        {
           
            Label src = e.Data.GetData(typeof(Label)) as Label;
            Label trg = sender as Label;
            if ((int)src.Tag > (int)trg.Tag)
            {
                src.Location = trg.Location;
                trg.Visible = false;
            }
            else src.Visible = false;
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(sender, DragDropEffects.Move);
            pt = new Point(671, 439);
        }

        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DoDragDrop(sender, DragDropEffects.Move);
        }

        private void label4_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
            Label trg = sender as Label;
            if ((int)src.Tag > (int)trg.Tag)
            {
                src.Location = trg.Location;
                trg.Visible = false;
            }
            else src.Visible = false;
        }

        private void label4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Label)) == sender)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            Label src = e.Data.GetData(typeof(Label)) as Label;
            (sender as TextBox).Text += src.Text;
            if (numdrops > 10)
            {
                textBox1.AllowDrop = false;
                textBox2.AllowDrop = false;
                textBox3.AllowDrop = false;
            }
            if (drops[numdrops].Substring(drops[numdrops].IndexOf("/") + 1, 3) == "lat")
            {
                res++;
                countTime = 0;
                rightAnswer = true;
                timer3.Start();
            }
            else
            {
                countTime = 0;
                rightAnswer = false;
                timer3.Start();
            }
            src.Location = new Point(600, 516);
            numdrops++;
            if (numdrops < 11)
            {
                src.Text = drops[numdrops].Substring(0, drops[numdrops].IndexOf("/"));
            }
            else src.Text = "Final score: " + res + "/12";
            label8.Text = "Score: " + res + "/12";
        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            if ((sender as TextBox).Text == "")
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (rightAnswer) textBox3.BackColor = Color.Green;
            else textBox3.BackColor = Color.Red;
            countTime++;
            if (countTime == 10)
            {
                textBox3.BackColor = Color.White;
                textBox3.Text = "";                
                timer3.Stop();
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmMove.ActiveForm.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            frmDictionary Next_form3 = new frmDictionary(label5.Text + ".xml", false);
            Next_form3.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            frmDictionary Next_form3 = new frmDictionary((label6.Text + ".xml"), false);
            Next_form3.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            frmDictionary Next_form3 = new frmDictionary((label7.Text + ".xml"), false);
            Next_form3.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            drops = File.ReadAllLines(Application.StartupPath + "\\tests\\"+"drops1.txt");
            res = 0;
            label8.Text = "Score: " + res + "/12";
            numdrops = 0;
            label1.Text = drops[numdrops].Substring(0, drops[numdrops].IndexOf("/"));
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Move the white box to columns");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}

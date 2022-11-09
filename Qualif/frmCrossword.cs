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
using System.Xml;

namespace Qualif
{
    public partial class frmCrossword : Form
    {
        public frmCrossword()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataView dv1;
        public static string nameXMLfile = "TopTable.xml";
        public static int currentrow = 0;
        Random rnd = new Random();
        string file;
        int res = 0;
        int tries=0;
        int finaltries = 0;
        bool authorizied = false;
        int max = 0;
        string username;
        bool updated = true;
        int users = 0;
        int rowCount;
        bool openedLeaders = false;

        private void button1_Click(object sender, EventArgs e)
        {
            CheckAuthorized();
            if (authorizied == false) GetAuthorized();
            else
            {
                username = textBox1.Text;              
                CheckCrossword();
            }
        }

        void CheckAuthorized()
        {
            bool excist = false;
            for (int i = 0; i < rowCount+users; i++)
            {
                if (dataGridView2[i, 0].Value.ToString() == textBox1.Text) excist = true;
            }
            if (textBox1.Text != "") authorizied = true;
            if (excist)
            {
                authorizied = false;
            }
        }

        void  GetAuthorized()
        {
            bool excist = false;
            for (int i = 0; i < rowCount+users; i++)
            {
                if (dataGridView2[i,0].Value.ToString() == textBox1.Text) excist = true;
            }
            if (textBox1.Text != "") authorizied = true;
            else
            {
                MessageBox.Show("Enter your name");

            }
            if (excist)
            {
                authorizied = false;
                MessageBox.Show("This username is taken");
            }
        }

        void SetDataGridView()
        {
            int n = 23;
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Width = 30;
                dataGridView1.Rows[i].Height = 30;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                    dataGridView1.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
         
        }
       void GetCellsMarked()
        {
            int horizontals = 0;
                  string[] words = File.ReadAllLines(file);
                for (int i = 0; i < words.Length; i++)
                {
                      if (words[i].Substring(0, 1) == "h")
                    {
                    horizontals++;
                    string col = words[i].Substring(words[i].LastIndexOf(" ")+1, words[i].IndexOf("/")- words[i].LastIndexOf(" ")-1);
                    string row = words[i].Substring(words[i].LastIndexOf("/") + 1);
                        int wordsize= words[i].LastIndexOf(" ")- words[i].IndexOf(" ")-1;
                    dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col)-1].Value = i+1;
                    for (int j = 0; j <wordsize ; j++)
                        {
                            dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col)+j].Style.BackColor = Color.Gray;
                        dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].ReadOnly = false;
                    }
                   
                }
                    if (words[i].Substring(0, 1) == "v")
                    {
                        string col = words[i].Substring(words[i].LastIndexOf(" ") + 1, words[i].IndexOf("/") - words[i].LastIndexOf(" ") - 1);
                        string row = words[i].Substring(words[i].LastIndexOf("/") + 1);
                        int wordsize = words[i].LastIndexOf(" ") - words[i].IndexOf(" ") - 1;
                    dataGridView1.Rows[int.Parse(row)-1].Cells[int.Parse(col)].Value = i + 1-horizontals;
                    for (int j = 0; j < wordsize; j++)
                        {
                            dataGridView1.Rows[int.Parse(row)+j].Cells[int.Parse(col)].Style.BackColor = Color.Gray;
                        dataGridView1.Rows[int.Parse(row) + j].Cells[int.Parse(col)].ReadOnly = false;
                    }
                    
                }

                }            
        }
        string UpFirstLetter(string s)
        {
            string sup = "";
            sup += Char.ToUpper(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                sup += s[i];
            }
            return sup;
        }
        void CheckCrossword()
        {
            string[] words = File.ReadAllLines(file);
            bool rightWord = true;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Substring(0, 1) == "h")
                {
                    rightWord = true;
                    string col = words[i].Substring(words[i].LastIndexOf(" ") + 1, words[i].IndexOf("/") - words[i].LastIndexOf(" ") - 1);
                    string row = words[i].Substring(words[i].LastIndexOf("/") + 1);
                    int wordsize = words[i].LastIndexOf(" ") - words[i].IndexOf(" ") - 1;
                    for (int j = 0; j < wordsize; j++)
                    {
                        if ((string)dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Value != words[i].Substring(words[i].IndexOf(" ") + 1 + j, 1)
                            && (string)dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Value != UpFirstLetter(words[i].Substring(words[i].IndexOf(" ") + 1 + j, 1))
                            )
                        {
                            rightWord = false;
                        }
 
                    }
                    if (rightWord==false)
                    {
                        for (int j = 0; j < wordsize; j++)
                        {
                                dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Style.BackColor = Color.Red;
                        }
                    }
                    if (rightWord == true)
                    {
                      if(updated)  res++;
                        for (int j = 0; j < wordsize; j++)
                        {
                            dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Style.BackColor = Color.Green;
                        }
                    }
                }
                if (words[i].Substring(0, 1) == "v")
                {
                    rightWord = true;
                    string col = words[i].Substring(words[i].LastIndexOf(" ") + 1, words[i].IndexOf("/") - words[i].LastIndexOf(" ") - 1);
                    string row = words[i].Substring(words[i].LastIndexOf("/") + 1);
                    int wordsize = words[i].LastIndexOf(" ") - words[i].IndexOf(" ") - 1;
                    for (int j = 0; j < wordsize; j++)
                    {
                        if ((string)dataGridView1.Rows[int.Parse(row) + j].Cells[int.Parse(col)].Value != words[i].Substring(words[i].IndexOf(" ") + 1 + j, 1)
                          && (string)dataGridView1.Rows[int.Parse(row) + j].Cells[int.Parse(col)].Value !=UpFirstLetter(words[i].Substring(words[i].IndexOf(" ") + 1 + j, 1))
                          )
                        {
                            rightWord = false;
                        }
                     
                    }
                    if (rightWord == false)
                    {
                        for (int j = 0; j < wordsize; j++)
                        {
                                dataGridView1.Rows[int.Parse(row) + j].Cells[int.Parse(col)].Style.BackColor = Color.Red;
                        }
                    }
                    if (rightWord == true)
                    {
                       if(updated) res++;
                        for (int j = 0; j < wordsize; j++)
                        {
                            dataGridView1.Rows[int.Parse(row) + j].Cells[int.Parse(col)].Style.BackColor = Color.Green;
                        }
                    }
                }
            }
            if (updated)
            {
                if (res > 0)
                {
                    label1.Text = "Score: " + (res - tries) + "/12, max = " + (12 - tries);
                    res = res - tries;
                }
                else
                {
                    res = 0;
                    label1.Text = "Score: 0/12, max = " + (12 - tries);
                }
                if (res > max)
                {
                    max = res;
                    finaltries = tries;
                }
                updated = false;
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Substring(0, 1) == "h")
                {
                    rightWord = true;
                    string col = words[i].Substring(words[i].LastIndexOf(" ") + 1, words[i].IndexOf("/") - words[i].LastIndexOf(" ") - 1);
                    string row = words[i].Substring(words[i].LastIndexOf("/") + 1);
                    int wordsize = words[i].LastIndexOf(" ") - words[i].IndexOf(" ") - 1;
                    for (int j = 0; j < wordsize; j++)
                    {
                        if ((string)dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Value != words[i].Substring(words[i].IndexOf(" ") + 1 + j, 1)
                            && (string)dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Value != UpFirstLetter(words[i].Substring(words[i].IndexOf(" ") + 1 + j, 1))
                            )
                        {
                            rightWord = false;
                        }
                    }
                    if (rightWord == true)
                    {
                        for (int j = 0; j < wordsize; j++)
                        {
                            dataGridView1.Rows[int.Parse(row)].Cells[int.Parse(col) + j].Style.BackColor = Color.Green;
                        }
                    }
                }
            }

            }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmCrossword.ActiveForm.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int n = 23;
            res = 0;
          if(textBox1.Text==username)  tries++;          
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor=Color.White;
                }
            }
            updated = true;
            GetCellsMarked();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dataGridView2.Visible = false;
            int randNum = rnd.Next(1, 4);
            file = Application.StartupPath+ "\\cross\\words" + randNum.ToString() + ".txt";
            pictureBox1.Load(Application.StartupPath + "\\cross\\cross" + randNum.ToString()+".png");
            label5.Text = "Crossword #"+randNum;
            SetDataGridView();
            GetCellsMarked();
            rowCount = dataGridView2.RowCount - 1;
            users = 0;
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            toolTip1.SetToolTip(pictureBox2, "Try again");
            toolTip1.SetToolTip(pictureBox5, "Users results");
            toolTip1.SetToolTip(pictureBox6, "Get a tip");
            toolTip1.SetToolTip(pictureBox3, "Next crossword");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int n = 23;
            int randNum = rnd.Next(1, 4);
            while (randNum == int.Parse(file.Substring(file.IndexOf("words") + 5,1)))
            {
                randNum = rnd.Next(1, 4);
            }
            file = Application.StartupPath + "\\cross\\words" + randNum.ToString() + ".txt";
            pictureBox1.Load(Application.StartupPath + "\\cross\\cross" + randNum.ToString() + ".png");
            label5.Text = "Crossword #" + randNum;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = "";
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Columns[i].Width = 30;
                dataGridView1.Rows[i].Height = 30;
            }
            GetCellsMarked();
            label1.Text = "Score: 0/12";
            res = 0;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (openedLeaders == false)
            {
                dataGridView2.Visible = true;
                dataGridView2.BringToFront();
                openedLeaders = true;
            }
            else
            {
                dataGridView2.Visible = false;
                openedLeaders = false;
            }
            SetTableLeaders();
        }
        void SetTableLeaders()
        {
            string[] userLines = File.ReadAllLines(Application.StartupPath + "\\cross\\leaders.txt");
            dataGridView2.RowCount = userLines.Length;
            dataGridView2.ColumnCount = 3;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns[0].HeaderText = "User";
            dataGridView2.Columns[1].HeaderText = "Points";
            dataGridView2.Columns[2].HeaderText = "Tries";
            dataGridView2.Columns[0].Width = 150;
            dataGridView2.Columns[1].Width = 150;
            dataGridView2.Columns[2].Width = 150;
            for (int i = 0; i < userLines.Length; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = userLines[i].Substring(0, userLines[i].IndexOf("/"));
                dataGridView2.Rows[i].Cells[1].Value = userLines[i].Substring(userLines[i].IndexOf("/") + 1, 1);
                dataGridView2.Rows[i].Cells[2].Value = userLines[i].Substring(userLines[i].LastIndexOf("/") + 1, 1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool takenUsername = false;
            string[] userLines = File.ReadAllLines(Application.StartupPath + "\\cross\\leaders.txt");
            if (textBox1.Text != "")
            {

                for (int i = 0; i < userLines.Length; i++)
                {
                    if (userLines[i].Substring(0, userLines[i].IndexOf("/")) == textBox1.Text) takenUsername=true;
                }
                if (takenUsername == false)
                {

                    textBox1.Text = "";
                    authorizied = false;
                    string[] saveUserLines = new string[userLines.Length + 1];
                    for (int i = 0; i < userLines.Length; i++)
                    {
                        saveUserLines[i] = userLines[i];
                    }
                    saveUserLines[userLines.Length] = username + "/" + res + "/" + (finaltries + 1);
                    File.WriteAllLines(Application.StartupPath + "\\cross\\leaders.txt", saveUserLines);
                    SetTableLeaders();
                }
                else
                {
                    MessageBox.Show("This username is already taken");
                }
            }
            else
            {
                MessageBox.Show("Username can not be empty");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Fill each marked cell with one letter to fill the crossword");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          if(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!="")  dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Substring(0, 1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

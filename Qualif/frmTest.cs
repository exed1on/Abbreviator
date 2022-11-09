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
    public partial class frmTest : Form
    {
        int time = 59;
        int res = 0;
        int question = 1;
        bool wrong = false;
        bool started = false;
        bool variantA, variantB, variantC;
        DataSet ds;
        DataView dv1;
        public static string nameXMLfile = Application.StartupPath + "\\tests\\"+ "Test1.xml";
        public static int currentrow = 0;

        void LoadXmlFile()
        {
            ds = new DataSet();
            FileStream fsReadXml = new FileStream(nameXMLfile, FileMode.Open);

            ds.ReadXml(fsReadXml, XmlReadMode.InferTypedSchema);
            fsReadXml.Close();

            dv1 = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv1;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Width = 10;
            dataGridView1.Columns[1].Width = 10;
            dataGridView1.Columns[2].Width = 10;
            //  string s = Convert.ToString(dataGridView1.Rows[0].Cells[0].Value.ToString());
            currentrow = 0;
        }

        public frmTest()
        {
            InitializeComponent();
        }
        void FirstTest()
        {
            if (question == 1)
            {
                variantA = false;
                variantB = false;
                variantC = false;
                label2.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                label4.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                label5.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                int index = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[0].Cells[i].Value.ToString().Contains("/t")) index = i-1;
                }
                if (index == 0)
                {
                    string ss = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    variantA = true;
                    label3.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 1)
                {
                    string ss = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    variantB = true;
                    label4.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 2)
                {
                    string ss = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    variantC = true;
                    label5.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
            }
            if (question == 2)
            {
                variantA = false;
                variantB = false;
                variantC = false;
                label2.Text = dataGridView1.Rows[1].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[1].Cells[1].Value.ToString();
                label4.Text = dataGridView1.Rows[1].Cells[2].Value.ToString();
                label5.Text = dataGridView1.Rows[1].Cells[3].Value.ToString();
                int index = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[1].Cells[i].Value.ToString().Contains("/t")) index = i-1;
                }
                if (index == 0)
                {
                    string ss = dataGridView1.Rows[1].Cells[1].Value.ToString();
                    variantA = true;
                    label3.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 1)
                {
                    string ss = dataGridView1.Rows[1].Cells[2].Value.ToString();
                    variantB = true;
                    label4.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 2)
                {
                    string ss = dataGridView1.Rows[1].Cells[3].Value.ToString();
                    variantC = true;
                    label5.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
            }
            if (question == 3)
            {
                variantA = false;
                variantB = false;
                variantC = false;
                label2.Text = dataGridView1.Rows[2].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[2].Cells[1].Value.ToString();
                label4.Text = dataGridView1.Rows[2].Cells[2].Value.ToString();
                label5.Text = dataGridView1.Rows[2].Cells[3].Value.ToString();
                int index = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[2].Cells[i].Value.ToString().Contains("/t")) index = i-1;
                }
                if (index == 0)
                {
                    string ss = dataGridView1.Rows[2].Cells[1].Value.ToString();
                    variantA = true;
                    label3.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 1)
                {
                    string ss = dataGridView1.Rows[2].Cells[2].Value.ToString();
                    variantB = true;
                    label4.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 2)
                {
                    string ss = dataGridView1.Rows[2].Cells[3].Value.ToString();
                    variantC = true;
                    label5.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
            }
            if (question == 4)
            {
                variantA = false;
                variantB = false;
                variantC = false;
                label2.Text = dataGridView1.Rows[3].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[3].Cells[1].Value.ToString();
                label4.Text = dataGridView1.Rows[3].Cells[2].Value.ToString();
                label5.Text = dataGridView1.Rows[3].Cells[3].Value.ToString();
                int index = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[3].Cells[i].Value.ToString().Contains("/t")) index = i-1;
                }
                if (index == 0)
                {
                    string ss = dataGridView1.Rows[3].Cells[1].Value.ToString();
                    variantA = true;
                    label3.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 1)
                {
                    string ss = dataGridView1.Rows[3].Cells[2].Value.ToString();
                    variantB = true;
                    label4.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 2)
                {
                    string ss = dataGridView1.Rows[3].Cells[3].Value.ToString();
                    variantC = true;
                    label5.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
            }
            if (question == 5)
            {
                variantA = false;
                variantB = false;
                variantC = false;
                label2.Text = dataGridView1.Rows[4].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[4].Cells[1].Value.ToString();
                label4.Text = dataGridView1.Rows[4].Cells[2].Value.ToString();
                label5.Text = dataGridView1.Rows[4].Cells[3].Value.ToString();
                int index = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[4].Cells[i].Value.ToString().Contains("/t")) index = i-1;
                }
                if (index == 0)
                {
                    string ss = dataGridView1.Rows[4].Cells[1].Value.ToString();
                    variantA = true;
                    label3.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 1)
                {
                    string ss = dataGridView1.Rows[4].Cells[2].Value.ToString();
                    variantB = true;
                    label4.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 2)
                {
                    string ss = dataGridView1.Rows[4].Cells[3].Value.ToString();
                    variantC = true;
                    label5.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
            }
            if (question == 6)
            {
                variantA = false;
                variantB = false;
                variantC = false;
                label2.Text = dataGridView1.Rows[5].Cells[0].Value.ToString();
                label3.Text = dataGridView1.Rows[5].Cells[1].Value.ToString();
                label4.Text = dataGridView1.Rows[5].Cells[2].Value.ToString();
                label5.Text = dataGridView1.Rows[5].Cells[3].Value.ToString();
                int index = 0;
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    if (dataGridView1.Rows[5].Cells[i].Value.ToString().Contains("/t")) index = i-1;
                }
                 if (index == 0)
                {
                    string ss = dataGridView1.Rows[5].Cells[1].Value.ToString();
                    variantA = true;
                    label3.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 1)
                {
                    string ss = dataGridView1.Rows[5].Cells[2].Value.ToString();
                    variantB = true;
                    label4.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
                if (index == 2)
                {
                    string ss = dataGridView1.Rows[5].Cells[3].Value.ToString();
                    variantC = true;
                    label5.Text = ss.Substring(0, ss.IndexOf("/t")) + ss.Substring(ss.IndexOf("/t") + 2);
                }
            }
        }
        void NextQuestion()
        {
            if (wrong)
            {
                if(variantA) label3.BackColor = Color.Green;
                if (variantB) label4.BackColor = Color.Green;
                if (variantC) label5.BackColor = Color.Green;
            }
           
        }
        void NoTimeLeft()
        {

        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmTest.ActiveForm.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (variantA)
                {
                    label3.BackColor = Color.Green;
                    res++;
                    label7.Text = "Score: " + res + "/6";
                }
                else
                {

                    wrong = true;
                    label3.BackColor = Color.Red;
                }
                started = false;
                counttime = 0;
                timer2.Start();
                NextQuestion();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (variantB)
                {
                    label4.BackColor = Color.Green;
                    res++;
                    label7.Text = "Score: " + res + "/6";
                }
                else
                {
                    label4.BackColor = Color.Red;
                    wrong = true;
                }
                started = false;
                counttime = 0;
                timer2.Start();
                NextQuestion();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (started)
            {
                if (variantC)
                {
                    label5.BackColor = Color.DarkGreen;
                    res++;
                    label7.Text = "Score: " + res + "/6";
                }
                else
                {
                    label5.BackColor = Color.DarkRed;
                    wrong = true;
                }
                started = false;
                counttime = 0;
                timer2.Start();
                NextQuestion();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            label9.Visible =false;
            pictureBox1.Visible = true;
            label2.Text = "Idk";
            label3.Text = "I don't know";
            label4.Text = "I don't keep";
            label5.Text = "I dropped key";
            dataGridView1.Visible = false;
            nameXMLfile = Application.StartupPath + "\\tests\\"+ "Test1.xml";
            label8.Text = "Test: unabbreviate";
            LoadXmlFile();
            pictureBox3.Visible = false;
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            toolTip1.SetToolTip(pictureBox6, "Get a tip");
            toolTip1.SetToolTip(pictureBox1, "Click to start the test");
            toolTip1.SetToolTip(pictureBox3, "Go to the next test");
            toolTip1.SetToolTip(label3, "Choose as an answer");
            toolTip1.SetToolTip(label4, "Choose as an answer");
            toolTip1.SetToolTip(label5, "Choose as an answer");
            toolTip1.SetToolTip(pictureBox2, "Click to restart the test");

        }

        int testNum = 1;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (testNum < 5)
            {
                label9.Visible = false;
                timer1.Stop();
                    timer1.Start();
                res = 0;
                testNum++;
                time = 59;
                label7.Text = "Score: " + "0/6";
                label3.BackColor = Color.Transparent;
                label4.BackColor = Color.Transparent;
                label5.BackColor = Color.Transparent;
                nameXMLfile = Application.StartupPath+"\\tests\\"+"Test" + testNum + ".xml";
                if (testNum == 2) label8.Text = "Test: translate";
                if (testNum == 3) label8.Text = "Test: group";
                if (testNum == 4) label8.Text = "Test: group";
                if (testNum == 5) label8.Text = "Test: translate";
                LoadXmlFile();
                currentQues = 0;
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    masQues[i] = 0;
                }
                masQues[currentQues] = rnd.Next(1, dataGridView1.RowCount);
                question = masQues[currentQues];
                label6.Text = "Question number " +(currentQues+1);
                FirstTest();
                pictureBox3.Visible = false;
                started = true;
            }
        }
        int counttime = 0;
        

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            time = 59;
            FirstTest();
            pictureBox1.Visible = false;
            started = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            counttime++;
            if (counttime == 10)
            {
                timer2.Stop();
                if (currentQues < 5)
                {
                      question = rnd.Next(1, dataGridView1.RowCount);
                      for (int i = 0; i < masQues.Length; i++)
                      {
                          for (int j = 0; j <masQues.Length; j++)
                          {
                              if (question == masQues[j])
                              {
                                  question = rnd.Next(1, dataGridView1.RowCount);
                                  i = 0;
                              }
                          }

                      }
                        currentQues++;
                    masQues[currentQues] = question;
                    NextQuestion();
                    FirstTest();
                    wrong = false;
                    label6.Text = "Question number " + (currentQues+1);
                    label7.Text = "Score: " + res + "/6";
                    label3.BackColor = Color.Transparent;
                    label4.BackColor = Color.Transparent;
                    label5.BackColor = Color.Transparent;
                    started = true;
                }
                else
                {
                    label9.Visible = true;
                    label9.Text = "Final score: " + res + "/6";
                    pictureBox3.Visible = true;
                    timer1.Stop();
                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here you can review your knowledge with unabbreviating and translation");
        }


        int currentQues = 0;
        Random rnd = new Random();
        int[] masQues;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
            label8.Text = "Test: unabbreviate";
            timer1.Stop();
            timer1.Start();
            res = 0;
            time = 59;
            label7.Text = "Score: " + "0/6";
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            nameXMLfile = Application.StartupPath + "\\tests\\" + "Test1.xml";
            LoadXmlFile();
            currentQues = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                masQues[i] = 0;
            }
            masQues[currentQues] = rnd.Next(1, dataGridView1.RowCount);
            question = masQues[currentQues];
            label6.Text = "Question number " + (currentQues + 1);
            FirstTest();
            pictureBox3.Visible = false;
            started = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
           masQues = new int[dataGridView1.RowCount-1];
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                masQues[i] = 0;
            }            
            masQues[currentQues]= rnd.Next(1, dataGridView1.RowCount);
            question = masQues[currentQues];
            timer1.Start();
            time = 59;
            FirstTest();
            pictureBox1.Visible = false;
            started = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                label1.Text = "Time left: " + time+" sec";
            time -= 1;
            if (time == 0)
            {                
                label1.BackColor = Color.Red;
                timer1.Stop();
                started = false;
            }
        }
    }
}

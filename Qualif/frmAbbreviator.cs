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
using System.Web;
using System.Net;
using System.Text;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web;
using System.Windows;


namespace Qualif
{
    public partial class frmAbbreviator : Form
    {
        public frmAbbreviator()
        {
            InitializeComponent();
        }
        DataSet ds;
        DataView dv1;
        public static string nameXMLfile = "Abbreviations.xml";
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmMenu.ActiveForm.Hide();
        }
        void LoadXmlFile()
        {
            ds = new DataSet();
            FileStream fsReadXml = new FileStream(nameXMLfile, FileMode.Open);

            ds.ReadXml(fsReadXml, XmlReadMode.InferTypedSchema);
            fsReadXml.Close();

            dv1 = new DataView(ds.Tables[0]);
            dataGridView1.DataSource = dv1;

            string s = dataGridView1.Rows[0].Cells[0].Value.ToString();
        }
        string UpAndDownFirstLetter(string s)
        {
            string st = "";
            if (Char.IsUpper(s[0])) st += Char.ToLower(s[0]);
            else st += Char.ToUpper(s[0]);
            for (int i = 1; i < s.Length; i++)
            {
                st += s[i];
            }
            return st;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string s = richTextBox1.Text;
            AbbreviateText(s);
        }

        void AbbreviateText(string s)
        {
            richTextBox2.Clear();
            listBox1.Items.Clear();
            string[] stRazd = s.Split(new char[] { ' ', ',', '"', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int abbr = 0;
            int replacing = 0;
            int contr = 0;
            int acr = 0;
            int abbit = 0;
            int abblat = 0;
            string virez = "";
            string stvirez = "";
            for (int j = 0; j < 6; j++)
            {
                if (j == 0) nameXMLfile = Application.StartupPath + "\\dics\\" + "Abbreviations.xml";
                if (j == 1) nameXMLfile = Application.StartupPath + "\\dics\\" + "Replacing consonant characters.xml";
                if (j == 2) nameXMLfile = Application.StartupPath + "\\dics\\" + "Contractions.xml";
                if (j == 3) nameXMLfile = Application.StartupPath + "\\dics\\" + "Acronyms and initialisms.xml";
                if (j == 4) nameXMLfile = Application.StartupPath + "\\dics\\" + "Abbreviations in IT sphere.xml";
                if (j == 5) nameXMLfile = Application.StartupPath + "\\dics\\" + "Abbreviations from Latin.xml";
                LoadXmlFile();
                for (int z = 0; z < dataGridView1.RowCount - 1; z++)
                {
                    for (int t = 0; t < stRazd.Length; t++)
                    {
                        stvirez = "";
                        for (int k = t; k < stRazd.Length; k++)
                        {
                            if (k > t) stvirez += " ";
                            stvirez += stRazd[k];
                            if (stvirez == dataGridView1.Rows[z].Cells[1].Value.ToString())
                            {
                                stRazd[t] = dataGridView1.Rows[z].Cells[0].Value.ToString();
                                if (k - t > 0)
                                {
                                    for (int r = 1; r <= k - t; r++)
                                    {
                                        stRazd[t + r] = "";
                                    }
                                }
                                if (j == 0) abbr++;
                                if (j == 1) replacing++;
                                if (j == 2) contr++;
                                if (j == 3) acr++;
                                if (j == 4) abbit++;
                                if (j == 5) abblat++;
                            }
                            if (stvirez == UpAndDownFirstLetter(dataGridView1.Rows[z].Cells[1].Value.ToString()))
                            {
                                stRazd[t] = UpAndDownFirstLetter(dataGridView1.Rows[z].Cells[0].Value.ToString());
                                if (k - t > 0)
                                {
                                    for (int r = 1; r <= k - t; r++)
                                    {
                                        stRazd[t + r] = "";
                                    }
                                }
                                if (j == 0) abbr++;
                                if (j == 1) replacing++;
                                if (j == 2) contr++;
                                if (j == 3) acr++;
                                if (j == 4) abbit++;
                                if (j == 5) abblat++;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < stRazd.Length; i++)
            {
                if (stRazd[i] != "") richTextBox2.Text += stRazd[i] + " ";
            }
            listBox1.Items.Add("Abbreviations - " + abbr);
            listBox1.Items.Add("Replacing consonant characters - " + replacing);
            listBox1.Items.Add("Contractions - " + contr);
            listBox1.Items.Add("Acronyms and initialisms - " + acr);
            listBox1.Items.Add("Abbreviations in IT sphere - " + abbit);
            listBox1.Items.Add("Abbreviations from Latin - " + abblat);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string s = richTextBox1.Text;
            UnabbreviateText(s);
        }


        void UnabbreviateText(string s)
        {
            richTextBox2.Clear();
            listBox1.Items.Clear();
            string[] stRazd = s.Split(new char[] { ' ', ',', '"', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            int abbr = 0;
            int replacing = 0;
            int contr = 0;
            int acr = 0;
            int abbit = 0;
            int abblat = 0;
            string virez = "";
            string stvirez = "";
            for (int j = 0; j < 6; j++)
            {
                if (j == 0) nameXMLfile = Application.StartupPath + "\\dics\\" + "Abbreviations.xml";
                if (j == 1) nameXMLfile = Application.StartupPath + "\\dics\\" + "Replacing consonant characters.xml";
                if (j == 2) nameXMLfile = Application.StartupPath + "\\dics\\" + "Contractions.xml";
                if (j == 3) nameXMLfile = Application.StartupPath + "\\dics\\" + "Acronyms and initialisms.xml";
                if (j == 4) nameXMLfile = Application.StartupPath + "\\dics\\" + "Abbreviations in IT sphere.xml";
                if (j == 5) nameXMLfile = Application.StartupPath + "\\dics\\" + "Abbreviations from Latin.xml";
                LoadXmlFile();
                for (int z = 0; z < dataGridView1.RowCount - 1; z++)
                {
                    for (int t = 0; t < stRazd.Length; t++)
                    {
                        stvirez = "";
                        for (int k = t; k < stRazd.Length; k++)
                        {
                            if (k > t) stvirez += " ";
                            stvirez += stRazd[k];
                            if (stvirez == dataGridView1.Rows[z].Cells[0].Value.ToString())
                            {
                                stRazd[t] = dataGridView1.Rows[z].Cells[1].Value.ToString();
                                if (k - t > 0)
                                {
                                    for (int r = 1; r <= k - t; r++)
                                    {
                                        stRazd[t + r] = "";
                                    }
                                }
                                if (j == 0) abbr++;
                                if (j == 1) replacing++;
                                if (j == 2) contr++;
                                if (j == 3) acr++;
                                if (j == 4) abbit++;
                                if (j == 5) abblat++;
                            }
                            if (j != 5)
                            {
                                if (Char.IsLetter(stvirez[0]) && stvirez == UpAndDownFirstLetter(dataGridView1.Rows[z].Cells[0].Value.ToString()))
                                {
                                    stRazd[t] = UpAndDownFirstLetter(dataGridView1.Rows[z].Cells[1].Value.ToString());
                                    if (k - t > 0)
                                    {
                                        for (int r = 1; r <= k - t; r++)
                                        {
                                            stRazd[t + r] = "";
                                        }
                                    }
                                    if (j == 0) abbr++;
                                    if (j == 1) replacing++;
                                    if (j == 2) contr++;
                                    if (j == 3) acr++;
                                    if (j == 4) abbit++;
                                    if (j == 5) abblat++;
                                }
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < stRazd.Length; i++)
            {
                richTextBox2.Text += stRazd[i] + " ";
            }
            listBox1.Items.Add("Abbreviations - " + abbr);
            listBox1.Items.Add("Replacing consonant characters - " + replacing);
            listBox1.Items.Add("Contractions - " + contr);
            listBox1.Items.Add("Acronyms and initialisms - " + acr);
            listBox1.Items.Add("Abbreviations in IT sphere - " + abbit);
            listBox1.Items.Add("Abbreviations from Latin - " + abblat);
        }

        private void Form7_Load(object sender, EventArgs e)
        {         
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            toolTip1.SetToolTip(pictureBox6, "Get a tip");
            toolTip1.SetToolTip(pictureBox1, "Upload text file");
            toolTip1.SetToolTip(listBox1, "Double click on line to open dictionary");
            toolTip1.SetToolTip(pictureBox2, "Abbreviate and save file");
            toolTip1.SetToolTip(pictureBox3, "Unabbreviate and save file");
        }
        string sFile = "";
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFile = File.ReadAllText(openFileDialog1.FileName);
            }
            richTextBox1.Text = sFile;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string sRes = "";
            AbbreviateText(sFile);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            sRes = richTextBox2.Text;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, sRes);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string sRes = "";
            UnabbreviateText(sFile);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            sRes = richTextBox2.Text;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, sRes);
            }
        }
        public void listBox1_DoubleClick(object sender, EventArgs e)
        {
            frmDictionary Next_form3 = new frmDictionary(listBox1.SelectedItem.ToString() + ".xml", true);
            Next_form3.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program abbreviates or unabbreviates texts using dictionaries");
        }
    }
}
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
    public partial class frmDictionary : Form
    {
        DataSet ds;
        DataView dv1;
        public static string nameXMLfile = "Abbreviations.xml";
        bool opened = false;
        void SaveXMLFile()
        {
            FileStream fsWriteXML = new FileStream(nameXMLfile, FileMode.Create);
            ds.WriteXml(fsWriteXML);
            fsWriteXML.Close();
        }
        void FillComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Abbreviations");
            comboBox1.Items.Add("Abbreviations from Latin");
            comboBox1.Items.Add("Replacing consonant characters");
            comboBox1.Items.Add("Contractions");
            comboBox1.Items.Add("Acronyms and initialisms");
            comboBox1.Items.Add("Abbreviations in IT sphere");
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
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Width = 300;
            dataGridView1.Columns[1].Width = 300;
            dataGridView1.Columns[2].Width = 300;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = 30;
            }
        }
        bool sendBool = false;
        public frmDictionary(string stt,bool changed)
        {
            InitializeComponent();
            nameXMLfile = stt;
            sendBool = changed;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameXMLfile =Application.StartupPath+"\\dics\\"+ comboBox1.Text+".xml";
            LoadXmlFile();
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frmMenu.ActiveForm.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox4, "Go to previous form");
            toolTip1.SetToolTip(pictureBox5, "Get a tip");
            toolTip1.SetToolTip(comboBox1, "Choose a name");
            pictureBox1.Visible = false;
            // nameXMLfile = "Abbreviations.xml";
            FillComboBox();
            frmAbbreviator Next_form7 = new frmAbbreviator();
        if(sendBool) comboBox1.Text = nameXMLfile.Substring(0,nameXMLfile.IndexOf("-")-1);
        else comboBox1.Text = nameXMLfile.Substring(0, nameXMLfile.IndexOf("."));
            LoadXmlFile();
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

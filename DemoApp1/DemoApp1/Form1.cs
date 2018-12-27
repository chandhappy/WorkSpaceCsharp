using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String ACqID = textBox1.Text;
            String Date = dateTimePicker1.Text;
            if(!(ACqID.Equals("")) && (!Date.Equals(""))){
               label10.Text=ACqID;
                label9.Text = Date;
            }
            else
            {
                MessageBox.Show("SiteID is empty");
            }

            String ConString,sql,output="";
            SqlCommand cmd;
            SqlDataReader datareader;

            ConString = "Data Source=INBLRN0402;Initial Catalog=DemoDB;User ID=sa;Password=P@ssw0rd";
            SqlConnection dbcon = new SqlConnection(ConString);
            dbcon.Open();
            sql = "select name from dbo.testTable";
            cmd = new SqlCommand(sql, dbcon);
            datareader = cmd.ExecuteReader();
            while (datareader.Read())
            {
                output = output + datareader.GetValue(0) + "\n";
            }
            cmd.Dispose();
            dbcon.Close();
            MessageBox.Show(output);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (!textBox1.Text.Equals(""))
            {
                string path = System.IO.Path.Combine(getHomePath(), "Downloads");
                MessageBox.Show(path);
                try
                {
                    if (!Directory.Exists(path + "/VHReports/"))
                    {
                        // Try to create the directory.
                        DirectoryInfo di = Directory.CreateDirectory(path + "/VHReports/");

                    }
                    if (!Directory.Exists(path + "/VHReports/" + textBox1.Text + "/" + dateTimePicker1.Text + "/"))
                    {
                        // Try to create the directory.
                        DirectoryInfo dir = Directory.CreateDirectory(path + "/VHReports/" + textBox1.Text + "/" + dateTimePicker1.Text + "/");
                    }
                }
                catch (IOException ioex)
                {
                    Console.WriteLine(ioex.Message);
                }
            }
            else
            {
                MessageBox.Show("SiteID is empty");
            }

        }
        public static string getHomePath()
        {
            // Not in .NET 2.0
            // System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (System.Environment.OSVersion.Platform == System.PlatformID.Unix)
                return System.Environment.GetEnvironmentVariable("HOME");
            return System.Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");
        }

    }
}

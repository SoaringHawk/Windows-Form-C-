using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class IP_Validator : Form
    {
        public IP_Validator()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void IP_Validator_Load(object sender, EventArgs e)
        {
            label1.Text = $"Today: {DateTime.Now.ToString("MMMM dd, yyyy")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string IPv4Pattern =
        @"^(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[0-1]?[0-9][0-9]?)$";
            string IPv6Pattern =
            @"^(?:[0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$";


            
            if ((Regex.IsMatch(textBox1.Text, IPv4Pattern)) )
            {
                // Both IPv4 and IPv6 addresses are valid
                MessageBox.Show("IPv4 addresse is valid.");
                    
                FileStream fs = new FileStream(@"./IP-Addresses.txt", FileMode.Append, FileAccess.Write);
                // create the output stream for a text file that exists
                BinaryWriter textOut = new BinaryWriter(fs);
                // write the fields into text file
                DateTime currentDate = DateTime.Now.Date;
                textOut.Write($" {currentDate} IP:{textBox1.Text}" + "\n");
                //textOut.WriteLine(textBox1.Text);
                // close the output stream for the text file
                textOut.Close();
            }
            else
            {
                // Show message box for invalid address
                MessageBox.Show($"{textBox1.Text}\n The IP must have 4 bytes \n integer numbers between 0 and 255 \n separated by a dot. 255.255.255.255.");
            }

            if ((Regex.IsMatch(textBox2.Text, IPv6Pattern)))
            {
                // Both IPv4 and IPv6 addresses are valid
                MessageBox.Show("IPv6 addresse is valid.");

                FileStream fs = new FileStream(@"./IP-Addresses.txt", FileMode.Append, FileAccess.Write);
                // create the output stream for a text file that exists
                BinaryWriter textOut = new BinaryWriter(fs);
                // write the fields into text file
                DateTime currentDate = DateTime.Now.Date;
                textOut.Write($" {currentDate} IP:{textBox2.Text}" + "\n");
                //textOut.WriteLine(textBox1.Text);
                // close the output stream for the text file
                textOut.Close();
            }
            else
            {
                // Show message box for invalid address
                MessageBox.Show($"{textBox2.Text}\n Invalid IPv6 address.\n eight groups of four hexadecimal digits separated by colons.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"./IP-Addresses.txt", FileMode.Open, FileAccess.Read);
            try
            {
                // create the object for the input stream for a text file
                BinaryReader textIn = new BinaryReader(fs);
                string textToPrint = "";
                // read the data from the file and store it in the list
                while (textIn.PeekChar() != -1)
                {
                    string row = textIn.ReadString();
                    //    string[] columns = row.Split('|');
                    textToPrint += row + "\n";
                }
                MessageBox.Show(textToPrint);
                // close the input stream for the text file
                textIn.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@".../IP-Addresses.txt" + " not found.", "File Not Found");
            }
            
            finally
            { if (fs != null) fs.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Exit?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}

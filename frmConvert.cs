//Christian Denis Marcelin
//Version 2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class frmConvert : Form
    {
        DateTime startTime = DateTime.Now;
        public frmConvert()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"./MoneyConversions.txt", FileMode.Append, FileAccess.Write);
            // create the output stream for a text file that exists
            StreamWriter textOut = new StreamWriter(fs);
            // write the fields into text file
            DateTime currentDate = DateTime.Now.Date;
            
            //textOut.WriteLine(textBox1.Text);
            // close the output stream for the text file
            
            if (radioButton1.Checked)
            {
                textBox1.Text = textBox6.Text;
                textBox2.Text = (Convert.ToDouble(textBox6.Text)* 0.757).ToString() ;
                textBox3.Text = (Convert.ToDouble(textBox6.Text) * 0.674).ToString();
                textBox4.Text = (Convert.ToDouble(textBox6.Text) * 0.58).ToString();
                textBox5.Text = (Convert.ToDouble(textBox6.Text) * 104).ToString();
                textBox7.Text = (Convert.ToDouble(textBox6.Text) * 68.83).ToString();
                textOut.Write($"{currentDate} {textBox1.Text} = {textBox1.Text} CAD; {textBox2.Text}USD; {textBox3.Text}EUR; {textBox4.Text}GBP; {textBox5.Text}HTG ;  {textBox7.Text} RUB" + "\n");
            }
            else if (radioButton2.Checked)
            {
                textBox2.Text = textBox6.Text;
                textBox1.Text = (Convert.ToDouble(textBox6.Text) * 1.32).ToString();
                textBox3.Text = (Convert.ToDouble(textBox6.Text) * 0.89).ToString();
                textBox4.Text = (Convert.ToDouble(textBox6.Text) * 0.76).ToString();
                textBox5.Text = (Convert.ToDouble(textBox6.Text) * 138).ToString();
                textBox7.Text = (Convert.ToDouble(textBox6.Text) * 90.68).ToString();
                textOut.Write($"{currentDate} {textBox2.Text} = {textBox1.Text} CAD; {textBox2.Text}USD; {textBox3.Text}EUR; {textBox4.Text}GBP; {textBox5.Text}HTG ;  {textBox7.Text} RUB" + "\n");
            }

            else if (radioButton3.Checked)
            {
                textBox3.Text = textBox6.Text;
                textBox1.Text = (Convert.ToDouble(textBox6.Text) * 1.5).ToString();
                textBox2.Text = (Convert.ToDouble(textBox6.Text) * 1.12).ToString();
                textBox4.Text = (Convert.ToDouble(textBox6.Text) * 0.86).ToString();
                textBox5.Text = (Convert.ToDouble(textBox6.Text) * 156).ToString();
                textBox7.Text = (Convert.ToDouble(textBox6.Text) * 101).ToString();
                textOut.Write($"{currentDate} {textBox3.Text} = {textBox1.Text} CAD; {textBox2.Text}USD; {textBox3.Text}EUR; {textBox4.Text}GBP; {textBox5.Text}HTG ;  {textBox7.Text} RUB" + "\n");
            }

            else if (radioButton4.Checked)
            {
                textBox4.Text = textBox6.Text;
                textBox1.Text = (Convert.ToDouble(textBox6.Text) * 1.72).ToString();
                textBox3.Text = (Convert.ToDouble(textBox6.Text) * 1.31).ToString();
                textBox2.Text = (Convert.ToDouble(textBox6.Text) * 1.16).ToString();
                textBox5.Text = (Convert.ToDouble(textBox6.Text) * 181).ToString();
                textBox7.Text = (Convert.ToDouble(textBox6.Text) * 118).ToString();
                textOut.Write($"{currentDate} {textBox4.Text} = {textBox1.Text} CAD; {textBox2.Text}USD; {textBox3.Text}EUR; {textBox4.Text}GBP; {textBox5.Text}HTG ; {textBox7.Text}RUB" + "\n");
            }
            else
            {
                textBox5.Text = textBox6.Text;
                textBox1.Text = (Convert.ToDouble(textBox6.Text) * 0.0095).ToString();
                textBox3.Text = (Convert.ToDouble(textBox6.Text) * 0.0072).ToString();
                textBox2.Text = (Convert.ToDouble(textBox6.Text) * 0.0064).ToString();
                textBox4.Text = (Convert.ToDouble(textBox6.Text) * 0.0065).ToString();
                textBox7.Text = (Convert.ToDouble(textBox6.Text) * 0.65).ToString();
                textOut.Write($"{currentDate} {textBox5.Text} = {textBox1.Text} CAD; {textBox2.Text}USD; {textBox3.Text}EUR; {textBox4.Text}GBP; {textBox5.Text}HTG ; {textBox7.Text}RUB" + "\n");
            }

            textOut.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"./MoneyConversions.txt", FileMode.Open, FileAccess.Read);
            try
            {
                // create the object for the input stream for a text file
                StreamReader textIn = new StreamReader(fs);
                string textToPrint = "";
                // read the data from the file and store it in the list
                while (textIn.Peek() != -1)
                {
                    string row = textIn.ReadLine();
                    //    string[] columns = row.Split('|');
                    textToPrint += row + "\n";
                }
                MessageBox.Show(textToPrint);
                // close the input stream for the text file
                textIn.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(@".../LottoNbrs.txt" + " not found.", "File Not Found");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show(@".../LottoNbrs.txt" + " not found.", "Directory Not Found");
            }
            catch (IOException ex)
            { MessageBox.Show(ex.Message, "IOException"); }
            finally
            { if (fs != null) fs.Close(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int minutes = (int)(DateTime.Now - startTime).TotalMinutes;
            int seconds = (int)(DateTime.Now - startTime).TotalSeconds;

            if (MessageBox.Show($"Do you want to quit this app? You have been here for {minutes} minutes and {seconds} seconds ", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }
    }
}

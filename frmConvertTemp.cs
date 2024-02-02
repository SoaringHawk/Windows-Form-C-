//Christian Denis Marcelin
//V2.0
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp7
{
    public partial class frmConvertTemp : Form
    {
        public frmConvertTemp()
        {
            InitializeComponent();
        }

        public static string GetTemperatureDescription(double celsius, double fahrenheit)
        {
            if (celsius == 100 || fahrenheit == 212)
            {
                return "Water boils";
            }
            else if (celsius == 40 || fahrenheit == 104)
            {
                return "Hot Bath";
            }
            else if (celsius == 37 || fahrenheit == 98.6)
            {
                return "Body temperature";
            }
            else if (celsius == 30 || fahrenheit == 86)
            {
                return "Beach weather";
            }
            else if (celsius == 21 || fahrenheit == 70)
            {
                return "Room temperature";
            }
            else if (celsius == 10 || fahrenheit == 50)
            {
                return "Cool Day";
            }
            else if (celsius == 0 || fahrenheit == 32)
            {
                return "Freezing point of water";
            }
            else if (celsius == -18 || fahrenheit == 0)
            {
                return "Very Cold Day";
            }
            else if (celsius == -40 || fahrenheit == -40)
            {
                return "Extremely Cold Day";
            }
            else
            {
                return "No specific description available";
            }
        }


        private void button1_Click(object sender, EventArgs e)

        {
            FileStream fs = new FileStream(@"./TempConversions.txt", FileMode.Append, FileAccess.Write);
            // create the output stream for a text file that exists
            StreamWriter textOut = new StreamWriter(fs);
            // write the fields into text file
            DateTime currentDate = DateTime.Now.Date;

            //textOut.WriteLine(textBox1.Text);
            // close the output stream for the text file

            if (radioButton1.Checked)
            {
                // Convert Celsius to Fahrenheit
                if (double.TryParse(textBox1.Text, out double celsius))
                {
                   

                    double fahrenheit = (celsius * 9 / 5) + 32;
                    String Message = GetTemperatureDescription(celsius, fahrenheit);
                    textBox2.Text = fahrenheit.ToString();
                    textOut.Write($"{textBox1.Text} C = {textBox2.Text}F {currentDate} {Message}" + "\n");
                    textBox3.Text = Message;
                }
                else
                {
                    // Invalid input for Celsius
                    MessageBox.Show("Invalid Input");
                }
            }
            else if (radioButton2.Checked)
            {
                // Convert Fahrenheit to Celsius
                if (double.TryParse(textBox1.Text, out double fahrenheit))
                {
                   

                    double celsius = (fahrenheit - 32) * 5 / 9;
                    String Message = GetTemperatureDescription(celsius, fahrenheit);
                    textBox2.Text = celsius.ToString();
                    textOut.Write($"{textBox1.Text} F = {textBox2.Text}C {currentDate} {Message}" + "\n");
                    textBox3.Text = Message;
                }
                else
                {
                    // Invalid input for Fahrenheit
                    MessageBox.Show("Invalid Input");
                }

            }

            textOut.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"./TempConversions.txt", FileMode.Open, FileAccess.Read);
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
            if (MessageBox.Show("You want to Exit?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "C";
            label3.Text = "F";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label4.Text = "F";
            label3.Text = "C";
        }
    }
}

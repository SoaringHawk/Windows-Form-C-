//Christian Denis Marcelin 
//7/10/2023
//V1.0.0
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
    public partial class frm649 : Form
    {
        public frm649()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static List<int> GenerateUniqueNumbers(int count, int min, int max)
        {
            List<int> numbers = new List<int>();
            Random random = new Random();

            while (numbers.Count < count)
            {
                int randomNumber = random.Next(min, max + 1);

                if (!numbers.Contains(randomNumber))
                {
                    numbers.Add(randomNumber);
                }
            }

            return numbers;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<int> numbers = GenerateUniqueNumbers(7, 1, 49);
            String stringNumbers = String.Join("\t", numbers);
            textBox1.Text = stringNumbers;

            FileStream fs = new FileStream(@"./LottoNbrs.txt", FileMode.Append, FileAccess.Write);
            // create the output stream for a text file that exists
            StreamWriter textOut = new StreamWriter(fs);
            // write the fields into text file
            DateTime currentDate = DateTime.Now.Date;
            textOut.Write($"649 {currentDate} {textBox1.Text.Replace('\t', ',')} Extra 11"+"\n");
            //textOut.WriteLine(textBox1.Text);
            // close the output stream for the text file
            textOut.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"./LottoNbrs.txt", FileMode.Open, FileAccess.Read);
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Exit?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                Application.Exit();
            }
        }
    }
}

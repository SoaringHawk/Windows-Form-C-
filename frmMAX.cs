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
    public partial class frmMAX : Form
    {
        public frmMAX()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("You want to Exit?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        static List<int> GenerateUniqueRandomNumbers(int count, int min, int max)
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

            List<int> numbers = GenerateUniqueRandomNumbers(8, 1, 50);
            String stringNumbers = String.Join("\t", numbers);
            
            textBox1.Text = stringNumbers;

            FileStream fs = new FileStream(@"./LottoNbrs.txt", FileMode.Append, FileAccess.Write);
            // create the output stream for a text file that exists
            StreamWriter textOut = new StreamWriter(fs);
            // write the fields into text file
            DateTime currentDate = DateTime.Now.Date;
            textOut.Write($"MAX {currentDate} {textBox1.Text.Replace('\t', ',')} Extra 30"+"\n");
            //textOut.WriteLine(textBox1.Text);
            // close the output stream for the text file
            textOut.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"./LottoNbrs.txt", FileMode.Open, FileAccess.Read);
            try
            {
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
    }
}

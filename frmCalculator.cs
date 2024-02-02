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
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += button1.Text;
            textBox2.Text += button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += button2.Text;
            textBox2.Text += button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += button3.Text;
            textBox2.Text += button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += button4.Text;
            textBox2.Text += button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += button5.Text;
            textBox2.Text += button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += button6.Text;
            textBox2.Text += button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += button7.Text;
            textBox2.Text += button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += button8.Text;
            textBox2.Text += button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += button9.Text;
            textBox2.Text += button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += button10.Text;
            textBox2.Text += button10.Text;
        }
        double num1 = 0;
        double num2 = 0;
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += button12.Text;
            num1 = Convert.ToDouble(textBox2.Text);
            textBox2.Text = "";
        }

        

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("+"))
            {
                textBox1.Text += button16.Text;
                num2 = Convert.ToDouble(textBox2.Text);
                textBox2.Text = (num1 + num2).ToString();
                textBox1.Text += (num1 + num2).ToString();
                button16.Enabled = false;
                FileStream fs = new FileStream(@"./calc.txt",
                                FileMode.Append, FileAccess.Write);
                StreamWriter objW = new StreamWriter(fs);
                objW.WriteLine(textBox1.Text);
                objW.Close();
                fs.Close();
            }
            else if(textBox1.Text.Contains("-"))
            {
                textBox1.Text += button16.Text;
                num2 = Convert.ToDouble(textBox2.Text);
                textBox2.Text = (num1 - num2).ToString();
                textBox1.Text += (num1 - num2).ToString();
                button16.Enabled = false;
                FileStream fs = new FileStream(@"./calc.txt",
                                FileMode.Append, FileAccess.Write);
                StreamWriter objW = new StreamWriter(fs);
                objW.WriteLine(textBox1.Text);
                objW.Close();
                fs.Close();
            }
            else if (textBox1.Text.Contains("*"))
            {
                textBox1.Text += button16.Text;
                num2 = Convert.ToDouble(textBox2.Text);
                textBox2.Text = (num1 * num2).ToString();
                textBox1.Text += (num1 * num2).ToString();
                button16.Enabled = false;
                FileStream fs = new FileStream(@"./calc.txt",
                                FileMode.Append, FileAccess.Write);
                StreamWriter objW = new StreamWriter(fs);
                objW.WriteLine(textBox1.Text);
                objW.Close();
                fs.Close();
            }
            else if (textBox1.Text.Contains("/"))
            {
                textBox1.Text += button16.Text;
                num2 = Convert.ToDouble(textBox2.Text);
                textBox2.Text = (num1 / num2).ToString();
                textBox1.Text += (num1 / num2).ToString();
                button16.Enabled = false;
                FileStream fs = new FileStream(@"./calc.txt",
                                FileMode.Append, FileAccess.Write);
                StreamWriter objW = new StreamWriter(fs);
                objW.WriteLine(textBox1.Text);
                objW.Close();
                fs.Close();
            }
            
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            num1 = 0;
            num2 = 0;
            button16.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += button13.Text;
            num1 = Convert.ToDouble(textBox2.Text);
            textBox2.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += button14.Text;
            num1 = Convert.ToDouble(textBox2.Text);
            textBox2.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text += button15.Text;
            num1 = Convert.ToDouble(textBox2.Text);
            textBox2.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Exit?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                this.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += button11.Text;
            textBox2.Text += button11.Text;
        }
    }
}

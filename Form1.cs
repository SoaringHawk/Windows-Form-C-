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

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            frmMAX obj = new frmMAX();
            //obj.Show();
            obj.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm649 obj = new frm649();
            //obj.Show();
            obj.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string dir = @"C:\Test\";
            //you can use relative path .\ => where the .exe is
            //or ..\ => one folder up where the .exe is.
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmConvert obj = new frmConvert();
            //obj.Show();
            obj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to Exit?", "Exit", MessageBoxButtons.YesNo).ToString() == "Yes")
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmConvertTemp obj = new frmConvertTemp();
            //obj.Show();
            obj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmCalculator obj = new frmCalculator();
            //obj.Show();
            obj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IP_Validator obj = new IP_Validator();
            //obj.Show();
            obj.ShowDialog();
        }
    }
}

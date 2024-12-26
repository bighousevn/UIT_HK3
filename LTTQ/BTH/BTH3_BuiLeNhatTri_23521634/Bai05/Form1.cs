using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool isValidNumber()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Không được để trống");
                return false;
            }

            if (!double.TryParse(textBox1.Text, out double number1) || !double.TryParse(textBox2.Text, out double number2))
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ, hãy nhập lại");
                return false;
            }


            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isValidNumber();
            textBox3.Text = (float.Parse(textBox1.Text) + float.Parse(textBox2.Text)).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isValidNumber();
            textBox3.Text = (float.Parse(textBox1.Text) - float.Parse(textBox2.Text)).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isValidNumber();
            textBox3.Text = (float.Parse(textBox1.Text) * float.Parse(textBox2.Text)).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isValidNumber();
            textBox3.Text = (float.Parse(textBox1.Text) / float.Parse(textBox2.Text)).ToString();
        }
    }
}

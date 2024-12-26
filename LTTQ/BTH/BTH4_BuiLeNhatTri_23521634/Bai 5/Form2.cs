using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai_5
{
    public partial class Form2 : Form
    {
        public class student
        {
            public string Ten;
            public string MSSV;
            public string Khoa;
            public double Diem;

            public student(string ten, string mSSV, string khoa, double diem)
            {
                Ten = ten;
                MSSV = mSSV;
                Khoa = khoa;
                Diem = diem;
            }
        }
        public student newStudent;
        public Form2()
        {
            InitializeComponent();
        }

        bool isValidInfo()
        {
            bool isValid = true;

            if (textBox2.Text == "" || textBox1.Text == "" || textBox4.Text == "")
                isValid = false;

            foreach (char c in textBox1.Text)
                if ((int)c < (int)'0' || (int)c > (int)'9')
                {
                    isValid = false;
                    textBox1.Text = "";
                }

            foreach (char c in textBox2.Text)
                if ((int)c >= (int)'0' && (int)c <= (int)'9')
                {
                    isValid = false;
                    textBox2.Text = "";
                }

            double temp;
            if (!double.TryParse(textBox4.Text, out temp))
            {
                textBox4.Text = "";
                isValid = false;
            }
            else if (temp > 10 || temp < 0)
            {
                textBox4.Text = "";
                isValid = false;
            }

            return isValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isValidInfo())
            {
                newStudent = new student(this.textBox1.Text, this.textBox2.Text, this.comboBox1.Text, double.Parse(this.textBox4.Text));
                this.Close();
            }
            else MessageBox.Show("Vui long dien day du thong tin");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" && this.textBox2.Text == "" && this.textBox4.Text == "")
                this.Close();
            else
            {
                DialogResult dr = MessageBox.Show("Ban co chac muon thoat ra?", "", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        long sum = 0;
        long sum2 = 0;
        private void button_Click(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            if (button.BackColor == Color.White)
            { button.BackColor = Color.Blue; }
            else if (button.BackColor == Color.Blue)
                button.BackColor = Color.White;
            else
                MessageBox.Show("Vui long chon cho khac");
        }

        private void choose_Click(object sender, EventArgs e)
        {
            foreach(Control btn in this.Controls)
                if(btn.GetType() == button1.GetType())
                    if(btn.BackColor == Color.Blue)
                    {
                        btn.BackColor = Color.Yellow;
                        if (int.Parse(btn.Text) >= 1 && int.Parse(btn.Text) <= 5)
                            sum += 5000;
                        else if (int.Parse(btn.Text) >= 6 && int.Parse(btn.Text) <= 10)
                            sum += 6500;
                        else sum += 8000;
                    }
            total.Text = sum.ToString();
            sum2 += sum;
            sum = 0;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (Control btn in this.Controls)
                if (btn.GetType() == button1.GetType())
                    if (btn.BackColor == Color.Blue)
                    {
                        btn.BackColor = Color.White;
                    }
            total.Text = "0";
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tong tien phai bo ra de mua ve: " + sum2 +"VND");
            foreach (Control btn in this.Controls)
                if (btn.GetType() == button1.GetType())
                    if (btn.BackColor == Color.Yellow || btn.BackColor == Color.Blue)
                        btn.BackColor = Color.White;
        }
    }
}

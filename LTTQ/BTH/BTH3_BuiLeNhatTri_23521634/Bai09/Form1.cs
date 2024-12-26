using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isValid()
        {
            bool isValidd = true;
            
            if(mssv.Text==""||name.Text==""||CN.Text=="")
            return false;
            foreach (Char c in mssv.Text)
                if ((int)c < (int)'0' || (int)c > (int)'9')
                {
                    mssv.Text = "";
                    isValidd = false;
                }

            foreach (Char c in name.Text)
                if((int)c >= (int)'0' && (int) c <= (int)'9')
                {
                    name.Text = "";
                    isValidd = false;
                }

            if(checkBox1.Checked== checkBox2.Checked)
            {
                checkBox1.Checked = checkBox2.Checked = false;
                isValidd = false;
            }

            if(listBox2.Items.Count <= 0) 
            {
                isValidd = false;
            }

            return isValidd;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string gender = checkBox1.Checked ? checkBox1.Text : checkBox2.Text;
                
                foreach(DataGridViewRow row in dataGridView1.Rows)
                    if (row.Cells[0].Value!=null)
                        if (mssv.Text == row.Cells[0].Value.ToString())
                        {
                            row.Cells[1].Value = name.Text;
                            row.Cells[2].Value = CN.Text;
                            row.Cells[3].Value = gender;
                            row.Cells[4].Value = listBox2.Items.Count.ToString();
                            MessageBox.Show("Thay doi du lieu thanh cong");
                            return;
                        }
                    
                    dataGridView1.Rows.Add(mssv.Text, name.Text, CN.SelectedItem.ToString(), gender, listBox2.Items.Count.ToString());
            }
            else MessageBox.Show("Thong tin nhap vao sai, vui long nhap lai");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i=0; i < listBox2.SelectedItems.Count; i++)
            {
                listBox1.Items.Add(listBox2.SelectedItems[i]);
                listBox2.Items.Remove(listBox2.SelectedItems[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                listBox2.Items.Add(listBox1.SelectedItems[i]);
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
                MessageBox.Show("Chua chon dong");
            else for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    dataGridView1.Rows.RemoveAt(i);       
        }
    }
}

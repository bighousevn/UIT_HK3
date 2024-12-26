namespace Bai_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int count = 1;
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Form2 addStudent = new Form2();
            this.Hide();
            addStudent.ShowDialog();
            if (addStudent.newStudent != null)
                studentInfor.Rows.Add(count++.ToString(), addStudent.newStudent.Ten, addStudent.newStudent.MSSV, addStudent.newStudent.Khoa, addStudent.newStudent.Diem.ToString());
            this.Show();
        }


        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < studentInfor.RowCount-1; i++)
            {
                if (studentInfor.Rows[i].Cells[2].Value != null && studentInfor.Rows[i].Cells[2].Value.ToString().ToLower().Contains(toolStripTextBox1.Text.ToLower()))
                    studentInfor.Rows[i].Visible = true;
                else studentInfor.Rows[i].Visible = false;
            }
        }
    }
}

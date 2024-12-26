namespace Bai_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Tọa độ nhấp chuột là (" + e.X.ToString() + " ," + e.Y.ToString() + ")");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Phim vừa nhấn là: " + e.KeyChar.ToString() + " với mã ASCII là " + ((int)e.KeyChar).ToString() + " với mã phím là " + keycode);
        }

        string keycode;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keycode = e.KeyCode.ToString();
        }
    }
}

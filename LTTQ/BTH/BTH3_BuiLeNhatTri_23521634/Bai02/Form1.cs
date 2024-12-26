using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random rnd = new Random();
            Graphics g = e.Graphics;

            float x = rnd.Next(0, Form1.ActiveForm.Width);
            float y = rnd.Next(0, Form1.ActiveForm.Height);

            var font = new Font(new FontFamily("Arial"), rnd.Next(20, 60), FontStyle.Bold, GraphicsUnit.Pixel);
            var solidbrush = new SolidBrush(Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255)));
            g.DrawString("Paint Event", font, solidbrush, new PointF(x, y));
        }
    }
}

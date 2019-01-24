using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleGraphicAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            paint = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        Bitmap paint;
        Random random = new Random();

        private bool ValidCheck() //checking user input
        {
            TextBox[] checkColor = {r,g,b,a};
            TextBox[] checkPosition = { x1, x2, y1, y2 };
            int parsed;
            foreach (TextBox tb in checkColor)
            {
                if (!(int.TryParse(tb.Text, out parsed) && parsed < 256 && parsed >= 0)) return false;
            }
            foreach (TextBox tb in checkPosition)
            {
                if (!(int.TryParse(tb.Text, out parsed) && parsed < 500 && parsed >= 0)) return false;
            }

            return true;
        }


        void DrawLine(Line line) //line algorithm
        {
            float x = line.sx, y = line.sy;
            int dx = line.ex - line.sx;
            int dy = line.ey - line.sy;
            int steps = 0;
            if (Math.Abs(dx) > Math.Abs(dy)) steps = Math.Abs(dx);
            else steps = Math.Abs(dy);
            float inX = (float)dx / (float)steps;
            float inY = (float)dy / (float)steps;

            for(int i=0;i < steps;i++)
            {
                x = x + inX;
                y = y + inY;
                paint.SetPixel(Convert.ToInt32(x), Convert.ToInt32(y), line.color);

            }

            pictureBox1.Image = paint;
        }

        private void button1_Click(object sender, EventArgs e) //draw img
        {
            if (ValidCheck()) DrawLine(new Line(Convert.ToInt32(x1.Text), Convert.ToInt32(y1.Text), Convert.ToInt32(x2.Text), Convert.ToInt32(y2.Text), Color.FromArgb(Convert.ToInt32(a.Text), Convert.ToInt32(r.Text), Convert.ToInt32(g.Text), Convert.ToInt32(b.Text))));
        }

        private void button3_Click(object sender, EventArgs e) //clear img
        {
            paint = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = paint;
        }

        private void button4_Click(object sender, EventArgs e) //save img
        {
            paint.Save(AppDomain.CurrentDomain.BaseDirectory + "\\image.png");
        }

        private void button5_Click(object sender, EventArgs e) //put random val
        {
            x1.Text = random.Next(500) + "";
            x2.Text = random.Next(500) + "";
            y1.Text = random.Next(500) + "";
            y2.Text = random.Next(500) + "";
            r.Text = random.Next(256) + "";
            g.Text = random.Next(256) + "";
            b.Text = random.Next(256) + "";
            a.Text = "255";
        }

        private void button2_Click(object sender, EventArgs e) // draw random lines
        {
            int nol;
            if(int.TryParse(numberOfLines.Text, out nol))
            {
                for (int i = 0; i < nol; i++) DrawLine(new Line(random.Next(500), random.Next(500), random.Next(500), random.Next(500), Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256))));
            }
        }
    }
}

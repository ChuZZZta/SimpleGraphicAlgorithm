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
        private void button1_Click(object sender, EventArgs e)
        {
            //paint.SetPixel(Convert.ToInt32(x1.Text), Convert.ToInt32(y1.Text), Color.Black);
            
            BLine(Convert.ToInt32(x1.Text), Convert.ToInt32(y1.Text), Convert.ToInt32(x2.Text), Convert.ToInt32(y2.Text));
            pictureBox1.Image = paint;
        }


        void BLine(int x0, int y0, int xk, int yk)
        {
            for (double t = 0.0; t < 1.0; t += 0.01)
            {
                int x = (int)(x0 * (1.0 - t) + xk * t);
                int y = (int)(y0 * (1.0 - t) + yk * t);
                paint.SetPixel(x, y, Color.Black);
            }
            
            
        }

    }
}

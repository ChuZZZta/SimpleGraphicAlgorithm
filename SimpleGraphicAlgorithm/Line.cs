using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraphicAlgorithm
{
    class Line
    {
        public Line(int a, int b, int c, int d, Color color)
        {
            sx = a;
            sy = b;
            ex = c;
            ey = d;
            this.color = color;
        }
        public int sx { get; set; }
        public int sy { get; set; }
        public int ex { get; set; }
        public int ey { get; set; }
        public Color color { get; set; }
    }
}

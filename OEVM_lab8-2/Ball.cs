using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OEVM_lab8_2
{
    class Ball
    {
        public int Vx { get; set; }
        public int Vy { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Ball(int vx, int vy, int x, int y)
        {
            Vx = vx;
            Vy = vy;
            X = x;
            Y = y;
        }
        public void Move()
        {
            X += Vx;
            Y += Vy;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Blue);
            g.FillEllipse(brush, X - 10, Y - 10, 20, 20);
        }
    }
}

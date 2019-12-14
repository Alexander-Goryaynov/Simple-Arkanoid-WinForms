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
        public int vx = -3;
        public int vy = -2;
        public int x = 300;
        public int y = 100;
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Blue);
            g.FillEllipse(brush, x - 10, y - 10, 20, 20);
        }
    }
}

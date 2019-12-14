using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEVM_lab8_2
{
    class Platform
    {
        public int x = 300;
        public int y = 500;
        public int platformWidth = 100;
        public int platformHeight = 10;
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, x, y, platformWidth, platformHeight);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OEVM_lab8_2
{
    class StartIcon
    {
        public void DrawStart(Graphics g, int width, int height)
        {
            Brush black = new SolidBrush(Color.Red);
            string str = "НАЧАТЬ ИГРУ";
            SolidBrush brText = new SolidBrush(Color.Black);
            Font roman = new Font("Times New Roman", 26, FontStyle.Bold);
            g.DrawString(str, roman, brText, 150, 300);
        }
    }
}

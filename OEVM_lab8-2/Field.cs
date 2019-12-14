using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEVM_lab8_2
{
    class Field
    {
        public const int amount = 13;
        public int blockSize = 40;
        public bool[] isAlive = new bool[amount];
        public Field()
        {            
            for (int i = 0; i < isAlive.Length; i++)
            {
                isAlive[i] = true;
            }
        }
        public bool CheckAnyAlive()
        {
            for (int i = 0; i < isAlive.Length; i++)
            {
                if (isAlive[i] == true) return true;
            }
            return false;
        }
        public void Draw(Graphics g, int width, int height)
        {
            Brush brush = new SolidBrush(Color.Red);
            int k = 10;
            for (int i = 0; i < isAlive.Length; i++)
            {
                if (isAlive[i]) {
                    g.FillRectangle(brush, k, 10, blockSize, blockSize); 
                }
                k += blockSize + 5;
            }
        }
    }
}

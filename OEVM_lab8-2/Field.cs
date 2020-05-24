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
        const int amount = 13;
        public int BlockSize { get; set; }
        public bool[] IsAlive { get; set; }
        public Field(int blockSize)
        {
            BlockSize = blockSize;
            IsAlive = new bool[amount];
            for (int i = 0; i < IsAlive.Length; i++)
            {
                IsAlive[i] = true;
            }
        }
        public bool CheckAnyAlive()
        {
            for (int i = 0; i < IsAlive.Length; i++)
            {
                if (IsAlive[i] == true) 
                    return true;
            }
            return false;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            int curX = 10;
            for (int i = 0; i < IsAlive.Length; i++)
            {
                if (IsAlive[i]) {
                    g.FillRectangle(brush, curX, 10, BlockSize, BlockSize); 
                }
                curX += BlockSize + 5;
            }
        }
    }
}

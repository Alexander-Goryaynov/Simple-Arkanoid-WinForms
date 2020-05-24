using System.Drawing;

namespace OEVM_lab8_2
{
    class Platform
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Platform(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public void Move(Direction dir)
        {
            switch(dir)
            {
                case Direction.Left:
                    X -= 40;
                    break;
                case Direction.Right:                    
                    X += 40;
                    break;
                default:
                    break;
            }
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillRectangle(brush, X, Y, Width, Height);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OEVM_lab8_2
{
    public partial class FormGame : Form
    {
        Timer timer;
        Field field;
        Ball ball;
        Platform platform;
        bool isStartIconActive;
        public FormGame()
        {
            InitializeComponent();
            timer = new Timer();
            field = new Field(40);
            ball = new Ball(-4, -3, 300, 100);
            platform = new Platform(300, 500, 100, 10);
            isStartIconActive = false;
        }
        void FormGame_Load(object sender, EventArgs e)
        {
            DrawStart();
            textBoxCount.Text = "";
        }
        void DrawStart()
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            DrawStartIcon(gr);
            pictureBox.Image = bmp;
        }
        void DrawField()
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            field.Draw(gr);
            ball.Draw(gr);
            platform.Draw(gr);
            pictureBox.Image = bmp;
        }
        void DrawStartIcon(Graphics g)
        {
            string text = "НАЖМИТЕ ЧТОБЫ\n    НАЧАТЬ ИГРУ";
            SolidBrush brush = new SolidBrush(Color.Black);
            Font roman = new Font("Times New Roman", 26, FontStyle.Bold);
            g.DrawString(text, roman, brush, 120, 250);
        }

        void PictureBox_Click(object sender, EventArgs e)
        {
            if (isStartIconActive) 
                return;
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1;
            DrawField();
            timer.Start();
            isStartIconActive = true;
        }
        void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            ball.Move();
            CheckIfWall();
            CheckFall();
            CheckPlatform();
            CheckBlock();
            UpdateCount();
            CheckWin();
            DrawField();
        }
        void CheckIfWall()
        {
            if ((ball.X > 585) || (ball.X <= 10)) 
                ball.Vx = - ball.Vx;
            if (ball.Y <= 0) 
                ball.Vy = - ball.Vy;
        }
        void CheckFall()
        {
            if (ball.Y >= 555)
            {
                timer.Stop();
                MessageBox.Show("Игра окончена", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Threading.Thread.Sleep(750);
                Application.Exit();
            }
        }
        void CheckWin()
        {
            if(!field.CheckAnyAlive())
            {
                timer.Stop();
                MessageBox.Show("Победа", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.Thread.Sleep(1000);
                Application.Exit();
            }
        }
        void CheckPlatform()
        {
            if((ball.X <= platform.X + platform.Width) &&
                    (ball.X >= platform.X) && (ball.Y >= platform.Y) &&
                    (ball.Y <= platform.Y + platform.Height))
            {
                ball.Vy *= -1;
            }
        }
        void CheckBlock()
        {
            int curX = 30;
            int curY = 30;
            for (int i = 0; i < field.IsAlive.Length; i++)
            {
                if (field.IsAlive[i])
                {
                    if ((Math.Abs(ball.X - curX) <= 15) && (Math.Abs(ball.Y - curY) <= 15))
                    {
                        Random rand = new Random();
                        int flag = rand.Next(0, 1);
                        field.IsAlive[i] = false;
                        if (flag == 1)
                        {
                            ball.Vx = - ball.Vx;
                        } 
                        else
                        {
                            ball.Vy = - ball.Vy;
                        }                     
                    }                    
                }
                curX += field.BlockSize + 5;
            }
        }
        void UpdateCount()
        {
            int count = 0;
            for (int i = 0; i < field.IsAlive.Length; i++)
            {
                if (field.IsAlive[i]) 
                    count++;
            }
            textBoxCount.Text = "Осталось: " + count;
        }
        void TextBoxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    platform.Move(Direction.Left);
                    break;
                case 'd':
                    platform.Move(Direction.Right);
                    break;
                case 'ф':
                    platform.Move(Direction.Left);
                    break;
                case 'в':
                    platform.Move(Direction.Right);
                    break;
                default:
                    break;
            }
        }
    }
}

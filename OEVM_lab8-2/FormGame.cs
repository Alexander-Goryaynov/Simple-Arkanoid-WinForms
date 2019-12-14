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
        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        StartIcon startIcon;
        Field field;
        Ball ball;
        Platform platform;
        bool flag = false; //for pictureBox_click
        public FormGame()
        {
            InitializeComponent();
            startIcon = new StartIcon();
            field = new Field();
            ball = new Ball();
            platform = new Platform();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DrawStart();
            textBoxCount.Text = "";
        }
        private void DrawStart()
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            startIcon.DrawStart(gr, pictureBox.Width, pictureBox.Height);
            pictureBox.Image = bmp;
        }
        private void DrawField()
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics gr = Graphics.FromImage(bmp);
            field.Draw(gr, pictureBox.Width, pictureBox.Height);
            ball.Draw(gr);
            platform.Draw(gr);
            pictureBox.Image = bmp;
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (flag) return;
            myTimer.Tick += new EventHandler(TimerEventProcessor);
            myTimer.Interval = 5;
            DrawField();
            myTimer.Start();
            flag = true;
        }
        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            ball.x += ball.vx;
            ball.y += ball.vy;
            CheckIfWall();
            CheckFall();
            CheckPlatform();
            CheckBlock();
            UpdateCount();
            CheckWin();
            DrawField();
        }
        private void CheckIfWall()
        {
            if ((ball.x > 585)||(ball.x <= 10)) ball.vx = -ball.vx;
            if (ball.y <= 0) ball.vy = -ball.vy;
        }
        private void CheckFall()
        {
            if (ball.y >= 555)
            {
                myTimer.Stop();
                MessageBox.Show("Игра окончена", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Threading.Thread.Sleep(750);
                Application.Exit();
            }
        }
        private void CheckWin()
        {
            if(!field.CheckAnyAlive())
            {
                myTimer.Stop();
                MessageBox.Show("Победа", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Threading.Thread.Sleep(1000);
                Application.Exit();
            }
        }
        private void CheckPlatform()
        {
            if((ball.y == platform.y)
                && (ball.x <= platform.x + platform.platformWidth)
                &&(ball.x >= platform.x))
            {
                ball.vy = -ball.vy;
            }
        }
        private void CheckBlock()
        {
            int curX = 30;
            int curY = 30;
            for (int i = 0; i < field.isAlive.Length; i++)
            {
                if (field.isAlive[i])
                {
                    if ((Math.Abs(ball.x - curX) <= 15) && (Math.Abs(ball.y - curY) <= 15))
                    {
                        Random rand = new Random();
                        int flag = rand.Next(0, 1);
                        field.isAlive[i] = false;
                        if (flag == 1)
                        {
                            ball.vx = -ball.vx;
                        } else
                        {
                            ball.vy = -ball.vy;
                        }                     
                    }                    
                }
                curX += field.blockSize + 5;
            }
        }
        private void UpdateCount()
        {
            int count = 0;
            for (int i = 0; i < field.isAlive.Length; i++)
            {
                if (field.isAlive[i]) count++;
            }
            textBoxCount.Text = "Осталось: " + count;
        }

        private void textBoxCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':
                    platform.x -= 40;
                    break;
                case 'd':
                    platform.x += 40;
                    break;
                default:
                    break;
            }
        }
    }
}

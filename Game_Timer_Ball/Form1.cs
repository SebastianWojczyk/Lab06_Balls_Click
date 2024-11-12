using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Timer_Ball
{
    public partial class Form1 : Form
    {
        Graphics graph;
        Random generator = new Random();
        List<Ball> listBalls = new List<Ball>();
        public Form1()
        {
            InitializeComponent();

            pictureBoxGame.Image = new Bitmap(pictureBoxGame.Width, pictureBoxGame.Height);
            graph = Graphics.FromImage(pictureBoxGame.Image);

            createNewBall();
            createNewBall();
            createNewBall();
            createNewBall();
            createNewBall();

            RedrawGame();
        }

        private void RedrawGame()
        {
            graph.Clear(Color.White);
            foreach (Ball b in listBalls)
            {
                b.DrawAndFill(graph);
            }
            pictureBoxGame.Refresh();
        }

        private void createNewBall()
        {
            int radius = generator.Next(20, 50);
            Point center = new Point(generator.Next(radius, pictureBoxGame.Width - radius),
                                     -radius);
            Color color = Color.FromArgb(generator.Next(256), generator.Next(256), generator.Next(256));

            listBalls.Add(new Ball(center, radius, color));
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Ball b in listBalls)
            {
                if (!b.Move(pictureBoxGame.Height))
                {
                    timer.Stop();
                    MessageBox.Show("KONIEC");
                    Close();
                }
            }
            RedrawGame();
        }

        private void PictureBoxGame_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Ball b in listBalls)
                {
                    if (b.Contains(e.Location))
                    {
                        listBalls.Remove(b);
                        createNewBall();

                        timer.Interval -= 1;
                        break;
                    }
                }
                RedrawGame();
            }
        }
    }
}

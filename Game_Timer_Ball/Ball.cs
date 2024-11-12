using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Timer_Ball
{
    class Ball
    {
        private Point center;
        private int radius;
        private Color color;

        public Ball(Point center, int radius, Color color)
        {
            this.center = center;
            this.radius = radius;
            this.color = color;
        }

        public void DrawAndFill(Graphics graph)
        {
            graph.FillEllipse(new SolidBrush(color),
                              center.X - radius,
                              center.Y - radius,
                              radius * 2,
                              radius * 2);
            graph.DrawEllipse(new Pen(Color.Black, 2),
                              center.X - radius,
                              center.Y - radius,
                              radius * 2,
                              radius * 2);
        }

        public bool Move(int maxY)
        {
            if (center.Y + radius < maxY)
            {
                center.Y += radius / 10;
                return true;
            }
            return false;
        }
        public bool Contains(Point mouseLocation)
        {
            if (Math.Sqrt(Math.Pow(center.X - mouseLocation.X, 2) +
                          Math.Pow(center.Y - mouseLocation.Y, 2)) < radius)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Controls;

namespace DasRennen
{
    internal class Driver

    {
        Point location;
        Rectangle borders;
        double orientation;
        private const int CarWidth = 40;
        private const int CarHeight = 20;
        Parameters.Direction throttle = Parameters.Direction.stop;
        public Point Location { get => location; set => location = value; }
        public double Orientation { get => orientation; set => orientation = value; }
        public Parameters.Direction Throttle { get => throttle; set => throttle = value; }
        public Driver(int x, int y, double orientation, Rectangle borders)
        {
            this.location.X = x;
            this.location.Y = y;
            this.orientation = orientation;
            this.borders = borders;
        }








        public void Drive()
        {
            int speed = Parameters.Speed;
            double radians = orientation * (Math.PI / 180); // degrees to radians

            switch (throttle)
            {
                case Parameters.Direction.right:
                case Parameters.Direction.left:
                    // for Calculate potential new position
                    double deltaX = Math.Cos(radians) * speed;
                    double deltaY = Math.Sin(radians) * speed;

                    // New potential X and Y positions
                    double newX = location.X + deltaX;
                    double newY = location.Y + deltaY;

                    if (newX >= borders.Left && newX + CarWidth <= borders.Right &&
                        newY >= borders.Top && newY + CarHeight <= borders.Bottom)
                    {
                        location = new Point((int)newX, (int)newY); 
                    }
                    break;
                default: break;
            }
        }









        public void Steer() { }
    }
}
    


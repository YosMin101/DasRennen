using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DasRennen
{
    internal class Race
   {
        Car greenCar, redCar;
        public Point greenLocation { get => greenCar.Location; set => greenCar.Location = value; }
        public double greenOrientation { get => greenCar.Orientation; set => greenCar.Orientation = value; }
        public Parameters.Direction greenThrottle { get => greenCar.Throttle; set => greenCar.Throttle = value; }
        public Point redLocation { get => redCar.Location; set => redCar.Location = value; }
        public double redOrientation { get => redCar.Orientation; set => redCar.Orientation = value; }
        public Parameters.Direction redThrottle { get => redCar.Throttle; set => redCar.Throttle = value; }
        public Race(int x, int y, double orientation, Rectangle borders)
        {
            greenCar = new Car(x, y, orientation, borders);
            redCar = new Car(x + 70, y, orientation, borders);
        }
        public void Drive(String carColor)
        {
            if (carColor == "green")
                greenCar.Drive();
            else if (carColor == "red")
                redCar.Drive();
        }
        public void Steer(String carColor)
        {
            if (carColor == "green") 
            {
                greenCar.Steer();
            }
            else if (carColor == "red")
                redCar.Steer();
        }
    }
}

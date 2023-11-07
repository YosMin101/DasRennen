using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DasRennen
{
    internal class Parameters
    {
        public enum Direction
        {
            stop = 0,
            left = 1,
            right = 2,
            up = 3,
            down = 4,
        }

        private static int _speed = 3; // Default speed

        public static int Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }
    }
}
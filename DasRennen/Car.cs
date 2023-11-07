using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DasRennen {
    internal class Car : Driver{
        public Car(int x, int y, double orientation, Rectangle borders) :
            base(x, y, orientation, borders) { }    
    }
}

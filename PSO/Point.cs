using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    class Point
    {
        double x;
        double y;
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        public void SetX(double newx)
        {
            x = newx;
        }
        public void SetY(double newy)
        {
            y = newy;
        }
    }
}

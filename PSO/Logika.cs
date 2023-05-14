using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    class Logika
    {
        public double Losuj(double zakres)
        {
            Random rand = new Random();
            double losowa;
            int losowyznak;
            losowa = rand.NextDouble();
            losowyznak = rand.Next(0, 2);
            if (losowyznak == 0)
            {
                losowa = losowa * zakres;
            }
            else if (losowyznak == 1)
            {
                losowa = losowa * -zakres;
            }
            return losowa;
        }
        public double RownanieA(double x, double y)
        {
            //funkcja bez nazwy - -1
            return Math.Sin(x) * Math.Cos(y);
        }
        public double RownanieB(double x, double y)
        {
            //funkcja ackleya 2 - -200
            return -200 * Math.Exp(-0.2 * Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)));
        }
        public double RownanieC(double x, double y)
        {
            //funkcja bartelsa - 1
            return Math.Abs(Math.Pow(x, 2) + Math.Pow(y, 2) + (x * y)) + Math.Abs(Math.Sin(x)) + Math.Abs(Math.Cos(y));
        }
        public double RownanieD(double x, double y)
        {
            //funkcja easom - -1
            return -Math.Cos(x) * Math.Cos(y) * Math.Exp(-Math.Pow(x - Math.PI, 2) - Math.Pow(y - Math.PI, 2));
        }
        public double ObliczDoRownania(double x, double y, int wybrany)
        {
            switch(wybrany)
            {
                case 0:
                    return RownanieA(x, y);
                case 1:
                    return RownanieB(x, y);
                case 2:
                    return RownanieC(x, y);
                case 3:
                    return RownanieD(x, y);
                default:
                    return RownanieA(x, y);
            }
        }
    }
}

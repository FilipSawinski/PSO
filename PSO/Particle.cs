using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO
{
    class Particle
    {
        //prędkość
        Point v = new Point();
        //pozycja cząsteczki
        Point position = new Point();
        //najlepsze lokalne rozwiązanie
        Point bestlocal = new Point();
        //wartość najlepszego lokalnego rozwiązania
        double bestlocalsolution;
        //logika
        Logika logika = new Logika();

        public Particle(double x, double y)
        {
            position.SetX(x);
            position.SetY(y);
            v.SetX(logika.Losuj(2));
            System.Threading.Thread.Sleep(10);
            v.SetY(logika.Losuj(2));
            bestlocal.SetX(position.GetX());
            bestlocal.SetY(position.GetY());
            bestlocalsolution = logika.RownanieA(GetPosX(), GetPosY());
        }

        public double GetPosX()
        {
            return position.GetX();
        }
        public double GetPosY()
        {
            return position.GetY();
        }
        public void SetV(Point newv)
        {
            v = newv;
        }
        public void Move()
        {
            position.SetX(position.GetX() + v.GetX());
            position.SetY(position.GetY() + v.GetY());
            double possiblebestlocal = logika.RownanieA(position.GetX(), position.GetY());
            if (possiblebestlocal < bestlocalsolution)
            {
                bestlocalsolution = possiblebestlocal;
                bestlocal = position;
            }
        }
        public void CalculateNewV(Point bestglobal, double w1, double w2, double w3)
        {
            Random r = new Random();
            double ran1 = r.NextDouble();
            System.Threading.Thread.Sleep(5);
            double ran2 = r.NextDouble();
            v.SetX((w1 * v.GetX()) + (w2 * ran1 * (bestlocal.GetX() - position.GetX())) + w3 * ran2 * (bestglobal.GetX() - position.GetX()));
            v.SetY((w1 * v.GetY()) + (w2 * ran1 * (bestlocal.GetY() - position.GetY())) + w3 * ran2 * (bestglobal.GetY() - position.GetY()));
        }
    }
}

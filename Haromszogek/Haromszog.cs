using System;
using System.Collections.Generic;

namespace Haromszogek
{
    internal class Haromszog
    {
        private double aOldal;
        private double bOldal;
        private double cOldal;

        public double terulet { get; private set; }
        public double kerulet { get; private set; }

        public bool szerkesztheto { get; private set; }

        private void Szerk()
        {
            if ((aOldal + bOldal) > cOldal && 
                (bOldal + cOldal) > aOldal && 
                (aOldal + cOldal) > bOldal)
            {
                szerkesztheto = true;
                terulet = teruletSzamitas();
                kerulet = keruletSzamitas();
            }
            else
            {
                szerkesztheto = false;
                terulet = 0;
                kerulet = 0;
            }
        }

        private double teruletSzamitas()
        {
            double s = (aOldal + bOldal + cOldal) / 2;
            return Math.Sqrt(s * (s - aOldal) * (s - bOldal) * (s - cOldal)); 
        }

        private double keruletSzamitas()
        {
            return aOldal + bOldal + cOldal;
        }

        public Haromszog(string sor)
        {
            string[] adatok = sor.Split(';');
            aOldal = double.Parse(adatok[0]);
            bOldal = double.Parse(adatok[1]);
            cOldal = double.Parse(adatok[2]);
            Szerk();
        }

        public Haromszog(double aOldal, double bOldal, double cOldal)
        {
            this.aOldal = aOldal;
            this.bOldal = bOldal;
            this.cOldal = cOldal;
            Szerk();
        }

        public List<string> AdatokSzoveg()
        {
            List<string> adatok = new List<string>();
            adatok.Add($"A:{aOldal} - B:{bOldal} - C:{cOldal}");
           
            if (szerkesztheto)
            {
                adatok.Add($"\nKerület: {kerulet:N2} - Terület: {terulet:N2}");
            }
            else
            {
                adatok.Add("Nem szerkeszthető.");
            }
            return adatok;
        }
    }
}
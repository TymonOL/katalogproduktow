using System;
using System.Collections.Generic;
using System.Text;

namespace katalogproduktow
{
    internal class Produkt
    {
        public string Nazwa { get; set; } = "";

        private double cena;
       
        public double Cena 
        {
            get { return cena; }
            set { cena = value < 0 ? 0 : value; }
}


public int Ilosc { get; set; }

        public string Kategoria { get; set; } = "";

        public override string ToString()
        {
            return $"{Nazwa} ({Kategoria}): {Cena:F2} zł, Ilość: {Ilosc}";
        }
    }
}



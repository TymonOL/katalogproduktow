using System.ComponentModel;

namespace katalogproduktow
{
    public class Produkt : INotifyPropertyChanged
    {
        public string Nazwa { get; set; } = "";

        private double cena;

        public double Cena
        {
            get { return cena; }
            set { cena = value < 0 ? 0 : value; Zmiana(nameof(Cena)); }
        }

        private int ilosc;

        public int Ilosc
        {
            get { return ilosc; }
            set
            {
                ilosc = value < 0 ? 0 : value;
                Zmiana(nameof(Ilosc));
            }
        }

        public string Kategoria { get; set; } = "";

        //public override string ToString()
        //{
        //    return $"{Nazwa} ({Kategoria}): {Cena:F2} zł, Ilość: {Ilosc}";
        //}
        public event PropertyChangedEventHandler? PropertyChanged;

        private void Zmiana(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}



using System;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;

namespace katalogproduktow
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Produkt> Produkty { get; set; } = new ObservableCollection<Produkt>();

        public MainWindow()
        {
            InitializeComponent();
            KategorieComboBox.ItemsSource = new string[] { "Elektronika", "Odzież", "Książki", "Meble" };
            KategorieComboBox.SelectedIndex = 0;
            Produkty.Add(new Produkt { Nazwa = "Laptop", Cena = 2500, Ilosc = 5, Kategoria = "Elektronika" });
            Produkty.Add(new Produkt { Nazwa = "Koszula", Cena = 120, Ilosc = 10, Kategoria = "Odzież" });
            //ListaProduktów.ItemsSource = produkty;
            DataContext = this;
        }


        private void Oblicz(object sender, RoutedEventArgs e)

        {
            // Pobranie danych z pól
            string nazwa = NazwaTextBox.Text;
            string kategoria = KategorieComboBox.Text;
            string cenaText = CenaTextBox.Text;
            string iloscText = IloscTextBox.Text;

            bool promocja = PromocjaCheckBox.IsChecked == true;

            // Sprawdzenie ceny
            if (!double.TryParse(cenaText, out double cena))
            {
                WynikTextBlock.Text = "Cena jest niepoprawna!";
                return;
            }

            // Sprawdzenie ilości
            if (!int.TryParse(iloscText, out int ilosc))
            {
                WynikTextBlock.Text = "Ilość jest niepoprawna!";
                return;
            }

            // Sprawdzenie wartości ujemnych
            if (cena < 0 || ilosc < 0)
            {
                WynikTextBlock.Text =
                    "Cena i ilość nie mogą być ujemne!";
                return;
            }

            // Obliczenie wartości zamówienia
            double wartoscZamowienia = cena * ilosc;

            // Naliczanie promocji 10%
            double rabat = 0;

            if (promocja)
            {
                rabat = wartoscZamowienia * 0.10;
                wartoscZamowienia -= rabat;
            }

            // Wyświetlenie wszystkich informacji
            WynikTextBlock.Text =
                $"Nazwa produktu: {nazwa}\n" +
                $"Kategoria: {kategoria}\n" +
                $"Cena: {cena:F2} zł\n" +
                $"Ilość: {ilosc}\n" +
                $"Promocja: {(promocja ? "Tak" : "Nie")}\n" +
                $"Rabat: {rabat:F2} zł\n" +
                $"Wartość zamówienia: {wartoscZamowienia:F2} zł";
        }

        private void DodajProdukt(object sender, RoutedEventArgs e)
        {
            string nazwa = NazwaTextBox.Text;
            double cena = double.Parse(CenaTextBox.Text);
            int ilosc = int.Parse(IloscTextBox.Text);
            string kategoria = KategorieComboBox.SelectedItem as string ?? "brak kategorii";

            Produkty.Add(new Produkt { Nazwa = nazwa, Cena = cena, Ilosc = ilosc, Kategoria = kategoria });
        }

        private void UsunProdukt(object sender, RoutedEventArgs e)
        {
            if (ListaProduktów.SelectedItem is Produkt wybranyProdukt)
            {
                Produkty.Remove(wybranyProdukt);
            }
            else
            {
                MessageBox.Show("Nie wybrano produktu do usunięcia.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
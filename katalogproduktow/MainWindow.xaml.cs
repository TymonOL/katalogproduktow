using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace katalogproduktow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Oblicz(object sender, RoutedEventArgs e)
        {
            // pobierz teskt z pola z cena i zmien go na liczbe 
            // pobierz teskt z pola z iloscia i zmien go na liczbe 
            //  jesli wartosci sa niepoprawne lub ujemne wypisz komunikat w pola wynik albo rzuc wyjatek 
            // oblicz wartosc zamowienia i wypisz ja w polu wynik 

            string cenaText = CenaTextBox.Text;

            if (!double.TryParse(cenaText, out double cena))
            {
                WynikTextBlock.Text = "Cena jest niepoprawna!";
                return;
            }

            string iloscText = IloscTextBox.Text;

            if (!int.TryParse(iloscText, out int ilosc))
            {
                WynikTextBlock.Text = "Ilość jest niepoprawna!";
                return;
            }

            if (cena < 0 || ilosc < 0)
            {
                WynikTextBlock.Text = "Cena i ilość nie mogą być ujemne!";
                return;
            }

            double wynik = cena * ilosc;

 
            WynikTextBlock.Text = $"Wartość zamówienia: {wynik:F2} zł";
        }
    }
}
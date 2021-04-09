using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sony4Room.Views
{
    /// <summary>
    /// Interaction logic for Soba2View.xaml
    /// </summary>
    public partial class Soba2View : UserControl
    {
        Dostupnost dost = new Dostupnost();
        SonyEntities se = new SonyEntities();

        public Soba2View()
        {
            InitializeComponent();
            if (se.Dostupnosts.Where(b => b.Naziv == "K7").FirstOrDefault().Slobodna == false)
            {
                K7.Background = Brushes.Red;
            }
            else
            {
                K7.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K8").FirstOrDefault().Slobodna == false)
            {
                K8.Background = Brushes.Red;
            }
            else
            {
                K8.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K9").FirstOrDefault().Slobodna == false)
            {
                K9.Background = Brushes.Red;
            }
            else
            {
                K9.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K10").FirstOrDefault().Slobodna == false)
            {
                K10.Background = Brushes.Red;
            }
            else
            {
                K10.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K11").FirstOrDefault().Slobodna == false)
            {
                K11.Background = Brushes.Red;
            }
            else
            {
                K11.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K12").FirstOrDefault().Slobodna == false)
            {
                K12.Background = Brushes.Red;
            }
            else
            {
                K12.Background = Brushes.LimeGreen;
            }
        }

        private void Konzola7_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K7";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola8_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K8";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola9_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K9";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola10_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K10";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola11_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K11";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola12_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K12";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }
    }
}

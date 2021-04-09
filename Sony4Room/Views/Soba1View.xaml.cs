using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Soba1View.xaml
    /// </summary>
    public partial class Soba1View : UserControl
    {
        //public bool boja = false;
        Dostupnost dost = new Dostupnost();
        SonyEntities se = new SonyEntities();
        public Soba1View()
        {
            InitializeComponent();
            if(se.Dostupnosts.Where(b => b.Naziv == "K1").FirstOrDefault(). Slobodna == false)
            {
                K1.Background = Brushes.Red;
            }
            else
            {
                K1.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K2").FirstOrDefault().Slobodna == false)
            {
                K2.Background = Brushes.Red;
            }
            else
            {
                K2.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K3").FirstOrDefault().Slobodna == false)
            {
                K3.Background = Brushes.Red;
            }
            else
            {
                K3.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K4").FirstOrDefault().Slobodna == false)
            {
                K4.Background = Brushes.Red;
            }
            else
            {
                K4.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K5").FirstOrDefault().Slobodna == false)
            {
                K5.Background = Brushes.Red;
            }
            else
            {
                K5.Background = Brushes.LimeGreen;
            }
            if (se.Dostupnosts.Where(b => b.Naziv == "K6").FirstOrDefault().Slobodna == false)
            {
                K6.Background = Brushes.Red;
            }
            else
            {
                K6.Background = Brushes.LimeGreen;
            }


        }
      
        public Soba1View(bool boja)
        {
            InitializeComponent();
            
        }

        private void Konzola1_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K1";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola2_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K2";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola3_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K3";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Konzola4_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K4";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Volan1_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K5";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }

        private void Volan2_Clicked(object sender, RoutedEventArgs e)
        {
            string brojKonzole = "K6";
            Racun ra = new Racun();
            var brojRacuna = ra.IdRacuna;
            RacunWindow rc = new RacunWindow(brojKonzole);
            rc.ShowDialog();
        }
    }
}

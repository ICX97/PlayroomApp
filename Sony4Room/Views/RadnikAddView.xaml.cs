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
    /// Interaction logic for RadnikAddView.xaml
    /// </summary>
    public partial class RadnikAddView : UserControl
    {
        SonyEntities db = new SonyEntities();

        public RadnikAddView()
        {
            InitializeComponent();
        }

        private void Sacuvaj_Clicked(object sender, RoutedEventArgs e)
        {
            Radnik newRadnik = new Radnik()
            {
                ImePrz = imeRadnika.Text,
                BrojTelefonaR = brojTelefonaRadnika.Text
            };
            db.Radniks.Add(newRadnik);
            db.SaveChanges();
            MessageBox.Show("Radnik uspesno dodat");
        }
    }
}

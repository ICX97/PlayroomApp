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
    /// Interaction logic for RadnikEditView.xaml
    /// </summary>
    public partial class RadnikEditView : UserControl
    {

        SonyEntities se = new SonyEntities();
        Radnik model = new Radnik();
        public List<Radnik> Ra { get; set; }
        public RadnikEditView()
        {
            InitializeComponent();
            bindCombo();
        }

        private void bindCombo()
        {
            //SonyEntities se = new SonyEntities();
            var item = se.Radniks.ToList();
            Ra = item;
            DataContext = Ra;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id = cmbSelection.SelectedItem as Radnik;
            var radnik = se.Radniks.Where(x => x.IdRadnika == id.IdRadnika).FirstOrDefault();
            txtIme.Text = radnik.ImePrz.ToString();
            txtTelefon.Text = radnik.BrojTelefonaR.ToString();
        }

        private void Izbrisi_Clicked(object sender, RoutedEventArgs e)
        {
            var id = cmbSelection.SelectedItem as Radnik;
            var radnik = se.Radniks.Where(x => x.IdRadnika == id.IdRadnika).FirstOrDefault();
            se.Radniks.Remove(radnik);
            se.SaveChanges();
            MessageBox.Show("Uspesno je izbrisan!!!");
        }

        private void Modifikuj_Clicked(object sender, RoutedEventArgs e)
        {
            var id = cmbSelection.SelectedItem as Radnik;
            var radnik = se.Radniks.Where(x => x.IdRadnika == id.IdRadnika).FirstOrDefault();
            radnik.ImePrz = txtIme.Text;
            radnik.BrojTelefonaR = txtTelefon.Text;
            se.SaveChanges();
            bindCombo();
            MessageBox.Show("Uspesno modifikovan !!!");
        }
    }
}

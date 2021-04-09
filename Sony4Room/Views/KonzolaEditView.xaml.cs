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
    /// Interaction logic for KonzolaEditView.xaml
    /// </summary>
    public partial class KonzolaEditView : UserControl
    {
        SonyEntities se = new SonyEntities();
        public List<Clan> Cl { get; set; }
        public KonzolaEditView()
        {
            InitializeComponent();
            cenaKonzole.Text=se.Konzolas.Where(a => a.IdKonzole == 2).FirstOrDefault().CenaPoSatu;
            cenaVolana.Text=se.Konzolas.Where(a => a.IdKonzole == 3).FirstOrDefault().CenaPoSatu;
            cenaAkcije.Text=se.Konzolas.Where(a => a.IdKonzole == 4).FirstOrDefault().CenaPoSatu ;
        }

        private void Sacuvaj_Clicked(object sender, RoutedEventArgs e)
        {
            se.Konzolas.Where(a => a.IdKonzole == 2).FirstOrDefault().CenaPoSatu = cenaKonzole.Text;
            se.Konzolas.Where(a => a.IdKonzole == 3).FirstOrDefault().CenaPoSatu = cenaVolana.Text;
            se.Konzolas.Where(a => a.IdKonzole == 4).FirstOrDefault().CenaPoSatu = cenaAkcije.Text;
            se.SaveChanges();
            MessageBox.Show("Uspesno modifikovana cena!");
        }
    }
}

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
    /// Interaction logic for ClanEditView.xaml
    /// </summary>
    public partial class ClanEditView : UserControl
    {
        SonyEntities se = new SonyEntities();
        Clan model = new Clan();
        public List<Clan> Cl { get; set; }
        public ClanEditView()
        {
            InitializeComponent();
            bindCombo();

        }

        private void bindCombo()
        {
            //SonyEntities se = new SonyEntities();
            var item = se.Clans.ToList();
            Cl = item;
            DataContext = Cl;
        }

        public void Clear()
        {
            txtIme.Text = "";
            txtDolasci.Text = "";
            txtTelefon.Text = "";
            txtSati.Text = "";
            txtNapomena.Text = "";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var id =cmbSelection.SelectedItem as Clan;
            
            if(cmbSelection.SelectedItem != null)
            {
                var clan= se.Clans.Where(x => x.IdClan == id.IdClan).FirstOrDefault();
                txtIme.Text = clan.Ime.ToString();
                txtDolasci.Text = clan.BrojDolaska.ToString();
                txtTelefon.Text = clan.BrojTelefona.ToString();
                txtSati.Text = clan.KumulativnoSati.ToString();
                txtNapomena.Text = clan.Napomena.ToString();
                bindCombo();
            }
            else
            {
                MessageBox.Show("Unesite drugog clana");
                Clear();
            }
        }

        private void Izbrisi_Clicked(object sender, RoutedEventArgs e)
        {
            var id = cmbSelection.SelectedItem as Clan;
            var clan = se.Clans.Where(x => x.IdClan == id.IdClan).FirstOrDefault();
            se.Clans.Remove(clan);
            se.SaveChanges();
            MessageBox.Show("Uspesno je izbrisan!!!");
            Clear();
        }

        private void Modifikuj_Clicked(object sender, RoutedEventArgs e)
        {
            var id = cmbSelection.SelectedItem as Clan;
            var clan = se.Clans.Where(x => x.IdClan == id.IdClan).FirstOrDefault();
            clan.Ime = txtIme.Text;
            clan.BrojDolaska = Convert.ToInt32(txtDolasci.Text);
            clan.BrojTelefona = txtTelefon.Text;
            clan.KumulativnoSati = txtSati.Text;
            clan.Napomena = txtNapomena.Text;
            se.SaveChanges();
            bindCombo();
            MessageBox.Show("Uspesno modifikovan !!!");
            Clear();
        }

        private void TxtIme_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
    }
}

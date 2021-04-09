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
    /// Interaction logic for ClanAddView.xaml
    /// </summary>
    public partial class ClanAddView : UserControl
    {

        //LinqToSqlDataContext dc = new LinqToSqlDataContext(Properties.Settings.Default.SonyConnectionString);
        SonyEntities db = new SonyEntities();
        public List<Clan> Cl { get; set; }
        public ClanAddView()
        {
            InitializeComponent();

        }

        private void Sacuvaj_Clicked(object sender, RoutedEventArgs e)
        {

            Clan newClan = new Clan()
            {
                Ime = imeClana.Text,
                BrojDolaska = 0,
                BrojTelefona = brojClana.Text,
                KumulativnoSati = "0",
                Napomena = napomena.Text
             };
            if (NameCheck() == true)
            {
                MessageBox.Show("Vec postoji "+imeClana.Text + "!" );
            }
            else
            {
                db.Clans.Add(newClan);
                db.SaveChanges();
                MessageBox.Show("Clan uspesno dodat");
            }
            imeClana.Text = "";
            brojClana.Text = "";
            napomena.Text = "";
        }

        public bool NameCheck()
        {
            var username = db.Clans.ToList();
            foreach (var name in username)
            {
                if (name.Ime.ToUpper() == imeClana.Text.ToUpper())
                    return true;
            }
            return false;
        }

        private void Napomena_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PrezimeClana_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

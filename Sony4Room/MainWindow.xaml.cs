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
using System.Data.SqlClient;
using Sony4Room.ViewModels;

namespace Sony4Room
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //LinqToSqlDataContext dc = new LinqToSqlDataContext(Properties.Settings.Default.SonyConnectionString);
        SonyEntities db = new SonyEntities();
        public static DataGrid datagrid;

        public MainWindow()
        {

            InitializeComponent();
            DataContext = new Soba1ViewModel();
        }

        
        private void Soba1_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Soba1ViewModel();
        }

        private void Soba2_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Soba2ViewModel();
        }

        private void Knjiga_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new KnjigaSankaViewModel();
        }

        private void AddClan_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ClanAddViewModel();
        }

        private void EditKonzola_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new KonzolaEditViewModel();
        }
        private void EditClan_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new ClanEditViewModel();
        }

        private void AddRadnik_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RadnikAddViewModel();
        }

        private void EditRadnik_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new RadnikEditViewModel();
        }
    }
}

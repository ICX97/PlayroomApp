using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Sony4Room.Views
{
    /// <summary>
    /// Interaction logic for ExportPodataka.xaml
    /// </summary>
    public partial class ExportPodataka : System.Windows.Window
    {
        SonyEntities se = new SonyEntities();
        ObservableCollection<Instanca> listaracuna = new ObservableCollection<Instanca>();

        public ExportPodataka()
        {
            InitializeComponent();
        }

        private void Exportuj_Clicked(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;

            Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            Worksheet ws = wb.Worksheets[1];
            DateTime currentDate = DateTime.Now;
            var theDate = piker.SelectedDate;
            var listaRacuna = se.Racuns.Where(a=>a.DatumR == theDate).ToList();
            //var listaRacuna = se.Racuns.Where(a=>a.DatumR == DateTime.Parse(theDate.ToString())).ToList();
            int counter = 2;

            ws.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;

            ws.Range["A1"].Value = "Datum i vreme pocetka";
            ws.Range["B1"].Value = "Radnik";
            ws.Range["C1"].Value = "Clan";
            ws.Range["D1"].Value = "Sati";
            ws.Range["E1"].Value = "Jojstika";
            ws.Range["F1"].Value = "Slusalice";
            ws.Range["G1"].Value = "Konzola";
            ws.Range["H1"].Value = "Naplaceno Pice";
            ws.Range["I1"].Value = "Naplaceno iznajmljivanje";
            ws.Range["J1"].Value = "Pice";
            ws.Range["K1"].Value = "Komada";
            foreach (var i in listaRacuna)
            {
                var racun = i.IdRacuna;
                var iznajmljivanje = i.IdIznajmljivanje;
                var listaIznajmljivanja = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == i.IdIznajmljivanje).ToList();

                foreach (var a in listaIznajmljivanja)
                {
                    ws.Range["A"+counter].Value = a.VremePocetka;
                    ws.Range["B" + counter].Value =se.Radniks.Where(b =>b.IdRadnika  == a.IdRadnika ).FirstOrDefault().ImePrz;
                    ws.Range["C" + counter].Value = se.Clans.Where(b=>b.IdClan == a.IdClan).FirstOrDefault().Ime;
                    ws.Range["D" + counter].Value = (DateTime.Parse(a.VremeZavrsavanja.ToString()) - DateTime.Parse(a.VremePocetka.ToString())).TotalHours;
                    ws.Range["E" + counter].Value = se.Joypeds.Where(b => b.IdJoypeda == a.IdJoypeda).FirstOrDefault().ImeJoypeda;
                    ws.Range["F" + counter].Value = se.Slusalice.Where(b => b.IdSlusalica == a.IdSlusalica).FirstOrDefault().NazivSlusalica;
                    ws.Range["G" + counter].Value = se.Konzolas.Where(b => b.IdKonzole == a.IdKonzole).FirstOrDefault().ImeKonzole;
                    ws.Range["H" + counter].Value = i.IzdatRacunPice;
                    ws.Range["I" + counter].Value = i.IzdatRacunIznajmljivanje;
                    if(se.Stavkas.Where(b => b.IdRacuna == i.IdRacuna).ToList() == null)
                    {
                        counter++;
                    }
                }
                foreach (var b in se.Stavkas.Where(a=>a.IdRacuna == i.IdRacuna).ToList())
                {
                    ws.Range["J" + counter].Value = se.Pices.Where(c=>c.IdPica == b.IdPica).FirstOrDefault().Predmet;
                    ws.Range["K" + counter].Value = b.KomadaPica;
                    counter++;
                }
            }
            

            wb.SaveAs("E:\\Projekat Sony4Room\\Sony4Room" + DateTime.Parse(piker.Text).Date.ToString("MM-dd-yyyy") +".xlsx");
        }

        private void Otkazi_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
        public class Instanca
        {
            public string IdRacuna { get; set; }
            public string IdIznajmljivanja { get; set; }
            public string IdClana { get; set; }
            public string IdRadnika { get; set; }
            public string IdKonzole { get; set; }
            public string IdSlusalica { get; set; }
            public string IdJojpeda { get; set; }
        }
    }

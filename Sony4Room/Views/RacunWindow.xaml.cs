using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Sony4Room.Views
{
    /// <summary>
    /// Interaction logic for RacunWindow.xaml
    /// </summary>
    public partial class RacunWindow : Window, INotifyPropertyChanged
    {
        //2560x 1440
        SonyEntities se = new SonyEntities();
        Radnik modelRadnik = new Radnik();
        Iznajmljivanje iznajmljivanje = new Iznajmljivanje();
        Konzola konzola = new Konzola();
        Joyped jojped = new Joyped();
        public event PropertyChangedEventHandler PropertyChanged;
        public Racun ra = new Racun();
        public Stavka st = new Stavka();
        public List<Radnik> Ra { get; set; }
        public List<Slusalouse> Slu { get; set; }
        public List<Joyped> Joy { get; set; }
        public List<Clan> Cl { get; set; }
        ObservableCollection<RacunPica> lista = new ObservableCollection<RacunPica>();
        ObservableCollection<RacunPica> obrisanaLista = new ObservableCollection<RacunPica>();
        ObservableCollection<Cena> listaSabranihCena = new ObservableCollection<Cena>() { };
        public DateTime dodatoVreme;
        public float cena;
        public bool racunPice = false;
        public bool racunIznajmljivanje = false;
        public int brojCola = 0;
        public int brojSprite = 0;
        public int brojFanta = 0;
        public int brojFantaMala = 0;
        public int brojColaMala = 0;
        public int brojJoyVisnja = 0;
        public int brojFuzeTeaBreskva = 0;
        public int brojTube = 0;
        public int brojAquaViva = 0;
        public int brojRosa = 0;
        public int brojKnjazMilos = 0;
        public int brojGuarana = 0;
        public int brojUltra = 0;
        public int brojJelen = 0;
        public int brojTuborg = 0;
        public int brojVelikiCips = 0;
        public int brojMaliCips = 0;
        public int brojVelikiSmokie = 0;
        public int brojMaliSmokie = 0;
        public int brojJafa = 0;
        public int brojMunchmallow = 0;
        public int brojRumKasato = 0;
        public int index = 0;
        public double ukupnoSati = 0;
        public string gledajNa;
        public bool bezKonzole = false;
        public bool dvaVolana = false;
        public Clan izabraniClan;
        public bool fiksnovreme = false;
        public int _brojIzabranogClana { get; set; }
        public int brojIzabranogClana
        {
            get
            {
                return _brojIzabranogClana;
            }
            set
            {
                _brojIzabranogClana = value;
                OnPropertyRaised("brojIzabranogClana");
            }
        }
        public Radnik izabraniRadnik;
        public int _brojIzabranogRadnika { get; set; }
        public int brojIzabranogRadnika
        {
            get
            {
                return _brojIzabranogRadnika;
            }
            set
            {
                _brojIzabranogRadnika = value;
                OnPropertyRaised("brojIzabranogRadnika");
            }
        }
        public Slusalouse izabraneSlusalice;
        public int _brojIzabranihSlusalica { get; set; }
        public int brojIzabranihSlusalica
        {
            get
            {
                return _brojIzabranihSlusalica;
            }
            set
            {
                _brojIzabranihSlusalica = value;
                OnPropertyRaised("brojIzabranihSlusalica");
            }
        }
        public Joyped izabraniJojped;
        public int _brojIzabranogJojpeda { get; set; }
        public int brojIzabranogJojpeda
        {
            get
            {
                return _brojIzabranogJojpeda;
            }
            set
            {
                _brojIzabranogJojpeda = value;
                OnPropertyRaised("brojIzabranogJojpeda");
            }
        }
        public string nazivKonzole;
        public int poslednjeIznajmljivanje;
        public int poslednjiRacun;

        public RacunWindow(string brojKonzole)
        {
            InitializeComponent();
            nazivK(brojKonzole);
            poslednjeIznajmljivanje = se.Iznajmljivanjes.OrderByDescending(o => o.IdIznajmljivanje).FirstOrDefault().IdIznajmljivanje;
            poslednjiRacun = se.Racuns.OrderByDescending(o => o.IdRacuna).FirstOrDefault().IdRacuna;

            var brPosRacuna = se.Dostupnosts.Where(b => b.Naziv == brojKonzole).FirstOrDefault().BrojPoslednjegRacuna;
            if (brPosRacuna==0)
            {
                listaSabranihCena.Add(new Cena() { cenaSabrana = 0, cenaPica = 0, cenaIznajmljivanja = 0 });
            }
            else
            {
                listaSabranihCena.Add(new Cena() { cenaSabrana = Int32.Parse(se.Racuns.Where(a => a.IdRacuna == brPosRacuna).FirstOrDefault().UkupnaCena),
                    cenaPica = Int32.Parse(se.Racuns.Where(a => a.IdRacuna == brPosRacuna).FirstOrDefault().CenaPica),
                    cenaIznajmljivanja = Int32.Parse(se.Racuns.Where(a => a.IdRacuna == brPosRacuna).FirstOrDefault().CenaIznajmljvanja) });

            }
            bindJoypedCombo();
            bindRadnikCombo();
            bindClanCombo();
            bindSlusaliceCombo();

            if (brPosRacuna > 0)
            {
               
                    var brIz = se.Racuns.Where(b => b.IdRacuna == brPosRacuna).FirstOrDefault().IdIznajmljivanje;
                    var brRadnika = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().IdRadnika;
                    var brClana = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().IdClan;
                    var brJojstika = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().IdJoypeda;
                    var brSlusalica = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().IdSlusalica;
                    var brojStavki = se.Stavkas.Count(t => t.IdRacuna == brPosRacuna);
                    dodatoVreme = DateTime.Parse(se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().VremeZavrsavanja.ToString());

                    izabraniRadnik = se.Radniks.Where(a => a.IdRadnika == brRadnika).FirstOrDefault();

                    cmbSelection.SelectedItem = se.Radniks.Where(a => a.IdRadnika == brRadnika).FirstOrDefault();

                    cmbClana.SelectedItem = se.Clans.Where(a => a.IdClan == brClana).FirstOrDefault();
                    izabraniClan = se.Clans.Where(a => a.IdClan == brClana).FirstOrDefault();

                    cmbJoypeda.SelectedItem = se.Joypeds.Where(a => a.IdJoypeda == brJojstika).FirstOrDefault();
                    izabraniJojped = se.Joypeds.Where(a => a.IdJoypeda == brJojstika).FirstOrDefault();

                    cmbSlusalice.SelectedItem = se.Slusalice.Where(a => a.IdSlusalica == brSlusalica).FirstOrDefault();
                    izabraneSlusalice = se.Slusalice.Where(a => a.IdSlusalica == brSlusalica).FirstOrDefault();

                    vremePocetka.Text = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().VremePocetka.ToString();
                    vremeZavrsetka.Text = se.Iznajmljivanjes.Where(a => a.IdIznajmljivanje == brIz).FirstOrDefault().VremeZavrsavanja.ToString();
                if (se.Stavkas.Any(a => a.IdRacuna == brPosRacuna) == true)
                {
                    var pocetniRacun = se.Stavkas.Where(a => a.IdRacuna == brPosRacuna).FirstOrDefault().IdStavka;
                    for (int i = pocetniRacun; i < pocetniRacun + brojStavki; i++)
                    {
                        var Idpice = se.Stavkas.Where(a => a.IdStavka == i).FirstOrDefault();
                        var pice = se.Pices.Where(a => a.IdPica == Idpice.IdPica).FirstOrDefault();
                        if (pice.Predmet == "Cola")
                        {
                            brojCola = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojCola, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Sprite")
                        {
                            brojSprite = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojSprite, Cena = pice.CenaPoKomadu });

                        }
                        if (pice.Predmet == "Fanta")
                        {
                            brojFanta = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojFanta, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "ColaMala")
                        {
                            brojColaMala = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojColaMala, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "FantaMala")
                        {
                            brojFantaMala = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojFantaMala, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "JoyVisnja")
                        {
                            brojJoyVisnja = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojJoyVisnja, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "FuzeTeaBreskva")
                        {
                            brojFuzeTeaBreskva = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojFuzeTeaBreskva, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "AquaViva")
                        {
                            brojAquaViva = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojAquaViva, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Rosa")
                        {
                            brojRosa = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojRosa, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "KnjazMilos")
                        {
                            brojKnjazMilos = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojKnjazMilos, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Guarana")
                        {
                            brojGuarana = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojGuarana, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Ultra")
                        {
                            brojUltra = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojUltra, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Jelen")
                        {
                            brojJelen = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojJelen, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Tuborg")
                        {
                            brojTuborg = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojTuborg, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "VelikiCips")
                        {
                            brojVelikiCips = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojVelikiCips, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "MaliCips")
                        {
                            brojMaliCips = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojMaliCips, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "VelikiSmokie")
                        {
                            brojVelikiSmokie = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojVelikiSmokie, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "MaliSmokie")
                        {
                            brojMaliSmokie = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojMaliSmokie, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Jafa")
                        {
                            brojJafa = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojJafa, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Munchmallow")
                        {
                            brojMunchmallow = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojMunchmallow, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "RumKasato")
                        {
                            brojRumKasato = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojRumKasato, Cena = pice.CenaPoKomadu });
                        }
                        if (pice.Predmet == "Tube")
                        {
                            brojTube = Int32.Parse(Idpice.KomadaPica.ToString());
                            lista.Add(new RacunPica() { Naziv = pice.Predmet, Broj = brojTube, Cena = pice.CenaPoKomadu });
                        }
                    }
                }
                    loadRacun();
                    loadCena();
            }
            else
            {
                if (iznajmljivanje.VremePocetka == null)
                {
                    vremePocetka.Text = DateTime.Now.ToString();
                }
                if (nazivKonzole == "K1")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K2")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K3")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K4")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K5")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "Volan1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "Volan1").FirstOrDefault().CenaPoSatu.ToString());

                }
                else if (nazivKonzole == "K6")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "Volan1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "Volan1").FirstOrDefault().CenaPoSatu.ToString());
                }
                else if (nazivKonzole == "K7")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K8")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K9")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K10")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K11")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
                else if (nazivKonzole == "K12")
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                    cbxDvaVolana.IsEnabled = false;
                }
            }
            if (nazivKonzole == "K1")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K2")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K3")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K4")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K5")
            {
                gledajNa = "Volan1";
            }
            else if (nazivKonzole == "K6")
            {
                gledajNa = "Volan1";
            }
            else if (nazivKonzole == "K7")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K8")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K9")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K10")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K11")
            {
                gledajNa = "K1";
            }
            else if (nazivKonzole == "K12")
            {
                gledajNa = "K1";
            }
            txtKonzola.Text = brojKonzole.ToString();
        }
        public void loadRacun()
        {
            listbox.ItemsSource = lista;
        }
        public void loadCena()
        {
            ukupnaCena.ItemsSource = listaSabranihCena;
        }
        public void nazivK(string br)
        {
            nazivKonzole = br;
        }
        private void bindJoypedCombo()
        {
            var item = se.Joypeds.ToList();
            Joy = item;
            cmbJoypeda.DataContext = Joy;
        }

        private void bindRadnikCombo()
        {
            var item = se.Radniks.ToList();
            Ra = item;
            cmbSelection.DataContext = Ra;
        }
        private void bindSlusaliceCombo()
        {
            var item = se.Slusalice.ToList();
            Slu = item;
            cmbSlusalice.DataContext = Slu;
        }
        private void bindClanCombo()
        {
            var item = se.Clans.ToList();
            Cl = item;
            cmbClana.DataContext = Cl;
        }
        //combo za radnika
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            izabraniRadnik = cmbSelection.SelectedItem as Radnik;
        }

        private void ComboBox_JojstickChanged(object sender, SelectionChangedEventArgs e)
        {
            if (izabraniJojped == null)
            {
                izabraniJojped = cmbJoypeda.SelectedItem as Joyped;
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(izabraniJojped.CenaJoypeda);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(izabraniJojped.CenaJoypeda);
            }
            else
            {
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja - Int32.Parse(izabraniJojped.CenaJoypeda);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana - Int32.Parse(izabraniJojped.CenaJoypeda);
                izabraniJojped = cmbJoypeda.SelectedItem as Joyped;
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(izabraniJojped.CenaJoypeda);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(izabraniJojped.CenaJoypeda);
            }
            loadCena();
        }

        private void ComboBox_SlusaliceChanged(object sender, SelectionChangedEventArgs e)
        {
            if (izabraneSlusalice == null)
            {
                izabraneSlusalice = cmbSlusalice.SelectedItem as Slusalouse;
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(izabraneSlusalice.CenaSlusalica);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(izabraneSlusalice.CenaSlusalica);
            }
            else
            {
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja - Int32.Parse(izabraneSlusalice.CenaSlusalica);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana - Int32.Parse(izabraneSlusalice.CenaSlusalica);
                izabraneSlusalice = cmbSlusalice.SelectedItem as Slusalouse;
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(izabraneSlusalice.CenaSlusalica);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(izabraneSlusalice.CenaSlusalica);
            }
            loadCena();
        }

        private void ComboBox_ClanChanged(object sender, SelectionChangedEventArgs e)
        {
            izabraniClan = (cmbClana.SelectedItem as Clan);
        }

        private void Otkazi_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Modifikuj_Clicked(object sender, RoutedEventArgs e)
        {
            vremeZavrsetka.Text = DateTime.Now.ToString();
            if (se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna > 0)
            {
                var racun = se.Racuns.Where(x => x.IdRacuna == se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna).FirstOrDefault();
                var iznajmljivanje = se.Iznajmljivanjes.Where(x => x.IdIznajmljivanje == racun.IdIznajmljivanje).FirstOrDefault();

                //modifikacija tabele iznajmljivanja

                iznajmljivanje.IdClan = izabraniClan.IdClan;
                if (bezKonzole == true)
                {
                    iznajmljivanje.IdJoypeda = 1;
                    iznajmljivanje.IdKonzole = 1;
                    iznajmljivanje.IdSlusalica = 1;
                }
                else
                {
                    iznajmljivanje.IdJoypeda = izabraniJojped.IdJoypeda;
                    iznajmljivanje.IdKonzole = se.Konzolas.Where(b => b.ImeKonzole == gledajNa).FirstOrDefault().IdKonzole;
                    iznajmljivanje.IdSlusalica = izabraneSlusalice.IdSlusalica;
                }
                iznajmljivanje.IdRadnika = izabraniRadnik.IdRadnika;
                iznajmljivanje.Datum = DateTime.Now;
                iznajmljivanje.VremePocetka = Convert.ToDateTime(vremePocetka.Text);
                iznajmljivanje.VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text);

                //modifikacija tabele racun
                racun.DatumR = DateTime.Now;
                racun.Naplaceno = false;
                racun.IzdatRacunIznajmljivanje = racunIznajmljivanje;
                racun.IzdatRacunPice = racunPice;
                racun.CenaIznajmljvanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja.ToString();
                racun.CenaPica = listaSabranihCena.FirstOrDefault().cenaPica.ToString();
                racun.UkupnaCena = listaSabranihCena.FirstOrDefault().cenaSabrana.ToString();
                racun.IdIznajmljivanje = iznajmljivanje.IdIznajmljivanje;

                //modifikacija stavke

                foreach (var item in lista)
                {
                    
                    var idPica = se.Pices.Where(a => a.Predmet == item.Naziv).FirstOrDefault();
                     if (se.Stavkas.Any(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == idPica.IdPica)) == true)
                     {
                        var stavka = se.Stavkas.Where(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == idPica.IdPica)).FirstOrDefault();
                        if (stavka.KomadaPica != item.Broj)
                        {
                             stavka.KomadaPica = item.Broj;
                        }
                    }
                    else
                    {
                        Stavka newStavka = new Stavka()
                        {
                            IdRacuna = se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna,
                            IdPica = se.Pices.Where(b => b.Predmet == item.Naziv).FirstOrDefault().IdPica,
                            KomadaPica = item.Broj
                        };
                        se.Stavkas.Add(newStavka);
                    }
                }
                foreach (var item in obrisanaLista)
                {
                    var idPica = se.Pices.Where(a => a.Predmet == item.Naziv).FirstOrDefault();
                    if(se.Stavkas.Any(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == idPica.IdPica)) == true)
                    {
                        var stavka = se.Stavkas.Where(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == idPica.IdPica)).FirstOrDefault();
                        se.Stavkas.Remove(stavka);
                    }
                }
                se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna = racun.IdRacuna;
                se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().Slobodna = false;
                se.SaveChanges();
            }
            else
            {

                Iznajmljivanje newIznajmljivanje;
                if (bezKonzole == true)
                {
                    newIznajmljivanje = new Iznajmljivanje()
                    {
                        IdClan = izabraniClan.IdClan,
                        IdJoypeda = 1,
                        IdKonzole = 1,
                        IdRadnika = izabraniRadnik.IdRadnika,
                        IdSlusalica = 1,
                        Datum = DateTime.Now,
                        VremePocetka = Convert.ToDateTime(vremePocetka.Text),
                        VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text)
                    };
                }
                else
                {
                    newIznajmljivanje = new Iznajmljivanje()
                    {
                        IdClan = izabraniClan.IdClan,
                        IdJoypeda = izabraniJojped.IdJoypeda,
                        IdKonzole = se.Konzolas.Where(b => b.ImeKonzole == gledajNa).FirstOrDefault().IdKonzole,
                        IdRadnika = izabraniRadnik.IdRadnika,
                        IdSlusalica = izabraneSlusalice.IdSlusalica,
                        Datum = DateTime.Now,
                        VremePocetka = Convert.ToDateTime(vremePocetka.Text),
                        VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text)
                    };
                }
                se.Iznajmljivanjes.Add(newIznajmljivanje);
                se.SaveChanges();
                Racun newRacun = new Racun()
                {
                    DatumR = DateTime.Now,
                    Naplaceno = false,
                    IzdatRacunIznajmljivanje = racunIznajmljivanje,
                    IzdatRacunPice = racunPice,
                    CenaIznajmljvanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja.ToString(),
                    CenaPica = listaSabranihCena.FirstOrDefault().cenaPica.ToString(),
                    UkupnaCena = listaSabranihCena.FirstOrDefault().cenaSabrana.ToString(),
                    IdIznajmljivanje = newIznajmljivanje.IdIznajmljivanje
                };
                se.Racuns.Add(newRacun);
                se.SaveChanges();
                foreach (var item in lista)
                {
                    int poslednjaStavka = se.Stavkas.OrderByDescending(o => o.IdStavka).FirstOrDefault().IdStavka;
                    Stavka newStavka = new Stavka()
                    {
                        IdRacuna = newRacun.IdRacuna,
                        IdPica = se.Pices.Where(b => b.Predmet == item.Naziv).FirstOrDefault().IdPica,
                        KomadaPica = item.Broj
                    };
                    se.Stavkas.Add(newStavka);
                }
                se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna = newRacun.IdRacuna;
                se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().Slobodna = false;
                se.SaveChanges();
                MessageBox.Show("Uspeno modifikovan");
            }

            se.SaveChanges();
            Close();
        }

        private void Izdaj_Clicked(object sender, RoutedEventArgs e)
        {
            vremeZavrsetka.Text = DateTime.Now.ToString();
            if (se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna > 0)
            {
                var racun = se.Racuns.Where(x => x.IdRacuna == se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna).FirstOrDefault();
                var iznajmljivanje = se.Iznajmljivanjes.Where(x => x.IdIznajmljivanje == racun.IdIznajmljivanje).FirstOrDefault();
                var nekaprom = se.Konzolas.Where(b => b.ImeKonzole == gledajNa).FirstOrDefault().IdKonzole; 
                //modifikacija tabele iznajmljivanja
                if (bezKonzole == true)
                {
                    iznajmljivanje.IdClan = izabraniClan.IdClan;
                    iznajmljivanje.IdRadnika = izabraniRadnik.IdRadnika;
                    iznajmljivanje.IdKonzole = 1;
                    iznajmljivanje.IdJoypeda = 1;
                    iznajmljivanje.IdSlusalica = 1;
                    iznajmljivanje.Datum = DateTime.Now;
                    iznajmljivanje.VremePocetka = Convert.ToDateTime(vremePocetka.Text);
                    iznajmljivanje.VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text);
                }
                else
                {
                    iznajmljivanje.IdClan = izabraniClan.IdClan;
                    iznajmljivanje.IdRadnika = izabraniRadnik.IdRadnika;
                    iznajmljivanje.IdKonzole = se.Konzolas.Where(b => b.ImeKonzole == gledajNa).FirstOrDefault().IdKonzole;
                    iznajmljivanje.IdJoypeda = izabraniJojped.IdJoypeda;
                    iznajmljivanje.IdSlusalica = izabraneSlusalice.IdSlusalica;
                    iznajmljivanje.Datum = DateTime.Now;
                    iznajmljivanje.VremePocetka = Convert.ToDateTime(vremePocetka.Text);
                    iznajmljivanje.VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text);
                }

                //modifikacija tabele racun
                racun.DatumR = DateTime.Now;
                racun.Naplaceno = true;
                racun.IzdatRacunIznajmljivanje = racunIznajmljivanje;
                racun.IzdatRacunPice = racunPice;
                racun.CenaIznajmljvanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja.ToString();
                racun.CenaPica = listaSabranihCena.FirstOrDefault().cenaPica.ToString();
                racun.UkupnaCena = listaSabranihCena.FirstOrDefault().cenaSabrana.ToString();
                racun.IdIznajmljivanje = iznajmljivanje.IdIznajmljivanje;

                //modifikacija stavke
                foreach (var item in lista)
                {

                    var provera = se.Pices.Where(a => a.Predmet == item.Naziv).FirstOrDefault();
                    if (se.Stavkas.Where(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == provera.IdPica)).FirstOrDefault().IdStavka > 0)
                    {
                        var stavka = se.Stavkas.Where(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == provera.IdPica)).FirstOrDefault();
                        if (stavka.KomadaPica != item.Broj)
                        {
                            if (item.Broj == 0)
                            {
                                se.Stavkas.Remove(stavka);
                            }
                            else
                            {
                                stavka.KomadaPica = item.Broj;
                            }
                        }
                        se.KnjigaSankas.Where(a => a.NazivPica == provera.Predmet).FirstOrDefault().Stanje = se.KnjigaSankas.Where(a => a.NazivPica == provera.Predmet).FirstOrDefault().Stanje - item.Broj;
                    }
                    else
                    {
                        Stavka newStavka = new Stavka()
                        {
                            IdRacuna = se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna,
                            IdPica = se.Pices.Where(b => b.Predmet == item.Naziv).FirstOrDefault().IdPica,
                            KomadaPica = item.Broj
                        };
                        se.Stavkas.Add(newStavka);
                        se.KnjigaSankas.Where(a => a.NazivPica == item.Naziv).FirstOrDefault().Stanje = se.KnjigaSankas.Where(a => a.NazivPica == item.Naziv).FirstOrDefault().Stanje - item.Broj;
                    }
                }
                foreach (var item in obrisanaLista)
                {
                    var idPica = se.Pices.Where(a => a.Predmet == item.Naziv).FirstOrDefault();
                    if (se.Stavkas.Any(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == idPica.IdPica)) == true)
                    {
                        var stavka = se.Stavkas.Where(a => (a.IdRacuna == racun.IdRacuna) && (a.IdPica == idPica.IdPica)).FirstOrDefault();
                        se.Stavkas.Remove(stavka);
                    }
                }
                se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna = 0;
                se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().Slobodna = true;
                se.Clans.Where(a => a.IdClan == iznajmljivanje.IdClan).FirstOrDefault().BrojDolaska++;
                if (fiksnovreme == true)
                {
                    if (ukupnoSati > 1)
                    {
                        se.Clans.Where(a => a.IdClan == iznajmljivanje.IdClan).FirstOrDefault().KumulativnoSati = (Int32.Parse(se.Clans.Where(a => a.IdClan == iznajmljivanje.IdClan).FirstOrDefault().KumulativnoSati) + ukupnoSati).ToString();
                    }
                }
                else
                {
                    DateTime pocetak = DateTime.Parse(vremePocetka.Text.ToString());
                    DateTime trenutno = DateTime.Now;
                    double sati = (trenutno - pocetak).TotalHours;
                    if (sati > 1)
                    {
                        se.Clans.Where(a => a.IdClan == iznajmljivanje.IdClan).FirstOrDefault().KumulativnoSati = (Int32.Parse(se.Clans.Where(a => a.IdClan == iznajmljivanje.IdClan).FirstOrDefault().KumulativnoSati) + Int32.Parse(sati.ToString())).ToString();
                    }
                }
                se.SaveChanges();
            }
            else
            {
                if (izabraneSlusalice != null && izabraniClan != null && izabraniJojped != null && izabraniRadnik != null)
                {
                    var brPosRacuna = se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna;
                    var racun = se.Racuns.Where(b => b.IdRacuna == brPosRacuna).FirstOrDefault();
                    Iznajmljivanje newIznajmljivanje;
                    if (bezKonzole == true)
                    {
                        newIznajmljivanje = new Iznajmljivanje()
                        {
                            IdClan = izabraniClan.IdClan,
                            IdJoypeda = 1,
                            IdKonzole = 1,
                            IdRadnika = izabraniRadnik.IdRadnika,
                            IdSlusalica = 1,
                            Datum = DateTime.Now,
                            VremePocetka = Convert.ToDateTime(vremePocetka.Text),
                            VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text)
                        };
                    }
                    else
                    {
                        newIznajmljivanje = new Iznajmljivanje()
                        {
                            IdClan = izabraniClan.IdClan,
                            IdJoypeda = izabraniJojped.IdJoypeda,
                            IdKonzole = se.Konzolas.Where(b => b.ImeKonzole == gledajNa).FirstOrDefault().IdKonzole,
                            IdRadnika = izabraniRadnik.IdRadnika,
                            IdSlusalica = izabraneSlusalice.IdSlusalica,
                            Datum = DateTime.Now,
                            VremePocetka = Convert.ToDateTime(vremePocetka.Text),
                            VremeZavrsavanja = Convert.ToDateTime(vremeZavrsetka.Text) 
                        };
                    }
                    Racun newRacun = new Racun()
                    {
                        DatumR = DateTime.Now,
                        Naplaceno = true,
                        IzdatRacunIznajmljivanje = racunIznajmljivanje,
                        IzdatRacunPice = racunPice,
                        CenaIznajmljvanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja.ToString(),
                        CenaPica = listaSabranihCena.FirstOrDefault().cenaPica.ToString(),
                        UkupnaCena = listaSabranihCena.FirstOrDefault().cenaSabrana.ToString(),
                        IdIznajmljivanje = newIznajmljivanje.IdIznajmljivanje
                    };
                    foreach (var item in lista)
                    {
                        se.KnjigaSankas.Where(a => a.NazivPica == item.Naziv).FirstOrDefault().Stanje = se.KnjigaSankas.Where(a => a.NazivPica == item.Naziv).FirstOrDefault().Stanje - item.Broj;
                        int poslednjaStavka = se.Stavkas.OrderByDescending(o => o.IdStavka).FirstOrDefault().IdStavka;
                        Stavka newStavka = new Stavka()
                        {
                            IdRacuna = newRacun.IdRacuna,
                            IdPica = se.Pices.Where(b => b.Predmet == item.Naziv).FirstOrDefault().IdPica,
                            KomadaPica = item.Broj
                        };
                        se.Stavkas.Add(newStavka);
                    }
                    foreach (var item in obrisanaLista)
                    {
                        var idPica = se.Pices.Where(a => a.Predmet == item.Naziv).FirstOrDefault();
                        if (se.Stavkas.Any(a => (a.IdRacuna == newRacun.IdRacuna) && (a.IdPica == idPica.IdPica)) == true)
                        {
                            var stavka = se.Stavkas.Where(a => (a.IdRacuna == newRacun.IdRacuna) && (a.IdPica == idPica.IdPica)).FirstOrDefault();
                            se.Stavkas.Remove(stavka);
                        }
                    }
                    se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().BrojPoslednjegRacuna = 0;
                    se.Dostupnosts.Where(b => b.Naziv == nazivKonzole).FirstOrDefault().Slobodna = true;
                    se.Clans.Where(a => a.IdClan == izabraniClan.IdClan).FirstOrDefault().BrojDolaska++;
                    se.Iznajmljivanjes.Add(newIznajmljivanje);
                    se.Racuns.Add(newRacun);
                    MessageBox.Show("Uspeno dodat");
                    Close();
                }
                else
                {
                    MessageBox.Show("Niste popunili sva polja!");
                }
                if (fiksnovreme == true)
                {
                    se.Clans.Where(a => a.IdClan == izabraniClan.IdClan).FirstOrDefault().KumulativnoSati = (Int32.Parse(se.Clans.Where(a => a.IdClan == izabraniClan.IdClan).FirstOrDefault().KumulativnoSati) + ukupnoSati).ToString();
                }
                else
                {
                    DateTime pocetak = DateTime.Parse(vremePocetka.Text.ToString());
                    DateTime trenutno = DateTime.Now;
                    double sati = (trenutno - pocetak).TotalHours;
                    MessageBox.Show("Igrao " + double.Parse(Math.Round(sati, 2).ToString()) + " sati ") ;
                    se.Clans.Where(a => a.IdClan == izabraniClan.IdClan).FirstOrDefault().KumulativnoSati = ((double.Parse(se.Clans.Where(a => a.IdClan == izabraniClan.IdClan).FirstOrDefault().KumulativnoSati) + double.Parse(sati.ToString()))).ToString() ;
                }
                se.SaveChanges();
            }
        }

        private void CbxRacunPice_Checked(object sender, RoutedEventArgs e)
        {
            if (racunPice == true)
            {
                racunPice = false;
            }
            else
                racunPice = true;
        }

        private void CbxRacunKonzolu_Checked(object sender, RoutedEventArgs e)
        {
            if (racunIznajmljivanje == true)
            {
                racunIznajmljivanje = false;
            }
            else
                racunIznajmljivanje = true;
        }
        public int Dodavanje(int broj,string naziv)
        {
            string cena =se.Pices.Where(b => b.Predmet == naziv).FirstOrDefault().CenaPoKomadu.ToString();
            if (broj == 0)
            {
                broj++;
                lista.Add(new RacunPica() { Naziv = naziv, Broj = broj, Cena = cena });
                listaSabranihCena.FirstOrDefault().cenaPica = listaSabranihCena.FirstOrDefault().cenaPica + Int32.Parse(cena);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(cena);
                if (obrisanaLista.FirstOrDefault(i => i.Naziv == naziv) !=null)
                {
                    var obrisana =  obrisanaLista.FirstOrDefault(i => i.Naziv == naziv);
                    obrisanaLista.Remove(obrisana);
                }
            }
            else if (broj != 0)
            {
                broj++;
                listaSabranihCena.FirstOrDefault().cenaPica = listaSabranihCena.FirstOrDefault().cenaPica + Int32.Parse(cena);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana + Int32.Parse(cena);
                var item = lista.FirstOrDefault(i => i.Naziv == naziv);
                if (item != null)
                {
                    item.Broj = broj;
                }
            }
            loadRacun();
            loadCena();
            return broj;
        }
        public int Oduzimanje(int broj, string naziv)
        {
            string cena = se.Pices.Where(b => b.Predmet == naziv).FirstOrDefault().CenaPoKomadu.ToString();
            if (broj == 0)
            {
                MessageBox.Show("Clan nije uzeo " + naziv+" !");
            }
            else if (broj == 1)
            {
                broj--;
                var item = lista.FirstOrDefault(i => i.Naziv == naziv);
                listaSabranihCena.FirstOrDefault().cenaPica = listaSabranihCena.FirstOrDefault().cenaPica - Int32.Parse(cena);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana - Int32.Parse(cena);
                if (item != null)
                {
                    item.Broj = broj;
                }
                lista.Remove(item);
                if (obrisanaLista.Any(b => b.Naziv == naziv) == true)
                {
                    obrisanaLista.Where(a => a.Naziv == naziv).FirstOrDefault().Broj = 0;

                }
                else
                {
                    obrisanaLista.Add(new RacunPica() { Naziv = naziv, Broj = 0, Cena = "0" });
                }
            }
            else
            {
                broj--;
                var item = lista.FirstOrDefault(i => i.Naziv == naziv);
                listaSabranihCena.FirstOrDefault().cenaPica = listaSabranihCena.FirstOrDefault().cenaPica - Int32.Parse(cena);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaSabrana - Int32.Parse(cena);
                if (item != null)
                {
                    item.Broj = broj;
                }
            }
            loadRacun();
            loadCena();
            return broj;
        }
        private void Cola_Clicked(object sender, RoutedEventArgs e)
        {
            brojCola=Dodavanje(brojCola,"Cola");
        }

        private void ColaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojCola = Oduzimanje(brojCola, "Cola");
        }

        private void Sprite_Clicked(object sender, RoutedEventArgs e)
        {
            brojSprite = Dodavanje(brojSprite, "Sprite");
        }
        private void SpriteRemove_Clicked(object sender, RoutedEventArgs e)
        {

            brojSprite = Oduzimanje(brojSprite, "Sprite");
        }

        private void Fanta_Clicked(object sender, RoutedEventArgs e)
        {
            brojFanta = Dodavanje(brojFanta, "Fanta");
        }

        private void FantaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojFanta = Oduzimanje(brojFanta, "Fanta");
        }

        private void FantaMala_Clicked(object sender, RoutedEventArgs e)
        {
            brojFantaMala = Dodavanje(brojFantaMala, "FantaMala");
        }

        private void FantaMalaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojFantaMala = Oduzimanje(brojFantaMala, "FantaMala");
        }

        private void ColaMala_Clicked(object sender, RoutedEventArgs e)
        {
            brojColaMala = Dodavanje(brojColaMala, "ColaMala");
        }

        private void ColaMalaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojColaMala = Oduzimanje(brojColaMala, "ColaMala");
        }

        private void Joy_Clicked(object sender, RoutedEventArgs e)
        {
            brojJoyVisnja = Dodavanje(brojJoyVisnja, "JoyVisnja");
        }

        private void JoyRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojJoyVisnja = Oduzimanje(brojJoyVisnja, "JoyVisnja");
        }

        private void Fuze_Clicked(object sender, RoutedEventArgs e)
        {
            brojFuzeTeaBreskva = Dodavanje(brojFuzeTeaBreskva, "FuzeTeaBreskva");
        }

        private void FuzeRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojFuzeTeaBreskva = Oduzimanje(brojFuzeTeaBreskva, "FuzeTeaBreskva");
        }

        private void Tube_Clicked(object sender, RoutedEventArgs e)
        {
            brojTube = Dodavanje(brojTube, "Tube");
        }

        private void TubeRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojTube = Oduzimanje(brojTube, "Tube");
        }

        private void AquaViva_Clicked(object sender, RoutedEventArgs e)
        {
            brojAquaViva = Dodavanje(brojAquaViva, "AquaViva");
        }

        private void AquaVivaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojAquaViva = Oduzimanje(brojAquaViva, "AquaViva");
        }

        private void Rosa_Clicked(object sender, RoutedEventArgs e)
        {
            brojRosa = Dodavanje(brojRosa, "Rosa");
        }

        private void RosaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojRosa = Oduzimanje(brojRosa, "Rosa");
        }

        private void KnjazMilos_Clicked(object sender, RoutedEventArgs e)
        {
            brojKnjazMilos = Dodavanje(brojKnjazMilos, "KnjazMilos");
        }

        private void KnjazMilosRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojKnjazMilos = Oduzimanje(brojKnjazMilos, "KnjazMilos");
        }

        private void Guarana_Clicked(object sender, RoutedEventArgs e)
        {
            brojGuarana = Dodavanje(brojGuarana, "Guarana");
        }

        private void GuaranaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojGuarana = Oduzimanje(brojGuarana, "Guarana");
        }

        private void Ultra_Clicked(object sender, RoutedEventArgs e)
        {
            brojUltra = Dodavanje(brojUltra, "Ultra");
        }

        private void UltraRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojUltra = Oduzimanje(brojUltra, "Ultra");
        }

        private void Jelen_Clicked(object sender, RoutedEventArgs e)
        {
            brojJelen = Dodavanje(brojJelen, "Jelen");
        }

        private void JelenRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojJelen = Oduzimanje(brojJelen, "Jelen");
        }

        private void Tuborg_Clicked(object sender, RoutedEventArgs e)
        {
            brojTuborg = Dodavanje(brojTuborg, "Tuborg");
        }

        private void TuborgRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojTuborg = Oduzimanje(brojTuborg, "Tuborg");
        }

        private void VelikiCips_Clicked(object sender, RoutedEventArgs e)
        {
            brojVelikiCips = Dodavanje(brojVelikiCips, "VelikiCips");
        }

        private void VelikiCipsRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojVelikiCips = Oduzimanje(brojVelikiCips, "VelikiCips");
        }

        private void MaliCips_Clicked(object sender, RoutedEventArgs e)
        {
            brojMaliCips = Dodavanje(brojMaliCips, "MaliCips");
        }

        private void MaliCipsRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojMaliCips = Oduzimanje(brojMaliCips, "MaliCips");
        }

        private void VelikiSmokie_Clicked(object sender, RoutedEventArgs e)
        {
            brojVelikiSmokie = Dodavanje(brojVelikiSmokie, "VelikiSmokie");
        }

        private void VelikiSmokieRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojVelikiSmokie = Oduzimanje(brojVelikiSmokie, "VelikiSmokie");
        }

        private void MaliSmokie_Clicked(object sender, RoutedEventArgs e)
        {
            brojMaliSmokie = Dodavanje(brojMaliSmokie, "MaliSmokie");
        }

        private void MaliSmokieRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojMaliSmokie = Oduzimanje(brojMaliSmokie, "MaliSmokie");
        }

        private void Jafa_Clicked(object sender, RoutedEventArgs e)
        {
            brojJafa = Dodavanje(brojJafa, "Jafa");
        }

        private void JafaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojJafa = Oduzimanje(brojJafa, "Jafa");
        }

        private void Manchmallow_Clicked(object sender, RoutedEventArgs e)
        {
            brojMunchmallow = Dodavanje(brojMunchmallow, "Munchmallow");
        }

        private void ManchmallowRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojMunchmallow = Oduzimanje(brojMunchmallow, "Munchmallow");
        }

        private void Rum_Clicked(object sender, RoutedEventArgs e)
        {
            brojRumKasato = Dodavanje(brojRumKasato, "RumKasato");
        }

        private void RumRemove_Clicked(object sender, RoutedEventArgs e)
        {
            brojRumKasato = Oduzimanje(brojRumKasato, "RumKasato");
        }


        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private void Izracunaj_Clicked(object sender, RoutedEventArgs e)
        {
            if(brojSati.Text == "")
            {
                MessageBox.Show("Niste uneli broj sati!");
            }
            else
            {
                ukupnoSati = double.Parse(brojSati.Text);
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja * Int32.Parse(brojSati.Text);
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaPica + listaSabranihCena.FirstOrDefault().cenaIznajmljivanja;
                fiksnovreme = true;
                if (vremeZavrsetka.Text == "")
                {
                    vremeZavrsetka.Text =DateTime.Parse(vremePocetka.Text).AddHours(Double.Parse(brojSati.Text)).ToString();
                }
                else
                {
                    vremeZavrsetka.Text = dodatoVreme.AddHours(Double.Parse(brojSati.Text)).ToString() ;

                }
                loadCena();
            }
        }

        private void CbxBezKonzole_Checked(object sender, RoutedEventArgs e)
        {
            if(bezKonzole ==false)
            {
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja - Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + listaSabranihCena.FirstOrDefault().cenaPica;
                bezKonzole = true;
                loadCena();
            }
            else
            {
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "K1").FirstOrDefault().CenaPoSatu.ToString());
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + listaSabranihCena.FirstOrDefault().cenaPica;

                bezKonzole = false;
                loadCena();
            }
        }

        private void CbxDvaVolana_Checked(object sender, RoutedEventArgs e)
        {
            if (dvaVolana == false)
            {
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja - Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "Volan1").FirstOrDefault().CenaPoSatu.ToString());
                if(fiksnovreme == true)
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = 0;
                }
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "ObaVolana").FirstOrDefault().CenaPoSatu.ToString());
                if(fiksnovreme == true)
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja * double.Parse(brojSati.Text);
                }
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + listaSabranihCena.FirstOrDefault().cenaPica;
                dvaVolana = true;
                loadCena();

            }
            else
            {
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja - Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "ObaVolana").FirstOrDefault().CenaPoSatu.ToString());
                if (fiksnovreme == true)
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = 0;
                }
                listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + Int32.Parse(se.Konzolas.Where(b => b.ImeKonzole == "Volan1").FirstOrDefault().CenaPoSatu.ToString());
                if (fiksnovreme == true)
                {
                    listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja * double.Parse(brojSati.Text);
                }
                listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + listaSabranihCena.FirstOrDefault().cenaPica;
                dvaVolana = false;
            }
        }

        private void IzracunajVreme_Clicked(object sender, RoutedEventArgs e)
        {
            DateTime pocetak = DateTime.Parse(vremePocetka.Text.ToString());
            DateTime trenutno = DateTime.Now;
            vremeZavrsetka.Text = DateTime.Now.ToString() ;

            double sati = ( trenutno- pocetak).TotalHours;
            sati = Math.Round(sati, 1);
            ukupnoSati = sati;
            listaSabranihCena.FirstOrDefault().cenaIznajmljivanja = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja * sati;
            listaSabranihCena.FirstOrDefault().cenaSabrana = listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + listaSabranihCena.FirstOrDefault().cenaPica;
            MessageBox.Show("Odigrano je " +sati+" sati" + listaSabranihCena.FirstOrDefault().cenaIznajmljivanja + " " + listaSabranihCena.FirstOrDefault().cenaSabrana);

        }
    }
    public class RacunPica : INotifyPropertyChanged
    {
        private int _broj;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Naziv { get; set; }
        public string Cena { get; set; }

        public int Broj
        {
            get
            {
                return _broj;
            }
            set
            {
                _broj = value;
                OnPropertyRaised("Broj");
            }
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
    public class Cena : INotifyPropertyChanged
    {
        private double _cenaSabrana;
        private double _cenaPica;
        private double _cenaIznajmljivanja;
        public event PropertyChangedEventHandler PropertyChanged;

        public double cenaPica
        {
            get
            {
                return _cenaPica;
            }
            set
            {
                _cenaPica = value;
                OnPropertyRaised("cenaPica");
            }
        }
        public double cenaIznajmljivanja
        {
            get
            {
                return _cenaIznajmljivanja;
            }
            set
            {
                _cenaIznajmljivanja = value;
                OnPropertyRaised("cenaIznajmljivanja");
            }
        }

        public double cenaSabrana
        {
            get
            {
                return _cenaSabrana;
            }
            set
            {
                _cenaSabrana = value;
                OnPropertyRaised("cenaSabrana");
            }
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
    
}

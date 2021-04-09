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
    /// Interaction logic for KnjigaSankaView.xaml
    /// </summary>
    public partial class KnjigaSankaView : UserControl
    {
        SonyEntities se = new SonyEntities();
        KnjigaSanka sank = new KnjigaSanka();

        public KnjigaSankaView()
        {
            InitializeComponent();
            ColaVelika.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 1).FirstOrDefault().Stanje.ToString();
            ColaMala.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 2).FirstOrDefault().Stanje.ToString();
            FantaVelika.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 3).FirstOrDefault().Stanje.ToString();
            FantaMala.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 4).FirstOrDefault().Stanje.ToString();
            Sprite.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 5).FirstOrDefault().Stanje.ToString(); 
            JoyVisnja.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 6).FirstOrDefault().Stanje.ToString();
            FuzeTeaBreskva.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 7).FirstOrDefault().Stanje.ToString();
            Tube.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 8).FirstOrDefault().Stanje.ToString();
            AquaViva.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 9).FirstOrDefault().Stanje.ToString();
            Rosa.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 10).FirstOrDefault().Stanje.ToString(); 
            KnjazMilos.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 11).FirstOrDefault().Stanje.ToString();
            Guarana.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 12).FirstOrDefault().Stanje.ToString();
            Ultra.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 13).FirstOrDefault().Stanje.ToString();
            Jelen.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 14).FirstOrDefault().Stanje.ToString();
            Tuborg.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 15).FirstOrDefault().Stanje.ToString();
            VelikiCips.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 16).FirstOrDefault().Stanje.ToString();
            MaliCips.Text= se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 17).FirstOrDefault().Stanje.ToString();
            VelikiSmokie.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 18).FirstOrDefault().Stanje.ToString();
            MaliSmokie.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 19).FirstOrDefault().Stanje.ToString();
            Jafa.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 20).FirstOrDefault().Stanje.ToString();
            Munchmallow.Text= se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 21).FirstOrDefault().Stanje.ToString();
            RumKasato.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 22).FirstOrDefault().Stanje.ToString();

            try
            {
                PoslednjaColaVelika.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 2).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaColaMala.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 2).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaFantaVelika.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 3).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaFantaMala.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 4).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaSprite.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 5).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaJoyVisnja.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 6).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaFuzeTeaBreskva.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 7).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaTube.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 8).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaAquaViva.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 9).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaRosa.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 10).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaKnjazMilos.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 11).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaGuarana.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 12).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaUltra.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 13).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaJelen.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 14).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaTuborg.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 15).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaVelikiCips.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 16).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaMaliCips.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 17).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaVelikiSmokie.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 18).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaMaliSmokie.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 19).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaJafa.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 20).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaMunchmallow.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 21).FirstOrDefault().PoslednjaIzmena.ToString();
                PoslednjaRumKasato.Text = se.KnjigaSankas.Where(a => a.IdKnjigaSanka == 22).FirstOrDefault().PoslednjaIzmena.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message); 
                throw;
            }
        }


        private void ColaVelikaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var cola = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 1).FirstOrDefault();
            cola.Stanje = cola.Stanje + 1;
            cola.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            ColaVelika.Text = cola.Stanje.ToString();
            PoslednjaColaVelika.Text = cola.PoslednjaIzmena.ToString();
        }

        private void ColaVelikaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var cola = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 1).FirstOrDefault();
            cola.Stanje = cola.Stanje -1 ;
            cola.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            ColaVelika.Text = cola.Stanje.ToString();
            PoslednjaColaVelika.Text = cola.PoslednjaIzmena.ToString();
        }

        private void ColaMalaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var cola = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 2).FirstOrDefault();
            cola.Stanje = cola.Stanje + 1;
            cola.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            ColaMala.Text = cola.Stanje.ToString();
            PoslednjaColaMala.Text = cola.PoslednjaIzmena.ToString();
        }

        private void ColaMalaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var cola = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 2).FirstOrDefault();
            cola.Stanje = cola.Stanje - 1;
            cola.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            ColaMala.Text = cola.Stanje.ToString();
            PoslednjaColaMala.Text = cola.PoslednjaIzmena.ToString();
        }

        private void FantaVelikaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var fanta = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 3).FirstOrDefault();
            fanta.Stanje = fanta.Stanje + 1;
            fanta.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            FantaVelika.Text = fanta.Stanje.ToString();
            PoslednjaFantaVelika.Text = fanta.PoslednjaIzmena.ToString();
        }

        private void FantaVelikaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var fanta = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 3).FirstOrDefault();
            fanta.Stanje = fanta.Stanje - 1;
            fanta.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            FantaVelika.Text = fanta.Stanje.ToString();
            PoslednjaFantaVelika.Text = fanta.PoslednjaIzmena.ToString();
        }

        private void FantaMalaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var fanta = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 4).FirstOrDefault();
            fanta.Stanje = fanta.Stanje + 1;
            fanta.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            FantaMala.Text = fanta.Stanje.ToString();
            PoslednjaFantaMala.Text = fanta.PoslednjaIzmena.ToString();
        }

        private void FantaMalaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var fanta = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 4).FirstOrDefault();
            fanta.Stanje = fanta.Stanje - 1;
            fanta.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            FantaMala.Text = fanta.Stanje.ToString();
            PoslednjaFantaMala.Text = fanta.PoslednjaIzmena.ToString();
        }

        private void SpriteAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var sprite = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 5).FirstOrDefault();
            sprite.Stanje = sprite.Stanje + 1;
            sprite.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Sprite.Text = sprite.Stanje.ToString();
            PoslednjaSprite.Text = sprite.PoslednjaIzmena.ToString();
        }

        private void SpriteRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var sprite = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 5).FirstOrDefault();
            sprite.Stanje = sprite.Stanje - 1;
            sprite.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Sprite.Text = sprite.Stanje.ToString();
            PoslednjaSprite.Text = sprite.PoslednjaIzmena.ToString();
        }

        private void JoyVisnjaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var joy = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 6).FirstOrDefault();
            joy.Stanje = joy.Stanje + 1;
            joy.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            JoyVisnja.Text = joy.Stanje.ToString();
            PoslednjaJoyVisnja.Text = joy.PoslednjaIzmena.ToString();
        }

        private void JoyvisnjaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var joy = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 6).FirstOrDefault();
            joy.Stanje = joy.Stanje - 1;
            joy.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            JoyVisnja.Text = joy.Stanje.ToString();
            PoslednjaJoyVisnja.Text = joy.PoslednjaIzmena.ToString();
        }

        private void FuzeTeaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var fuze = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 7).FirstOrDefault();
            fuze.Stanje = fuze.Stanje + 1;
            fuze.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            FuzeTeaBreskva.Text = fuze.Stanje.ToString();
            PoslednjaFuzeTeaBreskva.Text = fuze.PoslednjaIzmena.ToString();
        }

        private void FuzeTeaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var fuze = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 7).FirstOrDefault();
            fuze.Stanje = fuze.Stanje - 1;
            fuze.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            FuzeTeaBreskva.Text = fuze.Stanje.ToString();
            PoslednjaFuzeTeaBreskva.Text = fuze.PoslednjaIzmena.ToString();
        }

        private void TubeAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var tube = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 8).FirstOrDefault();
            tube.Stanje = tube.Stanje + 1;
            tube.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Tube.Text = tube.Stanje.ToString();
            PoslednjaTube.Text = tube.PoslednjaIzmena.ToString();
        }

        private void TubeRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var tube = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 8).FirstOrDefault();
            tube.Stanje = tube.Stanje - 1;
            tube.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Tube.Text = tube.Stanje.ToString();
            PoslednjaTube.Text = tube.PoslednjaIzmena.ToString();
        }

        private void AquaVivaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var aqua = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 9).FirstOrDefault();
            aqua.Stanje = aqua.Stanje + 1;
            aqua.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            AquaViva.Text = aqua.Stanje.ToString();
            PoslednjaAquaViva.Text = aqua.PoslednjaIzmena.ToString();
        }

        private void AquaVivaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var aqua = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 9).FirstOrDefault();
            aqua.Stanje = aqua.Stanje - 1;
            aqua.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            AquaViva.Text = aqua.Stanje.ToString();
            PoslednjaAquaViva.Text = aqua.PoslednjaIzmena.ToString();
        }

        private void RosaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var rosa = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 10).FirstOrDefault();
            rosa.Stanje = rosa.Stanje + 1;
            rosa.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Rosa.Text = rosa.Stanje.ToString();
            PoslednjaRosa.Text = rosa.PoslednjaIzmena.ToString();
        }

        private void RosaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var rosa = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 10).FirstOrDefault();
            rosa.Stanje = rosa.Stanje - 1;
            rosa.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Rosa.Text = rosa.Stanje.ToString();
            PoslednjaRosa.Text = rosa.PoslednjaIzmena.ToString();
        }

        private void KnjazMilosAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var knjaz = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 11).FirstOrDefault();
            knjaz.Stanje = knjaz.Stanje + 1;
            knjaz.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            KnjazMilos.Text = knjaz.Stanje.ToString();
            PoslednjaKnjazMilos.Text = knjaz.PoslednjaIzmena.ToString();
        }

        private void KnjazMilosRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var knjaz = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 11).FirstOrDefault();
            knjaz.Stanje = knjaz.Stanje - 1;
            knjaz.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            KnjazMilos.Text = knjaz.Stanje.ToString();
            PoslednjaKnjazMilos.Text = knjaz.PoslednjaIzmena.ToString();
        }

        private void GuaranaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var guarana = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 12).FirstOrDefault();
            guarana.Stanje = guarana.Stanje + 1;
            guarana.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Guarana.Text = guarana.Stanje.ToString();
            PoslednjaGuarana.Text = guarana.PoslednjaIzmena.ToString();
        }

        private void GuaranaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var guarana = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 12).FirstOrDefault();
            guarana.Stanje = guarana.Stanje - 1;
            guarana.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Guarana.Text = guarana.Stanje.ToString();
            PoslednjaGuarana.Text = guarana.PoslednjaIzmena.ToString();
        }

        private void UltraAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var ultra = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 13).FirstOrDefault();
            ultra.Stanje = ultra.Stanje + 1;
            ultra.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Ultra.Text = ultra.Stanje.ToString();
            PoslednjaUltra.Text = ultra.PoslednjaIzmena.ToString();
        }

        private void UltraRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var ultra = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 13).FirstOrDefault();
            ultra.Stanje = ultra.Stanje - 1;
            ultra.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Ultra.Text = ultra.Stanje.ToString();
            PoslednjaUltra.Text = ultra.PoslednjaIzmena.ToString();
        }

        private void JelenAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var jelen = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 14).FirstOrDefault();
            jelen.Stanje = jelen.Stanje + 1;
            jelen.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Jelen.Text = jelen.Stanje.ToString();
            PoslednjaJelen.Text = jelen.PoslednjaIzmena.ToString();
        }

        private void JelenRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var jelen = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 14).FirstOrDefault();
            jelen.Stanje = jelen.Stanje - 1;
            jelen.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Jelen.Text = jelen.Stanje.ToString();
            PoslednjaJelen.Text = jelen.PoslednjaIzmena.ToString();
        }

        private void TuborgAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var tuborg = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 15).FirstOrDefault();
            tuborg.Stanje = tuborg.Stanje + 1;
            tuborg.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Tuborg.Text = tuborg.Stanje.ToString();
            PoslednjaTuborg.Text = tuborg.PoslednjaIzmena.ToString();
        }

        private void TuborgRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var tuborg = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 15).FirstOrDefault();
            tuborg.Stanje = tuborg.Stanje - 1;
            tuborg.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Tuborg.Text = tuborg.Stanje.ToString();
            PoslednjaTuborg.Text = tuborg.PoslednjaIzmena.ToString();
        }

        private void VelikiCipsAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var cips = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 16).FirstOrDefault();
            cips.Stanje = cips.Stanje + 1;
            cips.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            VelikiCips.Text = cips.Stanje.ToString();
            PoslednjaVelikiCips.Text = cips.PoslednjaIzmena.ToString();
        }

        private void VelikiCipsRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var cips = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 16).FirstOrDefault();
            cips.Stanje = cips.Stanje - 1;
            cips.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            VelikiCips.Text = cips.Stanje.ToString();
            PoslednjaVelikiCips.Text = cips.PoslednjaIzmena.ToString();
        }

        private void MaliCipsAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var cips = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 17).FirstOrDefault();
            cips.Stanje = cips.Stanje + 1;
            cips.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            MaliCips.Text = cips.Stanje.ToString();
            PoslednjaMaliCips.Text = cips.PoslednjaIzmena.ToString();
        }

        private void MaliCipsRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var cips = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 17).FirstOrDefault();
            cips.Stanje = cips.Stanje - 1;
            cips.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            MaliCips.Text = cips.Stanje.ToString();
            PoslednjaMaliCips.Text = cips.PoslednjaIzmena.ToString();
        }

        private void VelikiSmokieAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var smokie = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 18).FirstOrDefault();
            smokie.Stanje = smokie.Stanje + 1;
            smokie.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            VelikiSmokie.Text = smokie.Stanje.ToString();
            PoslednjaVelikiSmokie.Text = smokie.PoslednjaIzmena.ToString();
        }

        private void VelikiSmokieRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var smokie = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 18).FirstOrDefault();
            smokie.Stanje = smokie.Stanje - 1;
            smokie.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            VelikiSmokie.Text = smokie.Stanje.ToString();
            PoslednjaVelikiSmokie.Text = smokie.PoslednjaIzmena.ToString();
        }

        private void MaliSmokieAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var smokie = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 19).FirstOrDefault();
            smokie.Stanje = smokie.Stanje + 1;
            smokie.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            MaliSmokie.Text = smokie.Stanje.ToString();
            PoslednjaMaliSmokie.Text = smokie.PoslednjaIzmena.ToString();
        }

        private void MaliSmokieRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var smokie = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 19).FirstOrDefault();
            smokie.Stanje = smokie.Stanje - 1;
            smokie.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            MaliSmokie.Text = smokie.Stanje.ToString();
            PoslednjaMaliSmokie.Text = smokie.PoslednjaIzmena.ToString();
        }

        private void JafaAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var jafa = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 20).FirstOrDefault();
            jafa.Stanje = jafa.Stanje + 1;
            jafa.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Jafa.Text = jafa.Stanje.ToString();
            PoslednjaJafa.Text = jafa.PoslednjaIzmena.ToString();
        }

        private void JafaRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var jafa = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 20).FirstOrDefault();
            jafa.Stanje = jafa.Stanje - 1;
            jafa.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Jafa.Text = jafa.Stanje.ToString();
            PoslednjaJafa.Text = jafa.PoslednjaIzmena.ToString();
        }

        private void MunchmallowAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var munch = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 21).FirstOrDefault();
            munch.Stanje = munch.Stanje + 1;
            munch.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Munchmallow.Text = munch.Stanje.ToString();
            PoslednjaMunchmallow.Text = munch.PoslednjaIzmena.ToString();
        }

        private void MunchmallowRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var munch = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 21).FirstOrDefault();
            munch.Stanje = munch.Stanje - 1;
            munch.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            Munchmallow.Text = munch.Stanje.ToString();
            PoslednjaMunchmallow.Text = munch.PoslednjaIzmena.ToString();
        }

        private void RumKasatoAdd_Clicked(object sender, RoutedEventArgs e)
        {
            var rum = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 22).FirstOrDefault();
            rum.Stanje = rum.Stanje + 1;
            rum.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            RumKasato.Text = rum.Stanje.ToString();
            PoslednjaRumKasato.Text = rum.PoslednjaIzmena.ToString();
        }

        private void RumKasatoRemove_Clicked(object sender, RoutedEventArgs e)
        {
            var rum = se.KnjigaSankas.Where(x => x.IdKnjigaSanka == 22).FirstOrDefault();
            rum.Stanje = rum.Stanje -1;
            rum.PoslednjaIzmena = DateTime.Now;
            se.SaveChanges();
            RumKasato.Text = rum.Stanje.ToString();
            PoslednjaRumKasato.Text = rum.PoslednjaIzmena.ToString();
        }

        private void Export_Clicked(object sender, RoutedEventArgs e)
        {
            ExportPodataka ep = new ExportPodataka();
            ep.ShowDialog();
        }
    }
}

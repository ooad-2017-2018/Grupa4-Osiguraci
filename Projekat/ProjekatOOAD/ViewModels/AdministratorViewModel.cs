using ProjekatOOAD.Models;
using ProjekatOOAD.Helper;
using ProjekatOOAD.Models.Baza_podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Globalization;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;

namespace ProjekatOOAD.ViewModels
{
    public class AdministratorViewModel
    {
       
       
        public ICommand LoginAdmin { get; set; }
        public ICommand LogoutAdmin { get; set; }
        public ICommand dodajPonudu { get; set; }
        public ICommand izmijeniPonudu { get; set; }
        public ICommand obrisiPonudu { get; set; }
        public ICommand dodajEvent { get; set; }
        public ICommand osvjeziEventove { get; set; } // brise putovanja koja su prosla
        public ICommand obrisiNeaktivneKorisnike { get; set; } //brise korisnike koji u zadnje 2 godine nisu otisli na putovanje
        private Dernek dernek;
        public String AdminIme { get; set; }
        public String AdminSifra { get; set; }
        public Models.Administrator logovaniAdministrator { get; set; }
        public Event event1 { get; set; }
        #region Atributi za putovanje
        public DateTime polazak { get; set; }
        public DateTime povratak { get; set;}
        public List<int> putnici { get; set; }
        public int kapacitet { get; set; }
        public double cijena { get; set; }
        public string strKapacitet { get; set; }
        public string strCijena { get; set; }
        public Lokal opis { get; set; }
        #endregion
        public Lokal ponuda { get; set; }
        #region Atributi za Ponudu
        public int brojDana { get; set; }
        public string naziv { get; set; }
        public string planPutovanja { get; set; }
        public string hotel { get; set; }
        public string liveCamera { get; set; }
        public string vremenskaPrognoza { get; set; }
        public string znamenitosti { get; set; }
        public int putaOdrzano { get; set; }
        #endregion
        public Lokal ponudaZaBrisanje { get; set; }
        public Lokal ponudaZaMijenjanje { get; set; }
        #region Atributi za mijenjanje ponude
        public int brojDana1 { get; set; }
        public string naziv1 { get; set; }
        public string planPutovanja1 { get; set; }
        public string hotel1 { get; set; }
        public string liveCamera1 { get; set; }
        public string vremenskaPrognoza1 { get; set; }
        public string znamenitosti1 { get; set; }
        public int putaOdrzano1 { get; set; }
        #endregion
        public static bool prviPut = true;
        public static DateTime minZadnjePut { get; set; }

        internal Dernek Dernek { get => dernek; set => dernek = value; }

        IMobileServiceTable<DataBaseEvent> eventTabela = App.MobileService.GetTable<DataBaseEvent>();
        IMobileServiceTable<DataBaseAdministrator> administratorTabela = App.MobileService.GetTable<DataBaseAdministrator>();
        IMobileServiceTable<DataBaseLokal> lokalTabela = App.MobileService.GetTable<DataBaseLokal>();
        IMobileServiceTable<DataBaseKorisnik> korisniciTabela = App.MobileService.GetTable<DataBaseKorisnik>();


        public AdministratorViewModel()
        {
            dernek = new Dernek();
            minZadnjePut = DateTime.Now.AddYears(-2);
            if (prviPut)
            {
                prviPut = false;
                ucitajIzBaze();
            }
            LoginAdmin = new RelayCommand<Object>(LoginAdministratora);
            LogoutAdmin = new RelayCommand<Object>(LogoutAdministratora);
            dodajPonudu = new RelayCommand<Object>(DodavanjeLokala);
            obrisiPonudu = new RelayCommand<Object>(BrisanjeLokala);
            izmijeniPonudu = new RelayCommand<Object>(AzuriranjeLokala);
            dodajEvent = new RelayCommand<Object>(DodavanjeEventa);
            osvjeziEventove = new RelayCommand<Object>(OsvjeziEventove);
            obrisiNeaktivneKorisnike = new RelayCommand<Object>(ObrisiNeaktivneKorisnike);
            
        }

        async void ucitajIzBaze()
        {
            var ponudeX = await (from p in lokalTabela select p).ToListAsync();
            foreach (DataBaseLokal x in ponudeX)
            {
                dernek.Ponude.Add(new Lokal(x));
                
            }
            int i = ponudeX.Count();
            if (i > 0) Int32.TryParse(ponudeX[i - 1].id, out Lokal.ID);
            Lokal.ID++;
            
            var putovanjaX = await (from p in eventTabela select p).ToListAsync();
            foreach(DataBaseEvent x in putovanjaX)
            {
                dernek.Putovanja.Add(new Event(x));
            }
            i = putovanjaX.Count();
            if(i>0) Int32.TryParse(putovanjaX[i - 1].id, out Event.ID);
            Event.ID++;
            var adminiX = await (from p in administratorTabela select p).ToListAsync();
            foreach (DataBaseAdministrator x in adminiX)
            {
                dernek.Administratori.Add(new Models.Administrator(x));
            }
            i = adminiX.Count();
            if (i > 0) Int32.TryParse(adminiX[i - 1].id, out Models.Administrator.ID);
            else
            {
                dodajAdministratora();
            }
            Models.Administrator.ID++;
            var korisniciX = await (from p in korisniciTabela select p).ToListAsync();
            foreach (DataBaseKorisnik x in korisniciX)
            {
                dernek.Putnici.Add(new Models.Korisnik(x));
            }

            i = korisniciX.Count();
            if (i > 0) Int32.TryParse(korisniciX[i - 1].id, out Korisnik.ID);
            Korisnik.ID++;
        }

        #region Login i Logout administratora

        #region Validacija username i lozinka
        public bool mozeLiLogin()
        {
            int ad = dernek.Administratori.Count(x => x.ImeIprezime == AdminIme);
            if (ad == 0 || String.IsNullOrWhiteSpace(AdminIme))
            {
                PrikaziPoruku("Korisnicko ime nije ispravno!");
                return false;
            }
            Models.Administrator admini = dernek.Administratori.FirstOrDefault(x => x.ImeIprezime == AdminIme);
            if (admini.Lozinka != AdminSifra)
            {
                PrikaziPoruku("Pogresna lozinka!");
                return false;
            }

            return true;
        }


        #endregion

        public void LoginAdministratora(Object o)
        {
            if (mozeLiLogin())
            {
                foreach(Models.Administrator a in dernek.Administratori)
                {
                    if(a.KorisnickoIme == AdminIme && a.Lozinka== AdminSifra)
                    {
                        logovaniAdministrator = a;
                        var frame = (Frame)Window.Current.Content;
                        frame.Navigate(typeof(Administrator), this);
                        //if (logovaniAdministrator.Obavjestenje == "") PrikaziPoruku("Nema obavjestenja!");
                        //else PrikaziPoruku("Obavjestenje: " + logovaniAdministrator.Obavjestenje);
                    }
                }
            }
        }

        public void LogoutAdministratora(Object o)
        {
            On_BackRequested();
        }

        private bool On_BackRequested()
        {
            var frame = (Frame)Window.Current.Content;
            if (frame.CanGoBack)
            {
                frame.GoBack();
                return true;
            }
            return false;
        }

        #endregion
        
        #region Dodavanje/Brisanje/Mijenjanje ponuda

        async public void dodajAdministratora()

        {
            Models.Administrator miran = new Models.Administrator("miran", DateTime.Now, "", 0, "miran", "miran");
            DataBaseAdministrator a1 = new DataBaseAdministrator(miran);
            try
            {
                await administratorTabela.InsertAsync(a1);

            }
            catch (Exception e)
            {
            }
            
            dernek.Administratori.Add(miran);
        }

        async public void DodavanjeLokala(Object o)
        {
            if (validirajDodavanje())
            {
                ponuda = new Lokal(naziv, null, brojDana, planPutovanja, hotel, liveCamera, vremenskaPrognoza,znamenitosti, putaOdrzano);
                
                DataBaseLokal dbPonuda = new DataBaseLokal(ponuda);
                
                try
                {
                    await lokalTabela.InsertAsync(dbPonuda);
                    
                }
                catch (Exception e) {
                    //PrikaziPoruku("Veza sa bazom podataka nije uspjesno uspostavljena! Pokusajte ponovo");
                    //PrikaziPoruku(e.Message.ToString());
                   // OpisPutovanja.ID++;
                }
                dernek.Ponude.Add(ponuda);
                Administrator.o.Add(ponuda);
                await (new MessageDialog("Lokal je uspjesno dodan")).ShowAsync();
                obrisiDodavanje();

            }
        }

        public bool validirajDodavanje()
        {
            if (brojDana <= 0 || String.IsNullOrWhiteSpace(naziv) || String.IsNullOrWhiteSpace(hotel) || String.IsNullOrWhiteSpace(planPutovanja) || String.IsNullOrWhiteSpace(vremenskaPrognoza))
            {
                PrikaziPoruku("Unesite ispravne podatke!");
                return false;
            }
            return true;
        }
        bool azur = false;
        async void BrisanjeLokala(Object o)
        {
            
            if (ponudaZaBrisanje != null)
            {
                Lokal x = new Lokal(ponudaZaBrisanje.Naziv, ponudaZaBrisanje.Slika, ponudaZaBrisanje.BrojDana, ponudaZaBrisanje.PlanPutovanja, ponudaZaBrisanje.Hotel, ponudaZaBrisanje.LiveCamera, ponudaZaBrisanje.VremenskaPrognoza, ponudaZaBrisanje.Znamenitosti, ponudaZaBrisanje.PutaOdrzano);
                var ponudeX = await (from p in lokalTabela where p.id == ponudaZaBrisanje.LokalID.ToString() select p).ToListAsync();
                if (ponudeX.Count == 1)
                {
                    await lokalTabela.DeleteAsync(ponudeX[0]);
                    

                }
                if (!azur)
                {
                    PrikaziPoruku("Lokal " + x.Naziv + " je obrisan!");
                    
                }
                else
                {
                    ponuda = x;
                }
                azur = true;
                dernek.Ponude.Remove(x);
                Administrator.o.Remove(x);
            }
            else
            {
                PrikaziPoruku("Prvo odaberite lokal!");
            }
        }

        void AzuriranjeLokala(Object o)
        {
            if (ponudaZaMijenjanje != null)
            {
                if (!String.IsNullOrWhiteSpace(liveCamera1))
                {
                    ponudaZaMijenjanje.LiveCamera = liveCamera1;
                }
                if (!String.IsNullOrWhiteSpace(vremenskaPrognoza1))
                {
                    ponudaZaMijenjanje.VremenskaPrognoza = vremenskaPrognoza1;
                }
                if (!String.IsNullOrWhiteSpace(znamenitosti1))
                {
                    ponudaZaMijenjanje.Znamenitosti = znamenitosti1;
                }
                if (brojDana1>0 )
                {
                    ponudaZaMijenjanje.BrojDana = brojDana1;
                }
                if (!String.IsNullOrWhiteSpace(naziv1))
                {
                    ponudaZaMijenjanje.Naziv = naziv1;
                }
                if (!String.IsNullOrWhiteSpace(planPutovanja1))
                {
                    ponudaZaMijenjanje.PlanPutovanja = planPutovanja1;
                }
                if (!String.IsNullOrWhiteSpace(hotel1))
                {
                    ponudaZaMijenjanje.Hotel = hotel1;
                }
                azur = true;
                ponudaZaBrisanje = ponudaZaMijenjanje;
                BrisanjeLokala(o);
                ponuda = ponudaZaMijenjanje;
                DodavanjeLokala(o);
                ponuda = ponudaZaBrisanje = ponudaZaMijenjanje = null;
            }
            else
            {
                PrikaziPoruku("Prvo odaberite lokal!");
            }
        }
         void obrisiDodavanje()
        {
            naziv = "";
            brojDana = new Int32();
            planPutovanja = "";
            hotel = liveCamera = vremenskaPrognoza = znamenitosti = "";
        }

        #endregion

        #region Dodavanje/Brisanje putovanja
        async public void DodavanjeEventa(Object o)
        {
            if (validirajEvent())
            {
                event1 = new Event(new List<int>(), polazak, povratak, kapacitet, cijena, opis.LokalID);
                dernek.Putovanja.Add(event1);
                DataBaseEvent put = new DataBaseEvent(event1);
                try
                {
                    await eventTabela.InsertAsync(put);
                    await(new MessageDialog("Event je uspjesno dodan")).ShowAsync();
                }
                catch (Exception e)
                {
                    PrikaziPoruku("Veza sa bazom podataka nije uspjesno uspostavljena! Pokusajte ponovo!");
                }
            }
        }

        public bool validirajEvent()
        {
            if (opis == null)
            {
                PrikaziPoruku("Odaberite jedan od lokala!");
                return false;
            }
            if (polazak < DateTime.Now || polazak > povratak)
            {
                PrikaziPoruku("Odaberite ispravne datume pocetka i kraja!");
                return false;
            }
            if(String.IsNullOrWhiteSpace(strKapacitet) || String.IsNullOrWhiteSpace(strCijena))
            {
                PrikaziPoruku("Upisite ispravan kapacitet ljudi i cijenu ulaznice!");
                return false;
            }
            else
            {
                int kap;
                double cij;
                Int32.TryParse(strKapacitet, out kap);
                Double.TryParse(strCijena, out cij);
                kapacitet = kap;
                cijena = cij;
                if(kapacitet <=0 || cijena <= 0)
                {
                    PrikaziPoruku("Upisite ispravan kapacitet ljudi i cijenu ulaznice!");
                    return false;
                }
            }
            return true;
        }

        void OsvjeziEventove(Object o)
        {
            foreach(Event p in dernek.Putovanja)
            {
                if (p.Polazak < DateTime.Now)
                {
                    ObrisiEvent(p);
                    ponudaZaMijenjanje = dernek.Ponude.FirstOrDefault(x => x.LokalID == p.LokalID);
                    putaOdrzano++;
                    AzuriranjeLokala(o);
                }
            }

        }

        async void ObrisiEvent(Event p)
        {
            dernek.Putovanja.Remove(p);
            var putovanjaX = await (from x in eventTabela where p.EventID.ToString() == x.id select x).ToListAsync();
            if (putovanjaX.Count == 1)
            {
                await eventTabela.DeleteAsync(putovanjaX[0]);
            }
        }
        #endregion

        public void ObrisiNeaktivneKorisnike(Object o)
        {
            
            foreach(Korisnik k in dernek.Putnici)
            {
                if(k.ZadnjeEvent < minZadnjePut)
                {
                    ObrisiPutnika(k);
                }
            }
        }

        async public void ObrisiPutnika(Korisnik k)
        {
            dernek.Putnici.Remove(k);
            var putniciX = await (from x in korisniciTabela where k.KorisnikID.ToString() == x.id select x).ToListAsync();
            if (putniciX.Count == 1)
            {
                await korisniciTabela.DeleteAsync(putniciX[0]);
            }
        }

        async void PrikaziPoruku(string error)
        {
            await new MessageDialog(error).ShowAsync();
        }
    }

}

using ProjekatOOAD.Models.Baza_podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace ProjekatOOAD.Models
{
    public class Lokal
    {
        public static int ID=0;
        private int lokalID;
        private string naziv;
        private BitmapImage slika;
        private int brojDana;
        private string planPutovanja;
        private string hotel;
        private string liveCamera;
        private string vremenskaPrognoza;
        private string znamenitosti;
        private int putaOdrzano;

        public int LokalID { get => lokalID;  }
        public string Naziv { get => naziv; set => naziv = value; }
        public BitmapImage Slika { get => slika; set => slika = value; }
        public int BrojDana { get => brojDana; set => brojDana = value; }
        public string PlanPutovanja { get => planPutovanja; set => planPutovanja = value; }
        public string Hotel { get => hotel; set => hotel = value; }
        public string LiveCamera { get => liveCamera; set => liveCamera = value; }
        public string VremenskaPrognoza { get => vremenskaPrognoza; set => vremenskaPrognoza = value; }
        public string Znamenitosti { get => znamenitosti; set => znamenitosti = value; }
        public int PutaOdrzano { get => putaOdrzano; set => putaOdrzano = value; }

        public Lokal() {  }

        public Lokal(string naziv, BitmapImage slika, int brojDana, string planPutovanja, string hotel, string liveCamera, string vremenskaPrognoza, string znamenitosti, int putaOdrzano)
        {
            lokalID=ID++;
            this.Naziv = naziv;
            this.Slika = slika;
            this.BrojDana = brojDana;
            this.PlanPutovanja = planPutovanja;
            this.Hotel = hotel;
            this.LiveCamera = liveCamera;
            this.VremenskaPrognoza = vremenskaPrognoza;
            this.Znamenitosti = znamenitosti;
            this.PutaOdrzano = putaOdrzano;
        }

        public Lokal(DataBaseLokal p)
        {
            Int32.TryParse(p.id ,out lokalID);
            this.naziv = p.naziv;
            this.brojDana = p.brojDana;
            this.planPutovanja = p.planPutovanja;
            this.hotel = p.hotel;
            this.liveCamera = p.liveCamera;
            this.vremenskaPrognoza = p.vremenskaPrognoza;
            this.znamenitosti = p.znamenitosti;
            this.putaOdrzano = p.putaOdrzano;
        }
    }
}

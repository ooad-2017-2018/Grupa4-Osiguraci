using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models.Baza_podataka
{
    public class DataBaseLokal
    {
        public string id;
        public string naziv;
        public int brojDana;
        public string planPutovanja;
        public string hotel;
        public string liveCamera;
        public string vremenskaPrognoza;
        public string znamenitosti;
        public int putaOdrzano;
        
        
        public DataBaseLokal() { }

        public DataBaseLokal(int lokalID, string naziv, int brojDana, string planPutovanja, string hotel, string liveCamera, string vremenskaPrognoza, string znamenitosti,  int putaOdrzano)
        {
            this.id = lokalID.ToString();
            this.naziv = naziv;
            this.brojDana = brojDana;
            this.planPutovanja = planPutovanja;
            this.hotel = hotel;
            this.liveCamera = liveCamera;
            this.vremenskaPrognoza = vremenskaPrognoza;
            this.znamenitosti = znamenitosti;
            this.putaOdrzano = putaOdrzano;
        }

        public DataBaseLokal(Lokal p)
        {
            this.id = p.LokalID.ToString();
            this.naziv = p.Naziv;
            this.brojDana = p.BrojDana;
            this.planPutovanja = p.PlanPutovanja;
            this.hotel = p.Hotel;
            this.liveCamera = p.LiveCamera;
            this.vremenskaPrognoza = p.VremenskaPrognoza;
            this.znamenitosti = p.Znamenitosti;
            this.putaOdrzano = p.PutaOdrzano;
        }
    }
}

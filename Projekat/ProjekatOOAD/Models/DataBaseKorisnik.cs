using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class DataBaseKorisnik
    {
        public string id;
        public string brojPasosa;
        public bool spol;
        public string brojTelefona;
        public bool obavijesti;
        public bool osiguranje;
        public string putovanja;
        public DateTime zadnjeEvent;
        public string imeIprezime;
        public DateTime datumRodjenja;
        public string email;
        public long jmbg;
        

        public DataBaseKorisnik() { }

        public DataBaseKorisnik(int korisnikID, string brojPasosa, bool spol, string brojTelefona, bool obavijesti, bool osiguranje, string imeIprezime, DateTime datumRodjenja, long jmbg, string email, string putovanja, DateTime zadnjeEvent)
        {
            this.id = korisnikID.ToString();
            this.brojPasosa = brojPasosa;
            this.spol = spol;
            this.brojTelefona = brojTelefona;
            this.obavijesti = obavijesti;
            this.osiguranje = osiguranje;
            this.putovanja = putovanja;
            this.zadnjeEvent = zadnjeEvent;
            this.imeIprezime = imeIprezime;
            this.datumRodjenja = datumRodjenja;
            this.email = email;
            this.jmbg = jmbg;
        }

        public DataBaseKorisnik(Korisnik k)
        {
            this.imeIprezime = k.ImeIprezime;
            this.spol = k.Spol;
            this.email = k.Email;
            this.jmbg = k.Jmbg;
            id = k.KorisnikID.ToString();
            this.brojPasosa = k.BrojPasosa;
            this.brojTelefona = k.BrojTelefona;
            this.obavijesti = k.Obavijesti;
            this.osiguranje = k.Osiguranje;
           
            this.putovanja = "";
            foreach(int i in k.Putovanja)
            {
                putovanja += i.ToString() + " ";
            }
        }
    }
}

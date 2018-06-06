using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class Korisnik: Osoba
    {
        public static int ID=0;
        private int korisnikID;
        private string brojPasosa;
        private bool spol;
        private string brojTelefona;
        private bool obavijesti;
        private bool osiguranje;
        private List<int> putovanja;
        private DateTime zadnjeEvent;

        public int KorisnikID { get => korisnikID;  }
        public string BrojPasosa { get => brojPasosa; set => brojPasosa = value; }
        public bool Spol { get => spol; set => spol = value; }
        public string BrojTelefona { get => brojTelefona; set => brojTelefona = value; }
        public bool Obavijesti { get => obavijesti; set => obavijesti = value; }
        public bool Osiguranje { get => osiguranje; set => osiguranje = value; }
        internal List<int> Putovanja { get => putovanja; set => putovanja = value; }
        public DateTime ZadnjeEvent { get => zadnjeEvent; set => zadnjeEvent = value; }

        public Korisnik() {  }

        public Korisnik(string imeIprezime, DateTime datumRodjenja, string email, long jmbg, string brojPasosa, bool spol, string brojTelefona, bool obavijesti, bool osiguranje, List<int> putovanja):
            base(imeIprezime, datumRodjenja, email, jmbg)
        {
            korisnikID= ID++;
            this.BrojPasosa = brojPasosa;
            this.Spol = spol;
            this.BrojTelefona = brojTelefona;
            this.Obavijesti = obavijesti;
            this.Osiguranje = osiguranje;
            this.Putovanja = putovanja;
        }

        public Korisnik(DataBaseKorisnik k)
        {
            base.ImeIprezime = k.imeIprezime;
            base.DatumRodjenja = k.datumRodjenja;
            base.Jmbg = k.jmbg;
            base.Email = k.email;
            Int32.TryParse(k.id, out korisnikID);
            this.BrojPasosa = k.brojPasosa;
            this.Spol = k.spol;
            this.BrojTelefona = k.brojTelefona;
            this.Obavijesti = k.obavijesti;
            this.Osiguranje = k.osiguranje;
            String[] put = k.putovanja.Split(' ');
            foreach(String x in put)
            {
                int a;
                Int32.TryParse(x, out a);
                Putovanja.Add(a);
            }
        }
    }
}

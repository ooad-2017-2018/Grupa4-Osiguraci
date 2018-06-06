using System;

namespace ProjekatOOAD.Models
{
    public class Osoba
    {
        private string imeIprezime;
        private DateTime datumRodjenja;
        private string email;
        private long jmbg;

        public string ImeIprezime { get => imeIprezime; set => imeIprezime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string Email { get => email; set => email = value; }
        public long Jmbg { get => jmbg; set => jmbg = value; }

        public Osoba() { }

        public Osoba(string imeIprezime, DateTime datumRodjenja, string email, long jmbg)
        {
            this.ImeIprezime = imeIprezime;
            this.DatumRodjenja = datumRodjenja;
            this.Email = email;
            this.Jmbg = jmbg;
        }

        public Osoba(Osoba o)
        {
            this.ImeIprezime = o.ImeIprezime;
            this.DatumRodjenja = o.DatumRodjenja;
            this.Email = o.Email;
            this.Jmbg = o.Jmbg;
        }
    }
}

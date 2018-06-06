using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class DataBaseAdministrator
    {
        public string id;
        public string imeIprezime;
        public DateTime datumRodjenja;
        public string email;
        public long jmbg;
        public string korisnickoIme;
        public string lozinka;
        public string obavjestenje;
        

        public DataBaseAdministrator() { }

        public DataBaseAdministrator(int id ,string imeIprezime, DateTime datumRodjenja, string email, long jmbg, string korisnickoIme, string lozinka) 
            
        {
            this.id = id.ToString();
            this.imeIprezime = imeIprezime;
            this.datumRodjenja = datumRodjenja;
            this.email = email;
            this.jmbg = jmbg;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
        }

        public DataBaseAdministrator(Administrator a)
        {
            id = a.AdminID.ToString();
            imeIprezime = a.ImeIprezime;
            jmbg = a.Jmbg;
            datumRodjenja = a.DatumRodjenja;
            email = a.Email;
            korisnickoIme = a.KorisnickoIme;
            lozinka = a.Lozinka;
        }
    }

}

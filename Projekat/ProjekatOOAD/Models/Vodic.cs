using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    class Vodic: Osoba
    {
        private static int ID = 0;
        private int vodicID;
        private List<Event> putovanja;
        private double plata;

        public int VodicID { get => vodicID;  }
        internal List<Event> Putovanja { get => putovanja; set => putovanja = value; }
        public double Plata { get => plata; set => plata = value; }

        public Vodic() { }

        public Vodic(string imeIprezime, DateTime datumRodjenja, string email, long jmbg, List<Event> putovanja, double plata):
            base(imeIprezime, datumRodjenja, email, jmbg)
        {
            vodicID=ID++;
            this.Putovanja = putovanja;
            this.Plata = plata;
        }

        public Vodic(Vodic v)
        {
            vodicID = v.VodicID;
            this.Putovanja = v.Putovanja;
            this.Plata = v.Plata;
        }

    }
}

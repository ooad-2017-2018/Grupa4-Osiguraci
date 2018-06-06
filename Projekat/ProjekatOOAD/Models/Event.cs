using ProjekatOOAD.Models.Baza_podataka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models
{
    public class Event
    {
        public static int ID = 0;
        private int eventID;
        private List<int> putnici;
        private DateTime polazak;
        private DateTime povratak;
        private int kapacitet;
        private double cijena;
        private int lokalID;

        public int EventID { get => EventID;  }
        public List<int> Putnici { get => putnici; set => putnici = value; }
        public DateTime Polazak { get => polazak; set => polazak = value; }
        public DateTime Povratak { get => povratak; set => povratak = value; }
        public int Kapacitet { get => kapacitet; set => kapacitet = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public int LokalID { get => lokalID; set => lokalID = value; }

        public Event() { }

        public Event(List<int> putnici, DateTime polazak, DateTime povratak, int kapacitet, double cijena, int lokalID)
        {
            eventID = ID++;
            this.Putnici = putnici;
            this.Polazak = polazak;
            this.Povratak = povratak;
            this.Kapacitet = kapacitet;
            this.Cijena = cijena;
            this.LokalID = lokalID;
        }

        public Event(DataBaseEvent p)
        {
            Int32.TryParse(p.id , out eventID);
            String[] a = p.putnici.Split(' ');
            foreach(String b in a)
            {
                int l;
                Int32.TryParse(b, out l);
                Putnici.Add(l);
            }
            this.Polazak = p.polazak;
            this.Povratak = p.povratak;
            this.Kapacitet = p.kapacitet;
            this.Cijena = p.cijena;
            this.LokalID = p.lokalID;
        }
    }
}

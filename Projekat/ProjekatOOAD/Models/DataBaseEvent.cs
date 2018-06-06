using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatOOAD.Models.Baza_podataka
{
    public class DataBaseEvent
    {
        public string id;
        public string putnici;
        public DateTime polazak;
        public DateTime povratak;
        public int kapacitet;
        public double cijena;
        public int lokalID;

        public DataBaseEvent() { }

        public DataBaseEvent(int EventID, string putnici, DateTime polazak, DateTime povratak, int kapacitet, double cijena, int lokalID)
        {
            this.id = EventID.ToString();
            this.putnici = putnici;
            this.polazak = polazak;
            this.povratak = povratak;
            this.kapacitet = kapacitet;
            this.cijena = cijena;
            this.lokalID = lokalID;
        }

        public DataBaseEvent(Event p)
        {
            this.id = p.EventID.ToString();
            this.putnici = "";
            foreach (int i in p.Putnici)
            {
                putnici += i.ToString() + " " ;
            }
            
            this.polazak = p.Polazak;
            this.povratak = p.Povratak;
            this.kapacitet = p.Kapacitet;
            this.cijena = p.Cijena;
            this.lokalID = p.LokalID;
        }

        
    }
}

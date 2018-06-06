using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Dernek.Models
{
    public class Dernek
    {
        [Key]
        public int IDDerneka { get; set; }
        public int IDLokala { get; set; }
        public int Kapacitet { get; set; }
        public string Naziv { get; set; }
        public string Slika { get; set; }
    }
}
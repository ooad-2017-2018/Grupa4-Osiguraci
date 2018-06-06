using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Dernek.Models
{
    public class Lokal
    {
        [Key]
        public int IDLokala { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Broj { get; set; }

    }
}
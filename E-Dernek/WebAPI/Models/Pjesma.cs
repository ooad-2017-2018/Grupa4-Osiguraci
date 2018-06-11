using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Pjesma
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string ImeMuzicara { get; set; } 
    }
}
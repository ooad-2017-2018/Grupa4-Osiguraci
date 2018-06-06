using E_Dernek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Dernek.Controllers
{
    public class DernekController : Controller
    {
        DataBaseContext db = new DataBaseContext();

        // GET: Ponude
        public ActionResult Index()
        {
            return View(db.Dernek.ToList());
        }
        public string vratiIme(string id)
        {
            string ime = string.Empty;
            int x;
            Int32.TryParse(id, out x);
            Dernek dernek = db.Dernek.Find(x);
            if (dernek != null)
            {
                ime = dernek.Naziv;
            }
            return ime;
        }

        public string vratiSliku(string id)
        {
            string slika = string.Empty;
            int x;
            Int32.TryParse(id, out x);
            Dernek dernek = db.Dernek.Find(x);
            if (dernek != null)
            {
                slika = dernek.Slika;
            }
            return slika;
        }
    }
}
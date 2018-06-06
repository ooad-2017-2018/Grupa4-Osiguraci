using E_Dernek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Dernek.Controllers
{
    public class AboutController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        // GET: About
        public ActionResult InfoDernek(int id)
        {
            Dernek model = db.Dernek.Find(id);
            return View(model);
        }
        public string rezervacija1(int id)
        {
            if(Dernek.SpremiRezervaciju(id))
                return "Uspjesno izvrsena rezervacija!";
            return "Nije uspjelo";
        }
    }
}
using E_Dernek.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace E_Dernek.Controllers
{
    public class AboutController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        SoundPlayer uspjeh, neuspjeh;
        // GET: About
        public ActionResult InfoDernek(int id)
        {
            Dernek model = db.Dernek.Find(id);
            return View(model);
        }
        public string rezervacija1(int id)
        {
            if (Dernek.SpremiRezervaciju(id))
            {
                //if (uspjeh == null)
                //    uspjeh = new SoundPlayer(Url.Content(@"./Potvrda.wav"));
                //uspjeh.Play();    
                return "Uspjesno izvrsena rezervacija!";
                //return //("Potvrda.wav");
            }
            return "Nije uspjelo";
        }
    }
}
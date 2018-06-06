using E_Dernek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Dernek.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        public ActionResult Index()
        {
            /*
            var ID1 = db.Lokal.ToList();
            int id1 = ID1.Count();
            Lokal lok = new Lokal();
            lok.IDLokala = id1;
            lok.Naziv = "My Face";
            lok.Adresa = "Vilsonovo";
            lok.Broj = "033 299 299";
            db.Lokal.Add(lok);
            
            var samoZaID = db.Dernek.ToList();
            int id = samoZaID.Count();
            Dernek p = new Dernek();
            p.IDDerneka = id;
            p.Naziv = "Aca Lukas - My Face";
            p.IDLokala = id1;
            p.Kapacitet = 100;
            p.Slika = "https://expresstabloid.ba/wp-content/uploads/2018/03/DSC_0042-1.jpg";
            db.Dernek.Add(p);

            var ID2 = db.Lokal.ToList();
            int id2 = ID2.Count();
            Lokal lok1 = new Lokal();
            lok1.IDLokala = id2;
            lok1.Naziv = "Cinemas Club SLOGA";
            lok1.Adresa = "Centar";
            lok1.Broj = "033 400 299";
            db.Lokal.Add(lok1);

            var samoZaID1 = db.Dernek.ToList();
            int id3 = samoZaID1.Count();
            Dernek p1 = new Dernek();
            p1.IDDerneka = id3;
            p1.Naziv = "Severina - Cinemas Club SLOGA";
            p1.IDLokala = id2;
            p1.Kapacitet = 70;
            p.Slika = "https://www.zadar.travel/images/original/Severina_1311711241.jpg";
            db.Dernek.Add(p1);
            db.SaveChanges();*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View(db.Dernek.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
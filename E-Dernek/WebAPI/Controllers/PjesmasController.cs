using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PjesmasController : ApiController
    {
        // GET: Pjesma
        Pjesma[] pjesmas = new Pjesma[]
        {
            new Pjesma { ID = 1, Naziv = "Voliš li me", ImeMuzicara = "Aca Lukas" },
            new Pjesma { ID = 3, Naziv = "Tarapana", ImeMuzicara = "Severina" },
            new Pjesma { ID = 4, Naziv = "Sve bi ja i ti", ImeMuzicara = "Saša Matić" },
            new Pjesma { ID = 2, Naziv = "La Martina", ImeMuzicara = "Jala Brat" },
            new Pjesma { ID = 5, Naziv = "Opasno", ImeMuzicara = "Buba Corelli" },
            new Pjesma { ID = 6, Naziv = "Tokio Drift", ImeMuzicara = "KVSH" }
        };
        public IEnumerable<Pjesma> GetAllPjesmas()
        {

            return pjesmas;
        }
        public IHttpActionResult GetPjesma(int id)
        {
            var product = pjesmas.FirstOrDefault((p) => p.ID == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}
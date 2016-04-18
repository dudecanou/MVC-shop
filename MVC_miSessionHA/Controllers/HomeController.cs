using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_miSessionHA.Controllers
{
    public class HomeController : Controller
    {
        private produitModel db = new produitModel();
        
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Consultation(string nom)
        {
            ViewBag.nomMarque = nom;
            ViewBag.Message = "Voici les Skateboard de la marque";
            int uneMarqueID = db.Marques.Single(x => x.Nom == nom).MarqueID;
            var lesSkates = db.Skateboards.Where(x => x.MarqueID == uneMarqueID).Select(c => c);
            var e = lesSkates.AsEnumerable();


            return View(e.ToList());
        }
        [Authorize]
        public ActionResult ListeMarques()
        {
            ViewBag.Message = "Liste";

            return View(db.Marques.ToList());
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agregation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReservationVoiture()
        {
            ViewBag.Message = "Ici, réservez le véhicule de vos rêves !";

            return View();
        }

        public ActionResult ReservationVol()
        {
            ViewBag.Message = "Ici, réservez un vol vers la destination de vos rêves !";

            return View();
        }

        public ActionResult ReservationHotel()
        {
            ViewBag.Message = "Ici, réservez l'hôtel de vos rêves !";

            return View();
        }
    }
}
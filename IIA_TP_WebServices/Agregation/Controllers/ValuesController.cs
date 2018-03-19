using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Agregation.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/infosAgregation
        [HttpGet]
        public string Get()
        {
            return " Liste de voiture : api/car/list?user=X&pass=Y \n Infos voiture : api/car/infos?user=X&pass=Y&voitureId=Z \n Réservation voiture : api/car/booking?user=X&pass=Y&dateResaStart=A&dateResaEnd=B&voitureId=C";
        }
    }
}

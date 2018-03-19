using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agregation.ReservationVoiture;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServices.ReservationVoiture.Soap;
using WebServices.ReservationVoiture.Soap.Messages;

namespace Agregation.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    public class ReservationController : Controller
    {
        // GET api/infosAgregation
        [HttpGet]
        public string Get()
        {
            var value = " Liste de voiture : /car/list?user=X&pass=Y " +
                        "\n Infos voiture : /car/infos?user=X&pass=Y&voitureId=Z " +
                        "\n Réservation voiture : /car/booking?user=X&pass=Y&dateResaStart=A&dateResaEnd=B&voitureId=C";

            return value;
        }

        #region Réservation de voitures
        [Route("car/list")]
        public List<BaseVoiture> call_GetVoitures_ws(string user, string pass)
        {
            if (user != null && pass != null)
            {
                MessageRequest request = new MessageRequest();
                CarService_ThyDy service = new CarService_ThyDy();
                request.Username = user;
                request.Password = pass;
                MessageResponse response = service.GetListeVoitures(request);
                return response.ListeVoitures;
            }
            else
                return new List<BaseVoiture>();
        }

        [Route("car/infos")]
        public BaseVoiture call_GetInfosVoiture_ws(string user, string pass, int voitureId)
        {
            if (user != null && pass != null)
            {
                MessageRequestInfo request = new MessageRequestInfo();
                CarService_ThyDy service = new CarService_ThyDy();
                request.Username = user;
                request.Password = pass;
                request.VoitureId = voitureId;
                MessageResponseInfo response = service.GetVoiture(request);
                return response.Voiture;
            }
            else
                return new BaseVoiture();
        }
        [Route("car/booking")]
        public bool call_ReserverVoiture_ws(string user, string pass, string dateResaStart, string dateResaEnd, int voitureId)
        {
            if (user != null && pass != null)
            {
                MessageRequestResa request = new MessageRequestResa();
                CarService_ThyDy service = new CarService_ThyDy();
                request.Username = user;
                request.Password = pass;
                request.DateResaStart = DateTime.Parse(dateResaStart);
                request.DateResaEnd = DateTime.Parse(dateResaEnd);
                request.VoitureId = voitureId;
                MessageResponseResa response = service.BookingVoiture(request);
                return response.Reservee;
            }
            else
                return false;
        }
        #endregion
    }
}
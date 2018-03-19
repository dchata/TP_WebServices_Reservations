using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agregation.ReservationVoiture;
using Agregation.ReservationVol;
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
            var value = " Liste de voitures : /car/list?user=X&pass=Y " +
                        "\n Infos voiture : /car/infos?user=X&pass=Y&voitureId=Z " +
                        "\n Réservation voiture : /car/booking?user=X&pass=Y&dateResaStart=A&dateResaEnd=B&voitureId=C" +
                        "\n\n Liste de voitures 2 : /car2/list?" +
                        "\n Réservation voiture 2 : /car2/booking?" +
                        //Vols
                        "\n\n Liste de vols : /vol/list?allFlights=bool&start=X&end=Y" +
                        "\n Réservation vol : /vol/booking" +
                        "\n\n Liste de vols 2 : /vol/list ? " +
                        "\n Réservation vol 2 : /vol/booking" +
                        //Hôtels
                        "\n\n Liste d'hôtels : /hotel/list?" +
                        "\n Réservation hôtels : /hotel/booking" +
                        "\n\n Liste d'hôtels 2 : /hotel2/list ? " +
                        "\n Réservation hôtels 2 : /hotel2/booking";

            return value;
        }

        #region Réservation de voitures
        [Route("car/list")]
        public object call_GetVoitures_ws(string user, string pass)
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
                return "Merci de saisir un identifiant et un mot de passe";
        }

        [Route("car/infos")]
        public object call_GetInfosVoiture_ws(string user, string pass, int voitureId)
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
                return "Merci de saisir un identifiant et un mot de passe";
        }

        [Route("car/booking")]
        public object call_ReserverVoiture_ws(string user, string pass, string dateResaStart, string dateResaEnd, int voitureId)
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
                return "Merci de saisir un identifiant et un mot de passe";
        }

        [Route("car2/list")]
        public object call_GetVoitures2_ws()
        {
            return false;
        }

        [Route("car2/booking")]
        public object call_ReserverVoitures2_ws()
        {
            return false;
        }
        #endregion

        #region Réservation de vols
        [Route("vol/list")]
        public object call_GetVols_ws(bool allFlights, string start, string end)
        {
            FlyService_DoJM service = new FlyService_DoJM();
            service.GetVols(allFlights, DateTime.Parse(start), DateTime.Parse(end));
            return false;
        }

        [Route("vol/booking")]
        public object call_ReserverVols_ws()
        {
            return false;
        }

        [Route("vol2/list")]
        public object call_GetVols2_ws()
        {
            return false;
        }

        [Route("vol2/booking")]
        public object call_ReserverVols2_ws()
        {
            return false;
        }
        #endregion

        #region Réservation d'hôtels
        [Route("hotel/list")]
        public object call_GetHotels_ws()
        {
            return false;
        }

        [Route("hotel/booking")]
        public object call_ReserverHotel_ws()
        {
            return false;
        }

        [Route("hotel2/list")]
        public object call_GetHotel2_ws()
        {
            return false;
        }

        [Route("hotel2/booking")]
        public object call_ReserverHotel2_ws()
        {
            return false;
        }
        #endregion
    }
}
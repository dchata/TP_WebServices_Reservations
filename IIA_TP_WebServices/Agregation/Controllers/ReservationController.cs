using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agregation.ReservationHotel;
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
            var value = " Liste de voitures : /car/list?user=string&pass=string" +
                        "\n Infos voiture : /car/infos?user=string&pass=string&voitureId=int " +
                        "\n Réservation voiture : /car/booking?user=string&pass=string&dateResaStart=YYYY-MM-DD&dateResaEnd=YYYY-MM-DD&voitureId=int" +
                        //Vols
                        "\n\n Liste de vols : /vol/list?allFlights=bool&start=YYYY-MM-DD&end=YYY-MM-DD" +
                        "\n Détails d'un vol : /vol/details?vol=int" +
                        "\n Réservation vol : /vol/booking?idBooking=int&lastName=string&firstName=string&places=int" +
                        //Hôtels
                        "\n\n Liste d'hôtels : /hotel/list?dateDebut=YYYY-MM-DD&dateFin=YYYY-MM-DD" +
                        "\n Détails d'un hôtel : /hotel/details?hotel=int" +
                        "\n Liste des réservation d'un hôtel : /hotel/reservationsListe?hotel=int&dateResa=YYYY-MM-DD" +
                        "\n Réservation hôtels : /hotel/booking";

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

                var content = "";

                foreach (var item in response.ListeVoitures)
                {
                    content += $"{item.id}-{item.modele}\n";
                }

                return content;
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

                var infos = $"Modèle : {response.Voiture.modele} \n" +
                            $"Agence : {response.Voiture.agence.nom} \n" +
                            $"Date de dispo début : {response.Voiture.dateDispoStart.ToShortDateString()} \n" +
                            $"Date de dispo fin : {response.Voiture.dateDispoEnd.ToShortDateString()} \n";

                return infos;
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

                var reservation = $"{response.message}";

                return reservation;
            }
            else
                return "Merci de saisir un identifiant et un mot de passe";
        }
        #endregion

        #region Réservation de vols
        [Route("vol/list")]
        public object call_GetVols_ws(bool allFlights, string start, string end)
        {
            FlyService_DoJM service = new FlyService_DoJM();
            var response = service.GetVols(allFlights, DateTime.Parse(start), DateTime.Parse(end));
            return response;
        }

        [Route("vol/details")]
        public object call_DetailsVol_ws(int vol)
        {
            FlyService_DoJM service = new FlyService_DoJM();
            var response = service.GetDetails(vol);
            return response;
        }

        [Route("vol/booking")]
        public object call_ReserverVols_ws(int idBooking,string lastName, string firstName,int places)
        {
            FlyService_DoJM service = new FlyService_DoJM();
            var response = service.ReservationVol(idBooking ,lastName,firstName,places);
            return response;
        }
        #endregion

        #region Réservation d'hôtels
        [Route("hotel/list")]
        public object call_GetHotels_ws(string dateDebut, string dateFin)
        {
            HostelService_FaFlo service = new HostelService_FaFlo();
            var response = service.GetHotels(DateTime.Parse(dateDebut), DateTime.Parse(dateFin));
            return response;
        }

        [Route("hotel/details")]
        public object call_DetailsHotels_ws(int hotel)
        {
            HostelService_FaFlo service = new HostelService_FaFlo();
            var response = service.GetDetails(hotel);
            return response;
        }

        [Route("hotel/reservationsListe")]
        public object call_ReservationsHotels_ws(int hotel, string dateResa)
        {
            //HostelService_FaFlo service = new HostelService_FaFlo();
            //var response = service.GetReservations(hotel, dateResa);
            //return response;

            return "Méthode non terminée";
        }

        [Route("hotel/booking")]
        public object call_ReserverHotel_ws()
        {
            return false;
        }
        #endregion
    }
}
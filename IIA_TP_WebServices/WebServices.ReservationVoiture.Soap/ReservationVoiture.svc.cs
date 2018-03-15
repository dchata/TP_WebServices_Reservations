using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebServices.ReservationVoiture.Soap.Messages;

namespace WebServices.ReservationVoiture.Soap
{

    public class Service1 : IVoiture
    {
        private string user = "web";
        private string pass = "services";

        public MessageResponse GetVoitures(MessageRequest messageRequest)
        {
            MessageResponse messageResponse = new MessageResponse();
            if (messageRequest.Username == user && messageRequest.Password == pass)
            {
                List<BaseVoiture> voitures = new List<BaseVoiture>();
                var baseVoiture = new BaseVoiture();
                voitures = baseVoiture.GetBaseVoitures();
                voitures = voitures.Where(v => v.diponible == true && v.dateDispoStart <= messageRequest.DateResaStart && v.dateDispoEnd > messageRequest.DateResaEnd && v.type == messageRequest.Type && v.agence.id == messageRequest.Agence).ToList();

                if (voitures.Any())
                    messageResponse.ListeVoitures = voitures;
                else
                    messageResponse.message = "Aucunes voitures ne correspondent aux paramètres saisis !";

            }
            else
                messageResponse.message = "Erreur lors de la connexion";

            return messageResponse;
        }

        public MessageResponseInfo GetInfosVoiture(MessageRequestInfo messageRequest)
        {
            MessageResponseInfo messageResponse = new MessageResponseInfo();
            if (messageRequest.Username == user && messageRequest.Password == pass)
            {
                var baseVoiture = new BaseVoiture();
                var voitures = baseVoiture.GetBaseVoitures();
                messageResponse.Voiture = voitures.Where(v => v.id == messageRequest.VoitureId).FirstOrDefault();

                if (messageResponse.Voiture == null)
                    messageResponse.message = "Aucune voiture ne correspond à l'id saisit !";
            }
            else
                messageResponse.message = "Erreur lors de la connexion";

            return messageResponse;
        }

        public MessageResponseResa ReserverVoiture(MessageRequestResa messageRequest)
        {
            MessageResponseResa messageResponse = new MessageResponseResa();
            if (messageRequest.Username == user && messageRequest.Password == pass)
            {
                var baseVoiture = new BaseVoiture();
                var voitures = baseVoiture.GetBaseVoitures();
                messageResponse.Reservee = false;

                foreach (var item in voitures)
                {
                    if (item.diponible == true && item.agence.id == messageRequest.Agence && item.id == messageRequest.VoitureId && item.dateDispoStart <= messageRequest.DateResaStart && item.dateDispoEnd > messageRequest.DateResaEnd)
                    {
                        messageResponse.Reservee = true;
                        break;
                    }
                }

                if (messageResponse.Reservee == false)
                    messageResponse.message = "La réservation n'a pas pu avoir lieu. Vérifiez votre saisie !";
            }
            else
                messageResponse.message = "Erreur lors de la connexion";

            return messageResponse;
        }
    }
}

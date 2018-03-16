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

    public class CarService : IVoiture
    {
        #region Properties
        //Définit le username et le password pour pouvoir accéder aux méthodes
        private string user = "web";
        private string pass = "services";
        #endregion

        #region Methods
        public MessageResponse GetVoitures(MessageRequest messageRequest)
        {
            MessageResponse messageResponse = new MessageResponse();
            if (messageRequest.Username == user && messageRequest.Password == pass) //Vérification des informations saisies vs infomations définies
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

            return messageResponse; // Retourne une instance de la classe MessageResponse qui contient une liste de voitures
        }

        public MessageResponseInfo GetInfosVoiture(MessageRequestInfo messageRequest)
        {
            MessageResponseInfo messageResponse = new MessageResponseInfo();
            if (messageRequest.Username == user && messageRequest.Password == pass) //Vérification des informations saisies vs infomations définies
            {
                var baseVoiture = new BaseVoiture();
                var voitures = baseVoiture.GetBaseVoitures();
                messageResponse.Voiture = voitures.Where(v => v.id == messageRequest.VoitureId).FirstOrDefault();

                if (messageResponse.Voiture == null)
                    messageResponse.message = "Aucune voiture ne correspond à l'id saisit !";
                else
                    messageResponse.message = "Connexion OK";
            }
            else
                messageResponse.message = "Erreur lors de la connexion";

            return messageResponse; // Retourne une instance de la classe MessageResponseInfo qui contient une voiture avec toutes ses informations
        }

        public MessageResponseResa ReserverVoiture(MessageRequestResa messageRequest)
        {
            MessageResponseResa messageResponse = new MessageResponseResa();
            if (messageRequest.Username == user && messageRequest.Password == pass) //Vérification des informations saisies vs infomations définies
            {
                var baseVoiture = new BaseVoiture();
                var voitures = baseVoiture.GetBaseVoitures();
                messageResponse.Reservee = false;

                foreach (var item in voitures)
                {
                    if (item.diponible == true && item.agence.id == messageRequest.Agence && item.id == messageRequest.VoitureId && item.dateDispoStart <= messageRequest.DateResaStart && item.dateDispoEnd > messageRequest.DateResaEnd)
                    {
                        messageResponse.Reservee = true;
                        baseVoiture = item;
                        break;
                    }
                }

                if (messageResponse.Reservee == false)
                    messageResponse.message = "La réservation n'a pas pu avoir lieu. Vérifiez votre saisie !";
                else
                    messageResponse.message = $"Vous avez réservé la {baseVoiture.modele} pour les dates du {messageRequest.DateResaStart.ToShortDateString()} au {messageRequest.DateResaEnd.ToShortDateString()}";
            }
            else
                messageResponse.message = "Erreur lors de la connexion";

            return messageResponse; // Retourne une instance de la classe MessageResponseResa qui contient un boolean pour dire si la voiture a été reservée ou non
        }
        #endregion
    }
}

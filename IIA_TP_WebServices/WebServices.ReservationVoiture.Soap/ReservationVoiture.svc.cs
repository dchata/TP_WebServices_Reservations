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
        private BaseVoiture _BaseVoitures = new BaseVoiture(true);
        #endregion

        #region Accesseur
        public BaseVoiture BaseVoitures
        {
            get { return _BaseVoitures; }
            set { _BaseVoitures = value; }
        }
        #endregion

        #region Methods
        public MessageResponse GetVoitures(MessageRequest messageRequest)
        {
            MessageResponse messageResponse = new MessageResponse();
            BaseUtilisateur user = new BaseUtilisateur();
            List<BaseUtilisateur> users = user.GetBaseUtilisateur();
            if (users.Select(u => u.Username == messageRequest.Username && u.Password == messageRequest.Password).FirstOrDefault() ) //Vérification des informations saisies vs infomations définies
            {
                List<BaseVoiture> voitures = new List<BaseVoiture>();
                voitures = BaseVoitures.ListeVoiture;
                voitures = voitures.Where(v => v.diponible == true).ToList();

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

            BaseUtilisateur user = new BaseUtilisateur();
            List<BaseUtilisateur> users = user.GetBaseUtilisateur();
            if (users.Select(u => u.Username == messageRequest.Username && u.Password == messageRequest.Password).FirstOrDefault()) //Vérification des informations saisies vs infomations définies
            {
             
                var voitures = BaseVoitures.ListeVoiture;
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
            BaseUtilisateur user = new BaseUtilisateur();
            List<BaseUtilisateur> users = user.GetBaseUtilisateur();
            if (users.Select(u => u.Username == messageRequest.Username && u.Password == messageRequest.Password).FirstOrDefault()) //Vérification des informations saisies vs infomations définies
            {
                var baseVoiture = new BaseVoiture();
                var voitures = BaseVoitures.ListeVoiture;
                messageResponse.Reservee = false;

                foreach (var item in voitures)
                {
                    if (item.diponible == true && item.id == messageRequest.VoitureId && item.dateDispoStart <= messageRequest.DateResaStart && item.dateDispoEnd > messageRequest.DateResaEnd)
                    {
                        messageResponse.Reservee = true;
                        baseVoiture = item;
                        Reservation reservation = new Reservation(item.id, messageRequest.Username, messageRequest.DateResaStart, messageRequest.DateResaEnd);
                        break;
                    }
                }

                if (messageResponse.Reservee == false)
                    messageResponse.message = "La réservation n'a pas pu avoir lieu. Vérifiez les dates ou l'id de la voiture !";
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

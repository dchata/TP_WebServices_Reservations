using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebServices.ReservationVoiture.Soap.Messages
{
    [MessageContract]
    public class MessageResponse //Les champs qui sont retournés suite à l'appel de la méthode de récupérations de voitures
    {
        [MessageBodyMember]
        public List<BaseVoiture> ListeVoitures;

        [MessageBodyMember]
        public string message;
    }

    [MessageContract]
    public class MessageResponseInfo //Les champs retournés suite à une demande d'informations sur une voiture
    {
        [MessageBodyMember]
        public BaseVoiture Voiture;
        [MessageBodyMember]
        public string message;
    }

    [MessageContract]
    public class MessageResponseResa //Les champs retourné suite à une demande de réservation sur une voiture
    {
        [MessageBodyMember]
        public bool Reservee;
        [MessageBodyMember]
        public string message;
    }
}
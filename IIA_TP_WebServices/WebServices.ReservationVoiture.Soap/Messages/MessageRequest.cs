using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebServices.ReservationVoiture.Soap.Messages
{
    //MessageHeader Username / Password nous permettent de sécuriser l'api SOAP

    [MessageContract]
    public class MessageRequest //Les champs requis pour la méthodes lister les voitures
    {
        [MessageHeader]
        public string Username;
        [MessageHeader]
        public string Password;
        [MessageBodyMember]
        public DateTime DateResaStart;
        [MessageBodyMember]
        public DateTime DateResaEnd;
        [MessageBodyMember]
        public BaseVoiture.TypeVoiture Type;
        [MessageBodyMember]
        public int Agence;
    }

    [MessageContract]
    public class MessageRequestResa //Les champs requis pour la méthode de réservations
    {
        [MessageHeader]
        public string Username;
        [MessageHeader]
        public string Password;
        [MessageBodyMember]
        public DateTime DateResaStart;
        [MessageBodyMember]
        public DateTime DateResaEnd;
        [MessageBodyMember]
        public BaseVoiture.TypeVoiture Type;
        [MessageBodyMember]
        public int Agence;
        [MessageBodyMember]
        public int VoitureId;
    }

    [MessageContract]
    public class MessageRequestInfo //Les champs requis pour la méthode de récupération des infos sur une voiture
    {
        [MessageHeader]
        public string Username;
        [MessageHeader]
        public string Password;
        [MessageBodyMember]
        public int VoitureId;
    }


}
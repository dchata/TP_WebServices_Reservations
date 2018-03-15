using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebServices.ReservationVoiture.Soap.Messages
{
    [MessageContract]
    public class MessageResponse
    {
        [MessageBodyMember]
        public List<BaseVoiture> ListeVoitures;

        [MessageBodyMember]
        public string message;
    }

    [MessageContract]
    public class MessageResponseInfo
    {
        [MessageBodyMember]
        public BaseVoiture Voiture;
        [MessageBodyMember]
        public string message;
    }

    [MessageContract]
    public class MessageResponseResa
    {
        [MessageBodyMember]
        public bool Reservee;
        [MessageBodyMember]
        public string message;
    }
}
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
    }

    [MessageContract]
    public class MessageResponseInfo
    {
        [MessageBodyMember]
        public BaseVoiture Voiture;
    }

    [MessageContract]
    public class MessageResponseResa
    {
        [MessageBodyMember]
        public bool Reservee;
    }
}
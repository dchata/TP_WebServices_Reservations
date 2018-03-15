using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebServices.ReservationVoiture.Soap.Messages
{
    [MessageContract]
    public class MessageRequest
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
    public class MessageRequestResa
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
    public class MessageRequestInfo
    {
        [MessageHeader]
        public string Username;
        [MessageHeader]
        public string Password;
        [MessageBodyMember]
        public int VoitureId;
    }


}
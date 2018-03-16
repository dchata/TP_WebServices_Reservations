using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using WebServices.ReservationVoiture.Soap.Messages;

namespace WebServices.ReservationVoiture.Soap
{
    [ServiceContract]
    interface IVoiture //Notre interface pour modèle de la classe Service1
    {
        [OperationContract]
        MessageResponse GetVoitures(MessageRequest messageRequest); //Méthode implémentée dans Service1 nous permettant de récupérer une liste de voiture

        [OperationContract]
        MessageResponseInfo GetInfosVoiture(MessageRequestInfo messageRequestInfo); //Méthode implémentée dans Service1 nous permettant de récupérer les informations sur une voiture

        [OperationContract]
        MessageResponseResa ReserverVoiture(MessageRequestResa messageRequestResa); //Méthode implémentée dans Service1 nous permettant de réserver une voiture
    }
}

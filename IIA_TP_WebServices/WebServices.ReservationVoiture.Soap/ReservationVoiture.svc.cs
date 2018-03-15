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

        public MessageResponse GetVoitures(MessageRequest messageRequest)
        {
            MessageResponse messageResponse = new MessageResponse();
            if (messageRequest.Username =="web" && messageRequest.Password == "services")
            {
                List<BaseVoiture> voitures = new List<BaseVoiture>();
                var baseVoiture = new BaseVoiture();
                voitures = baseVoiture.GetBaseVoitures();
                voitures = voitures.Where(v => v.diponible == true && v.dateDispoStart <= messageRequest.DateResaStart && v.dateDispoEnd > messageRequest.DateResaEnd && v.type == messageRequest.Type && v.agence.id == messageRequest.Agence).ToList();
                messageResponse.ListeVoitures = voitures;
            }
            return messageResponse;
        }

        public MessageResponseInfo GetInfosVoiture(MessageRequestInfo messageRequest)
        {
            MessageResponseInfo messageResponse = new MessageResponseInfo();
            var baseVoiture = new BaseVoiture();
            var voitures = baseVoiture.GetBaseVoitures();
            messageResponse.Voiture= voitures.Where(v => v.id == messageRequest.VoitureId).FirstOrDefault();
            return messageResponse;
        }

        public MessageResponseResa ReserverVoiture(MessageRequestResa messageRequest)
        {
            MessageResponseResa messageResponse = new MessageResponseResa();
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

            //Commenté car a fonctionné mais ne fonctionne plus, d'où le foreach
            //var voitureReservee = voitures.Select(v => v.id == voitureId && v.agence.id == agence && v.diponible == true && v.dateDispoStart <= dateResaStart && v.dateDispoEnd > dateResaEnd).FirstOrDefault();
            return messageResponse;
        }
    }
}

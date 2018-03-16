using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServices.ReservationVoiture.Soap;
using WebServices.ReservationVoiture.Soap.Messages;

namespace Agregation.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class ReservationController : Controller
    {
        CarService svc_car = new CarService();
        [Route("car/list")]
        public MessageResponse call_GetVoitures_ws(string user,string pass/*,string dateResaStart, string dateResaEnd, BaseVoiture.TypeVoiture type, int agence*/)
        {
            MessageRequest request = new MessageRequest();
            request.Username = user;
            request.Password = pass;
            /*request.DateResaStart = DateTime.Parse(dateResaStart);
            request.DateResaEnd = DateTime.Parse(dateResaEnd);
            request.Type = type;
            request.Agence = agence;*/
            MessageResponse response = svc_car.GetVoitures(request);
            return response;
        }

        [Route("car/infos")]
        public MessageResponseInfo call_GetInfosVoiture_ws(string user, string pass, int voitureId)
        {
            MessageRequestInfo request = new MessageRequestInfo();
            request.Username = user;
            request.Password = pass;
            request.VoitureId = voitureId;
            MessageResponseInfo response = svc_car.GetInfosVoiture(request);
            return response;
        }
        [Route("car/booking")]
        public MessageResponseResa call_ReserverVoiture_ws(string user, string pass, string dateResaStart, string dateResaEnd/*, BaseVoiture.TypeVoiture type, int agence*/, int voitureId)
        {
            MessageRequestResa request = new MessageRequestResa();
            request.Username = user;
            request.Password = pass;
            request.DateResaStart = DateTime.Parse(dateResaStart);
            request.DateResaEnd = DateTime.Parse(dateResaEnd);
            /*request.Type = type;
            request.Agence = agence;*/
            request.VoitureId = voitureId;
            MessageResponseResa response = svc_car.ReserverVoiture(request);
            return response;
        }

    }
}
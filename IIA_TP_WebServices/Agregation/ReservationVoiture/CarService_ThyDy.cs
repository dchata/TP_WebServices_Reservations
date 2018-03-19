using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServices.ReservationVoiture.Soap;
using WebServices.ReservationVoiture.Soap.Messages;

namespace Agregation.ReservationVoiture
{
    public class CarService_ThyDy
    {
        public CarService_ThyDy()
        {
        }

        //Liste de voitures disponibles
        public MessageResponse GetListeVoitures(MessageRequest request)
        {
            CarService svc_car = new CarService();
            return svc_car.GetVoitures(request);
        }

        //Informations sur une voiture
        public MessageResponseInfo GetVoiture(MessageRequestInfo request)
        {
            CarService svc_car = new CarService();
            return svc_car.GetInfosVoiture(request);
        }

        //Réservation d'une voiture
        public MessageResponseResa BookingVoiture(MessageRequestResa request)
        {
            CarService svc_car = new CarService();
            return svc_car.ReserverVoiture(request);
        }
    }
}

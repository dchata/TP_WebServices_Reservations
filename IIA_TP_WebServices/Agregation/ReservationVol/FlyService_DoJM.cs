using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agregation.ReservationVol
{
    public class FlyService_DoJM
    {
        RestClient myRestClient = new RestClient("http://192.168.43.226:8082/");

        public FlyService_DoJM()
        {
        }

        //Liste de vols
        public string GetVols()
        {
            RestRequest myRestRequest = new RestRequest("api/flight/", Method.GET);

            return "";
        }


        //Réservation

    }
}

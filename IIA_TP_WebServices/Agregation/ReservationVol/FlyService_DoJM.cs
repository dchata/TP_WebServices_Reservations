using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServices.ReservationVoiture.Soap.Messages;

namespace Agregation.ReservationVol
{
    public class FlyService_DoJM
    {
        RestClient myRestClient = new RestClient("http://192.168.234.4:8082/");

        public FlyService_DoJM()
        {
        }

        //Liste de vols
        public string GetVols(bool allFlights, DateTime start, DateTime end)
        {
            RestRequest myRestRequest = new RestRequest("api/flight", Method.GET);
            myRestRequest.AddParameter("allFlights", allFlights);
            myRestRequest.AddParameter("start", start);
            myRestRequest.AddParameter("end", end);

            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);

            var response = String.Format("(Flux retourné) : {0}", myRestResponse.Content);

            return response;
        }


        //Réservation

    }
}

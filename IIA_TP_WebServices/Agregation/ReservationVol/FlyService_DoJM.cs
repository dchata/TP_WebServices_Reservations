using Newtonsoft.Json.Linq;
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
            var test = allFlights.ToString().ToLower();
            RestRequest myRestRequest = new RestRequest($"api/flight?allFlights={test}&start={start.ToString("yyyy-MM-dd")}&end={end.ToString("yyyy-MM-dd")}", Method.GET);

            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);
            
            var response = JArray.Parse(myRestResponse.Content).ToString();

            return response;
        }

        //Détail d'un vol
        public string GetDetails(int volId)
        {
            RestRequest myRestRequest = new RestRequest($"api/flight/{volId}", Method.GET);

            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);
            
            var response = myRestResponse.Content.ToString();

            return response;
        }


        //Réservation

    }
}

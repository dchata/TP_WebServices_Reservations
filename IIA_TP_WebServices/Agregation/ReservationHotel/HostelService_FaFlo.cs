using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agregation.ReservationHotel
{
    public class HostelService_FaFlo
    {
        RestClient myRestClient = new RestClient("http://192.168.234.1:8080/hotel/rest/");


        public HostelService_FaFlo()
        {
        }

        //Liste des hôtels
        public string GetHotels(DateTime start, DateTime end)
        {
            RestRequest myRestRequest = new RestRequest($"hotels?dateDeb={start.ToString("yyyy-MM-dd")}&dateFin={end.ToString("yyyy-MM-dd")}", Method.GET);

            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);

            var response = JArray.Parse(myRestResponse.Content).ToString();

            return response;
        }

        //Détail d'un hôtel
        public string GetDetails(int hotelId)
        {
            RestRequest myRestRequest = new RestRequest($"hotels/{hotelId}", Method.GET);

            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);

            var response = myRestResponse.Content.ToString();

            return response;
        }
    }
}

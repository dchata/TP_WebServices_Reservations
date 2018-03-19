using Newtonsoft.Json;
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
            RestRequest myRestRequest = new RestRequest($"hotels?dateDeb={start}&dateFin={end}", Method.GET);

            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);

            var response = JArray.Parse(myRestResponse.Content).ToString();

            return response;
        }

        public string ReservationHotel(int hotelId, DateTime date)
        {
            //grant_type=client_credentials& &scope=account
            /*RestRequest myTokenRequest = new RestRequest("login", Method.POST);
            string info = JsonConvert.SerializeObject();
            myTokenRequest.AddParameter("application/x-www-form-urlencoded", info, ParameterType.RequestBody);
            
            IRestResponse myTokenResponse = myRestClient.Execute(myTokenRequest);
            Token myToken = JsonConvert.DeserializeObject<Token>(myTokenResponse.Content);

            RestRequest myRestRequest = new RestRequest($"reservations?hotelId={hotelId}&date={date}", Method.POST);
            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);
            var response = String.Format(myRestResponse.Content+myTokenResponse.Content);

            return response;*/
            
            return "Methode non terminée";
        }
    }
}

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
        RestClient myRestAuth = new RestClient("http://192.168.234.4:8081/");
        
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

        public string ReservationVol(int idBooking, string lastName, string firstName, int places)
        {
            RestRequest myTokenRequest = new RestRequest("connect/token", Method.POST);
            myTokenRequest.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=CompanyC&client_secret=CompanyC&scope=account", ParameterType.RequestBody);
            IRestResponse myTokenResponse = myRestAuth.Execute(myTokenRequest);
            Token myToken = JsonConvert.DeserializeObject<Token>(myTokenResponse.Content);

            RestRequest myRestRequest = new RestRequest("api/flight/"+idBooking+"/book", Method.POST);
            myRestRequest.AddHeader("Authorization", myToken.Token_type+" "+myToken.Access_token);
            myRestRequest.AddParameter("bookerLastName", lastName);
            myRestRequest.AddParameter("bookerFirstName", firstName);
            myRestRequest.AddParameter("places", places);
           
            IRestResponse myRestResponse = myRestClient.Execute(myRestRequest);

            var response = String.Format("Numéro de réservation : {0}", myRestResponse.Content);
           
            return response;
        }


    }
}

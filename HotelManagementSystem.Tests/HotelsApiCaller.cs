using HotelManagementSystem.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;



namespace HotelManagementSystem.Tests
{
    public static class HotelsApiCaller
    {
        private static RestClient client = new RestClient("http://localhost:52475/api");
        public static List<Hotel> AddHotel(Hotel hotel)
        {
            var request = new RestRequest("Hotel", Method.POST);
            string json = JsonConvert.SerializeObject(hotel);
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Hotel>>(content);
        }

      public static Hotel GetHotelById(int id) {

            var request = new RestRequest(string.Format("Hotel/{0}",id), Method.GET);
           
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<Hotel>(content);

        }
        public static List<Hotel> VerifyHotel(List<Hotel>hotel)
        {
           List<Hotel>hotelsVerify=new List<Hotel>();


            for (int i = 0; i < hotel.Count; i++)
            {
                hotelsVerify.Add(hotel[i]);

            }
            return hotelsVerify;
        }
            





        /*
        public static Hotel GetHotelById(int id)
        {

            var request = new RestRequest(string.Format("Hotel/{0}", id), Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<Hotel>(content);

        }
        */

    }
}

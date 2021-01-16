using Newtonsoft.Json;
using ObiletcomProject.BusinessLayer.Abstract;
using ObiletcomProject.Entities.ViewModel;
using RestSharp;
using System;

namespace ObiletcomProject.BusinessLayer.Concrete
{
    public class BusLocationManager : IBusLocationService
    {
        public BusLocationViewModel GetBusLocations()
        {
            try
            {
                var client = new RestClient("blablabla");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Basic blablabla");
                var jsonDetail = new DeviceSessionInfo
                {
                    data = null,
                    DeviceSession = new DeviceSession
                    {
                        SessionId = CurrentSession.User.ToString(),
                        DeviceId = CurrentSession.Get("deviceId").ToString(),
                    },
                    date = DateTime.Now,
                    language = "tr-TR"
                };
                request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(jsonDetail), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                BusLocationViewModel busLocationInfo = JsonConvert.DeserializeObject<BusLocationViewModel>(response.Content);
                if (busLocationInfo.status == "Success")
                    return busLocationInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new BusLocationViewModel();
        }
    }

    public class DeviceSessionInfo
    {
        public object data { get; set; }

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        public DateTime date { get; set; }
        public string language { get; set; }
    }

    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }
    }
}

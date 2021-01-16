using Newtonsoft.Json;
using ObiletcomProject.BusinessLayer.Abstract;
using ObiletcomProject.Entities.ViewModel;
using RestSharp;
using System;

namespace ObiletcomProject.BusinessLayer.Concrete
{
    public class JourneyManager : IJourneyService
    {
        public BusJourneyViewModel.BusJourney GetJourneyDetail(int frombuslocation, int tobuslocation, DateTime flatpickr)
        {
            try
            {
                var client = new RestClient("blablabla");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Basic ZEdocGMybHpZV0p5WVc1a2JtVjNZbWx1");
                var jsonDetail = new BusJourneyJsonDetailViewModel.DeviceSessionInfos
                {
                    data = new BusJourneyJsonDetailViewModel.Data
                    {
                        OriginId = frombuslocation,
                        DestinationId = tobuslocation,
                        DepartureDate = DateTime.Parse(flatpickr.ToString("yyyy-MM-dd"))
                    },
                    date = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                    DeviceSession = new BusJourneyJsonDetailViewModel.SessionandDevice
                    {
                        DeviceId = CurrentSession.Get("deviceId").ToString(),
                        SessionId = CurrentSession.User.ToString()
                    },
                    language = "tr-TR"
                };
                request.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(jsonDetail), ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                BusJourneyViewModel.BusJourney busjourneyInfo = JsonConvert.DeserializeObject<BusJourneyViewModel.BusJourney>(response.Content);
                if (busjourneyInfo.status == "Success")
                    return busjourneyInfo;
                else if (busjourneyInfo.status == "InvalidDepartureDate")
                    throw new Exception(busjourneyInfo.UserMessage.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new BusJourneyViewModel.BusJourney();
        }
    }
}

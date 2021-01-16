using Newtonsoft.Json;
using System;

namespace ObiletcomProject.Entities.ViewModel
{
    public class BusJourneyJsonDetailViewModel
    {
        public class DeviceSessionInfos
        {
            [JsonProperty("device-session")]
            public SessionandDevice DeviceSession { get; set; }

            public DateTime date { get; set; }
            public string language { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            [JsonProperty("origin-id")]
            public int OriginId { get; set; }

            [JsonProperty("destination-id")]
            public int DestinationId { get; set; }

            [JsonProperty("departure-date")]
            public DateTime DepartureDate { get; set; }
        }

        public class SessionandDevice
        {
            [JsonProperty("session-id")]
            public string SessionId { get; set; }

            [JsonProperty("device-id")]
            public string DeviceId { get; set; }
        }
    }
}
using Newtonsoft.Json;

namespace ObiletcomProject.Entities.ViewModel
{
    public class SessionData
    {
        [JsonProperty("session-id")]
        public string SessionId { get; set; }

        [JsonProperty("device-id")]
        public string DeviceId { get; set; }

        public object affiliate { get; set; }

        [JsonProperty("device-type")]
        public int DeviceType { get; set; }

        public object device { get; set; }
    }
}
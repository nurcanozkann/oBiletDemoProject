﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiletcomProject.Entities.ViewModel
{
    public class SessionInfo
    {
        public string status { get; set; }
        public SessionData data { get; set; }
        public object message { get; set; }
        [JsonProperty("user-message")]
        public object UserMessage { get; set; }
        [JsonProperty("api-request-id")]
        public object ApiRequestId { get; set; }
        public object controller { get; set; }
        [JsonProperty("client-request-id")]
        public object ClientRequestId { get; set; }
    }
}

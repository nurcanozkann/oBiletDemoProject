﻿using Newtonsoft.Json;
using ObiletcomProject.BusinessLayer.Abstract;
using ObiletcomProject.Entities.ViewModel;
using RestSharp;
using System;

namespace ObiletcomProject.BusinessLayer.Concrete
{
    public class SessionManager : ISessionService
    {
        public SessionInfo CreateSession()
        {
            try
            {
                var client = new RestClient("blablabla");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "Basic blablabla");
                request.AddParameter("application/json", "{\r\n \"type\":1,\r\n \"connection\":{\r\n \"ip-address\":\"blablabla\",\r\n \"port\":\"5117\"\r\n },\r\n \"browser\":{\r\n \"name\":\"Chrome\",\r\n \"version\":\"47.0.0.12\",\r\n \"equipment-id\":\"distribusion\"\r\n }\r\n}", ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                SessionInfo sessionInfo = JsonConvert.DeserializeObject<SessionInfo>(response.Content);

                return sessionInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

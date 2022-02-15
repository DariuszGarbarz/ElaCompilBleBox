﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using WLightBoxApi.Contracts;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// Class thats connects to device /api/rgbw/state and gets all State of Lightning data
    /// </summary>
    public class GetRgbw : ApiCommunication
    {
        public GetRgbw(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        public RgbwResponse GetRgbwFromApi()
        {
            
            var uri = new Uri($"https://{_ipAdress}/api/rgbw/state");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Communication Error");
            }
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var rgbwResult = JsonConvert.DeserializeObject<RgbwResponse>(getResultsJson);

            return rgbwResult;
        }
    }
}

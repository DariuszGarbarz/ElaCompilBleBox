﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WLightBoxApi.Contracts;
using WLightBoxApi.Models;

namespace WLightBoxApi.WebServices
{
    /// <summary>
    /// class that gets all the basic info about our device from GET /info Api
    /// </summary>
    public class GetInfo : ApiCommunication
    {
        /// <summary>
        /// URL or ipAdress of the device we want to interact with
        /// </summary>
        /// <param name="ipAdress">string without https:// ex: 192.168.1.11</param>
        public GetInfo(string ipAdress, HttpClient httpClient) : base(ipAdress, httpClient)
        {

        }

        /// <summary>
        /// Gets general information about device
        /// </summary>
        /// <returns>Complete DeviceModel</returns>
        public DeviceResponse GetInfoFromApi()
        {
            
            var uri = new Uri($"https://{_ipAdress}/info");

            HttpResponseMessage response = _httpClient.GetAsync(uri).Result;
            var getResultsJson = response.Content.ReadAsStringAsync().Result;

            var deviceResult = JsonConvert.DeserializeObject<DeviceResponse>(getResultsJson);

            return deviceResult;
        }

    }
}
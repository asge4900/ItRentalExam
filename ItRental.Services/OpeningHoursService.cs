using ItRental.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;

namespace ItRental.Services
{
    public class OpeningHoursService
    {
        public string Url { get; set; }

        public List<OpeningHourInfo> GetOpeningHour()
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                using (var client = new WebClient())
                {
                    string json = client.DownloadString(Url);
                    List<OpeningHourInfo> openingHourInfo = JsonConvert.DeserializeObject<List<OpeningHourInfo>>(json);
                    return openingHourInfo;
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}

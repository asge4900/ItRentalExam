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

        public OpeningHourInfo GetOpeningHour()
        {
            if (!string.IsNullOrWhiteSpace(Url))
            {
                using (var client = new WebClient())
                {
                    string json = client.DownloadString(Url);
                    OpeningHourInfo openingHourInfo = JsonConvert.DeserializeObject<OpeningHourInfo>(json);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Entities;
using ItRental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<OpeningHours> OpeningHours { get; set; }
        public void OnGet()
        {
            OpeningHoursService openingHoursService = new OpeningHoursService()
            {
                Url = "http://api.aspitcloud.dk/openinghours"
            };
            OpeningHourInfo openingHourInfo = openingHoursService.GetOpeningHour();
            OpeningHours = openingHourInfo.OpeningHours;
        }
    }
}
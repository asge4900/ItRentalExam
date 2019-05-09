using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal;
using ItRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class DetailsModel : PageModel
    {
        public Renter Renter { get; set; }
        public List<Renter> Renters { get; set; } = new List<Renter>();
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        public DetailsModel()
        {
            //RenterRepository renterRepository = new RenterRepository();
            //Renters = renterRepository.GetRenters();

            //RentalRepository rentalRepository = new RentalRepository();
            //Rentals = rentalRepository.GetRentals();
        }
        public void OnGet(int id)
        {
            RentalRepository rentalRepository = new RentalRepository();
            Rentals = rentalRepository.GetRentalDetailsFor(id);
        }
    }
}
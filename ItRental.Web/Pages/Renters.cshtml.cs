﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItRental.Dal;
using ItRental.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ItRental.Web.Pages
{
    public class RentersModel : PageModel
    {
        
        public Renter Renter { get; set; }
        public List<Renter> Renters { get; set; } = new List<Renter>();
        public List<Rental> Rentals { get; set; } = new List<Rental>();

        public RentersModel()
        {
            RenterRepository renterRepository = new RenterRepository();
            Renters = renterRepository.GetRenters();

            RentalRepository rentalRepository = new RentalRepository();
            Rentals = rentalRepository.GetRentals();
        }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            RenterRepository renterRepository = new RenterRepository();

            renterRepository.AddRenter(Renter);
        }

        public void OnPostSeach()
        {
            RenterRepository renterRepository = new RenterRepository();
            Renters = renterRepository.FindRenter(Renter);
        }
    }
}
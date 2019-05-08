using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ItRental.Entities
{
    public class Renter
    {
        public int Id { get; set; }
        [Display(Name = "Navn")]
        public string Name { get; set; }
        //[Display(RenterLevel = "Rettighed")]
        public RenterLevel RenterLevel { get; set; }
        public List<Rental> Rentals { get; set; }
        public int NumberOfRentals { get;}
        
        //public Rental NextRentalDue()
        //{

        //}

        //public bool GotOverdueRental()
        //{

        //}
    }
}

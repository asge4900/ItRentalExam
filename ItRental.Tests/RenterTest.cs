using ItRental.Entities;
using System;
using Xunit;

namespace ItRental.Tests
{
    public class RenterTest
    {
        [Fact]
        public void IsRentalOverdue_ReturnsTrueWhenOverdue()
        {
            //Arrange
            Rental rental = new Rental()
            {
                ReturnTime = new DateTime(2019, 05, 08)
            };

            Renter renter = new Renter();
            renter.Rentals.Add(rental);

            bool expectedIsRentalOverdue = true;

            //Act
            bool actualIsRentalOverdue = renter.IsOverdueRental();

            //Assert
            Assert.Equal(expectedIsRentalOverdue, actualIsRentalOverdue);
        }

        [Fact]
        public void IsRentalOverdue_ReturnsFalseWhenNotOverdue()
        {
            //Arrange
            Rental rental = new Rental()
            {
                ReturnTime = DateTime.Now.AddDays(1)
            };

            Renter renter = new Renter();
            renter.Rentals.Add(rental);

            bool expectedIsRentalOverdue = false;

            //Act
            bool actualIsRentalOverdue = renter.IsOverdueRental();

            //Assert
            Assert.Equal(expectedIsRentalOverdue, actualIsRentalOverdue);
        }
    }
}

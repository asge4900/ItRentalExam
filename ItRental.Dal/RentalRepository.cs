using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ItRental.Dal
{
    public class RentalRepository : BaseRepository
    {
        public List<Rental> GetRentals()
        {
            string sql = "SELECT * FROM dbo.Rentals r";
            return HandleData(ExecuteQuery(sql));
        }
                       
        private List<Rental> HandleData(DataTable dataTable)
        {
            List<Rental> rentals = new List<Rental>();
            if (dataTable is null)
                return rentals;

            foreach (DataRow row in dataTable.Rows)
            {
                Equipment equipment = new Equipment()
                {
                    Id = (int)row["EquipmentsId"]
                };

                Renter renter = new Renter()
                {
                    Id = (int)row["RenterId"]
                };

                Rental rental = new Rental()
                {
                    Id = (int)row["RenterId"],
                    RentalTime = (DateTime)row["RentalTime"],
                    ReturnTime = (DateTime)row["ReturnTime"],
                    Units = (int)row["Units"],
                    Equipment = equipment,
                    Renter = renter
                };
                rentals.Add(rental);
            }
            return rentals;
        }

        //public int AddRenter(Renter renter)
        //{
        //    string sql = $"INSERT INTO dbo.Renters VALUES ('{renter.Name}', {(int)renter.RenterLevel})";

        //    return ExecuteNonQuery(sql);
        //}
    }
}

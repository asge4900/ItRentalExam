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

        public int AddRenter(Renter renter)
        {
            string sql = $"INSERT INTO dbo.Renters VALUES ('{renter.Name}', {(int)renter.RenterLevel})";

            return ExecuteNonQuery(sql);
        }

        public List<Rental> GetRentalDetailsFor(int id)
        {
            List<Rental> rentals = new List<Rental>();

            string sql = $"SELECT r2.*, e.Name AS EquipmentName, r.RentalId, r.RentalTime, r.ReturnTime, r.Units FROM dbo.Rentals r JOIN dbo.Equipments e ON r.EquipmentsId = e.EquipmentId JOIN dbo.Renters r2 ON r.RenterId = r2.RenterId WHERE r2.RenterId = {id}";

            DataTable rentalsTable = ExecuteQuery(sql);
            
            foreach (DataRow row in rentalsTable.Rows)
            {
                Equipment equipment = new Equipment()
                {
                    Name = (string)row["EquipmentName"]
                };

                 Renter renter = new Renter()
                {
                    Id = (int)row["RenterId"],
                    Name = (string)row["Name"],
                    RenterLevel = (RenterLevel)row["RenterLevel"]
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
    }
}

using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ItRental.Dal
{
    public class RenterRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all equipments from the database
        /// </summary>
        /// <returns></returns>
        public List<Renter> GetRenters()
        {
            string sql = "SELECT * FROM dbo.Renters r";
            return HandleData(ExecuteQuery(sql));
        }

        /// <summary>
        /// Helper method used to convert DataTable to a list of Equipments.
        /// Returns an empty list if the parameter is null.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Renter> HandleData(DataTable dataTable)
        {
            List<Renter> renters = new List<Renter>();
            if (dataTable is null)
                return renters;

            foreach (DataRow row in dataTable.Rows)
            {
                Renter renter = new Renter()
                {
                    Id = (int)row["RenterId"],
                    Name = (string)row["Name"],                    
                    RenterLevel = (RenterLevel)row["RenterLevel"]
                };
                renters.Add(renter);
            }
            return renters;
        }

        public int AddRenter(Renter renter)
        {
            string sql = $"INSERT INTO dbo.Renters VALUES ('{renter.Name}', {(int)renter.RenterLevel})";

            return ExecuteNonQuery(sql);
        }
    }
}

﻿using ItRental.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace ItRental.Dal
{
    public class EquipmentRepository : BaseRepository
    {
        /// <summary>
        /// Retrieves all equipments from the database
        /// </summary>
        /// <returns></returns>
        public List<Equipment> GetEquipments()
        {
            string sql = "SELECT * FROM Equipments";
            return HandleData(ExecuteQuery(sql));
        }

        /// <summary>
        /// Helper method used to convert DataTable to a list of Equipments.
        /// Returns an empty list if the parameter is null.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        private List<Equipment> HandleData(DataTable dataTable)
        {
            List<Equipment> equipments = new List<Equipment>();
            if (dataTable is null)
                return equipments;

            foreach (DataRow row in dataTable.Rows)
            {
                Equipment equipment = new Equipment()
                {
                    Id = (int)row["EquipmentId"],
                    Name = (string)row["Name"],
                    Category = (string)row["Category"],
                    Units = (int)row["Units"]
                };
                equipments.Add(equipment);
            }
            return equipments;
        }

        public int AddEquipment (Equipment equipment)
        {
            string sql = $"INSERT INTO dbo.Equipments VALUES ('{equipment.Name}', '{equipment.Category}', {equipment.Units})";

            return ExecuteNonQuery(sql);
        }
    }
}

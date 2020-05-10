using System;
using System.Collections.Generic;

namespace Assignment
{/// <summary>
/// The transactions have only the variables that i want to print to the console
/// Each variable will be taken from the vehicle list when a vehicel will be realised from the pump after it fueled
/// </summary>
    class Transaction
    {
        public static List<Transaction> trans = new List<Transaction>();

        public int vehicleID { get; set; }
        public string vehicleType { get; set; }
        public string fuelType { get; set; }
        public double fuelNeeded { get; set; }
        public double totalFuel { get; set; }
        public static void AddTransaction(int vehicleID, string vehicleType, string fuelType, double fuelNeeded, double totalFuel)
        {
            trans.Add(item: new Transaction { vehicleID = vehicleID, vehicleType = vehicleType, 
                                              fuelType = fuelType, fuelNeeded = fuelNeeded, totalFuel = totalFuel });
        }
    }
}

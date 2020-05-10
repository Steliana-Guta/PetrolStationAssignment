using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment
{/// <summary>
/// Here wehave all the elements that are part of a vehicle
/// Each vehicle will have a type,a fuel type, a tank level and an ID number
/// </summary>
    class Vehicle
    {
        public static Random random = new Random();
        public string vehicleType;
        public string fuelType;
        public double fuelNeeded; 
        public double fuelTime;
        private static int nextVehicleID = 0;
        public int vehicleID;
        public Vehicle()
        {
            vehicleType = GetVehicleType();
            fuelType = GetFuelType();
            fuelNeeded = GetFuelNeeded();
            fuelTime = GetFuelTime();
            vehicleID = nextVehicleID;
            nextVehicleID++;
        }
        private static string GetVehicleType()
        {// Randomly generates a vehicle type out of the 3 otions
            string[] type = new string[] { "Car", "Van", "HGV" };
            int numIndex = random.Next(0, 3);
            string result = type[numIndex];

            return result;
        }
        private string GetFuelType()
        {// Each vehicle get's a specific fuel type or a random one out of the ones available to that specific vehicle type
            if (vehicleType == "Car")
            {

                string[] type = new string[] { "Diesel", "Unleaded", "LPG" };
                int numIndex = random.Next(0, 3);
                string result = type[numIndex];
                return result;

            }
            if (vehicleType == "Van")
            {
                string[] type = new string[] { "LPG", "Unleaded" };
                int numIndex = random.Next(0, 2);
                string result = type[numIndex];
                return result;
            }
            else
            {
                string result = "Diesel";
                return result;
            }
        }
        private double GetFuelNeeded()
        {//Each type of vehicle has a different tank capacity
            //Each vehicle is created with a maximum of 25% of the tank already full
            int oldFuel;
            if (vehicleType == "Car")
            {
                oldFuel = random.Next(1, 10);
                fuelNeeded = 40 - oldFuel; //Litres needed to fuel
                return fuelNeeded;
            }
            if (vehicleType == "Van")
            {
                oldFuel = random.Next(1, 20);
                fuelNeeded = 80 - oldFuel; 
                return fuelNeeded;
            }
            else
            {
                oldFuel = random.Next(1, 37);
                fuelNeeded = 150 - oldFuel; 
                return fuelNeeded;
            }
        }
        private double GetFuelTime()
        {// Here we are transforming the amount of liters needed in time, because our pumps dispense 1.5L per second
            double result = fuelNeeded / 1.5;
            return result;
        }
    }
}

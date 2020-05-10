using System;
using System.Timers;

namespace Assignment
{/// <summary>
/// In the pump class we can find the prices of each individual fuel type
/// We create totals of each individual one and all togheter
/// And we keep the vehicle that's serviced sending it to the transaction list afterwards, while adding itto the "vehicles services" count 
/// </summary>
    class Pump
    {
        public Vehicle currentVehicle = null;
        public static int vehiclesServiced;
        //Totals
        public static double price;
        public static double total;
        public static double totalLitersSold;
        public static double totalDiesel;
        public static double totalUnleaded;
        public static double totalLPG;
        public bool IsAvailable()
        {//Returns TRUE if currentveh. is NULL, aka available
            return currentVehicle == null;
           
        }
        public void AssignVehicle(Vehicle v)
        {
            currentVehicle = v;

            Timer timer = new Timer();
            timer.Interval = v.fuelTime * 1000;// Fueling time based on how empty is the tank, 1,5 liters per second 
            timer.AutoReset = false; //Do not repeat
            timer.Elapsed += ReleaseVehicle;// When the liters needed get fueld up the vehicle will be realised and the pump will look fofr another vehicle to service
            timer.Enabled = true;
            timer.Start();
        }
        public void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            vehiclesServiced++; //Record number of vehicles served
            TotalRevenue();//Adding the abount paid by the vehicle to the revenue total
            TotalLitersSold();//Adding the amount of liters fueled by the vehicle to the count
            //Record transaction
            Transaction.AddTransaction(currentVehicle.vehicleID, currentVehicle.vehicleType, currentVehicle.fuelType, currentVehicle.fuelNeeded, price);
            currentVehicle = null; // Releasing vehicle
        }
        public double TotalRevenue()
        {
            if (currentVehicle.fuelType == "Diesel")
            {
                price = 1.12 * currentVehicle.fuelNeeded;
                total += price; //Getting the revenue of the petrol station
                totalDiesel += currentVehicle.fuelNeeded; // Getting to the total diesel liters sold
                return total;
            }
            if (currentVehicle.fuelType == "Unleaded")
            {
                price = 1.16 * currentVehicle.fuelNeeded;
                total += price;//Adding to the revenue
                totalUnleaded += currentVehicle.fuelNeeded;// Getting the total unleaded liters sold 
                return total;
            }
            else
            {
                price = 0.94 * currentVehicle.fuelNeeded;
                total += price;//Adding to the revenue
                totalLPG += currentVehicle.fuelNeeded;// Getting the total of LPG liters sold
                return total;
            }
        }
        public double TotalLitersSold()
        {
            totalLitersSold = totalLitersSold + currentVehicle.fuelNeeded; //Getting the total of liters sold by the petrol station
            return totalLitersSold;
        }
    }
}

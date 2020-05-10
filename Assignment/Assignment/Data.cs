using System;
using System.Collections.Generic;
using System.Timers;

namespace Assignment
{/// <summary>
/// In the data class i keep the timer and the lists
/// Here i keep the count of vehicles that left without being serviced
/// and all the attendant information(salary + commision)
/// </summary>
    class Data
    {
        private static Timer timer;
        public static List<Vehicle> vehicles;
        public static List<Pump> pumps;
        private static Random random = new Random();
        public static int vehiclesLeft;
        //Attendant 
        public static double salaryHour = 2.49;
        public static double salary;
        public static double commision;

        public static void Initialise()
        {
            InitialisePumps();
            InitialiseVehicles();
            NotServiced();
        }
        public static void InitialiseVehicles()
        { 
            vehicles = new List<Vehicle>();
            int interval = random.Next(1500, 2200);//A random time in between 1.5 and 2.2 sec to create a new vehicle

            timer = new Timer();
            timer.Interval = interval;
            timer.AutoReset = true; //Repeat every 1.5 sec - 2.2 sec
            timer.Elapsed += CreateVehicle;// Creates vhicles that wait on the queue
            timer.Enabled = true;
            timer.Start();
        }
        private static void CreateVehicle(object sender, ElapsedEventArgs e)
        {//Creates new vehicles
            if (vehicles.Count < 5)//A maximum of 5 cars in the queue
            {
                Vehicle v = new Vehicle();
                vehicles.Add(v);
            }
        }
        private static void InitialisePumps()
        {//Creating the pumps
            pumps = new List<Pump>();
            Pump p;
            // Initialising 9 pumps
            for(int i = 0; i < 9; i++)
            {
                p = new Pump();
                pumps.Add(p);
            }
        }
        public static void AssignVehicles()
        {//Every 0.05 seconds the sistem will search for a vehicle waiting and a pump to be available and then will move the vehicle from the queue to the pump
            timer = new Timer();
            timer.Interval = 50;
            timer.AutoReset = true;
            timer.Elapsed += AssignVehicleToPump;// Move vehicle to pump
            timer.Enabled = true;
            timer.Start();
        }
        public static void AssignVehicleToPump(object sender, ElapsedEventArgs e)
        {//When all conditions are true the vehicle will be moved to the pump
            Vehicle v;
            Pump p;

            if (vehicles.Count == 0) { return; }

            for (int i = 0; i < 9; i++)
            {
                p = pumps[i]; //9 pump slots
                //Check for the last available pump
                if (p.IsAvailable())
                {
                    v = vehicles[0];//Get first vehicle
                    vehicles.RemoveAt(0);//Remove vehicle from queue
                    p.AssignVehicle(v);//Assign it to the pump
                }
                if(vehicles.Count == 0) { break; }
            }
        }
        public static void NotServiced()
        {
            timer = new Timer();
            timer.Interval = 1500;//Checks the queue every 1.5 sec for not serviced vehicles
            timer.AutoReset = true;
            timer.Elapsed += ReleaseVehicle;// Release vehicle if not serviced in 1.5 sec
            timer.Enabled = true;
            timer.Start();
        }
        public static void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            if (vehicles.Count > 0)
            {
                vehicles.RemoveAt(0);// Removes vehicle from queue
                vehiclesLeft++;// Adds to the "vehicles left " count 
            }
        }
        public static void Attendant()
        {
            salary = salary + (salaryHour * 0.05);//Adds up as long as the app is running 
            Display.WriteAt("Attendant salary: £ " + salary.ToString("###,###.##"), 68, 24);//Displayed under the totals
            commision = Pump.total / 100;// 1% commision on sales
            Display.WriteAt("Attendant commision: £ " + commision.ToString("###,###.##"), 65, 25);
        }
    }
}

using System;

namespace Assignment
{/// <summary>
/// In the display i put together all the visual funtions such as how the pumps are going to look like, how many of them we will have and what is going to be displayed on them
/// Here we draw/create the vehicles as well, we show only some elements as the ID number, vehicle type, and fuel type
/// We have here all the different totals for fuels and revenue and vehicles serviced or not serviced
/// And we position the transaction list on the side choosing what we want to display from each transaction
/// </summary>
    class Display
    {
        protected static int origRow;
        protected static int origCol;

        public static void WriteAt(string s, int col, int row)//Use in the console to posistion things with (x,y) coordonates
        {
            Console.SetCursorPosition(origCol + col, origRow + row);
            Console.WriteLine(s);
        }
        public static void DrawVehicle()
        {
            Vehicle v;

            Console.Clear();
            WriteAt("Vehicles Queue:",1,0);
            //List all the vehiles waiting to be served and their type,fuel and the number 
            for(int i = 0; i< Data.vehicles.Count;i++)
            {
                v = Data.vehicles[i];
                Console.Write("#{0} {1} Fuel Type: {2} \n", v.vehicleID, v.vehicleType, v.fuelType);
            }
        }
        public static void DrawTotals(int col, int row)
        {//Listing totals and adjusting their position
            WriteAt("Vehicles left without service: " + Data.vehiclesLeft, col + 60, row + 14);
            WriteAt("Vehicles serviced : " + Pump.vehiclesServiced, col + 67, row + 15);
            WriteAt("Total revenue: £ " + Pump.total.ToString("###,###.##"), col + 69, row + 17);
            WriteAt("Total liters sold: " + Pump.totalLitersSold.ToString("###,###.##") + " L", col + 65, row + 18);
            WriteAt("Total Diesel sold: " + Pump.totalDiesel.ToString("###,###.##") + " L", col + 65, row + 20);
            WriteAt("Total Unleaded sold: " + Pump.totalUnleaded.ToString("###,###.##") + " L", col + 63, row + 21);
            WriteAt("Total LPG sold: " + Pump.totalLPG.ToString("###,###.##") + " L", col + 68, row + 22);
        }
        public static void DrawPumps(int col, int row)
        {
            Pump p;
            WriteAt("Pump Status:", col + 14, row- 3);
            //List the pumps and format the way they're listed (3 per row in 3 col.)
            for (int i = 0; i < 9; i++)
            {
                p = Data.pumps[i];

                WriteAt("" + (i + 1), col, row);
                if (p.IsAvailable()) { WriteAt("| Available | ", col, row); }//If pump is available diplay "available"
                else { WriteAt("| Busy      | ", col, row); }// If pump ocupied then diplay "busy"
                if (i % 3 == 2) { row = row + 2; col = col - 28; }//Formating 3 pumps on a row
                else { col = col + 14; }//Putting the 3 pumps one after each other
            }
        }
        public static void DrawTransactions(int col, int row)
        { WriteAt("Transactions: ", col, row);//Positioning the header

            for (int i = 0; i < Transaction.trans.Count; i++)
            {//Listing the vehicle ID, vehicle type, fuel type, liters sold and anout paid for each vehicleserviced at any pumps
                WriteAt("#" + Transaction.trans[i].vehicleID  + ", " + Transaction.trans[i].vehicleType + ", " + Transaction.trans[i].fuelType + ", " + Transaction.trans[i].fuelNeeded.ToString("###,###.##") + "L , £" + Transaction.trans[i].totalFuel.ToString("###,###.##"), col , row + 1 + i);
                if(Transaction.trans.Count > 30)
                {//When the transactions reach 30 the oldest transaction will not be displayed anymore making space for new transactions
                    Transaction.trans.RemoveAt(0);
                }
            }
        }
    }
}

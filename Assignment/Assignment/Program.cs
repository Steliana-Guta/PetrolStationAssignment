using System;
using System.Timers;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {//Setting the size of the console
            Console.SetWindowSize(160, 45);
            Data.Initialise();
            Data.AssignVehicles();

            Timer timer = new Timer();
            timer.Interval = 2050;
            timer.AutoReset = true; // Repeat every 2 seconds
            timer.Elapsed += RunProgramLoop;
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Display.DrawVehicle();
            Console.WriteLine();
            Console.WriteLine();
            Display.DrawPumps(55,6);
            Display.DrawTotals(0,0);
            Display.DrawTransactions(110,0);
            Data.Attendant();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_Jwwilliams4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "invalid";
            while (input != "valid"){
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("Please select a function");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Trainers");
                Console.WriteLine("2. Listings");
                Console.WriteLine("3. Bookings");
                Console.WriteLine("4. Reports");
                Console.WriteLine("5. Exit Application");
                Console.WriteLine("=======================");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "trainer"||lowerAnswer == "1"){
                    input = "valid";
                    Trainer classObj = new Trainer();
                    classObj.TrainerMenu();
                }
                else if (lowerAnswer == "listing"||lowerAnswer == "2"){
                    input = "valid";
                    Listing classObj2 = new Listing();
                    classObj2.Sessions();
                }
                else if (lowerAnswer == "booking"||lowerAnswer == "3"){
                    input = "valid";
                    Booking classObj3 = new Booking();
                    classObj3.BookingsMenu();
                }
                else if (lowerAnswer == "report"||lowerAnswer == "4"){
                    input = "valid";
                    Reports classObj4 = new Reports();
                    classObj4.ReportsMenu();
                }
                else if (lowerAnswer == "exit" || lowerAnswer == "exit application"||lowerAnswer == "5"){
                    input = "valid";
                }
                else{

                }
            }
        }
    }
}
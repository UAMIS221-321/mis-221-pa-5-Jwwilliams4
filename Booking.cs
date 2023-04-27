using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_Jwwilliams4
{
    public class Booking
    {
        public void BookingsMenu()
        {
            string input = "invalid";
            while (input != "valid"){
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("        Bookings      ");
                Console.WriteLine("=======================");
                Console.WriteLine("Please select an option");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. View Available Sessions");
                Console.WriteLine("2. Book Session");
                Console.WriteLine("3. Update Booking");
                Console.WriteLine("4. Exit Application");
                Console.WriteLine("=======================");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "view available sessions"||lowerAnswer == "1"){
                    input = "valid";
                    BookingsOpenList();
                    Console.WriteLine("Press ANY key to continue.");
                    Console.ReadKey();
                    BookingsMenu();
                }
                else if (lowerAnswer == "book"||lowerAnswer == "book session"||lowerAnswer == "2"){
                    input = "valid";
                    BookingsBookSession();
                }
                else if (lowerAnswer == "update"||lowerAnswer == "3"){
                    input = "valid";
                    BookingsEdit();
                }
                else if (lowerAnswer == "exit" || lowerAnswer == "exit application"||lowerAnswer == "4"){
                    input = "valid";
                }
                else{

                }
            }
        }

        static void BookingsOpenList()
        {
            Console.Clear();
            StreamReader LL = new StreamReader("listings.txt");
            string temp = LL.ReadLine();
            Console.WriteLine("===================================================================================================================");
            Console.WriteLine($"  Listing ID\t   Trainer ID\t\tSession Date\tSession Time\tSession Cost\tAvailability");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            while (temp != null)
            {
                string [] tempArray = temp.Split('#');
                if (tempArray[5] == "open" || tempArray[5] == "Open" || tempArray[5] == "available" || tempArray[5] == "Available"){
                Console.WriteLine($"\t{tempArray[0]}\t\t{tempArray[1]}\t\t{tempArray[2]}\t\t\t{tempArray[3]}\t\t{tempArray[4]}\t{tempArray[5]}"); 
                }
                temp = LL.ReadLine();
            }
            Console.WriteLine("===================================================================================================================");
            LL.Close();
        }

        static void BookingsBookSession()
        {
            BookingsOpenList();
            string lID = "";
            string trainingDate = "";
            string trainerID = "";
            string trainerName = "";
            Console.WriteLine("listing ID");
            string listingID = Console.ReadLine();
            StreamReader listing = new StreamReader("listings.txt");
            string listingInput = listing.ReadLine();
            while (listingInput != null)
            {
                string []tempList = listingInput.Split('#');
                if (listingID == tempList[0]){
                    lID = tempList[0];
                    trainingDate = tempList[2];
                    trainerID = tempList[1];
                    listingInput = listing.ReadLine();
                }
                else{
                    listingInput = listing.ReadLine();
                }
            }
            if (listingID != lID){
                Console.WriteLine("Invalid Listing ID");
                BookingsBookSession();
            }
            listing.Close();
            StreamReader trainer = new StreamReader("trainers.txt");
            string trainerInput = trainer.ReadLine();
            while (trainerInput != null)
            {
                string [] tempList = trainerInput.Split('#');
                if (trainerID == tempList[3]){
                    trainerName = tempList[0];
                    trainerInput = trainer.ReadLine();
                }
                else{
                    trainerInput = trainer.ReadLine();
                }
            }   
            trainer.Close();
            string input = "invalid";
            int ID =0;
            string[] tempArray = new string[100];
            StreamReader myfile = new StreamReader("transactions.txt");

            string fileInput = myfile.ReadLine();
            while (fileInput != null)
            {
                tempArray = fileInput.Split('#');
                ID = int.Parse(tempArray[0]) + 1;
                fileInput = myfile.ReadLine();
            }   
            myfile.Close();
            Console.Clear();
            Console.WriteLine("==========================");
            Console.WriteLine("Please enter Customers Name");
            Console.WriteLine("==========================");
            string name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Please enter Customers E-Mail Address");
            Console.WriteLine("=======================");
            string eMail = Console.ReadLine();
            while (input != "valid")
            {
                Console.Clear();
                Console.WriteLine("===================================================");
                Console.WriteLine("is the Sessions info correct");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Session ID:                {ID}");
                Console.WriteLine($"Customers Name:            { name }");
                Console.WriteLine($"Customers E-Mail Address:  {eMail}");
                Console.WriteLine($"Session Date:              {trainingDate}");
                Console.WriteLine($"Trainer ID:                {trainerID}");
                Console.WriteLine($"Trainer Name:              {trainerName}");
                Console.WriteLine("===================================================");
                Console.WriteLine("Yes");
                Console.WriteLine("No");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "yes"){
                    string bookingInput = (ID+"#"+name+"#"+eMail+"#"+trainingDate+"#"+trainerID+"#"+trainerName+"#"+"booked");
                    StreamWriter trainerInfo = new StreamWriter("transactions.txt", true);
                    trainerInfo.Write(bookingInput);
                    trainerInfo.WriteLine();
                    trainerInfo.Close();
                    input = "valid";
                }
                else if (lowerAnswer == "no"){
                    input = "valid";
                    BookingsBookSession();
                }
                else{}
            }

            string tID = "";
            string date = "";
            string time = "";
            string cost = "";
            string taken = "";
            StreamReader myfile2 = new StreamReader("listings.txt");

            string fileInput2 = myfile2.ReadLine();
            while (fileInput2 != null)
            {
                string[] tempArray2 = fileInput2.Split('#');
                    if (lID == tempArray2[0])
                    {
                        tID = tempArray2[1];
                        date = tempArray2[2];
                        time = tempArray2[3];
                        cost = tempArray2[4];
                        taken = tempArray2[5];
                    }
                fileInput2 = myfile2.ReadLine();
            }
                    myfile2.Close();
                    taken = "taken";
                    BufferPush(lID,tID,date,time,cost,taken);
                    
            myfile2.Close();
            static void BufferPush(string lID, string tID, string date, string time, string cost, string taken)
            {
                int count =0;
                Console.Clear();
                StreamReader sessions = new StreamReader("listings.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                Trainer classObj = new Trainer();
                classObj.TrainerList();
                string fileInput = sessions.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if (lID == tempArray[0]){
                        bufferWrite.Write(lID+"#"+tID+"#"+date+"#"+time+"#"+cost+"#"+taken);
                        bufferWrite.Write('^');
                        count++;
                    }
                    else{
                        bufferWrite.Write(fileInput);
                        bufferWrite.Write('^');
                        count++;
                    }
                    fileInput = sessions.ReadLine();
                }
                sessions.Close();
                bufferWrite.Close();
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter sessionssWrite = new StreamWriter("listings.txt");
                string fileBuffer = bufferRead.ReadLine();
                while (fileBuffer != null)
                {
                    string[] tempArray = fileBuffer.Split('^');
                    for (int i =0;i<count;i++){
                        sessionssWrite.Write(tempArray[i]);
                        sessionssWrite.WriteLine();
                    }    
                    fileBuffer = bufferRead.ReadLine();
                }
                sessionssWrite.Close();
                bufferRead.Close();
               
        }
            Booking classObj = new Booking();
            classObj.BookingsMenu();
        }

        static void BookingsEdit()
        {
            string name = "";
            string eMail = "";
            string trainingDate = "";
            string trainerID = "";
            string trainerName = "";
            string availability = "";
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("Please enter Session ID");
            Console.WriteLine("========================");
            string ID = Console.ReadLine();

            StreamReader myfile = new StreamReader("transactions.txt");

            string fileInput = myfile.ReadLine();
            while (fileInput != null)
            {
                string[] tempArray = fileInput.Split('#');
                    if (ID == tempArray[0])
                    {
                        name = tempArray[1];
                        eMail = tempArray[2];
                        trainingDate = tempArray[3];
                        trainerID = tempArray[4];
                        trainerName = tempArray[5];
                        availability = tempArray[6];
                    }
                fileInput = myfile.ReadLine();
            }
                myfile.Close();
                Console.Clear();
                Console.WriteLine("===================================================");
                Console.WriteLine("                 Session info");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Session ID:                {ID}");
                Console.WriteLine($"Customers Name:            { name }");
                Console.WriteLine($"Customers E-Mail Address:  {eMail}");
                Console.WriteLine($"Session Date:              {trainingDate}");
                Console.WriteLine($"Trainer ID:                {trainerID}");
                Console.WriteLine($"Trainer Name:              {trainerName}");
                Console.WriteLine($"Session Availability:      {availability}");
                Console.WriteLine("===================================================");
                Console.WriteLine("Is the Session completed, cancelled, or a no-show?");
                availability = Console.ReadLine();
                Push(ID, name, eMail, trainingDate, trainerID, trainerName, availability);

            static void Push(string ID, string name, string eMail, string trainingDate, string trainerID, string trainerName, string availability)
            {
                int count =0;
                Console.Clear();
                StreamReader transactions = new StreamReader("transactions.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                Trainer classObj2 = new Trainer();
                classObj2.TrainerList();
                string fileInput = transactions.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if (ID == tempArray[0]){
                        bufferWrite.Write(ID+"#"+name+"#"+eMail+"#"+trainingDate+"#"+trainerID+"#"+trainerName+"#"+availability);
                        bufferWrite.Write('^');
                        count++;
                    }
                    else{
                        bufferWrite.Write(fileInput);
                        bufferWrite.Write('^');
                        count++;
                    }
                    fileInput = transactions.ReadLine();
                }
                transactions.Close();
                bufferWrite.Close();
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter transactionsWrite = new StreamWriter("transactions.txt");
                string fileBuffer = bufferRead.ReadLine();
                while (fileBuffer != null)
                {
                    string[] tempArray = fileBuffer.Split('^');
                    for (int i =0;i<count;i++){
                        transactionsWrite.Write(tempArray[i]);
                        transactionsWrite.WriteLine();
                    }    
                    fileBuffer = bufferRead.ReadLine();
                }
                transactionsWrite.Close();
                bufferRead.Close();
                Booking classObj = new Booking();
                classObj.BookingsMenu();
            }    
        }
    }
}
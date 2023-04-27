using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_Jwwilliams4
{
    public class Listing
    {   
        public void Sessions()
        {
            string input = "invalid";
            while (input != "valid"){
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("        Sessions       ");
                Console.WriteLine("=======================");
                Console.WriteLine("Please select an option");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Edit");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View List");
                Console.WriteLine("5. Exit Application");
                Console.WriteLine("=======================");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "add"||lowerAnswer == "1"){
                    input = "valid";
                    SessionsAdd();
                }
                else if (lowerAnswer == "edit"||lowerAnswer == "2"){
                    input = "valid";
                    SessionsEdit();
                }
                else if (lowerAnswer == "delete"||lowerAnswer == "3"){
                    input = "valid";
                    SessionsDelete();
                }
                else if (lowerAnswer == "view"||lowerAnswer == "list"||lowerAnswer == "view list"||lowerAnswer == "4"){
                    input = "valid";
                    SessionsList();
                    Console.WriteLine("Press ANY key to continue");
                    Console.ReadKey();
                    Sessions();
                }
                else if (lowerAnswer == "exit" || lowerAnswer == "exit application"||lowerAnswer == "5"){
                    input = "valid";
                }
                else{

                }
            }
        }

        static void SessionsAdd()
        {
            int lID =1;
            string name ="";
            string[] tempArray = new string[100];
            StreamReader myfile = new StreamReader("listings.txt");

            string fileInput = myfile.ReadLine();
            while (fileInput != null)
            {
                tempArray = fileInput.Split('#');
                lID = int.Parse(tempArray[0]) + 1;
                fileInput = myfile.ReadLine();
            }   
            myfile.Close();
            string input = "invalid";
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Please enter Trainers ID");
            Console.WriteLine("=======================");
            string tID = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Please enter Date of the Session (mm/dd/yy)");
            Console.WriteLine("=======================");
            string date = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Please enter Time of the Session");
            Console.WriteLine("=======================");
            string time = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Please enter Cost of the Session");
            Console.WriteLine("=======================");
            string cost = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("=======================");
            Console.WriteLine("Please enter Availability of the Session");
            Console.WriteLine("=======================");
            string taken = Console.ReadLine();
            StreamReader trainers = new StreamReader("trainers.txt");

            string fileInput2 = trainers.ReadLine();
            while (fileInput2 != null)
            {
                string[] tempName = fileInput2.Split('#');
                if (tID == tempName[3]){
                    name = tempName[0];
                }
                fileInput2 = trainers.ReadLine();
            }   
            trainers.Close();
            while (input != "valid")
            {
                Console.Clear();
                Console.WriteLine("===================================================");
                Console.WriteLine("is the Session info correct");
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Listing ID:\t{lID}");
                Console.WriteLine($"Trainers Name:\t{name}");
                Console.WriteLine($"Session Date:\t{date}");
                Console.WriteLine($"Session Time:\t{time}");
                Console.WriteLine($"Session Cost:\t{cost}");
                Console.WriteLine($"Session Availability:\t{taken}");
                Console.WriteLine("===================================================");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "yes"||lowerAnswer == "1"){
                    string trainerInput = (lID+"#"+tID+"#"+date+"#"+time+"#"+cost+"#"+taken);
                    StreamWriter sessionInfo = new StreamWriter("listings.txt", true);
                    sessionInfo.Write(trainerInput);
                    sessionInfo.WriteLine();
                    sessionInfo.Close();
                    input = "valid";
                }
                else if (lowerAnswer == "no"||lowerAnswer == "2"){
                    input = "valid";
                    SessionsAdd();
                }
                else{

                }
            }
            Listing classObj2 = new Listing();
                    classObj2.Sessions();
        }

        static void SessionsEdit()
        {
            string tID = "";
            string date = "";
            string time = "";
            string cost = "";
            string taken = "";
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("Please enter Listing ID");
            Console.WriteLine("========================");
            string lID = Console.ReadLine();

            StreamReader myfile = new StreamReader("listings.txt");

            string fileInput = myfile.ReadLine();
            while (fileInput != null)
            {
                string[] tempArray = fileInput.Split('#');
                    if (lID == tempArray[0])
                    {
                        tID = tempArray[1];
                        date = tempArray[2];
                        time = tempArray[3];
                        cost = tempArray[4];
                        taken = tempArray[5];
                    }
                fileInput = myfile.ReadLine();
            }
                    myfile.Close();
                    Console.Clear();
                    Console.WriteLine("==================================");
                    Console.WriteLine($"Trainer ID: {tID}");
                    Console.WriteLine($"Session Date {date}");
                    Console.WriteLine($"Session Time {time}");
                    Console.WriteLine($"Session Cost {cost}");
                    Console.WriteLine($"Session Availability {taken}");
                    Console.WriteLine("==================================");
                    Console.WriteLine("What field would you like to edit?");
                    Console.WriteLine("Trainer");
                    Console.WriteLine("Date");
                    Console.WriteLine("Time");
                    Console.WriteLine("cost");
                    Console.WriteLine("Availability");
                    string input = Console.ReadLine();
                    string lowerInput = input.ToLower();
                    if (lowerInput == "id"||lowerInput == "trainer"||lowerInput == "trainer id"){
                        Console.WriteLine("Update Trainer");
                        tID = Console.ReadLine();
                        BufferPush(lID,tID,date,time,cost,taken);
                    }
                    else if (lowerInput == "date"){
                        Console.WriteLine("Update session date");
                        date = Console.ReadLine();
                        BufferPush(lID,tID,date,time,cost,taken);
                    }
                    else if (lowerInput == "time"){
                        Console.WriteLine("Update session time");
                        time = Console.ReadLine();
                        BufferPush(lID,tID,date,time,cost,taken);
                    }
                    else if (lowerInput == "cost"){
                        Console.WriteLine("Update session cost");
                        cost = Console.ReadLine();
                        BufferPush(lID,tID,date,time,cost,taken);
                    }
                    else if (lowerInput == "availability"){
                        Console.WriteLine("Update session abailability");
                        date = Console.ReadLine();
                        BufferPush(lID,tID,date,time,cost,taken);
                    }
            myfile.Close();
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
            Listing classObj2 = new Listing();
                    classObj2.Sessions();
        }

        static void SessionsDelete()
        {
            int count =0;
            Console.Clear();
            SessionsList();
            StreamReader listings = new StreamReader("listings.txt");
            StreamWriter bufferWrite = new StreamWriter("buffer.txt");
            Console.WriteLine("input Listing ID to DELETE");
            string delete = Console.ReadLine();
            string fileInput = listings.ReadLine();
            while (fileInput != null)
            {
                string[] tempArray = fileInput.Split('#');
                if (delete == tempArray[0]){
                }
                else{
                    bufferWrite.Write(fileInput);
                    bufferWrite.Write('^');
                    count++;
                }
                fileInput = listings.ReadLine();
            }
            listings.Close();
            bufferWrite.Close();
            StreamReader bufferRead = new StreamReader("buffer.txt");
            StreamWriter listingsWrite = new StreamWriter("listings.txt");
            string fileBuffer = bufferRead.ReadLine();
            while (fileBuffer != null)
            {
                string[] tempArray = fileBuffer.Split('^');
                for (int i =0;i<count;i++){
                    listingsWrite.Write(tempArray[i]);
                    listingsWrite.WriteLine();
                }    
                fileBuffer = bufferRead.ReadLine();
            }
            listingsWrite.Close();
            bufferRead.Close();
            Listing classObj2 = new Listing();
                    classObj2.Sessions();
        }

        static void SessionsList()
        {
            Console.Clear();
            StreamReader SL = new StreamReader("listings.txt");
            string temp = SL.ReadLine();
            Console.WriteLine("===================================================================================================================");
            Console.WriteLine($"  Listing ID\t   Trainer ID\t\tSession Date\tSession Time\tSession Cost\tAvailability");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            while (temp != null)
            {
                string [] tempArray = temp.Split('#');
                Console.WriteLine($"\t{tempArray[0]}\t\t{tempArray[1]}\t\t{tempArray[2]}\t\t\t{tempArray[3]}\t\t{tempArray[4]}\t{tempArray[5]}");
                temp = SL.ReadLine();
            }
            Console.WriteLine("===================================================================================================================");
            SL.Close();
        }
    }
}
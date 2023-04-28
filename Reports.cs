using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_Jwwilliams4
{
    public class Reports
    {
        public void ReportsMenu()
        {
            string input = "invalid";
            while (input != "valid"){
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("        Reports       ");
                Console.WriteLine("=======================");
                Console.WriteLine("Please select an option");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Individual Customer Sessions");
                Console.WriteLine("2. Historical Customer Sessions");
                Console.WriteLine("3. Historical Revenue Report");
                Console.WriteLine("4. Individual Trainer Sessions");
                Console.WriteLine("5. Session cost");
                Console.WriteLine("6. Exit Application");
                Console.WriteLine("=======================");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "individual customer sessions"||lowerAnswer == "1"){
                    input = "valid";
                    IndividualCustomer();
                }
                else if (lowerAnswer == "historical customer sessions"||lowerAnswer == "2"){
                    input = "valid";
                    date();
                }
                else if (lowerAnswer == "historical revenue report"||lowerAnswer == "3"){
                    input = "valid";
                   Revenue();
                }
                else if (lowerAnswer == "view"||lowerAnswer == "list"||lowerAnswer == "view list"||lowerAnswer == "4"){
                    input = "valid";
                    IndividualTrainer();                    
                }
                else if (lowerAnswer == "session" || lowerAnswer == "session cost"||lowerAnswer == "5"){
                    input = "valid";
                    MoneySort();
                }
                else if (lowerAnswer == "exit" || lowerAnswer == "exit application"||lowerAnswer == "6"){
                    input = "valid";
                
                }
                else{

                }
            }
        }

        static void IndividualCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter Customer E-Mail Address.");
            string input = Console.ReadLine();
            Console.Clear();
            StreamReader LL = new StreamReader("transactions.txt");
            string temp = LL.ReadLine();
            Console.WriteLine("===================================================================================================================");
            Console.WriteLine($"  Transaction ID\t   Customer Name\t\tCustomer Email\tTraining Date\tTrainer ID\tTrainer Name\tStatus");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            while (temp != null)
            {
                string [] tempArray = temp.Split('#');
                if (tempArray[2] == input){
                Console.WriteLine($"\t{tempArray[0]}\t\t{tempArray[1]}\t\t{tempArray[2]}\t\t\t{tempArray[3]}\t\t{tempArray[4]}\t{tempArray[5]}\t{tempArray[6]}"); 
                }
                temp = LL.ReadLine();
            }
            Console.WriteLine("===================================================================================================================");
            LL.Close();
            Console.WriteLine("Would you like to save this report?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string answer = Console.ReadLine();
            string lowerAnswer = answer.ToLower();
            if (lowerAnswer == "yes"||lowerAnswer == "1")
            {
                Console.WriteLine("Enter report name.");
                string saveName = Console.ReadLine();
                StreamWriter myReport = new StreamWriter($"{saveName}.txt");
                myReport.Close();
                
                int count =0;
                Console.Clear();
                StreamReader trainers = new StreamReader("transactions.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                string fileInput = trainers.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if (input == tempArray[2]){
                        bufferWrite.Write($"{tempArray[0]} {tempArray[1]} {tempArray[2]} {tempArray[3]} {tempArray[4]} {tempArray[5]} {tempArray[6]}");
                        bufferWrite.Write('^');
                        count++;
                    }
                    else{
                        count++;
                    }
                    fileInput = trainers.ReadLine();
                }
                trainers.Close();
                bufferWrite.Close();
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter trainersWrite = new StreamWriter($"{saveName}.txt");
                string fileBuffer = bufferRead.ReadLine();
                while (fileBuffer != null)
                {
                    string[] tempArray = fileBuffer.Split('^');
                    for (int i =0;i<count;i++){
                        trainersWrite.Write(tempArray[i]);
                        trainersWrite.WriteLine();
                    }    
                    fileBuffer = bufferRead.ReadLine();
                }
                trainersWrite.Close();
                bufferRead.Close(); 
            }
            else
            {

            }
        }

        static void date(){
            Console.Clear();
            int count = 1;
            StreamReader SL = new StreamReader("transactions.txt");
            List<string> dates = new List<string>();
            List<DateTime> dateTime = new List<DateTime>();
            string temp = SL.ReadLine();
            while (temp != null)
            {
                string[] tempArray = temp.Split('#');
                string text = tempArray[3];
                dateTime.Add(DateTime.ParseExact(text, "MM/dd/yyyy", null));
                temp = SL.ReadLine();
                count++;
            }          
            SL.Close();
            dateTime.Sort();
            
            for(int i = 0; i < count - 1; i++)      
            {
                StreamReader LL = new StreamReader("transactions.txt");
                string temp2 = LL.ReadLine();
                while (temp2 != null)
                {
                    string [] tempArray = temp2.Split('#');
                    string text = tempArray[3];                    
                    if (dateTime[i] == DateTime.ParseExact(text, "MM/dd/yyyy", null))
                    {
                        Console.WriteLine($"\t{tempArray[0]} {tempArray[1]} {tempArray[2]} {tempArray[3]} {tempArray[4]} {tempArray[5]} {tempArray[6]}"); 
                    }                        
                    temp2 = LL.ReadLine();
                } 
                LL.Close();
            }
        }

        static void Revenue()
        {
            int money = 0;
            Console.Clear();
            StreamReader LL = new StreamReader("listings.txt");
            string temp = LL.ReadLine();
            while (temp != null)
            {
                string [] tempArray = temp.Split('#');
                if (tempArray[5] == "taken"){
                Console.WriteLine($"{tempArray[0]} {tempArray[1]} {tempArray[2]} {tempArray[3]} {tempArray[4]} {tempArray[5]}"); 
                money += int.Parse(tempArray[4]);
                }
                temp = LL.ReadLine();
            }
            LL.Close();
            Console.WriteLine("Total revenue earned is: $" + money);
            Console.WriteLine("===================================");

            Console.WriteLine("Would you like to save this report?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string answer = Console.ReadLine();
            string lowerAnswer = answer.ToLower();
            if (lowerAnswer == "yes"||lowerAnswer == "1")
            {
                Console.WriteLine("Enter report name.");
                string saveName = Console.ReadLine();
                StreamWriter myReport = new StreamWriter($"{saveName}.txt");
                myReport.Close();
                
                int count =0;
                Console.Clear();
                StreamReader trainers = new StreamReader("listings.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                string fileInput = trainers.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if ("taken" == tempArray[4]){
                        bufferWrite.Write($"{tempArray[0]} {tempArray[1]} {tempArray[2]} {tempArray[3]} {tempArray[4]} {tempArray[5]}");
                        bufferWrite.Write('^');
                        count++;
                    }
                    else{
                        bufferWrite.Write(fileInput);
                        bufferWrite.Write('^');
                        count++;
                    }
                    fileInput = trainers.ReadLine();
                }
                bufferWrite.Write("==================================");
                bufferWrite.Write('^');
                bufferWrite.Write("Total revenue earned is: $" + money);
                bufferWrite.Write('^');
                count++;
                trainers.Close();
                bufferWrite.Close();
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter trainersWrite = new StreamWriter($"{saveName}.txt");
                string fileBuffer = bufferRead.ReadLine();
                while (fileBuffer != null)
                {
                    string[] tempArray = fileBuffer.Split('^');
                    for (int i =0;i<count;i++){
                        trainersWrite.Write(tempArray[i]);
                        trainersWrite.WriteLine();
                    }    
                    fileBuffer = bufferRead.ReadLine();
                }
                trainersWrite.Close();
                bufferRead.Close(); 
            }
            else
            {

            }
        }

        static void IndividualTrainer()
        {
            Console.Clear();
            Console.WriteLine("Enter Trainer ID.");
            string input = Console.ReadLine();
            Console.Clear();
            StreamReader LL = new StreamReader("transactions.txt");
            string temp = LL.ReadLine();
            Console.WriteLine("===================================================================================================================");
            Console.WriteLine($"  Transaction ID\t   Customer Name\t\tCustomer Email\tTraining Date\tTrainer ID\tTrainer Name\tStatus");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            while (temp != null)
            {
                string [] tempArray = temp.Split('#');
                if (tempArray[4] == input){
                Console.WriteLine($"\t{tempArray[0]}\t\t{tempArray[1]}\t\t{tempArray[2]}\t\t\t{tempArray[3]}\t\t{tempArray[4]}\t{tempArray[5]}\t{tempArray[6]}"); 
                }
                temp = LL.ReadLine();
            }
            Console.WriteLine("===================================================================================================================");
            LL.Close();
            Console.WriteLine("Would you like to save this report?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string answer = Console.ReadLine();
            string lowerAnswer = answer.ToLower();
            if (lowerAnswer == "yes"||lowerAnswer == "1")
            {
                Console.WriteLine("Enter report name.");
                string saveName = Console.ReadLine();
                StreamWriter myReport = new StreamWriter($"{saveName}.txt");
                myReport.Close();
                
                int count =0;
                Console.Clear();
                StreamReader trainers = new StreamReader("transactions.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                string fileInput = trainers.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if (input == tempArray[4]){
                        bufferWrite.Write($"{tempArray[0]} {tempArray[1]} {tempArray[2]} {tempArray[3]} {tempArray[4]} {tempArray[5]} {tempArray[6]}");
                        bufferWrite.Write('^');
                        count++;
                    }
                    else{
                        count++;
                    }
                    fileInput = trainers.ReadLine();
                }
                trainers.Close();
                bufferWrite.Close();
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter trainersWrite = new StreamWriter($"{saveName}.txt");
                string fileBuffer = bufferRead.ReadLine();
                while (fileBuffer != null)
                {
                    string[] tempArray = fileBuffer.Split('^');
                    for (int i =0;i<count;i++){
                        trainersWrite.Write(tempArray[i]);
                        trainersWrite.WriteLine();
                    }    
                    fileBuffer = bufferRead.ReadLine();
                }
                trainersWrite.Close();
                bufferRead.Close(); 
            }
            else
            {

            }
        }

        static void MoneySort()
        {
            int money = 0;
            Console.Clear();
            Console.WriteLine("Enter minimum session cost.");
            int input = int.Parse(Console.ReadLine());
            Console.Clear();
            StreamReader LL = new StreamReader("listings.txt");
            string temp = LL.ReadLine();
            while (temp != null)
            {
                string [] tempArray = temp.Split('#');
                if (int.Parse(tempArray[4]) > input){
                Console.WriteLine($"\t{tempArray[0]}\t\t{tempArray[1]}\t\t{tempArray[2]}\t\t\t{tempArray[3]}\t\t{tempArray[4]}\t{tempArray[5]}"); 
                money += int.Parse(tempArray[4]);
                }
                temp = LL.ReadLine();
            }
            LL.Close();
            Console.WriteLine("Total revenue earned is: $" + money);
            Console.WriteLine("===================================");
            Console.WriteLine("Would you like to save this report?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            string answer = Console.ReadLine();
            string lowerAnswer = answer.ToLower();
            if (lowerAnswer == "yes"||lowerAnswer == "1")
            {
                Console.WriteLine("Enter report name.");
                string saveName = Console.ReadLine();
                StreamWriter myReport = new StreamWriter($"{saveName}.txt");
                myReport.Close();
                
                int count =0;
                Console.Clear();
                StreamReader trainers = new StreamReader("listings.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                string fileInput = trainers.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if (int.Parse(tempArray[4]) > input){
                        bufferWrite.Write($"{tempArray[0]} {tempArray[1]} {tempArray[2]} {tempArray[3]} {tempArray[4]} {tempArray[5]}");
                        bufferWrite.Write('^');
                        count++;
                    }
                    else{
                        count++;
                    }
                    fileInput = trainers.ReadLine();
                }
                bufferWrite.Write("==================================");
                bufferWrite.Write('^');
                bufferWrite.Write("Total revenue earned is: $" + money);
                bufferWrite.Write('^');
                count++;
                trainers.Close();
                bufferWrite.Close();
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter trainersWrite = new StreamWriter($"{saveName}.txt");
                string fileBuffer = bufferRead.ReadLine();
                while (fileBuffer != null)
                {
                    string[] tempArray = fileBuffer.Split('^');
                    for (int i =0;i<count;i++){
                        trainersWrite.Write(tempArray[i]);
                        trainersWrite.WriteLine();
                    }    
                    fileBuffer = bufferRead.ReadLine();
                }
                trainersWrite.Close();
                bufferRead.Close(); 
            }
            else
            {

            }
        }

    }
}
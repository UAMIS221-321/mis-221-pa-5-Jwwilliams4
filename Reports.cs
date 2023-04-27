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
                Console.WriteLine("4. View List");
                Console.WriteLine("5. Exit Application");
                Console.WriteLine("=======================");
                string answer = Console.ReadLine();
                string lowerAnswer = answer.ToLower();
                if (lowerAnswer == "individual customer sessions"||lowerAnswer == "1"){
                    input = "valid";
                    IndividualCustomer();
                }
                else if (lowerAnswer == "historical customer sessions"||lowerAnswer == "2"){
                    input = "valid";
                    
                }
                else if (lowerAnswer == "historical revenue report"||lowerAnswer == "3"){
                    input = "valid";
                   
                }
                else if (lowerAnswer == "view"||lowerAnswer == "list"||lowerAnswer == "view list"||lowerAnswer == "4"){
                    input = "valid";
                    
                    Console.WriteLine("Press ANY key to continue");
                    Console.ReadKey();
                    
                }
                else if (lowerAnswer == "exit" || lowerAnswer == "exit application"||lowerAnswer == "5"){
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
                        bufferWrite.Write(fileInput);
                        bufferWrite.Write('^');
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

    }
}
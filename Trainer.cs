using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_Jwwilliams4
{
    class Trainer
    {
        public void TrainerMenu()
        {
            string input = "invalid";
            while (input != "valid"){
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("        Trainers       ");
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
                    TrainersAdd();
                }
                else if (lowerAnswer == "edit"||lowerAnswer == "2"){
                    input = "valid";
                    TrainersEdit();
                }
                else if (lowerAnswer == "delete"||lowerAnswer == "3"){
                    input = "valid";
                    TrainersDelete();
                }
                else if (lowerAnswer == "view"||lowerAnswer == "list"||lowerAnswer == "view list"||lowerAnswer == "4"){
                    input = "valid";
                    TrainerList();
                    Console.WriteLine("Press ANY key to continue");
                    Console.ReadKey();
                    TrainerMenu();
                }
                else if (lowerAnswer == "exit" || lowerAnswer == "exit application"||lowerAnswer == "5"){
                    input = "valid";
                
                }
                else{

                }
            }
        }

        static void TrainersAdd()
            {
                string input = "invalid";
                int ID =0;
                string[] tempArray = new string[100];
                StreamReader myfile = new StreamReader("trainers.txt");

                string fileInput = myfile.ReadLine();
                while (fileInput != null)
                {
                    tempArray = fileInput.Split('#');
                    ID = int.Parse(tempArray[3]) + 1;
                    fileInput = myfile.ReadLine();
                }   
                myfile.Close();
                Console.Clear();
                Console.WriteLine("==========================");
                Console.WriteLine("Please enter Trainers Name");
                Console.WriteLine("==========================");
                string name = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("Please enter Trainers Mailing Address");
                Console.WriteLine("=======================");
                string mail = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("Please enter Trainers E-Mail Address");
                Console.WriteLine("=======================");
                string eMail = Console.ReadLine();
                while (input != "valid")
                {
                    Console.Clear();
                    Console.WriteLine("===================================================");
                    Console.WriteLine("is the Trainers info correct");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine($"Trainers ID:  {ID}");
                    Console.WriteLine($"Trainers Name:            { name }");
                    Console.WriteLine($"Trainers Mailing Address: {mail}");
                    Console.WriteLine($"Trainers E-Mail Address:  {eMail}");
                    Console.WriteLine("===================================================");
                    Console.WriteLine("Yes");
                    Console.WriteLine("No");
                    string answer = Console.ReadLine();
                    string lowerAnswer = answer.ToLower();
                    if (lowerAnswer == "yes"){
                        string trainerInput = (name+"#"+mail+"#"+eMail+"#"+ID);
                        StreamWriter trainerInfo = new StreamWriter("trainers.txt", true);
                        trainerInfo.Write(trainerInput);
                        trainerInfo.WriteLine();
                        trainerInfo.Close();
                        input = "valid";
                    }
                    else if (lowerAnswer == "no"){
                        input = "valid";
                        TrainersAdd();
                    }
                    else{

                    }
                }
                Trainer classObj = new Trainer();
                    classObj.TrainerMenu();
            }
    
        static void TrainersEdit()
        {
            //gets info needed to edit trainers.txt
            string name = "";
            string mail = "";
            string eMail = "";
            Console.Clear();
            Trainer classObj = new Trainer();
            classObj.TrainerList();
            Console.WriteLine("========================");
            Console.WriteLine("Please enter Trainers ID");
            Console.WriteLine("========================");
            string ID = Console.ReadLine();

            StreamReader myfile = new StreamReader("trainers.txt");

            string fileInput = myfile.ReadLine();
            while (fileInput != null)
            {
                string[] tempArray = fileInput.Split('#');
                    if (ID == tempArray[3])
                    {
                        name = tempArray[0];
                        mail = tempArray[1];
                        eMail = tempArray[2];
                    }
                fileInput = myfile.ReadLine();
            }
            myfile.Close();
                    Console.Clear();
                    Console.WriteLine("==================================");
                    Console.WriteLine($"Trainer Name: {name}");
                    Console.WriteLine($"Trainer Mailing Address {mail}");
                    Console.WriteLine($"Training E-Mail Address {eMail}");
                    Console.WriteLine("==================================");
                    Console.WriteLine("What field would you like to edit?");
                    Console.WriteLine("Name");
                    Console.WriteLine("Mail");
                    Console.WriteLine("EMail");
                    string input = Console.ReadLine();
                    string lowerInput = input.ToLower();
                    if (lowerInput == "name"){
                        Console.WriteLine("Update Trainer Name");
                        name = Console.ReadLine();
                        BufferPush(name,mail,eMail,ID);
                    }
                    else if (lowerInput == "mail"){
                        Console.WriteLine("Update Trainer Mailing Address");
                        mail = Console.ReadLine();
                        BufferPush(name,mail,eMail,ID);
                    }
                    else if (lowerInput == "email"){
                        Console.WriteLine("Update Trainer E-Mail Address");
                        eMail = Console.ReadLine();
                        BufferPush(name,mail,eMail,ID);
                    }        
            myfile.Close();

            //updates buffer.txt with new info
            static void BufferPush(string name, string mail, string eMail, string ID)
            {
                int count =0;
                Console.Clear();
                StreamReader trainers = new StreamReader("trainers.txt");
                StreamWriter bufferWrite = new StreamWriter("buffer.txt");
                Trainer classObj = new Trainer();
                classObj.TrainerList();
                string fileInput = trainers.ReadLine();
                while (fileInput != null)
                {
                    string[] tempArray = fileInput.Split('#');
                    if (ID == tempArray[3]){
                        bufferWrite.Write(name+"#"+mail+"#"+eMail+"#"+ID);
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

                //updates trainers.txt with correct info from buffer.txt
                StreamReader bufferRead = new StreamReader("buffer.txt");
                StreamWriter trainersWrite = new StreamWriter("trainers.txt");
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
            classObj.TrainerMenu();
        }

        static void TrainersDelete()
        {
            //finds trainer to delete and puts all other info into buffer.txt
            int count =0;
            Console.Clear();
            StreamReader trainers = new StreamReader("trainers.txt");
            StreamWriter bufferWrite = new StreamWriter("buffer.txt");
            Trainer classObj = new Trainer();
            classObj.TrainerList();
            Console.WriteLine("input ID of Trainer to DELETE");
            string delete = Console.ReadLine();
            string fileInput = trainers.ReadLine();
            while (fileInput != null)
            {
                string[] tempArray = fileInput.Split('#');
                if (delete == tempArray[3]){
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

            //updates trainers.txt from buffer.txt
            StreamReader bufferRead = new StreamReader("buffer.txt");
            StreamWriter trainersWrite = new StreamWriter("trainers.txt");
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

        public void TrainerList()
    {
        Console.Clear();
        StreamReader TL = new StreamReader("trainers.txt");
        string temp = TL.ReadLine();
        Console.WriteLine("=====================================");
        Console.WriteLine($"Trainer Name\t\tTrainer ID");
        Console.WriteLine("-------------------------------------");
        while (temp != null)
        {
            string [] tempArray = temp.Split('#');
            Console.WriteLine($"{tempArray[0]}\t\t     {tempArray[3]}");
            temp = TL.ReadLine();
        }
        Console.WriteLine("=====================================");
        TL.Close();
    }
    }
}
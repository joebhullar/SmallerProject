using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmallerProject
{   //This class is responsible for dealing with FileMode & Console mode of operation.
    class OperationMode
    {   //In the file mode of operation, the class needs to have an int number of lines returned 
        //for the whole loop to know how long it should keep going.
        public int modeOfOperation(bool fileModeOfOperation)
        {
            int lineCount = 1;//If in console mode lineCount=1 which defaults the while loop to an infinite loop to run on console.
            if (fileModeOfOperation) //only reads file in fileModeOfOperation
                lineCount = File.ReadLines(@"C:\test\paramater.txt").Count();
            return lineCount;
        }
        //returns index for argument of while loop in main. we use valueOfInputEqnString to tell us in while if we are dealing with
        //The File mode or the Interactive Mode. For the file mode the inputeqn is at an index, otherwise in console mode it's always at index 0.
        public string valueOfInputEqnString(bool fileModeOfOperation, int inputindexOfStrEqn)
        {
            string writtentext = "";
            string[] arrayoffileinputstring = { };
            OperationMode obj = new OperationMode();
            arrayoffileinputstring = obj.readingInMode(fileModeOfOperation);
            if (fileModeOfOperation)
                return writtentext = arrayoffileinputstring[inputindexOfStrEqn]; //For fileMode
            else
                return writtentext = arrayoffileinputstring[0];//For Interactive mode
        }

        //This function is responsible for declaring path to read math eqn files.
        //It is also responsible for declaring number of inputlines to store for FileMode. (in our case i wrote down 1000)
        public string[] readingInMode(bool FileMode)
        {
            string[] writtentext = new string[1000]; // can have up to 1000 lines of input filecode to run!
            //List<string> writtentext = new List<string>();
            if (FileMode)
            {   //FileMode has no introline because we are just writing solutions to a file in filemode.
                using (StreamReader reader = new StreamReader(@"C:\test\paramater.txt"))
                {
                    int inputindexOfStrEqn = 0;
                    string algebralineinputeqn;
                    while ((algebralineinputeqn = reader.ReadLine()) != null) // reads each input line of the file!
                    {//NOw you have the algebraic eqn called algebralineinputeqn
                        writtentext[inputindexOfStrEqn] = algebralineinputeqn;
                        inputindexOfStrEqn++;
                    }
                }
                return writtentext;
            }
            else //Interactive Console Mode.
            {   //Below is our input line for consoleMode.
                Console.WriteLine("Welcome To Joe's Program: Please Enter an Equation and it will be solved \n ");
                //writtentext[0] is  indexed at zero to be in a while loop in main. This is so the user can keep
                //entering in input equations until he/she presses Ctrl+C
                writtentext[0] = Console.ReadLine();//COMMENTED OUT FOR IO TESTING!! UNCOMMENT FOR CONSOLE TESTING!!
                return writtentext;
            }
        }

        public void WriteOutMode(StringBuilder strtooutput, bool FileMode, ref int inputindexOfStrEqn, int lineCount)
        {
            if (FileMode)
            {
                using (var writer = new StreamWriter(@"C:\test\mydoc.out", true))//if  i dont want to append the existing file i enter false
                    writer.WriteLine(strtooutput);
            }
            else //We Want Interactive Mode
                Console.Write(strtooutput);
            if (FileMode)
            {
                if (inputindexOfStrEqn <= lineCount)
                    inputindexOfStrEqn++;
            }
        }
    }
}

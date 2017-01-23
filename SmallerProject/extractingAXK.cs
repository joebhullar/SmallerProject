using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
    //This class has functions that extract values a,x,and k of ax^k
   public class extractingAXK
    {   //AlgebraicBlockOfEqn takes in half of an eqn and determins if it's on LHS or RHS. If it's on RHS it will
        //multiply it's a coefficient with -1 to effectivly move that block of variable to the LHS. 
        //LeftsideOfEqn tells you which side it's on.
        public AlgebraicBlockOfEqn.blockOfAlgebra axkExtractor(String axkstr, bool LeftsideOfEqn)
        {
            double a = 1.0;
            implementingNegativeNumberStr negNumbr = new implementingNegativeNumberStr();
            negNumbr.implementNegNumber(ref axkstr, ref a);//This acknowledges the negative sign into a if needed
            a = a * extractingvalueofa(axkstr);// Extract value of a from string
            VariableAndExponentDictionary.vAEDictionary algebraicvariablesinblock = extractAlgebraicVariablesInBlock(axkstr); //Extract key value pairs of variables(as keys) and their corresponding powers(as values) and store them in 1 dictionary for a corresponding block.
            AlgebraicBlockOfEqn.blockOfAlgebra oneblock = new AlgebraicBlockOfEqn.blockOfAlgebra(); //Now we store value of a and variables  blockOfAlgebra class to represent one block of Algebra.
            if (!LeftsideOfEqn) //THIS IS Effectivley multiplying everything on RHS with Negative 1
                a = a * (-1);
            oneblock.a = a;//stores value of a into algebraicblock instance, oneblock
            oneblock.dictionaryForOneBlock = algebraicvariablesinblock;//stores dictionary value of variable and power of a into algebraicblock instance, oneblock
            return oneblock;
        }
        //This function is responsible for extracting the actual variables and powers to those variables.
        public VariableAndExponentDictionary.vAEDictionary extractAlgebraicVariablesInBlock(string inputeqnstralgebraic)//we are concerning ourselves with something like 32(x^23)*yz(p^2)
        {
            int counter = 0;
            VariableAndExponentDictionary.vAEDictionary dictEntry = new VariableAndExponentDictionary.vAEDictionary();
            while (counter <= (inputeqnstralgebraic.Length - 1))//WHILE we have variables together like xy or (x^3)*y*(z^3)
            {
                {
                    if (inputeqnstralgebraic[counter] <= 'z' && inputeqnstralgebraic[counter] >= 'a') //when a variable is detected
                    {
                        char varcontainer = inputeqnstralgebraic[counter];                            //The variable is stored in a string.
                        int extractedvalofk = 1;
                        if (((counter + 2) <= (inputeqnstralgebraic.Length - 1)) && (inputeqnstralgebraic[counter + 1] == '^'))//THIS MEANS THAT A K VALUE MUST EXIST & NEEDS TO BE EXTRACTED!!
                        { // now we KNOW that the integers here relate to power k of that last found variable.
                            extractedvalofk = inputeqnstralgebraic[counter + 2] - '0'; //Assigns First Value of k ONLY for FIRST digit
                            counter = counter + 2; //NOW COUNTER IS AT FIRST DIGIT WHICH IS ALREADY RECORDED. Lets see if there is a second digit? If that second digit is an int?
                            if ((counter + 1) <= (inputeqnstralgebraic.Length - 1))//does another digit OR Bracket OR Variable excist?
                            {
                                if (inputeqnstralgebraic[counter + 1] <= '9' && inputeqnstralgebraic[counter + 1] >= '0')//is the digit an int? if it is then it is  part of k!
                                {
                                    extractedvalofk = extractedvalofk * 10 + inputeqnstralgebraic[counter + 1] - '0';//Now The SECOND Digit has been incoorporated into k
                                    counter++;
                                    while (((counter + 1) <= (inputeqnstralgebraic.Length - 1)) && inputeqnstralgebraic[counter + 1] <= '9' && inputeqnstralgebraic[counter + 1] >= '0')
                                    {
                                        extractedvalofk = extractedvalofk * 10 + (inputeqnstralgebraic[counter + 1] - '0');
                                        counter++;
                                    }
                                }// Now we must look at the third digit until we run out of digits. Counter is now at the second digit!                            
                            }
                        }
                        counter++;
                        dictEntry.varAndExponentDictionary.Add(varcontainer, extractedvalofk);//STORES THE x and POWER k x^k for each instance it sees it
                    }
                    else
                        counter++;
                }
            }
            return dictEntry;
        }

        public double extractingvalueofa(string inputeqnstr)
        {
            int counter = 0;
            int internalndex = 0;
            double extractedvalofa = 1;
            if (inputeqnstr[0] <= '9' && inputeqnstr[0] >= '0')
            {
                extractedvalofa = inputeqnstr[0] - '0'; //Assigns First Value of A only for first digit
                counter++;
                internalndex++;
            }
            while (counter < inputeqnstr.Length && (counter == internalndex))
            {
                if (inputeqnstr[counter] <= '9' && inputeqnstr[counter] > '0')
                {
                    extractedvalofa = extractedvalofa * 10 + (inputeqnstr[counter] - '0');
                    internalndex++;
                    counter++;
                }
                else if (inputeqnstr[counter] == '.')
                {
                    double decimalcount = 1.0;
                    counter++;//must go AFTER the decimal to get number AFTER decimal
                    internalndex++;
                    if (inputeqnstr[counter] <= '9' && inputeqnstr[counter] > '0')
                    {
                        double strtodble = Char.GetNumericValue(inputeqnstr[counter]);
                        extractedvalofa = extractedvalofa + (strtodble / 10.0);  //Now we have digit after decimal
                        internalndex++;
                        decimalcount++;
                        counter++;
                    }
                    double denominatortn = 0.0; //this will be multiplied by 10 it will never be zero!
                    double numeratorofstr = 1.0;
                    while (counter < inputeqnstr.Length && (counter == internalndex) && inputeqnstr[counter] <= '9' && inputeqnstr[counter] > '0')//36.58
                    {
                        numeratorofstr = Char.GetNumericValue(inputeqnstr[counter]);
                        denominatortn = Math.Pow(10, decimalcount);
                        extractedvalofa = extractedvalofa + (numeratorofstr / (denominatortn));
                        decimalcount++;
                        counter++;
                        internalndex++;
                    }
                }
                else
                    counter++;
            }
            return extractedvalofa;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
    //Output string formatting class.
    public class OutputStringFormatting
    {   //This function extracts the Canonical form String from mergedBlocksOfAlgebraOnLhs. It then sends this string to the ouputfunction
        public StringBuilder formatSolutionStrForOutput(List<AlgebraicBlockOfEqn.blockOfAlgebra> mergedBlocksOfAlgebraOnLhs)
        {
            bool firstBlock = true;
            StringBuilder outputeqn = new StringBuilder();
            outputeqn.Append("Solution:  ");
            foreach (var listItem in mergedBlocksOfAlgebraOnLhs)
            {
                if (listItem.dictionaryForOneBlock.varAndExponentDictionary != null)//For each variable in the algebraicEqns Dictionary
                {
                    var list = listItem.dictionaryForOneBlock.varAndExponentDictionary.Keys.ToList();//it turns that variable into a list
                    list.Sort();
                    if (listItem.a == 0)// if coefficient =0 then a=0 and the string dosn't print.
                        outputeqn.Append("");
                    else if (firstBlock)
                    {
                        {
                            if (listItem.a == 1)
                                outputeqn.Append("");
                            else if (listItem.a < 0 && Math.Abs(listItem.a) == 1)
                                outputeqn.Append("-");//places '-' infront for negative number
                            else
                                outputeqn.Append(listItem.a);
                        }
                        firstBlock = false;// now that we are done formatting the first  block we set firstblock to false 
                    }
                    else if (listItem.a < 0)
                    {
                        if (listItem.a < 0 && Math.Abs(listItem.a) == 1)
                            outputeqn.Append("-"); //if fcoefficient is = -1 then we add '-' to the front of it.
                        else
                            outputeqn.Append("-" + Math.Abs(listItem.a)); //otherwise if its <0 but not -1 we add it's value aswell
                    }
                    else
                    {
                        if (listItem.a == 1)
                            outputeqn.Append("+"); //same logic asabove except for '+' instead of '-'
                        else
                            outputeqn.Append("+" + listItem.a);
                    }
                    foreach (var key in list)
                    {
                        if (listItem.a == 0) //omits the dictionary values if a == 0
                            outputeqn.Append("");
                        else if (listItem.dictionaryForOneBlock.varAndExponentDictionary[key] == 1)
                            outputeqn.Append(key); //if Exponent of that vairable =1 then we just print variable
                        else //otherwise we format the variable and power to print like so:
                            outputeqn.Append("(" + key + "^" + listItem.dictionaryForOneBlock.varAndExponentDictionary[key] + ")");
                    }
                }
            }
            outputeqn.Append("= 0 \n\n"); // after the while loop, when we have all of our eqns, we finis the string with =0 for the RHS.
            return outputeqn; //return output string
        }
    }
}

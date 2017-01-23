using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
    //This class is responsible for multiplying the coefficeint a with -1 if and only if there is a negative 
    //sign '-' immediatley at the first character of the cofficient -- variable a is the coefficent in ax^k.
    class implementingNegativeNumberStr
    {
        public void implementNegNumber(ref string aCoeffStr, ref double aCoefficnt)
        {
            if (aCoeffStr[0] == '-')//checks for the first element of coefficent string
            {
                aCoefficnt = (-1) * (aCoefficnt);
                aCoeffStr = aCoeffStr.Remove(0, 1);//We completely Remove the negative sign so we can only worry about length of a
            }
        }
    }
}

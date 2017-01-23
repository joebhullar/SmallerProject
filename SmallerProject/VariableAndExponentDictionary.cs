using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{   //This class stores an Algebraic Block's corresponding variable and power into an instance of a Dictionary.
    //ie) if we are dealing with algebraic block 23(x^36)(y^23) then the vAEDictionary would have variable x and its
    //corresponding power 36 and variable y and it's corresponding power 23.
   public class VariableAndExponentDictionary
    {
        //Each Algebraic Block of Code would have One instance of vAEDictionary and one variable a for it's coefficient.
        public class vAEDictionary
        {
            public Dictionary<char, int> varAndExponentDictionary = new Dictionary<char, int>();
        }
    }
}

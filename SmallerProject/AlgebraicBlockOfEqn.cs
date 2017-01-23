using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallerProject
{
   //This class represents each algebraic block of equation. 
   public class AlgebraicBlockOfEqn
    {
        //This is because each block of AlgebraicEquation has a coefficient a, & each block has variables
        //and their corredponding values of a.
        public class blockOfAlgebra
        {
            public double a;
            // Dictionary of Variable's and Exponents  
            public VariableAndExponentDictionary.vAEDictionary dictionaryForOneBlock;
        }
    }
}

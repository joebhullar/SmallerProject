using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{   
    //This class is for a function that takes input equation pf string and outputs the string to Canonical Form.
    class TestEqnChecker
    {   //This function is used ONLY for tests to input equations to see if they match the string Canonical form.
        public string TestEquationChecker(string writtentextTesting)
        {
            SmallerProject.equationStringToCanonicalForm eqnStrToCanonical = new SmallerProject.equationStringToCanonicalForm();
            StringBuilder outputeqn = eqnStrToCanonical.inputEquationStringToCanonicalString(writtentextTesting);
            string comparpurpose = outputeqn.ToString();// We must cast convert StringBuilder into string. 
            return comparpurpose;                       //This is done by assining output to a string variable.
        }
    }
}

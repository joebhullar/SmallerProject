using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmallerProject
{
    //This class is for converting the LHS and RHS strings of inputequations into a list of blockOfAlgebra
    //blockOfAlgebra is ax^k where a is the coefficient, x is the variable and k is the power/exponent.
   public class ScanningAlgorithm
    {
        //This function is responsible for scanning a string of equation and returning a list of blockOfAlgebra type.
        public List<AlgebraicBlockOfEqn.blockOfAlgebra> LeftRightEqn(string writtentext, bool leftsideqn)
        {
            int zeroindexforleft = 0;//for left side of eqn we set zeroindexforleft=0
            if (!leftsideqn)
                zeroindexforleft = 1;//for right side of eqn we set zeroindexforleft=1
            ScanningAlgorithm blockScannerobj = new ScanningAlgorithm();
            extractingAXK blockOfaxkAlgebra = new extractingAXK();
            string blocksOfHalfTheEqn = "";
            List<AlgebraicBlockOfEqn.blockOfAlgebra> LeftANDRightSideListofBlockAlgebra = new List<AlgebraicBlockOfEqn.blockOfAlgebra>();
            blocksOfHalfTheEqn = writtentext.Split('=')[zeroindexforleft];//we split between LHS and RHS with the '=' sign.
            string[] extractedfromOneSofEQN = blockScannerobj.blockVariableCount(blocksOfHalfTheEqn); //splits up string chunck of blocks and puts them into array of string called extractedfromLHSofEQN

            for (int j = 0; j < extractedfromOneSofEQN.Length; j++)
            {
                blockScannerobj.blockExtractor(ref extractedfromOneSofEQN[j]);// Now the array of strings is filled with the blocks of algorithms extracted in extractedfromLHSofEQN     
                LeftANDRightSideListofBlockAlgebra.Add(blockOfaxkAlgebra.axkExtractor(extractedfromOneSofEQN[j], leftsideqn));
            }
            return LeftANDRightSideListofBlockAlgebra;//Returns either side of function depending on whether bool leftidesign is true or false.
        }

        //Splits original input string intop words with seperating characters.
        public String[] blockVariableCount(String writtentext)
        //to prevent '-' from getting cut out we replace it with a pipe | after the function call that took it out for splitting the string with delimiters.
        // so we can later on, in line 49 put them back where they were.
        {
            writtentext = writtentext.Replace("-", " |");
            char[] separatingChars = { '-', ' ', '+', '=' }; //delimiters
            string[] words = writtentext.Split(separatingChars, System.StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        // since '-' had to be one of the delimiters for '-' seperation it was cut out. 
        //to compensate for the lost '-' we replaced it back with '-' by subbing in '|'
        public void blockExtractor(ref String owb)
        {
            owb = owb.Replace("|", "-");// seperates each math block and replaces neg sign with | to replace later.
        }
    }

}

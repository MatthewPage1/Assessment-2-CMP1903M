using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Assessment_2
{
    internal class Testing
    {
        //TEST REQUIREMENTS
        //Use debug.assert() to verify:
        //Sevens Out: Total of sum, stop if total = 7
        //Three Or More: Scores set and added correctly, recognise when total >= 20.

        public void SevensOutGame(int Total)
        {
            Debug.Assert(Total != 7, "Total shouldnt be 7");    //Tests the total from the SevensOut game and if its not 7, prints accordingly.
            Console.WriteLine("(TESTING) Total is not 7");
        }

        public void ThreeOrMoreGame(int Total)
        {
            Debug.Assert(Total <= 20, "Total shouldnt be 20 or more"); //Tests the total from the ThreeOrMore game and if its not 20 or more, prints accordingly
            Console.WriteLine("(TESTING) Total is not greater than 20");

            Debug.Assert(Total >= 0, "Scores shouldnt be less than 0"); //Tests that the scores of each player and if its not less than 0, prints accordingly
            Console.WriteLine("(TESTING) Scores are not be less than 0");
        }

    }
}

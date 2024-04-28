using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    internal class SevensOut
    {


        public int Total { get; private set; }
        public int NumPlays { get; private set; }

        public void PlayGame()
        {
            Testing SevensOutTest = new Testing();  // Instantiate Testing class
            Statistics SevensHighScore = new Statistics(); //Instantiate Statistics for high score
            Statistics SevensNumPlays = new Statistics(); //Instantiate Statistics for number of plays

            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
            int target = 7; //Set the target value for the sum of the 2 die

            while (true) //loop will stay true until target value is found
            {
                Die myFirstDie = new Die();          //new instance of die called myDie
                myFirstDie.CurrentDieVal = 1;        //give currentdievalue an initial value

                Die mySecondDie = new Die();        //second instance called my second die
                mySecondDie.CurrentDieVal = 1;

                myFirstDie.RollDie();                                                                   //roll first die
                mySecondDie.RollDie();                                                                   //roll second die


                Total += myFirstDie.CurrentDieVal + mySecondDie.CurrentDieVal; //add to the running total

                
                Console.WriteLine($"\n{myFirstDie.CurrentDieVal} and {mySecondDie.CurrentDieVal} which makes {myFirstDie.CurrentDieVal + mySecondDie.CurrentDieVal}!");       //print to screen the values
                
                //if statement for rolling a double
                if (myFirstDie.CurrentDieVal == mySecondDie.CurrentDieVal)
                {
                    Console.WriteLine($"you rolled a double {myFirstDie.CurrentDieVal}! As a result, your total for this go is doubled");
                    Total += (myFirstDie.CurrentDieVal * 2); //times by 2 only because we have already added one part of the double above

                }

                //if statement for getting to the target value of 7
                else if (myFirstDie.CurrentDieVal + mySecondDie.CurrentDieVal == target)
                {
                    Console.WriteLine($"\nValue 7 has been found and the total is {Total}\n");
                    SevensHighScore.UpdateHighScore(Total); //Send total to Statistics class so it can be checked to see if its a new highscore
                    Console.WriteLine($"Current high score: {SevensHighScore.GetHighScore()}");
                    break; // Exit the loop
                }


                SevensOutTest.SevensOutGame(Total);  // Testing verifies total is not 7
                Console.WriteLine($"The running sum of the dice values are: {Total}");

            }

         SevensNumPlays.UpdatePlays(); //add to the number of plays counter
         Console.WriteLine($"Number of SevensOut plays:  {SevensNumPlays.GetNumPlays()}");
         Game myGame = new Game(); //create new instance of game once current one has finished
         myGame.PlayGame();

        }
    }
}
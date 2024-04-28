using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    internal class ThreeOrMore
    {
        public int Total { get; private set; }
        public int NumPlays { get; private set; }
        public void PlayGame()
        {

            Testing ThreeOrMoreTest = new Testing();  // Instantiate Testing class
            Statistics ThreeOrMoreNumPlays = new Statistics();

            bool PlayerTurn = true; //this determines whos turn it is, starting with player
            bool GameOver = false; //game over variable

            int PlayerPoints = 0;
            int Player2Points = 0;

            //keep running until game over is set to true
            while (!GameOver)
            {


                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                if (PlayerTurn == true)
                {
                    Console.WriteLine($"\nPlayer 1's turn!\n");
                }
                else
                {
                    Console.WriteLine($"\nPlayer 2's turn!\n");
                }

                Console.WriteLine("\nRolling...");

                Die PlayerFirstDie = new Die();          //new instance of die called PlayerFirstDie
                PlayerFirstDie.CurrentDieVal = 1;        //give currentdievalue an initial value

                Die PlayerSecondDie = new Die();        //second instance called PlayerSecondDie
                PlayerSecondDie.CurrentDieVal = 1;

                Die PlayerThirdDie = new Die();          //third instance called PlayerThirdDie
                PlayerThirdDie.CurrentDieVal = 1;

                Die PlayerFourthDie = new Die();        //fourth instance called PlayerFourthDie
                PlayerFourthDie.CurrentDieVal = 1;

                Die PlayerFifthDie = new Die();          //fifth instance called PlayerFifthDie
                PlayerFifthDie.CurrentDieVal = 1;


                Die ComFirstDie = new Die();          //new instance of die called ComFirstDie
                ComFirstDie.CurrentDieVal = 1;        //give currentdievalue an initial value

                Die ComSecondDie = new Die();        //second instance called ComSecondDie
                ComSecondDie.CurrentDieVal = 1;

                Die ComThirdDie = new Die();          //third instance of die called ComThirdDie
                ComThirdDie.CurrentDieVal = 1;

                Die ComFourthDie = new Die();        //fourth instance called ComFourthDie
                ComFourthDie.CurrentDieVal = 1;

                Die ComFifthDie = new Die();          //fifth instance of ComFifthDie
                ComFifthDie.CurrentDieVal = 1;


                PlayerFirstDie.RollDie();                                                                   //roll first die for player
                PlayerSecondDie.RollDie();                                                                  //roll second die for player
                PlayerThirdDie.RollDie();                                                                   //roll third die for player
                PlayerFourthDie.RollDie();                                                                  //roll fourth die for player
                PlayerFifthDie.RollDie();                                                                   //roll fifth die for player


                //store the dice values into an array
                int[] PlayerArray = { PlayerFirstDie.CurrentDieVal, PlayerSecondDie.CurrentDieVal, PlayerThirdDie.CurrentDieVal, PlayerFourthDie.CurrentDieVal, PlayerFifthDie.CurrentDieVal };

                CheckForDoubles(PlayerArray, PlayerTurn, ref PlayerPoints, ref Player2Points); 


                static void CheckForDoubles(int[] Rolls, bool PlayerTurn, ref int PlayerPoints, ref int Player2Points)
                {
                    Dictionary<int, int> RollCounts = new Dictionary<int, int>();

                    //check each roll
                    foreach (int roll in Rolls)
                    {

                        Console.WriteLine(roll);
                        //check for the double value
                        if (RollCounts.ContainsKey(roll))
                        {
                            RollCounts[roll]++;
                        }
                        else
                        {
                            RollCounts[roll] = 1;
                        }
                    }



                    //check for doubles
                    if (RollCounts.ContainsValue(5))
                    {
                        //for rolling 5 doubles
                        Console.WriteLine("\n5 Doubles, 12 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 12;
                        }
                        else if (PlayerTurn == false) 
                        {
                            Player2Points += 12;
                        }
                    }
                    else if (RollCounts.ContainsValue(4))
                    {
                        //for rolling 4 doubles
                        Console.WriteLine("\n4 Doubles, 6 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 6;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 6;
                        }
                    }
                    else if (RollCounts.ContainsValue(3))
                    {
                        //for rolling 3 doubles
                        Console.WriteLine("\n3 Doubles, 3 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 3;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 3;
                        }
                    }
                    else if (RollCounts.ContainsValue(2))
                    {
                        //for rolling 2 doubles ask user to rethrow all or remaining
                        Console.WriteLine("\n2 Doubles, do you want to rethrow all dice or rethrow the remaining dice please type 'all' or 'remaining' respectively: ");
                        string RerollChoice = Console.ReadLine();

                        if (RerollChoice.ToLower() == "all")
                        {
                            Console.Write("\nRerolling all\n");
                            RerollAll(Rolls, PlayerTurn, ref PlayerPoints, ref Player2Points);
                        }

                        else if (RerollChoice == "remaining")
                        {
                            Console.Write("\nRerolling remaining\n");
                            RerollRemaining(Rolls, PlayerTurn, ref PlayerPoints, ref Player2Points);
                        }

                        else
                        {
                            Console.WriteLine("\nIncorrect input...");

                        }
                    }
                    else
                    {
                        //for no doubles
                        Console.WriteLine("\nNo doubles");
                    }
                }

                //reroll all dice function
                static void RerollAll(int[] Rolls, bool PlayerTurn, ref int PlayerPoints, ref int Player2Points)
                {
                    List<int> RerolledValues = new List<int>(); //list stores rerolled values

                    //rerolls all dice
                    for (int i = 0; i < Rolls.Length; i++)
                    {
                        Die RerollDie = new Die();
                        RerollDie.CurrentDieVal = Rolls[i];
                        RerollDie.RollDie();
                        Rolls[i] = RerollDie.CurrentDieVal;
                    }

                    //prints the rerolled values
                    Console.WriteLine("\nRerolled values: ");
                    foreach (int roll in Rolls)
                    {
                        Console.WriteLine(roll);
                        RerolledValues.Add(roll); //adds the values to a list to be checked
                    }

                    //changes the values in the array
                    int[] RerolledArray = new int[5];
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < RerolledValues.Count)
                        {
                            RerolledArray[i] = RerolledValues[i];
                        }

                    }

                    
                    Dictionary<int, int> RollCounts = new Dictionary<int, int>();
                    foreach (int value in RerolledArray)
                    {
                        //check for the double value
                        if (RollCounts.ContainsKey(value))
                        {
                            RollCounts[value]++;
                        }
                        else
                        {
                            RollCounts[value] = 1;
                        }

                    }



                    //checks for doubles
                    if (RollCounts.ContainsValue(5))
                    {
                        Console.WriteLine("\n5 Doubles, 12 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 12;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 12;
                        }
                    }
                    else if (RollCounts.ContainsValue(4))
                    {
                        Console.WriteLine("\n4 Doubles, 6 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 6;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 6;
                        }
                    }
                    else if (RollCounts.ContainsValue(3))
                    {
                        Console.WriteLine("\n3 Doubles, 3 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 3;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo points obtained as no double greater than 2.");
                    }


                }

                //reroll remaining dice function
                static void RerollRemaining(int[] Rolls, bool PlayerTurn, ref int PlayerPoints, ref int Player2Points)
                {
                    List<int> RemainingDiceToReroll = new List<int>(); //list to store the remaining dice to reroll
                    List<int> RerolledValues = new List<int>(); //list to store the rerolled values

                    //find the dice needed to be rerolled 
                    for (int i = 0; i < Rolls.Length; i++)
                    {
                        if (Rolls.Count(r => r == Rolls[i]) == 1)
                        {
                            RemainingDiceToReroll.Add(i);

                        }

                    }

                    //reroll the remaining dice
                    foreach (var index in RemainingDiceToReroll)
                    {
                        Die RerollDie = new Die();
                        RerollDie.CurrentDieVal = Rolls[index];
                        RerollDie.RollDie();
                        Rolls[index] = RerollDie.CurrentDieVal;
                    }

                    //print rerolled values
                    Console.WriteLine("\nRerolled values: ");
                    for (int i = 0; i < Rolls.Length; i++)
                    {
                        Console.WriteLine(Rolls[i]);
                        RerolledValues.Add(Rolls[i]); //add values to a list to be checked
                    }

                    //change the values in the array
                    int[] RerolledArray = new int[5];
                    for (int i = 0; i < 5; i++)
                    {
                        if (i < RerolledValues.Count)
                        {
                            RerolledArray[i] = RerolledValues[i];
                        }

                    }

                    Dictionary<int, int> RollCounts = new Dictionary<int, int>();
                    foreach (int value in RerolledArray)
                    {
                        //check for double values
                        if (RollCounts.ContainsKey(value))
                        {
                            RollCounts[value]++;
                        }
                        else
                        {
                            RollCounts[value] = 1;
                        }

                    }


                    //chheck for doubles
                    if (RollCounts.ContainsValue(5))
                    {
                        Console.WriteLine("\n5 Doubles, 12 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 12;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 12;
                        }

                    }
                    else if (RollCounts.ContainsValue(4))
                    {
                        Console.WriteLine("\n4 Doubles, 6 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 6;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 6;
                        }
                    }
                    else if (RollCounts.ContainsValue(3))
                    {
                        Console.WriteLine("\n3 Doubles, 3 points!");
                        if (PlayerTurn == true)
                        {
                            PlayerPoints += 3;
                        }
                        else if (PlayerTurn == false)
                        {
                            Player2Points += 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo points obtained as no double greater than 2.");
                    }

                }


                //points
                Console.WriteLine("\nPlayer 1's Points: " + PlayerPoints);
                Console.WriteLine($"Player 2's Points: {Player2Points}\n");

                //checks the points to the win conditions
                if (PlayerPoints >= 20)
                {
                    Console.WriteLine("Player 1 Wins!!");
                    GameOver = true;
                }
                else if (Player2Points >= 20) 
                {
                    Console.WriteLine("Player 2 Wins!!");
                    GameOver = true;
                }
                else
                {
                    PlayerTurn = !PlayerTurn; //next players turn
                    Thread.Sleep(1000); //sleep program so that the terminal isnt spammed
                }

                ThreeOrMoreTest.ThreeOrMoreGame(Total);  // Testing verifies total is not 20 or more and is not less than zero
            }

            ThreeOrMoreNumPlays.UpdatePlays(); //add to the number of plays counter
            Console.WriteLine($"\nTotal number of ThreeOrMore plays:  {ThreeOrMoreNumPlays.GetNumPlays()}\n");

            
            Game myGame = new Game(); //create new instance of game once current one has finished
            myGame.PlayGame();
        }
    }
}
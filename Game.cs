using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    internal class Game
    {

        public int Total { get; private set; }



        //Methods
        public void PlayGame()
        {
            int GameChoice = 0;
            while (GameChoice != 1 || GameChoice !=2)
            {
                Console.WriteLine("Would you like to play 'Sevens Out' or 'Three or More' select 1 or 2 respectively: ");
                if (int.TryParse(Console.ReadLine(), out GameChoice))
                {
                    if (GameChoice == 1 || GameChoice == 2)
                    {
                        
                        break;
                    }
                        
                }

            }

            //check if user choice is for the sevens out game or the three or more game
            switch (GameChoice)
            {
                case 1:
                    SevensOut RunGame = new SevensOut();
                    RunGame.PlayGame();
                    break;
                case 2:
                    ThreeOrMore RunGame2 = new ThreeOrMore();
                    RunGame2.PlayGame();
                    break;
            }
        }
    }
}

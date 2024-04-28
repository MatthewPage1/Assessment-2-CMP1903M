using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    public class Statistics
    {
        private static int HighScore = 0;
        private static int NumPlays = 0;

        //Update high score function
        public void UpdateHighScore(int Score)
        {
            //set new highscore if score is greater than current highscore
            if (Score > HighScore)
            {
                HighScore = Score;
                Console.WriteLine($"New high score: {HighScore}");
            }
        }

        //get highscore
        public int GetHighScore()
        {
            return HighScore;
        }

        //increment total number of plays
        public void UpdatePlays()
        {
            NumPlays = NumPlays + 1;
            
        }

        //get number of plays
        public int GetNumPlays()
        {
            return NumPlays;
        }

    }
}
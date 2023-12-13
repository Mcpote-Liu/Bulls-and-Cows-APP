using System.Reflection.Metadata.Ecma335;
using BullsAndCowsApp.FunctionalClasses;

namespace BullsAndCowsGame{
    class GameStart
    {
        static void Main(string[] args)
        {
            bool ifKeepPlaying = true;

            Console.WriteLine("Welcome to bulls and cows game!");

            while (ifKeepPlaying)
            {
                Game game = new Game();
                game.BCGame();

                ifKeepPlaying = UserInput();
                if(ifKeepPlaying)
                {
                    Console.WriteLine("Welcome to next round");
                }

                else
                {
                    Console.WriteLine("See you:)");
                    break;
                }
            }
        }

        static bool UserInput()
        {
            while(true){
                Console.WriteLine("Do you want to play again, if so, please type \"Y\", if not please type \"N\".");
                string playAgain = Keyboard.ReadInput();

                if (string.IsNullOrWhiteSpace(playAgain))
                {
                Console.WriteLine("Please enter a character");
                continue;   
                }

                else if (!playAgain.Equals("Y", StringComparison.CurrentCultureIgnoreCase) && 
                !playAgain.Equals("N", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Please enter \"Y\" or \"N\" ");
                }

                else if(playAgain.Equals("Y", StringComparison.CurrentCultureIgnoreCase)){
                    return true;
                }

                else
                {
                    return false;
                }           
            }
        }
    }
}

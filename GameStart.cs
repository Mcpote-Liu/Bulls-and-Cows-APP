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

                Console.WriteLine("Do you want to play again, if so, please type \"Y\", if not please type \"N\".");
                string playAgain = Keyboard.ReadInput();

                if (string.IsNullOrWhiteSpace(playAgain))
                {
                    Console.WriteLine("Please enter a character");
                    continue;
                }

                if (!playAgain.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
                {
                    ifKeepPlaying = false;
                }
                else
                {
                    Console.WriteLine("Welcome to next round!");
                }

            }
        }
    }
}

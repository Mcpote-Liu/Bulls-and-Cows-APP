using Microsoft.VisualBasic;
using BullsAndCowsApp.FunctionalClasses;
using BullsAndCowsAssignment.FunctionalClasses;

namespace BullsAndCowsGame{
    class GameStart
    {
        static void Main(string[] args)
        {
            bool ifKeepPlaying = true;

            Console.WriteLine("Welcome to bulls and cows game!");

            while (ifKeepPlaying)
            {

//player
                try
                {
                    Console.WriteLine("Do you want to play again, if so, please type \"Y\", if not please type \"N\".");
                    string playAgain = Keyboard.ReadInput();

                    if (string.IsNullOrWhiteSpace(playAgain))
                    {
                        throw new InvalidOperationException("Please enter again with a char");
                    }

                    if (playAgain.ToUpper() != "Y")
                    {
                        ifKeepPlaying = false;
                    }
                    else
                    {
                        Console.WriteLine("Welcome to next round!");
                    }

                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}





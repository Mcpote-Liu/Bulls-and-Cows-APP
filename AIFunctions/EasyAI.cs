using BullsAndCowsApp.FunctionalClasses;

namespace BullsAndCowsApp.AIFunctions
{
    public class EasyAI : AI
    {
        private string? _computerGuess;

        private string ComputerGuessGenerator()
        {
            RandomNumber random = new RandomNumber();
            _computerGuess = random.GenerateRandomNumber();
            return _computerGuess;
        }

        public override string GetComputerGuess()
        {
            Console.WriteLine("Computer Guess: " + ComputerGuessGenerator());
            return ComputerGuessGenerator();
        }
    }
}
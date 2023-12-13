using BullsAndCowsApp.FunctionalClasses;

namespace BullsAndCowsApp.AIFunctions
{
    public class EasyAI(int digitNumber) : AI(digitNumber)
    {
        private string? _computerGuess;

        private string ComputerGuessGenerator()
        {
            RandomNumber random = new RandomNumber();
            _computerGuess = random.GenerateRandomNumber(digitNumber);
            return _computerGuess;
        }

        public override string GetComputerGuess()
        {
            return ComputerGuessGenerator();
        }
    }
}
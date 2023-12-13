using BullsAndCowsApp.FunctionalClasses;

namespace BullsAndCowsApp.AIFunctions
{
    public class MediumAI(int digitNumber) : AI(digitNumber)
    {
        private string computerGuess;
        private static readonly HashSet<string> GeneratedGuessSet = new HashSet<string>();

        // Generate a number and examine whether it has been generated using a HashSet
        private void ComputerGuessGenerator()
        {
            RandomNumber random = new RandomNumber();
            computerGuess = random.GenerateRandomNumber(digitNumber);
            while (GeneratedGuessSet.Contains(computerGuess))
            {
                computerGuess = random.GenerateRandomNumber(digitNumber);
            }
            GeneratedGuessSet.Add(computerGuess);
        }

        public override string GetComputerGuess()
        {
            ComputerGuessGenerator();
            return computerGuess;
        }
    }
}
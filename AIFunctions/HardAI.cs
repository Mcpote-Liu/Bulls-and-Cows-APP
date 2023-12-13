using System.Diagnostics;
using BullsAndCowsApp.FunctionalClasses;

namespace BullsAndCowsApp.AIFunctions
{
    public class HardAI : AI
    {
        private List<string> differentDigitsNumbers = new List<string>();
        //by test, list is better than hash set for the function
        private string computerGuess;
        Stopwatch stopwatch = new Stopwatch();

        // In constructor, generate all possible numbers.
        public HardAI(int digitNumber) : base(digitNumber)
        {
            stopwatch.Start();
            //better code mainatinable and scalability 
            for (int i = 0; i <= Math.Pow(10,digitNumber) - 1; i++)
            {
                string numberStr = i.ToString($"D{digitNumber}");
                if (Player.IsRightNumberDifferentDigits(numberStr, digitNumber))
                {
                    differentDigitsNumbers.Add(numberStr);
                }
                
            }
            stopwatch.Stop();
            Console.WriteLine($"Generate the whole list costs {stopwatch.ElapsedMilliseconds} milliseconds.");
        }

        // Remove all impossible numbers with round result
        public void ReturnResults(int[] result, string guess)
        {
            GuessEvaluator guessEvaluator = new GuessEvaluator();
            differentDigitsNumbers.RemoveAll(num => !EqualArrays(result, guessEvaluator.EvaluateGuess(num, guess)));
        }

        //pick a possible code to show 
        private void ComputerGuessGenerator()
        {
            Random random = new Random();
            int randomIndex = random.Next(differentDigitsNumbers.Count);
            computerGuess = differentDigitsNumbers[randomIndex];
        }

        public override string GetComputerGuess()
        {
            ComputerGuessGenerator();
            Console.WriteLine($"current count of the possible list is {differentDigitsNumbers.Count}");
            return computerGuess;
        }

        // Helper method to compare two arrays
        private static bool EqualArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length)
            {
                return false;
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
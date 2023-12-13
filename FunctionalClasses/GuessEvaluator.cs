namespace BullsAndCowsApp.FunctionalClasses
{
    public class GuessEvaluator
    {
        public int[] EvaluateGuess(string target, string guess)
        {
            int bulls = 0;
            int cows = 0;

            for (int i = 0; i < target.Length; i++)
            {
                if (target[i] == guess[i])
                {
                    bulls++;
                }
                else if (target.Contains(guess[i]))
                {
                    cows++;
                }
            }
            return [bulls, cows];
        }
    }
}
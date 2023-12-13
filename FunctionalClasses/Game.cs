using System.Diagnostics;
using BullsAndCowsApp.AIFunctions;

namespace BullsAndCowsApp.FunctionalClasses
{
    public class Game
    {
        public void BCGame(){
            Stopwatch stopwatch = new Stopwatch();     
            int roundCount = 1;

            Console.WriteLine("Please enter the digit your want to play with(3,4,5, or 6)");
            int digitChoice = DigitChoice();

            RandomNumber random = new RandomNumber();
            string computerCode = random.GenerateRandomNumber(digitChoice);
            
            Console.WriteLine("Please enter the difficulty you want to play with: enter \"easy\", \"medium\", or \"hard\"");
            string difficultyChoice = DifficultyChoice();

            Player player = new Player(digitChoice);
            string playerInput = player.EnterCode();
            Console.WriteLine($"You entered code is {playerInput}");

            AI ai;
            if (difficultyChoice.Equals("Easy", StringComparison.OrdinalIgnoreCase))
            {
                ai = new EasyAI(digitChoice);
            }
            else if (difficultyChoice.Equals("Medium", StringComparison.OrdinalIgnoreCase))
            {
                ai = new MediumAI(digitChoice);
            }
            else
            {
                ai = new HardAI(digitChoice);
            }

            GuessEvaluator guessEvaluator = new GuessEvaluator();

            while (roundCount <= 7)
            {
                Console.WriteLine("---");
                Console.WriteLine($"Round {roundCount}");
                Console.Write("Enter your guess: ");
                string playerGuess = player.EnterCode();

                stopwatch.Start();

                int[] playerResult = guessEvaluator.EvaluateGuess(computerCode, playerGuess);
                ResultDisplayer(playerResult);

                Console.WriteLine();

                string computerGuess = ai.GetComputerGuess();
                Console.WriteLine("Computer Guess: " + computerGuess);
                int[] computerResult = guessEvaluator.EvaluateGuess(playerInput, computerGuess);
                ResultDisplayer(computerResult);

                if (difficultyChoice.Equals("Hard", StringComparison.OrdinalIgnoreCase))
                {
                    ((HardAI)ai).ReturnResults(computerResult, computerGuess);
                }

                roundCount++;

                stopwatch.Stop();
                Console.WriteLine($"This round computer cost {stopwatch.ElapsedMilliseconds} milliseconds to deal with.");

                if (playerResult[0] == digitChoice)
                {
                    Console.WriteLine(UserWin());
                    break;
                }
                else if (computerResult[0] == digitChoice)
                {
                    Console.WriteLine(AIWin());
                    Console.WriteLine("Computer Choose: " + computerCode);
                    break;
                }
                else if (roundCount == 8)
                {
                    Console.WriteLine(Draw());
                    Console.WriteLine("Computer Choose: " + computerCode);
                }
            }

        }

        private void ResultDisplayer(int[] result)
        {
            Console.WriteLine("Result: " + result[0] + " Bulls and " + result[1] + " Cows");
        }
        
        private string DifficultyChoice()
        {
            while (true)
            {
                string input = Keyboard.ReadInput();
                if (input.Equals("Easy", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Medium", StringComparison.OrdinalIgnoreCase) ||
                input.Equals("Hard", StringComparison.OrdinalIgnoreCase))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("Please enter your choice again");
                }
            }
        }

        private int DigitChoice()
        {
            while (true)
            {
                string input = Keyboard.ReadInput();

                if (input.Equals("3") || input.Equals("4") || input.Equals("5") || input.Equals("6"))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 3, 4, 5, or 6.");
                }
            }
        }
        
        private string UserWin()
        {
            return "You win! :)";
        }

        private string Draw()
        {
            return "Draw! No-one wins";
        }

        private string AIWin()
        {
            return "Computer wins! Stupid HUMAN ahhhhhh :)";
        }
    }
}
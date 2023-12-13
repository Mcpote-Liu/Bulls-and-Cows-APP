using System;
using System.Collections.Generic;

namespace BullsAndCowsApp.FunctionalClasses
{
    public class Player
    {
        private readonly int digitNumber;

        public Player(int digitNumber){
            this.digitNumber = digitNumber;
        }

        public string EnterCode()
        {
            while (true)
            {
                Console.Write($"Please enter your code with {digitNumber} different digits: ");
                string input = Keyboard.ReadInput();

                bool ifValidate = ValidateInput(input, digitNumber);
                if (ifValidate)
                {
                    return input;
                }
                else
                {
                    Console.Write("Please re-write: ");
                }
            }
        }

        private static bool ValidateInput(string input, int digitNumber)
        {
            if (!IsNumeric(input))
            {
                Console.WriteLine("Please enter a number.");
                return false;
            }
            else if (!IsRightNumberDifferentDigits(input, digitNumber))
            {
                Console.WriteLine($"Please enter a {digitNumber}-different-digits number.");
                return false;
            }
            else
            {
                return true;
            }
        }

        // Examine whether input is a number
        private static bool IsNumeric(string str)
        {
            return int.TryParse(str, out _);
        }

        // Examine whether input has right number different digits, also used for HardAI
        public static bool IsRightNumberDifferentDigits(string str, int digitNumber)
        {
            if (str.Length != digitNumber)
            {
                return false;
            }

            HashSet<char> set = new HashSet<char>();
            foreach (char c in str)
            {
                if (set.Contains(c))
                {
                    return false;
                }
                set.Add(c);
            }
            return true;
        }
    }
}
using System;
using System.Collections.Generic;

namespace BullsAndCowsApp.FunctionalClasses
{
    public class Player
    {
        public string EnterCode()
        {
            while (true)
            {
                Console.Write("Enter code: ");
                string input = Console.ReadLine();

                try
                {
                    ValidateInput(input);
                    return input;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.Write("Please re-write: ");
                }
            }
        }

        private static void ValidateInput(string input)
        {
            if (!IsNumeric(input))
            {
                throw new Exception("Please enter a number.");
            }

            if (!IsFourDifferentDigits(input))
            {
                throw new Exception("Please enter a 4-different-digits number.");
            }
        }

        // Examine whether input is a number
        private static bool IsNumeric(string str)
        {
            return int.TryParse(str, out _);
        }

        // Examine whether input has 4 different digits, also used for HardAI
        public static bool IsFourDifferentDigits(string str)
        {
            if (str.Length != 4)
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
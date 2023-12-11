using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCowsApp.FunctionalClasses
{
    public class RandomNumber
    {
        Random random = new Random(); 
        public string GenerateRandomNumber()
        {
            HashSet<int> uniqueDigits = new HashSet<int>();
            string numberString = "";
            while (numberString.Length < 4)
            {
                int digit = random.Next(0, 10);
                if (uniqueDigits.Add(digit)) 
                {
                    numberString += digit.ToString();
                }
            }
            return numberString;
        }
    }
}
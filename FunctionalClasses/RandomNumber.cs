namespace BullsAndCowsApp.FunctionalClasses
{
    public class RandomNumber
    {
        Random random = new Random(); 
        public string GenerateRandomNumber(int length)
        {
            HashSet<int> uniqueDigits = new HashSet<int>();
            string numberString = "";
            while (numberString.Length < length)
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
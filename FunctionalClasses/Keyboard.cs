using System;

namespace BullsAndCowsAssignment.FunctionalClasses
{
    public static class Keyboard
    {
        private static bool redirected = false;

        public static string ReadInput()
        {
            try
            {
                if (!redirected)
                {
                    redirected = Console.IsInputRedirected;
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("An error has occurred in the Keyboard constructor.");
                Console.Error.WriteLine(e);
                Environment.Exit(-1);
            }

            try
            {
                string input = Console.ReadLine();
                if (redirected)
                {
                    Console.WriteLine(input);
                }
                return input;
            }
            catch (InvalidOperationException e)
            {
                Console.Error.WriteLine("An error has occurred in the Keyboard.ReadInput() method.");
                Console.Error.WriteLine(e);
                Environment.Exit(-1);
            }

            return null;
        }
    }
}
namespace BullsAndCowsApp.AIFunctions
{
    public abstract class AI
    {
        protected int digitNumber;

        protected AI (int digitNumber){
            this.digitNumber = digitNumber;
        }

        public abstract string GetComputerGuess();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BullsAndCowsApp.FunctionalClasses
{
    public class Game
    {
        public void BCGame(){
            Player player = new Player();
            string playerInput = player.EnterCode();
            Console.WriteLine(playerInput);
        }
    }
}
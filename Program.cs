using System;
using System.Collections.Immutable;

namespace BlackJackGame
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(Menu.Accueil);
            Player cyril = new Player("cyril");
            Player steph = new Player("steph");
            Dealer.Players.Add(cyril);
            Dealer.Players.Add(steph);
            Game.Start(); 
        }
    }
}

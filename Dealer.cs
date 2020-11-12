using System;
using System.Collections.Generic;


namespace BlackJackGame
{
    
    public class Dealer
    {
        public static void GiveCards(Player player){
            
            if(!Sabot.carts.MoveNext()) {
                Sabot.NewCards();
                Sabot.carts.MoveNext();

            }
            Cards card = Sabot.carts.Current;
            player.CalculateValues(card.Value);
            player.Cards.Add(card);

        }
        public static List<Player> Players = new List<Player>();
    }
}

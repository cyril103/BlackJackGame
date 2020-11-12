using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJackGame
{
    
    public class Cards
    {
        public string Name { get; }
        public char Color { get; }
        public int Value { get; }
        public Cards(string name, char color, int value)
        {
            Name = name;
            Color = color;
            Value = value;

        }
        public override string ToString() => $"{Name} {Color}";

    }
    public class Deck
    {
        private static Random rng = new Random();

        public static List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }



        private Dictionary<string, int> namevalues = new Dictionary<string, int>  {
            {"2",2},{"3",3},{"4",4},{"5",5},{"6",6},{"7",7},
            {"8",8},{"9",9},{"10",10},{"V",10},{"D",10},{"R",10},{"As",11}
            };
        private List<char> colors = new List<char> { '\u2663', '\u2665', '\u2666', '\u2660' };

        private List<Cards> MakeCards()
        {
            return (from c in colors from nv in namevalues select new Cards(nv.Key, c, nv.Value)).ToList<Cards>();

        }
        public List<Cards> Cards
        {
            get => Shuffle( MakeCards());            
        }
    }
    public class Sabot{
        private static  List<Cards> deck6 = new Deck().Cards;
        private static void MakeDeck6(){
         for (int i = 0; i < 3; i++) deck6.AddRange(deck6);
        }
            
        private static IEnumerator<Cards> _cards() {
            MakeDeck6();
            Deck.Shuffle<Cards>(deck6);
            IEnumerable<Cards> deck =  deck6.Take(deck6.Count/2).Skip(5);

        foreach (var item in  deck)
        {
            yield return item;
        }

        }
        private static IEnumerator<Cards>  _carts =  _cards();
        public static IEnumerator<Cards>  carts =  _carts;

        public static void NewCards(){
            _carts = _cards();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;



namespace BlackJackGame
{
    
    public class Player
    {
        
        public string Name { get;  }
        public ImmutableList<int> Values { get; set; }
        public List<Cards> Cards { get; }

        public Player(string name){
            Name = name;
            Values = ImmutableList<int>.Empty.Add(0);
            Cards = new List<Cards>();
        }
        public override string ToString()
        {
            var res = new StringBuilder();
            res.Append(Name).Append(" ").Append("cards ");
            foreach (var item in Cards)
            {
                res.Append(item.Name)
                .Append(item.Color).Append(" ");
                
            }
            res.Append(" valeur ");
            if(Values.Count == 0)
                res.Append("past");
                else if(Values.Count == 1)
                    res.Append(Values[0]);
                    else{
            foreach (var item in Values)
            {
                res.Append(item).Append("/");
            }
                    }
            return res.ToString();
        }

        public void Init(){
            Values = Values.Clear().Add(0);
            Cards.Clear();
        }
        public void Hit() {
            Dealer.GiveCards(this);
        }
        private void PrintMenu(){
            Console.WriteLine(Menu.HitOrStay);
        }

        private void AskHitOrStay(){
            for(int i = 0; i < 20 ;i++)
                Console.WriteLine();
            Game.PrintTable();
            Console.WriteLine();
            PrintMenu();

            Console.Write($"{Name} > ");
            string str =  Console.ReadLine();
            if(str == "h"){
                Hit();
                Game.PrintTable();
                AskDecision();
            }else if(str == "s"){
                // do nothing
            }else{
                AskHitOrStay();
            }
        }

        public void AskDecision(){
            if(Values.Count > 0 && Values.Min() < 22)
                AskHitOrStay();
            
        }

        public void CalculateValues(int value){

            if(value == 11){           

            ImmutableList<int> xs1 = Values.ConvertAll<int>(_ => _ + 1);
            ImmutableList<int> xs2 = Values.ConvertAll<int>(_ => _ + 11);
            xs1 = xs1.AddRange(xs2);
            Values = (from x in xs1
                     where x < 22 && x > 0
                     select x).Distinct().ToImmutableList<int>();
                                    
            }
            else{
                Values = Values.ConvertAll(_ => _ + value);
                Values = (from x in Values
                            where x < 22 && x > 0
                            select x).Distinct().ToImmutableList<int>();
            }           

        }



    }
}

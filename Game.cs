using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace BlackJackGame
{

    public class Game
    {
        private static bool endOfTtun = false;
        private static Player Bank = new Player("bank");
        public static void Start(){
            bool quit = false;
            while(!quit){
                endOfTtun = false;
                //PrintTable();
                Console.WriteLine();
                Deal();
                //PrintTable();
                Console.WriteLine();
                Dealer.Players.ForEach(p => p.AskDecision());
                if(CheckPlayers(Dealer.Players).Count == 0){
                    Dealer.Players.ForEach(p => Console.WriteLine($"{p.Name} lose"));
                    Console.WriteLine($"{Bank.Name} win");
                    InitEveryBody();
                    endOfTtun = true;
                }
                else{
                    DealTheBank();
                }
                if(!endOfTtun){
                    if(Bank.Values.Count == 0){
                        Dealer.Players.ForEach(p => Console.WriteLine($"{p.Name} win"));
                        Console.WriteLine($"{Bank.Name} lose");
                    }
                    else{
                        Dealer.Players.ForEach(p => Result(p,Bank.Values));
                    }
                }
                InitEveryBody();

                Console.WriteLine("quit? y/n");
                string res = Console.ReadLine();
                if(res == "y") quit = true;

            }
        }
        public static void PrintTable(){
            Console.WriteLine(Bank);
            Dealer.Players.ForEach(Console.WriteLine);
        }
        private static void Deal(){
            for(int i = 0 ; i < 2; i++){
                Dealer.Players.ForEach(p => p.Hit());
            }
            Bank.Hit();
        }
        private static void InitEveryBody(){
            Bank.Init();
            Dealer.Players.ForEach(p => p.Init());
        }
        private static void DealTheBank(){
            while(Bank.Values.Count > 0 && Bank.Values.Max() < 17 ){
                Bank.Hit();
            }
            for(int i = 0; i <20 ; i++)
                Console.WriteLine();
            PrintTable();
        }

        private static void Result(Player player , ImmutableList<int> values){
            if(player.Values.Count == 0){
                Console.WriteLine($"{player.Name} lose");
            }else{

            
            if(values.Count == 0){
                Console.WriteLine($"{Bank.Name} lose");
                Dealer.Players.ForEach(p => Console.WriteLine($"{player.Name } win"));
            }else{
                if(player.Values.Max() > values.Max()){
                    Console.WriteLine($"{Bank.Name} lose");
                    Console.WriteLine($"{player.Name} win");

                }else if(player.Values.Max() < values.Max()){
                    Console.WriteLine($"{Bank.Name} win");
                    Console.WriteLine($"{player.Name} lose");
                }else{
                    Console.WriteLine($"{player.Name} draw");
                }
            }
            }

        }

        private static List<Player> CheckPlayers(List<Player> players){

            List<Player> f = (from p in players
                            where p.Values.Count > 0
                            select p).ToList<Player>();
            return f;
        }

    }
}

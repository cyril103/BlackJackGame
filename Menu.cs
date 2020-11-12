using System;
using System.Text;

namespace BlackJackGame
{
    
    public class Menu
    {
        public static string HitOrStay { get{
            var res = new StringBuilder();
            res.Append("Hit ? : h/H").AppendLine();
            res.Append("Stay ?: s/S").AppendLine();

            return res.ToString();
        }
        }
        public static  string Accueil 
        { get{
            var res = new StringBuilder();
            res.Append("*******************").AppendLine();
            res.Append("blackJack").AppendLine();
            res.Append("by cyril bertin").AppendLine();
            res.Append("********************").AppendLine();

            return res.ToString();
        } }
    }
}

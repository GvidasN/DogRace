using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_races
{
    public class Bets
    {
        public int Amount, Dog;
        public Guys Bettor;
        
        public string GetDestcription()
        {
            if (Amount==0) return " hasn't placed a bet";
            else return Bettor + " bets " + Amount + " on dog #" + Dog;

        }

        public int PayOut(int Winner)
        {
            if (Winner == Dog) return Amount;
            else return -Amount;   
        }
    }
}

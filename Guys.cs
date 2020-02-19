using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_races
{
    public class Guys
    {
        public string name;
        public Bets MyBet = new Bets();
        public int Cash;
        public RadioButton MyRadioButton;
        public Label Mylabel;

        public void UpdateLabels()
        {
            MyRadioButton.Text = name + " has " + Cash + " bucks";
            Mylabel.Text  = MyBet.GetDestcription();
        }

        public void ClearBet() { MyBet.Amount = 0; }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (Cash >= BetAmount)
            {
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                return true;
            }
            else return false;
        }

        public void Collect(int Winner)
        {
            MyBet.PayOut(Winner);
            MyBet.Amount = 0;
            UpdateLabels();
            
        }
    }
}

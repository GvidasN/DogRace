using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_races
{
    public class Greyhounds
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer = new Random();


        public bool Run()
        {
            Location += Randomizer.Next(1, 8);
            MyPictureBox.Left = StartingPosition + Location;

            if (MyPictureBox.Left >= RacetrackLength) return true;
            else return false;      
        }

        public void TakeStartingPosition()
        {
            Location = StartingPosition;
            MyPictureBox.Left = StartingPosition;
        }
    }
}

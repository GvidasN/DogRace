using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_at_races
{
    public partial class Form1 : Form
    {
        Guys[] guy = new Guys[3];
        Greyhounds[] greyhound = new Greyhounds[4];
        public Random MyRandomizer = new Random();
        

        public Form1()
        {
            InitializeComponent();

            minimumBetLabel.Text = "minimum bet: " + betAmount.Value.ToString() + " bucks";

            greyhound[0] = new Greyhounds()
            {
                MyPictureBox = Greyhound1,
                StartingPosition = Greyhound1.Left,
                RacetrackLength = RaceTrack.Width - Greyhound1.Width,
                Randomizer = MyRandomizer
            };
            greyhound[1] = new Greyhounds()
            {
                MyPictureBox = Greyhound2,
                StartingPosition = Greyhound2.Left,
                RacetrackLength = RaceTrack.Width - Greyhound2.Width,
                Randomizer = MyRandomizer
            };
            greyhound[2] = new Greyhounds()
            {
                MyPictureBox = Greyhound3,
                StartingPosition = Greyhound3.Left,
                RacetrackLength = RaceTrack.Width - Greyhound3.Width,
                Randomizer = MyRandomizer
            };
            greyhound[3] = new Greyhounds()
            {
                MyPictureBox = Greyhound4,
                StartingPosition = Greyhound4.Left,
                RacetrackLength = RaceTrack.Width - Greyhound4.Width,
                Randomizer = MyRandomizer
            };

            guy[2] = new Guys()
            {
                name = "joe",
                Cash = 50,
                MyRadioButton = joeRadioButton,
                Mylabel = joeBetLabel
            };
            guy[1] = new Guys()
            {
                name = "bob",
                Cash = 75,
                MyRadioButton = bobRadioButton,
                Mylabel = bobBetLabel,
            };
            guy[0] = new Guys()
            {
                name = "al",
                Cash = 45,
                MyRadioButton = alRadioButton,
                Mylabel = alBetLabel
            };

            for (int i = 0; i < 3; i++)
            {
                guy[i].UpdateLabels();
                guy[i].ClearBet();
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = guy[2].name;
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = guy[1].name;
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = guy[0].name;
        }


        private void Race_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Race.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (greyhound[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("The winner is #" + i++ + " dog");

                    for (int j = 0; j < 3; j++)
                    {
                        guy[j].MyBet.PayOut(i++);
                        guy[j].ClearBet();
                    }
                }
            }
        }

        private void Bet_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked == true)
            {
                guy[2].ClearBet();
                guy[2].PlaceBet((int) betAmount.Value, (int)greyhoundsNumber.Value);
                guy[2].UpdateLabels();
            }
            else if (bobRadioButton.Checked == true)
            {
                guy[1].ClearBet();
                guy[1].PlaceBet((int)betAmount.Value, (int)greyhoundsNumber.Value);
                guy[1].UpdateLabels();
            }
            else if (alRadioButton.Checked == true)
            {
                guy[0].ClearBet();
                guy[0].PlaceBet((int)betAmount.Value, (int)greyhoundsNumber.Value);
                guy[0].UpdateLabels();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dzień_na_wyścigach
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Random Random = new Random();
        
        public Form1()
        {
            InitializeComponent();
            InitializeGuys();
            CreateGreyhounds();
            
        }


        public void InitializeGuys()
        {
            GuyArray[0] = new Guy() { name = "Joe", Cash = 50, MyRadioButton = joeRadioButton, MyLabel = joeBetLabel };
            GuyArray[0].Update();

            GuyArray[1] = new Guy() { name = "Bob", Cash = 75, MyRadioButton = bobRadioButton, MyLabel = bobBetLabel };
            GuyArray[1].Update();

            GuyArray[2] = new Guy() { name = "Arek", Cash = 45, MyRadioButton = arekRadioButton, MyLabel = ArekBetLabel };
            GuyArray[2].Update();

        }

        public void CreateGreyhounds()
        {
            for(int i = 0; i < 4; i++)
            {
                GreyhoundArray[i] = new Greyhound() {

                    StartPosition = CzartPictureBox1.Left,
                    RacetrackLength = pictureBox1.Width - CzartPictureBox1.Width,
                    MyRandom = Random
                };
            }
            GreyhoundArray[0].MyPictureBox = CzartPictureBox1;
            GreyhoundArray[1].MyPictureBox = CzartPictureBox2;
            GreyhoundArray[2].MyPictureBox = CzartPictureBox3;
            GreyhoundArray[3].MyPictureBox = CzartPictureBox4;
        }
            

        private void startButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Wygrał czart z numerem: " + (i + 1), "Koniec gry");
                    for (int j = 0; j < 4; j++)
                    {
                        GreyhoundArray[j].TakeStartPosition();
                    }
                    for (int k = 0; k < 3; k++)
                    {
                        GuyArray[k].Collect(i+1);
                        GuyArray[k].ClearBet();
                        GuyArray[k].Update();
                        panel1.Enabled = true;
                    }
                    
                }
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Joe";
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Bob";
        }

        private void arekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            nameLabel.Text = "Arek";
        }

        public bool properValues(int BetAmount, int GreyhoundNumber)
        {
            if (BetAmount>=5  &&BetAmount<=15 && GreyhoundNumber >=1 && GreyhoundNumber <=4)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Nieprawidlowa wartość");
                return false;
            }
        }

        private void stawkaButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                if (properValues((int)kasaNumericUpDown.Value, (int)czartNumericUpDown.Value))
                {
                    GuyArray[0].PlaceBet((int)kasaNumericUpDown.Value, (int)czartNumericUpDown.Value);
                    
                }

                
            }



            if (bobRadioButton.Checked)
            {
                if (properValues((int)kasaNumericUpDown.Value, (int)czartNumericUpDown.Value))
                {
                    GuyArray[1].PlaceBet((int)kasaNumericUpDown.Value, (int)czartNumericUpDown.Value);
                    
                }
            }


            if (arekRadioButton.Checked)
            {
                if (properValues((int)kasaNumericUpDown.Value, (int)czartNumericUpDown.Value))
                {
                    GuyArray[2].PlaceBet((int)kasaNumericUpDown.Value, (int)czartNumericUpDown.Value);
                    
                }
            }


        }
    }
}

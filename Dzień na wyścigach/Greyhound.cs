using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dzień_na_wyścigach
{
    class Greyhound
    {
        public int StartPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom = new Random();

        public bool Run()
        {
            MyPictureBox.Left += MyRandom.Next(1, 10);
            Location = MyPictureBox.Left;

            if (Location >= RacetrackLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartPosition()
        {
            this.Location = 0;
            MyPictureBox.Left = 0;
        }
    }
}

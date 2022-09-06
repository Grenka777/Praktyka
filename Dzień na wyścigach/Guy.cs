using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Dzień_na_wyścigach
{
    class Guy
    {
        public string name;
        public Bet MyBet = new Bet();
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public Guy()
        {
            MyBet.Bettor = this;
        }
        public void Update()
        {
            MyRadioButton.Text = name + " ma " + Cash + " zł";
            MyLabel.Text = MyBet.GetDescription();
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
            MyBet.Dog = 0;
        }

        public bool PlaceBet(int Amount, int DogTowin)
        {
            if (Cash >= Amount)
            {
                MyBet.Amount = Amount;
                MyBet.Dog = DogTowin;
                Update();
                return true;
            }
            else
            {
                MessageBox.Show(name + "nie ma wystarczjąco pieniędzy by postawić taki zakład");
                return false;
            }
        }
        public void Collect(int winner)
        {
            Cash += MyBet.PayOut(winner);

        }
    }
}

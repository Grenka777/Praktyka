using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dzień_na_wyścigach
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount >= 5 && Amount <= 15)
            {
                return Bettor.name + " postawił " + Amount + " zł na psa " + Dog;
            }
            else
            {
                return this.Bettor.name + " nie zawarł zakładu ";
            }
        }
        public int PayOut(int Winner)
        {
            if (Winner == Dog)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}

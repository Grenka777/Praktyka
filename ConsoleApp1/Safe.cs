using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Safe
    {
        private Jewels contents = new Jewels();
        private string safeCombination = "12345";

        public Jewels Open(string combination)
        {
            if (safeCombination == combination)
            {
                return contents;
            }
            else
                return null;
        }
        public void PickLock(Locksmith lockPicker)
        {
            lockPicker.WriteDownCombination(safeCombination);
        }

    }
}

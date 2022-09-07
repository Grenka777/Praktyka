using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class JewelThief : Locksmith
    {
        private Jewels stolenJewels = null;

       override public void ReturnContents(Jewels safeContents, Owner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine("Im stealing the contents! "+ stolenJewels.Sparkle());
        }

    }
}

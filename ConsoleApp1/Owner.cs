using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Owner
    {
        private Jewels returnedContents;
        public void ReceiveContents(Jewels safeContents)
        {
            returnedContents = safeContents;
            Console.WriteLine("Thank you for returning my jewels! "+ safeContents.Sparkle());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niechlujny_Janek
{
    class MenuMaker
    {
        public Random random = new Random();

        string[] Meats =
        {
            "Pieczona wołowina","Salami","Indyk","Szynka","Karkówka"
        };

        string[] Condiments = { "żółta musztarda", "brązowa musztarda", "musztarda miodowa","majonez", "przyprawa", "sos francuski" };

        string[] Breads = {"chleb ryżowy", "chleb biały","chleb zbożowy","pumpernikel","chleb włoski","bułka" };
        public string GetMenuItem()
        {
            string randomMeat = Meats[random.Next(Meats.Length)];
            string randomCondiments = Condiments[random.Next(Condiments.Length)];
            string randomBreads = Breads[random.Next(Breads.Length)];
            return randomMeat + "," + randomCondiments + "," + randomBreads;
        }
    }
}

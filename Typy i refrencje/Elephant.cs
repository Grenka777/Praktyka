using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typy_i_refrencje
{
    class Elephant
    {
        string name;
        int earSize;

        public Elephant(string name, int size)
        {
            this.name = name;
            this.earSize = size;

        }
        public string whoAmI()
        {
            return String.Format("Moję uszy mają "+earSize+ " centymetrów szerokości", name + "mówi...");

        }
    }
}

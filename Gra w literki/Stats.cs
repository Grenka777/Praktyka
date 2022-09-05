using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_w_literki
{
    class Stats
    {
       public int total, missed, correct, accurancy = 0;

        public void Update(bool correctKey)
        {
            total++;
            if (!correctKey)
            {
                missed++;
            }
            else
            {
                correct++;
            }
            accurancy = 100 * correct / (missed + correct);
        }
        public void Clear()
        {
            this.total = 0;
            this.missed = 0;
            this.correct = 0;
            this.accurancy = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typy_i_refrencje
{
    public partial class Referencje : Form
    {
        public Referencje()
        {
            InitializeComponent();
        }

        Elephant lucinda = new Elephant("Lucinda", 33);
        Elephant lloyd = new Elephant("Lloyd", 40);
        Elephant szklanka = new Elephant("",0);

        private void buttonLoid_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lloyd.whoAmI());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(lucinda.whoAmI());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            szklanka = lloyd;
            lloyd = lucinda;
            lucinda = szklanka;
            MessageBox.Show("Objekty zamienione");
        }
    }
}

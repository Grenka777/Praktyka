using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cwiczenie_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (Visible)
            {
            for (int i=0; i<254; i++)
            {
                this.BackColor = Color.FromArgb(25, 255 - i, 33);
                Application.DoEvents();
                System.Threading.Thread.Sleep(10);
            }
            for (int c =254;c>=0&&Visible;c--)
            {
                this.BackColor = Color.FromArgb(41, 255 - c, 68);
                Application.DoEvents();
                System.Threading.Thread.Sleep(10);
            }
            }
            
        }
    }
}

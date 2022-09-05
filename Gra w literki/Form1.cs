using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gra_w_literki
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if(listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Koniec gry");
                timer1.Stop();
                startButton.Visible = true;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
                if (listBox1.Items.Contains(e.KeyCode))
                {
                    stats.Update(true);
                    listBox1.Items.Remove(e.KeyCode);
                    listBox1.Refresh();
                    if (timer1.Interval > 400)
                        timer1.Interval -= 10;
                    if (timer1.Interval > 250)
                        timer1.Interval -= 7;
                    if (timer1.Interval > 100)
                        timer1.Interval -= 2;
                    difficultyProgressBar.Value = 800 - timer1.Interval;


                }
                else
                {
                    stats.Update(false);
                }

                correctLabel.Text = "Correct: " + stats.correct;
                missedLabel.Text = "Missed: " + stats.missed;
                totalLabel.Text = "Total: " + stats.total;
                accurancyLabel.Text = "Accurancy: " + stats.accurancy;
            
           
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           
        }
        private void startButton_Click(object sender, EventArgs e)
        {
           
            listBox1.Items.Clear();
            startButton.Visible = false;
            timer1.Start();
            difficultyProgressBar.Value = 0;
            stats.Clear();
            correctLabel.Text = "Correct: " + stats.correct;
            missedLabel.Text = "Missed: " + stats.missed;
            totalLabel.Text = "Total: " + stats.total;
            accurancyLabel.Text = "Accurancy: " + stats.accurancy;
            stats.Update(true);
        }
    }
}

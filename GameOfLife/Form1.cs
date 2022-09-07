using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private int currentGeniration = 0;
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int cols;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
           
            StartGame();
           
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }

        private void StartGame()
        {
            currentGeniration = 0;
            Text = $"Generation {currentGeniration}";

            if (timer1.Enabled)
            {
                return;
            }

            numericUpDownDensity.Enabled = false;
            numericUpDownResolution.Enabled = false;
            resolution = (int)numericUpDownResolution.Value;
            rows = pictureBox1.Height / resolution;
            cols = pictureBox1.Width / resolution;
            field = new bool[cols, rows];

            Random random = new Random();
            for (int x = 0;x<cols; x++)
            {
                for (int y=0;y<rows;y++)
                {
                    field[x, y] = random.Next((int)numericUpDownDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void NextGeneration()
        {
            var newfield = new bool[cols, rows];

            graphics.Clear(Color.Black);

            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {

                    var neighboursCount = CountNeighbours(x,y);
                    var hasLife = field[x, y];

                    if (!hasLife && neighboursCount == 3)
                    {
                        newfield[x, y] = true;
                    } 
                    else if (hasLife && (neighboursCount<2 || neighboursCount >3))
                    {
                        newfield[x, y] = false;
                    }
                    else
                    {
                        newfield[x, y] = field[x, y];
                    }

                    if (hasLife)
                    {
                        graphics.FillRectangle(Brushes.Purple, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }
            Text = $"Generation {++currentGeniration}";
            field = newfield;
            pictureBox1.Refresh();

        }

        private void StopGame()
        {
            if (!timer1.Enabled)
                return;
            timer1.Stop();
            numericUpDownResolution.Enabled = true;
            numericUpDownDensity.Enabled = true;
            
        }

        private int CountNeighbours(int x, int y)
        {
            int count = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    var col = (x + i + cols)%cols;
                    var row = (y + j + rows)%rows;



                    var isSelfCheck = col == x && row == y;
                    var hasLife = field[col, row];
                    if(hasLife && !isSelfCheck)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!timer1.Enabled)
            {
                return;
            }
            
            if (e.Button == MouseButtons.Left)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                field[x, y] = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                var x = e.Location.X / resolution;
                var y = e.Location.Y / resolution;
                field[x, y] = false;
            }

        }
    }
}

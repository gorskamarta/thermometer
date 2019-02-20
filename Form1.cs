using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thermometer
{
    public partial class Form1 : Form
    {
        Bitmap img;
        Bitmap bar;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            img = Properties.Resources.tempscalessmall;
            bar = Properties.Resources.bar;
            numericUpDown1.Value += 1;
            numericUpDown1.Value -= 1;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            Bitmap newImg = new Bitmap(img);
            Graphics gr = Graphics.FromImage(newImg);
            
            //calculate height of bar2
            int barTop = (numericUpDown1.Value > 0 ? 9 : 7) + Convert.ToInt32(((100 - numericUpDown1.Value) / 10) * 20);
            //create a new bitmap for this thermometer bar
            Bitmap bar2 = new Bitmap(12, 264 - barTop);
            Graphics gr2 = Graphics.FromImage(bar2);
            //draw part of original bar image into new bitmap
            gr2.DrawImage(bar, new Rectangle(Point.Empty, bar2.Size), new Rectangle(0, Properties.Resources.bar.Height - bar2.Height, 12, bar2.Height), GraphicsUnit.Pixel);
            //draw new bar image onto new background image
            gr.DrawImage(bar2, new Point(162, barTop));

            pictureBox1.Image = newImg;
        }
    }
}

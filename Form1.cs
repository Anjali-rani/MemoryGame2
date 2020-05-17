using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!","!","N","N",",",",","k","k","b","b","v","v","w","w","z","z"
        };

        Label firstClicked, secondClicked;

        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquare();
        }

        private void AssignIconsToSquare()
        {
            Label label;
            int randomnumber;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)

            {

                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                randomnumber = random.Next(0, icons.Count);
                label.Text = icons[randomnumber];
                icons.RemoveAt(randomnumber);
            }

        }

        private void label_click(object sender, EventArgs e)
        {

        }

        private void label_Click(object sender, EventArgs e)
        {
            if (firstClicked != null && secondClicked != null)
                return;
            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;
            if (clickedLabel.ForeColor == Color.Black)
                return;
            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }
            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();


            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
                timer1.Start();

            

        }
        private void CheckForWinner()
        {
            for(int i = 0; i < tableLayoutPanel1.Controls.Count;i++)
            {
               label1= tableLayoutPanel1.Controls[i] as Label;
                if (label1 != null && label1.ForeColor == label1.BackColor)
                    return;

            }
            MessageBox.Show("You matched all the icons --- Congrats! You are Winner" );
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


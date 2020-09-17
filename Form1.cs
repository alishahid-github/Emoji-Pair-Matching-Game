using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matching_Pairs_Of_Emoji
{
    public partial class homeScreen : Form
    {
        public homeScreen()
        {
            InitializeComponent();
            set_icons_in_label_randomly();
            
        }

        Random random_no = new Random();


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void set_icons_in_label_randomly()
        {
            string[] icons =
            {
                "😀","😀",
                "😌","😌",
                "😒","😒",
                "😊","😊",
                "😉","😉",
                "😁","😁",
                "❤","❤",
                "🥴","🥴"
            };
            int[] used_icons = new int[16]; int c = 0;      //used_icons array is used to store the emojis which are added randomly and c is the counter

            for (int i = 0; i < 16; i++)
                used_icons[i] = -1;             //assigning the -1 default values of array to avoid any ambuigity

            foreach (var control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;     //finding the label in the control

                if (iconLabel != null)
                {
                    int r = random_no.Next(0, 16);

                    while (used_icons.Contains<int>(r))         //running this loop to find the unique random number for emoji
                        r = random_no.Next(0, 16);

                    iconLabel.Text = icons[r];
                    iconLabel.ForeColor = Color.Coral;              //making this property to invisible

                    used_icons[c++] = r;

                }
            }


        }

        Label first_box, secoond_box = null;
        int total_clicks = 0;
        private void label6_Click(object sender, EventArgs e)
        {
            total_clicks++;
            label17.Text = "Total Clicks: " + total_clicks;
            Label click_labled = sender as Label;

            if (timer1.Enabled)
                return;

            if (first_box == null)
            {
                first_box = click_labled;
                first_box.ForeColor = Color.Black;
            }
            else if (secoond_box == null)
            {
                secoond_box = click_labled;
                secoond_box.ForeColor = Color.Black;
                if (first_box.Text != secoond_box.Text)
                    timer1.Start();
                else
                {                    
                    first_box = null;
                    secoond_box = null;
                    if (check_winner())
                    {
                        MessageBox.Show("Hurraa!!, You find all matching emojis ✌", "Winner", MessageBoxButtons.YesNo, MessageBoxIcon.Information);                        
                        this.Close();
                        
                    }



                }



            }

        }

        private void homeScreen_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            first_box.ForeColor = Color.Coral;
            secoond_box.ForeColor = Color.Coral;
            first_box = null;
            secoond_box = null;

        }

        private bool check_winner()
        {
            foreach (var control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;     //finding the label in the control

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == Color.Coral)
                        return false;                    
                }
            }
            return true;
        }
    }
}

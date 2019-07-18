using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fallout_4_Statistics_Breakdown
{
    public partial class Form1 : Form
    {
        // Set constant ints for arrays' sizes'
        const int STATSIZE = 11;

        public Form1()
        {
            InitializeComponent();
        }
        // Method to clear form (Maybe one day I'll
        // learn how to clear the form all at once :/ )
        private void ClearForm()
        {
            awardListBox.Items.Clear();
            levelTextBox.Clear();
            daysTextBox.Clear();
            locDiscTextBox.Clear();
            locDiscLabel.Text = "";
            locClearTextBox.Clear();
            locClearLabel.Text = "";
            hoursSleptTextBox.Clear();
            hoursSleptLabel.Text = "";
            hoursWaitTextBox.Clear();
            hoursWaitLabel.Text = "";
            capsTextBox.Clear();
            capsLabel.Text = "";
            junkTextBox.Clear();
            junkLabel.Text = "";
            chestsTextBox.Clear();
            chestsLabel.Text = "";
            magsTextBox.Clear();
            magsLabel.Text = "";
            foodTextBox.Clear();
            foodLabel.Text = "";
            stimsTextBox.Clear();
            stimsLabel.Text = "";
            chemsTextBox.Clear();
            chemsLabel.Text = "";
        }
        private void calculateButton_Click(object sender, EventArgs e)
        {
            // Clear awardsListBox if user modifies stats, level,
            // or in-game days passed
            awardListBox.Items.Clear();

            // Create an array to hold players stats
            int[] statsArray = new int[STATSIZE];

            // Create an array to hold stats per day
            double[] perDayArray = new double[STATSIZE];

            // Create an array to hold rewards
            string[] awardsArray =  { "Explorer", "Master of Recon","Lazy Bum",
                                    "Killing Time", "Oo! A Penny!","Hoarder",
                                    "Treasure Hunter", "Linguist", "Snacks-A-Lot",
                                    "Medic", "User"};

            // variable to hold in-game days passed assigned from
            // daysTextBox
            int daysPassed = int.Parse(daysTextBox.Text);



            // Assign all stat textboxes to statsArray
            statsArray[0] = int.Parse(locDiscTextBox.Text);
            statsArray[1] = int.Parse(locClearTextBox.Text);
            statsArray[2] = int.Parse(hoursSleptTextBox.Text);
            statsArray[3] = int.Parse(hoursWaitTextBox.Text);
            statsArray[4] = int.Parse(capsTextBox.Text);
            statsArray[5] = int.Parse(junkTextBox.Text);
            statsArray[6] = int.Parse(chestsTextBox.Text);
            statsArray[7] = int.Parse(magsTextBox.Text);
            statsArray[8] = int.Parse(foodTextBox.Text);
            statsArray[9] = int.Parse(stimsTextBox.Text);
            statsArray[10] = int.Parse(chemsTextBox.Text);

            // Call CalculatePerDay method on line __ and assign to 
            // perDayArray subscripts
            for (int i = 0; i < perDayArray.Length; i++)
            {
                perDayArray[i] = CalculatePerDay(statsArray[i], daysPassed);
            }

            // Display perDayArray subscripts in appropriate labels
            locDiscLabel.Text = perDayArray[0].ToString("n2");
            locClearLabel.Text = perDayArray[1].ToString("n2");
            hoursSleptLabel.Text = perDayArray[2].ToString("n2");
            hoursWaitLabel.Text = perDayArray[3].ToString("n2");
            capsLabel.Text = perDayArray[4].ToString("n2");
            junkLabel.Text = perDayArray[5].ToString("n2");
            chestsLabel.Text = perDayArray[6].ToString("n2");
            magsLabel.Text = perDayArray[7].ToString("n2");
            foodLabel.Text = perDayArray[8].ToString("n2");
            stimsLabel.Text = perDayArray[9].ToString("n2");
            chemsLabel.Text = perDayArray[10].ToString("n2");
                   
            // Variable to hold player level
            int level;

            // If user enters int for power level, continue to
            // process data
            if (int.TryParse(levelTextBox.Text, out level))
            {
                // Variable to hold minimum perDay requirement
                int min = 2;

                // If level is less than or equal to 10, set minimum
                // requirement to 2 of stat per day
                if (level <= 10)
                {
                    AwardMinimum(perDayArray, min, awardsArray);
                }
                else if (level > 10 && level <= 20)
                {
                    AwardMinimum(perDayArray, min = 3, awardsArray);
                }
                else if (level > 20 && level <= 30)
                {
                    AwardMinimum(perDayArray, min = 4, awardsArray);
                }
                else if (level > 30 && level <= 40)
                {
                    AwardMinimum(perDayArray, min = 5, awardsArray);
                }
                else if (level > 40 && level <= 50)
                {
                    AwardMinimum(perDayArray, min = 6, awardsArray);
                }
                else if (level > 50 && level <= 60)
                {
                    AwardMinimum(perDayArray, min = 7, awardsArray);
                }
                else
                {
                    AwardMinimum(perDayArray, min = 8, awardsArray);
                }
 
            }
            else
            {
                MessageBox.Show("Please enter Sole Survivor Level numerically");
            }
        }
        // Method to calculate how much each action was performed
        private double CalculatePerDay(double stats, int days)
        {
            return stats / days;
        }

        //Method for determining if perdayArray subscript is greater
        // than the minimum required for award, and display award in
        // awardsListBox is those requirements are met
        private void AwardMinimum(double[] perDay, int min, string[] awards)
        {
            for (int i = 0; i < STATSIZE; i++)
            {
                if (perDay[i] >= min)
                {
                    awardListBox.Items.Add(awards[i]);
                }
            }
            if (awardListBox.Items.Contains(""))
            {
                awardListBox.Items.Add("No Awards");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_TAc_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true; // when true = X turn, false = O turn
        int turnCount = 0;





        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Nir Izhak", "Tic Tac Toe About"); //about text
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // when exit pressed
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            turnCount++;
            checkForWinner();
        }



        private void checkForWinner()
        {
            bool thereIsWinner = false;

            // horizontal checks
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereIsWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereIsWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsWinner = true;

            // vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsWinner = true;

            // diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                thereIsWinner = true;
           




            if (thereIsWinner)
            {
                disableButtons();
                string winner = "";
                if (turn)
                {
                    winner = "O";
                    o_win_count.Text = (int.Parse(o_win_count.Text) + 1).ToString(); // O winner
                }
                else
                { 
                    winner = "X";
                    x_win_count.Text = (int.Parse(x_win_count.Text) + 1).ToString(); // X winner

                }
                
                MessageBox.Show(winner + " Wins!", "Yay!"); // message for winner
                newGameToolStripMenuItem.PerformClick(); // reset automaticly
            }

            else
            {
                if (turnCount == 9)
                {
                    draw_count.Text = (int.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Bummer!"); // tie message
                    newGameToolStripMenuItem.PerformClick();
                   
                }
            }
        }

        private void disableButtons() // disable buttons
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }

            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) // new game
        {
            turn = true;
            turnCount = 0;

            
                foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }

            }
            
        }

        private void button_enter(object sender, EventArgs e) // X/O hover button
        {
            Button b = (Button)sender;
            if(b.Enabled)
            {
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            }
            
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
               b.Text = "";

        }

        private void resetWinCountToolStripMenuItem_Click(object sender, EventArgs e) // reset wins
        {
            x_win_count.Text = "0";
            o_win_count.Text = "0";
            draw_count.Text = "0";

        }
    }
}

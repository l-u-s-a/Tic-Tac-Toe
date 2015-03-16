using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SimpleGame
{
    public partial class Form1 : Form
    {

        private GameModel game;
        public string currentPlayerSign
        {
            set
            {
                this.label2.Text = string.Format("Player {0}", game.currentPlayerSign);
            }
            get
            {
                return this.label2.Text;
            }
        }

        public Form1()
        {
            game = new GameModel();
            InitializeComponent();
            updateUI();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (game.IsFinished())
            {
                showMessage();
            }
            else
            {
                if (sender is Button)
                {
                    Button field = (Button)sender;
                    string fieldName = Regex.Match(field.Name, @"\d+").Value;
                    int fieldNumber = Convert.ToInt32(fieldName) - 1;
                    int row = fieldNumber / 3;
                    int column = fieldNumber % game.fields.GetLength(0);

                    if (game.fields[row, column] == null)
                    {
                        game.fields[row, column] = game.currentPlayerSign;
                        if (!game.IsFinished()) game.changePlayer();
                        updateUI();
                    }
                }

            }
        }

        private void startNewGame()
        {
            game = new GameModel();
            updateUI();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            startNewGame();
        }

        private void updatePlayerLabel()
        {
            if (game.IsFinished())
            {
                this.label1.Text = "Winner:";
            }
            else
            {
                this.label1.Text = "On the turn:";
            }
        }

        private void updateUI()
        {
            updateButtons();
            updatePlayerLabel();
            if (game.IsFinished())
            {
                showMessage();
            }
            else
            {
                currentPlayerSign = game.currentPlayerSign;
            }
        }

        private void updateButtons()
        {
            this.button1.Text = game.fields[0, 0];
            this.button2.Text = game.fields[0, 1];
            this.button3.Text = game.fields[0, 2];
            this.button4.Text = game.fields[1, 0];
            this.button5.Text = game.fields[1, 1];
            this.button6.Text = game.fields[1, 2];
            this.button7.Text = game.fields[2, 0];
            this.button8.Text = game.fields[2, 1];
            this.button9.Text = game.fields[2, 2];
        }

        private void showMessage()
        {
            string message = currentPlayerSign + " won! Time for revenge?";
            DialogResult result = MessageBox.Show(message, "Win!", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) startNewGame();
        }
    }
}
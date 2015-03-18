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

using TicTacToe.Controller;

namespace TicTacToe.View
{
    public partial class GameView : Form, IGameView {
		private string WON_MSG = " won! Time for revenge?";
		private string DIALOG_TITLE = "Win!";
    	private GameController controller;

        public GameView()
        {
        	InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
        	if(sender is Button) {
	        	Button field = (Button)sender;
	            string fieldName = Regex.Match(field.Name, @"\d+").Value;
	            controller.playerMove(fieldName);
            }
        }
        
        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            controller.newGame();
        }

        public void updateButtons(String[,] fields)
        {
            this.button1.Text = fields[0, 0];
            this.button2.Text = fields[0, 1];
            this.button3.Text = fields[0, 2];
            this.button4.Text = fields[1, 0];
            this.button5.Text = fields[1, 1];
            this.button6.Text = fields[1, 2];
            this.button7.Text = fields[2, 0];
            this.button8.Text = fields[2, 1];
            this.button9.Text = fields[2, 2];
        }
               
        public void updatePlayerLabel(String msg)
        {
        	this.label1.Text = msg;
        	
//            if (game.IsFinished())
//            {
//                this.label1.Text = "Winner:";
//            }
//            else
//            {
//                this.label1.Text = "";
//            }
        }
        
        public void showMessage()
        {
            string message = CurrentPlayerSign + WON_MSG;
            DialogResult result = MessageBox.Show(message, DIALOG_TITLE, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
            	controller.newGame();
            }
        }
        
        public string CurrentPlayerSign
        {
            set
            {
                this.label2.Text = string.Format("Player {0}", value);
            }
            get
            {
                return this.label2.Text;
            }
        }
        
       public GameController Controller {
			set {
				controller = value;
			}
		}
    }
}
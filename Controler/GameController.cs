using System;

using TicTacToe.Model;
	
namespace TicTacToe.Controller {
	
	public class GameController {
		private string WON_MSG = "Winner:";
		private string TURN_MSG = "On the turn:";
		private GameModel game;
		private IGameView view;
		
		public GameController(IGameView view) {
			game = new GameModel();
			this.view = view;
			view.Controller = this;
		}
		
		public void newGame() {
			game = new GameModel();
			view.updateButtons(game.Fields);
			view.updatePlayerLabel("");
			view.CurrentPlayerSign = game.CurrentPlayerSign;
		}
		
		public void playerMove(string fieldName) {
			if (game.IsFinished()) {
               view.showMessage();
			}else {
                    int fieldNumber = Convert.ToInt32(fieldName) - 1;
                    int row = fieldNumber / 3;
                    int column = fieldNumber % game.Fields.GetLength(0);

                    if (game.Fields[row, column] == null) {
                        game.Fields[row, column] = game.CurrentPlayerSign;
                        
                        if (!game.IsFinished()) {
                        	view.CurrentPlayerSign = game.changePlayer();
                        	view.updateButtons(game.Fields);
                        	view.updatePlayerLabel("");
                        }
                        else {
                        	view.updateButtons(game.Fields);
                        	view.updatePlayerLabel("Winner");
                        	view.showMessage();
                        }
                    }
                }
		}
		

	}
}
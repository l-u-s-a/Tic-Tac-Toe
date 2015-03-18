namespace TicTacToe.Controller {
	
	public interface IGameView {
		void updateButtons(string[,] fields);
		void updatePlayerLabel(string msg);
		void showMessage();
		string CurrentPlayerSign{ get; set; }
		GameController Controller{ set;}
	}
}
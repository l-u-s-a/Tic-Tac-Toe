using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TicTacToe.View;
using TicTacToe.Controller;

namespace TicTacToe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            GameView view = new GameView();
            GameController controller = new GameController(view);
            
            Application.Run(view);
        }
    }
}

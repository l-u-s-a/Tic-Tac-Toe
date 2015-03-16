using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame
{
    class GameModel
    {
        public string currentPlayerSign = "";

        public string[,] fields = new string[3, 3];

        public GameModel()
        {
            setRandomFirstPlayer();
        }

        private void setRandomFirstPlayer()
        {
            int randomNumber = new Random().Next(0, 2);
            List<string> players = new List<string>() { "X", "O" };
            string firstPlayerSign = players[randomNumber];
            currentPlayerSign = firstPlayerSign;
        }

        public void changePlayer()
        {
            currentPlayerSign = currentPlayerSign == "X" ? "O" : "X";
        }

        public bool IsFinished()
        {
            return rowIsCompleted() || columnIsCompleted() || diagonalIsCompleted();
        }

        private bool rowIsCompleted()
        {
            for (int i = 0; i < fields.GetLength(0); i++)
            {
                int hits = 1;
                string signToCompare = fields[i, 0];
                for (int j = 1; j < fields.GetLength(1); j++)
                {
                    if (fields[i, j] == null)
                    {
                        hits = 0;
                    }

                    else if (signToCompare == null)
                    {
                        hits = 1;                        
                    }

                    else if (fields[i, j].Equals(signToCompare))
                    {
                        hits++;
                        if (hits == 3) return true;
                    }
                    signToCompare = fields[i, j];
                }
            }
            return false;
        }

        private bool columnIsCompleted()
        {
            for (int j = 0; j < fields.GetLength(1); j++)
            {
                int hits = 1;
                string signToCompare = fields[0, j];
                for (int i = 1; i < fields.GetLength(0); i++)
                {
                    if (fields[i, j] == null)
                    {
                        hits = 0;
                    }
                    else if (signToCompare == null)
                    {
                        hits = 1;
                    }
                    else if (fields[i, j].Equals(signToCompare))
                    {
                        hits++;
                        if (hits == 3) return true;
                    }
                    signToCompare = fields[i, j];
                }
            }
            return false;
        }

        private bool diagonalIsCompleted()
        {
            return firstDiagonalIsCompleted() || secondDiagonalIsCompleted();
        }

        private bool firstDiagonalIsCompleted() {
            int hits = 1;
            string signToCompare = fields[0, 0];

            for (int i = 1; i < fields.GetLength(0); i++)
            {
                int j = i;
                if (fields[i, j] == null)
                {
                    hits = 0;
                }
                else if (signToCompare == null)
                {
                    hits = 1;
                }

                else if (fields[i, j].Equals(signToCompare))
                {
                    hits++;
                    if (hits == 3) return true;
                }
                signToCompare = fields[i, j];
            }
            return false;
        }
            
        private bool secondDiagonalIsCompleted() {
            int hits = 1;
            string signToCompare = fields[fields.GetLength(0) - 1, 0];
            
            for (int i = fields.GetLength(0) - 2; i >= 0 ; i--)
            {
                int j = fields.GetLength(0) - 1 - i;

                if (fields[i, j] == null)
                {
                    hits = 0;
                }
                else if (signToCompare == null)
                {
                    hits = 1;
                }

                else if (fields[i, j].Equals(signToCompare))
                {
                    hits++;
                    if (hits == 3) return true;
                }
                signToCompare = fields[i, j];
            }
            return false;
        }
    }
}

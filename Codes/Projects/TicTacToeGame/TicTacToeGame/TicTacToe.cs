using System;

namespace TicTacToeGame
{
    public enum Turn { X, O, T };
    class TicTacToe
    {
        private Char[,] game = new char[3, 3];
        Turn turn;

        public TicTacToe()
        {
            for (int i = 0; i < this.game.GetLength(0); i++)
            {
                for (int j = 0; j < this.game.GetLength(1); j++)
                {
                    this.game[i, j] = ' ';
                }
            }
            this.turn = Turn.X;
        }

        public void StartOver()
        {
            for (int i = 0; i < this.game.GetLength(0); i++)
            {
                for (int j = 0; j < this.game.GetLength(1); j++)
                {
                    this.game[i, j] = ' ';
                }
            }
            this.turn = Turn.X;
        }

        public bool IfWin()
        {
            bool firstRow = (game[0, 0] == 'X' || game[0, 0] == 'O') && game[0, 0] == game[0, 1] && game[0, 1] == game[0, 2];
            bool secondRow = (game[1, 0] == 'X' || game[1, 0] == 'O') && game[1, 0] == game[1, 1] && game[1, 1] == game[1, 2];
            bool thirdRow = (game[2, 0] == 'X' || game[2, 0] == 'O') && game[2, 0] == game[2, 1] && game[2, 1] == game[2, 2];
            bool mainDiag = (game[0, 0] == 'X' || game[0, 0] == 'O') && game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2];
            bool secdDiag = (game[2, 0] == 'X' || game[2, 0] == 'O') && game[2, 0] == game[1, 1] && game[1, 1] == game[0, 2];
            bool firstCol = (game[0, 0] == 'X' || game[0, 0] == 'O') && game[0, 0] == game[1, 0] && game[1, 0] == game[2, 0];
            bool secondCol = (game[0, 1] == 'X' || game[0, 1] == 'O') && game[0, 1] == game[1, 1] && game[1, 1] == game[2, 1];
            bool thirdCol = (game[2, 0] == 'X' || game[2, 0] == 'O') && game[2, 0] == game[2, 1] && game[2, 1] == game[2, 2];
            if (firstRow || secondRow || thirdRow || mainDiag || secdDiag || firstCol || secondCol || thirdCol)
                return true;
            else
            {
                if (!Contains(' '))
                {
                    return true;
                    this.turn = Turn.T;
                }
            }
            return false;
        }

        public bool Contains(char comparing)
        {
            for (int i = 0; i < game.GetLength(0); i++)
            {
                for (int j = 0; j < game.GetLength(1); j++)
                {
                    if (game[i, j] == comparing)
                        return true;
                }
            }
            return false;
        }

        public string WhoWon()
        {
            if (IfWin())
            {
                if (this.turn == Turn.X)
                    return "X";
                else if (this.turn == Turn.O)
                    return "O";
                return "Tie";
            }
            return " ";
        }

        public void SwitchTurn()
        {
            if (this.turn == Turn.X)
                this.turn = Turn.O;
            else
                this.turn = Turn.X;
        }

        public string turnNow()
        {
            if (this.turn == Turn.X)
                return "X";
            return "O";
        }
    }
}
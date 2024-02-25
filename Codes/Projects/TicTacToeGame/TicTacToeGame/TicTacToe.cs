using Android.Widget;

namespace TicTacToeGame
{

    public enum State { X, O, T, None };
    public enum Choice { none, X, O };
    class TicTacToe
    {
        private Choice[,] board = new Choice[3, 3];
        private Choice currentChoice;
        private State winner = State.None;
        public TicTacToe()
        {
            RestartBoard();
            this.currentChoice = Choice.X;
        }
        public TicTacToe(Choice turn)
        {
            RestartBoard();
            this.currentChoice = turn;
        }
        public void StartOver(Choice turn)
        {
            RestartBoard();
            this.currentChoice = turn;
        }

        private void RestartBoard()
        {
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    this.board[i, j] = Choice.none;
                }
            }
        }

        public bool IfWin()
        {
            bool firstRow = (board[0, 0] == Choice.X || board[0, 0] == Choice.O) && board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2];
            bool secondRow = (board[1, 0] == Choice.X || board[1, 0] == Choice.O) && board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2];
            bool thirdRow = (board[2, 0] == Choice.X || board[2, 0] == Choice.O) && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2];
            bool mainDiag = (board[0, 0] == Choice.X || board[0, 0] == Choice.O) && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2];
            bool secdDiag = (board[2, 0] == Choice.X || board[2, 0] == Choice.O) && board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2];
            bool firstCol = (board[0, 0] == Choice.X || board[0, 0] == Choice.O) && board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0];
            bool secondCol = (board[0, 1] == Choice.X || board[0, 1] == Choice.O) && board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1];
            bool thirdCol = (board[2, 0] == Choice.X || board[2, 0] == Choice.O) && board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2];
            if (firstRow || secondRow || thirdRow || mainDiag || secdDiag || firstCol || secondCol || thirdCol)
            {
                if (currentChoice == Choice.X)
                    winner = State.X;
                else
                    winner = State.O;
                return true;
            }
            else
            {
                if (full())
                {
                    this.winner = State.T;
                    return true;
                }
            }
            return false;
        }

        public bool full()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == Choice.none)
                        return false;
                }
            }
            return true;
        }

        public string WhoWon()
        {
            if (winner == State.X)
                return "X";
            else if (winner == State.O)
                return "O";
            return "Tie";
        }

        public void SwitchTurn()
        {
            if (this.currentChoice == Choice.X)
                this.currentChoice = Choice.O;
            else
                this.currentChoice = Choice.X;
        }

        public void SetChoice(object sender, Button[,] buttons)
        {
            int line = -1;
            int col = -1;
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j] == (Button)sender)
                    {
                        line = i;
                        col = j;
                        break;
                    }
                }
                if (line != -1 && col != -1)
                    break;
            }
            this.board[line, col] = currentChoice;
        }

        public string TurnNow()
        {
            if (this.currentChoice == Choice.X)
                return "X";
            return "O";
        }
    }
}
using System;

namespace TicTacToeClass
{
    public enum Player { none, X, O };
    public enum GameStatus { inProgress, xWin, oWin, Tie };
    public class TicTacToe
    {

        private Player[,] board;
        private GameStatus status;
        private Player winner;
        private Player choosing;
        private Line winLine;

        public TicTacToe(Player beginWith)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = Player.none;
                }
            }
            choosing = beginWith;
            status = GameStatus.inProgress;
            winner = Player.none;
            winLine = null;
        }
        public bool DoTurn(Player value, int row, int col)
        {
            if (IsValidTurn(value, row, col))
            {
                board[row, col] = value;
                GetNextTurn();
                return true;
            }
            return false;
        }

        public string ValidateTurn(Player value, int row, int col)
        {
            if (!IsValidTurn(value, row, col))
                return "invalid turn";
            return "";
        }

        private bool IsValidTurn(Player value, int row, int col)
        {
            return board[row, col] == Player.none && value == choosing && status == GameStatus.inProgress;
        }

        public Player GetCellValue(int row, int col)
        {
            return board[row, col];
        }

        public Player GetWinner()
        {
            if (status == GameStatus.oWin)
                return Player.O;
            else if (status == GameStatus.xWin)
                return Player.X;
            return Player.none;
        }

        public Line GetWinLine()
        {
            return winLine;
        }

        public GameStatus GetStatus()
        {
            return status;
        }

        public Player GetNextTurn()
        {
            if (choosing == Player.X)
                choosing = Player.O;
            else
                choosing = Player.X;
            return choosing;
        }

        public Cell SuggestNextTurn()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == Player.none)
                        return new Cell(i, j,choosing);
                }
            }
            return null;
        }

        public void Print()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == Player.X)
                        Console.Write("|X");
                    else if (board[i, j] == Player.O)
                        Console.Write("|O");
                    else
                        Console.Write("| ");
                }
                Console.Write("|\n");
            }
        }

        private bool IfWin(Player value)
        {
            bool topRow = board[0, 0] == value && board[0, 1] == value && board[0, 2] == value;
            bool midRow = board[1, 0] == value && board[1, 1] == value && board[1, 2] == value;
            bool botRow = board[2, 0] == value && board[2, 1] == value && board[2, 2] == value;
            bool mainDig = board[0, 0] == value && board[1, 1] == value && board[2, 2] == value;
            bool secondDig = board[0, 2] == value && board[1, 1] == value && board[2, 0] == value;
            if (topRow || midRow || botRow || mainDig || secondDig)
                return true;
            return IsEmpty();
        }

        private bool IsEmpty()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != Player.none)
                        return false;
                }
            }
            return true;
        }
    }



    public class Line
    {
        private Cell[] cells;

        public Line(Cell cel1, Cell cel2, Cell cel3)
        {
            cells[0] = cel1;
            cells[1] = cel2;
            cells[2] = cel3;
        }

        public Cell[] Cells
        {
            get { return cells; }
        }
    }

    public class Cell
    {
        private int row;
        private int col;
        private Player player;


        public Cell(int row, int col, Player value)
        {
            this.row = row;
            this.col = col;
            this.player = value;
        }

        public int Row
        {
            get { return this.row; }
        }

        public int Col
        {
            get { return this.col; }
        }

        public Player Value
        {
            get { return this.player; }
        }
    }
}

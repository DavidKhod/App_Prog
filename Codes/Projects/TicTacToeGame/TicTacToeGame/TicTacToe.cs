using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToeGame
{
    public enum Turn { X,O,N};
    class TicTacToe
    {
        private Char[] game = new char[9];
        Turn turn;

        public TicTacToe()
        {
            for (int i = 0; i < game.Length; i++)
            {
                game[i] = ' ';
            }
            this.turn = Turn.X;
        }

        public bool IfWin()
        {
            bool firstRow = game[0] == game[1] && game[1] == game[2];
            bool secondRow = game[3] == game[4] && game[4] == game[5];
            bool thirdRow = game[6] == game[7] && game[7] == game[8];
            bool mainDiagonal = game[0] == game[4] && game[0] == game[8];
            bool secondDiagonal = game[6] == game[4] && game[4] == game[2];
            bool firstCol = game[0] == game[3] && game[3] == game[6];
            bool secondCol = game[1] == game[4] && game[4] == game[7];
            bool thirdCol = game[2] == game[5] && game[5] == game[8];
            if (firstRow || secondRow || thirdRow || mainDiagonal || secondDiagonal || firstCol || secondCol || thirdCol)
                return true;
            return false;
        }

        public string WhoWon()
        {
            if (IfWin())
            {
                if (this.turn == Turn.X)
                    return "X";
                return "O";
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


    }
}
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
    public enum Step { X,Y};
    class TicTacToe
    {
        private Step step;

        public TicTacToe()
        {
            this.step = Step.X;
        }

        public void NextStep()
        {
            if (this.step == Step.X)
                this.step = Step.Y;
            else
                this.step = Step.Y;
        }

        public string StepNow()
        {
            if (this.step == Step.X)
                return "X";
            return "O";
        }
    }
}
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
    [Activity(Label = "StartPage", MainLauncher = true)]
    public class StartPage : Activity
    {
        bool isX = true;
        bool startWithX = true;
        Button startGame;
        RadioGroup radGroup;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.StartPage);
            startGame = FindViewById<Button>(Resource.Id.gameStartBtn);
            startGame.Click += StartGame_Click;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(Application.Context, typeof(MainActivity));
        }
    }
}
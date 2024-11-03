using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace animals
{
    [Activity(Label = "FishActivity")]
    public class FishActivity : Activity
    {
        Button move, talk;
        Fish fish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.fish_layout);
            Init();
            fish = new Fish("Georgeius the 3rd", Gender.Other, -3, 666);
            Toast.MakeText(this, $"Welcome to {fish.name}'s aquarium", ToastLength.Short).Show();
        }

        public void Init()
        {
            move = FindViewById<Button>(Resource.Id.moveBtn);
            move.Click += Move_Click;
            talk = FindViewById<Button>(Resource.Id.talkBtn);
            talk.Click += Talk_Click;
        }

        private void Talk_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, fish.MakeSound(), ToastLength.Short).Show();
        }

        private void Move_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, fish.Move(), ToastLength.Short).Show();
        }
    }
}
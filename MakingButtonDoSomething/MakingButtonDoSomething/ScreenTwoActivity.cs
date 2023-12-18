using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace MakingButtonDoSomething
{
    [Activity(Label = "ScreenTwoActivity", MainLauncher = true)]
    public class ScreenTwoActivity : Activity
    {
        Button backToScreen;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);
            backToScreen = FindViewById<Button>(Resource.Id.backToScreen);

            backToScreen.Click += BackToScreen_Click;
        }

        private void BackToScreen_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(MainActivity));
        }
    }
}
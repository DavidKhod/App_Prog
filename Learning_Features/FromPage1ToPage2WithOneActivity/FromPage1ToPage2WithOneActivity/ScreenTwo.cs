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

namespace FromPage1ToPage2WithOneActivity
{
    [Activity(Label = "ScreenTwo")]
    public class ScreenTwo : Activity
    {
        Button closeScreen;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SecondScreen);
            closeScreen = FindViewById<Button>(Resource.Id.closeScreen);
            closeScreen.Click += CloseScreen_Click;
        }

        private void CloseScreen_Click(object sender, EventArgs e)
        {
            Finish();
        }
    }
}
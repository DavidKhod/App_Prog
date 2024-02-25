using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Graphics;
using System;
namespace Dynamic_Prog_First
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnClose, changeColor,changeLayoutSize;
        EditText edtNumber1;
        LinearLayout layout1, mainLayout;
        Random rnd = new Random();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();

        }

        void Init()
        {
            btnClose = FindViewById<Button>(Resource.Id.btnClose);
            changeColor = FindViewById<Button>(Resource.Id.bntChangeColor);
            changeLayoutSize = FindViewById<Button>(Resource.Id.changeLayoutSize);
            edtNumber1 = FindViewById<EditText>(Resource.Id.edtNumber1);
            layout1 = FindViewById<LinearLayout>(Resource.Id.linearLayout1);
            mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLayout);

            btnClose.Click += BtnClose_Click;
            changeColor.Click += ChangeColor_Click;
            changeLayoutSize.Click += ChangeLayoutSize_Click;
        }


        private void ChangeLayoutSize_Click(object sender, EventArgs e)//Randomizes the width and height of layout1
        {
            layout1.LayoutParameters = new LinearLayout.LayoutParams(rnd.Next(301), rnd.Next(301));
        }

        private void ChangeColor_Click(object sender, System.EventArgs e)
        {
            mainLayout.SetBackgroundColor(GetRandomColor());
        }

        Color GetRandomColor()
        {
            return new Color(rnd.Next(256), rnd.Next(256), rnd.Next(256), rnd.Next(126));//Creates and Randomizes RGBA values, and then returns it
        }

        private void BtnClose_Click(object sender, System.EventArgs e)
        {
            Finish();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
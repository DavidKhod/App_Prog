using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
using Android.Content;
using System;
namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnCloseScreen,btnShowImages,btnClearScreen;
        LinearLayout mainLayout, imagesLayout;
        Random rnd;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
        }

        void Init()
        {
            btnClearScreen = FindViewById<Button>(Resource.Id.btnClearScreen);
            btnCloseScreen = FindViewById<Button>(Resource.Id.CloseScreen);
            btnShowImages = FindViewById<Button>(Resource.Id.btnShowImages);
            mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLayout);
            imagesLayout = FindViewById<LinearLayout>(Resource.Id.imagesLayout);
            rnd = new Random();
            btnCloseScreen.Click += BtnCloseScreen_Click;
            btnShowImages.Click += BtnShowImages_Click;
            btnClearScreen.Click += BtnClearScreen_Click;
        }

        private void BtnClearScreen_Click(object sender, EventArgs e)
        {
            imagesLayout.RemoveAllViews();
        }

        private void BtnShowImages_Click(object sender, EventArgs e)
        {
            imagesLayout.RemoveAllViews();
            for (int i = 0; i < 4; i++)
            {
                int x = rnd.Next(1, 14);
                char[] types = new char[] { 'S', 'D', 'H', 'C' };
                char type = types[rnd.Next(types.Length)];
                string imagename = $"img{x}{type}";
                int id = Resources.GetIdentifier(imagename, "drawable", this.PackageName);
                var imgv = new ImageView(this);
                imgv.SetImageResource(id);
                imgv.LayoutParameters = new LinearLayout.LayoutParams(0,200,1);
                imagesLayout.AddView(imgv);
            }
        }

        private void BtnCloseScreen_Click(object sender, System.EventArgs e)
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
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnCloseScreen, btnShowImages, btnClearScreen;
        LinearLayout mainLayout, imagesLayout;
        Random rnd;
        EditText editTextCount;
        int cnt;
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
            btnClearScreen = FindViewById<Button>(Resource.Id.btnClearScreen);
            btnCloseScreen = FindViewById<Button>(Resource.Id.CloseScreen);
            btnShowImages = FindViewById<Button>(Resource.Id.btnShowImages);
            mainLayout = FindViewById<LinearLayout>(Resource.Id.mainLayout);
            imagesLayout = FindViewById<LinearLayout>(Resource.Id.imagesLayout);
            editTextCount = FindViewById<EditText>(Resource.Id.editTextCount);
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
            int resId1 = Resources.GetIdentifier("img10C", "drawable", PackageName);
            int resId2 = Resources.GetIdentifier("img10c", "drawable", PackageName);

            imagesLayout.RemoveAllViews();
            string count = editTextCount.Text;
            if (string.IsNullOrEmpty(count))
                cnt = 0;
            else
                cnt = int.Parse(count);
            char[] types = new char[] { 'S', 'D', 'H', 'C' };
            var tempLayout = new LinearLayout(this);
            int matchParent = ViewGroup.LayoutParams.MatchParent;
            int wrapContent = ViewGroup.LayoutParams.WrapContent;
            tempLayout.Orientation = Orientation.Horizontal;
            tempLayout.SetBackgroundColor(Android.Graphics.Color.Red);
            LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(matchParent, wrapContent);
            for (int i = 0; i <= cnt; i++)
            {
                if (i % 5 == 0)
                {
                    if (i > 0)
                    {
                        var img = new ImageView(this);
                        int imgIdx = rnd.Next(1, 14);
                        char imgType = types[rnd.Next(4)];
                        string imgName = $"img{imgIdx}{imgType}";
                        int resId = Resources.GetIdentifier(imgName, "drawable", this.PackageName);
                        img.SetImageResource(resId);
                        img.LayoutParameters = new LinearLayout.LayoutParams(0, 200, 1);
                        //tempLayout.AddView(img);
                        imagesLayout.AddView(img);
                    }
                    imagesLayout.AddView(tempLayout);
                    tempLayout = new LinearLayout(this);
                    tempLayout.LayoutParameters = lp;
                    continue;
                }
                var imgv = new ImageView(this);
                imgv.SetImageResource(Resources.GetIdentifier($"img{rnd.Next(1, 14)}{types[rnd.Next(4)]}", "drawable", this.PackageName));
                imgv.LayoutParameters = new LinearLayout.LayoutParams(0, 200, 1);
                tempLayout.AddView(imgv);
            }
            imagesLayout.AddView(tempLayout);
        }

        //void addalayoutwithrandomcards()
        //{

        //    var layout = new linearlayout(this);
        //    layout.layoutparameters = new linearlayout.layoutparams(linearlayout.layoutparams.matchparent, linearlayout.layoutparams.wrapcontent, 1);
        //    layout.orientation = orientation.horizontal;
        //    for (int i = 0; i < 5 && cnt > 0; i++, cnt--)
        //    {
        //        var imgv = new imageview(this);
        //        imgv.setimageresource(generaterandomcardimageidentifier());
        //        imgv.layoutparameters = new linearlayout.layoutparams(0, linearlayout.layoutparams.matchparent, 1);
        //        layout.addview(imgv);
        //    }
        //    imageslayout.addview(layout);
        //}

        int GenerateRandomCardImageIdentifier()
        {
            int x = rnd.Next(1, 14);
            char[] types = new char[] { 's', 'd', 'h', 'c' };
            char type = types[rnd.Next(types.Length)];
            string imagename = $"img{x}{type}";
            return Resources.GetIdentifier(imagename, "drawable", this.PackageName);
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
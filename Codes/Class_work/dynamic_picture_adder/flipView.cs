using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace dynamic_picture_adder
{
    [Activity(Label = "flip_Page")]
    public class flip_Page : Activity
    {
        static Random rnd = new Random();
        int amountToShow = 0;
        Button next, back, homePage;
        LinearLayout toShowLay;
        ImageView[] images;
        int i = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flip_View);
            Init();
            if (amountToShow != 0)
            {
                GenerateImageArray();
                ShowCurrentImage();
                UpdateButtonsVisibily();
            }
            else
            {
                next.Visibility = ViewStates.Invisible;
                back.Visibility = ViewStates.Invisible;
            }

        }

        public void Init()
        {
            amountToShow = Intent.GetIntExtra("amountToShow", 0);
            i = 0;
            next = FindViewById<Button>(Resource.Id.showNext);
            back = FindViewById<Button>(Resource.Id.showBack);
            homePage = FindViewById<Button>(Resource.Id.homePage);
            toShowLay = FindViewById<LinearLayout>(Resource.Id.toShowLay);
            back.Click += Back_Click;
            next.Click += Next_Click;
            homePage.Click += HomePage_Click;
        }

        private void HomePage_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        public void GenerateImageArray()
        {
            images = new ImageView[amountToShow];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = GenerateRandomPic();
            }
        }

        public void ShowCurrentImage()
        {
            toShowLay.RemoveAllViews();
            toShowLay.AddView(images[i]);
        }

        public ImageView GenerateRandomPic()
        {
            const int FILL_PARENT = LinearLayout.LayoutParams.FillParent;
            const int MATCH_PARENT = LinearLayout.LayoutParams.MatchParent;
            var img = new ImageView(this);
            char[] types = { 's', 'c', 'h', 'd' };
            int id = rnd.Next(1, 14);
            char type = types[rnd.Next(0, types.Length)];
            img.SetImageResource(Resources.GetIdentifier($"img{id}{type}", "drawable", this.PackageName));
            img.LayoutParameters = new LinearLayout.LayoutParams(FILL_PARENT, MATCH_PARENT, 1);
            return img;
        }

        public void UpdateButtonsVisibily()
        {
            if (i <= 0)//Back button visibility
                back.Visibility = ViewStates.Invisible;
            else
                back.Visibility = ViewStates.Visible;

            if (i == amountToShow - 1)//Next button visibility
                next.Visibility = ViewStates.Invisible;
            else
                next.Visibility = ViewStates.Visible;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (i < amountToShow - 1)
            {
                i++;
                ShowCurrentImage();
                UpdateButtonsVisibily();
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;
                ShowCurrentImage();
                UpdateButtonsVisibily();
            }
        }
    }
}

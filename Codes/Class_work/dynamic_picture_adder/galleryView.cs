using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace dynamic_picture_adder
{
    [Activity(Label = "galleryView")]
    public class galleryView : Activity
    {
        public static System.Random rnd = new System.Random();
        LinearLayout toShowLay;
        Button show, homePage;
        int amountToShow;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.gallery_View);
            show = FindViewById<Button>(Resource.Id.show);
            toShowLay = FindViewById<LinearLayout>(Resource.Id.toShowLay);
            homePage = FindViewById<Button>(Resource.Id.homePage);
            homePage.Click += HomePage_Click;
            show.Click += Show_Click;
            amountToShow = Intent.GetIntExtra("amountToShow", 0);
        }

        private void HomePage_Click(object sender, System.EventArgs e)
        {
            Finish();
        }

        private void Show_Click(object sender, System.EventArgs e)
        {
            Show_gallery(amountToShow);
        }

        private void Show_gallery(int amountToShow)
        {
            toShowLay.RemoveAllViews();
            int rows = (amountToShow / 3) + 1;
            for (int i = 0; i < rows; i++)
            {
                var tempLay = new LinearLayout(this);
                tempLay.Orientation = Orientation.Horizontal;
                for (int j = 0; j < 3 && amountToShow != 0; j++)
                {
                    tempLay.AddView(generateRandomPic());
                    amountToShow--;
                }
                toShowLay.AddView(tempLay);
            }
        }

        public ImageView generateRandomPic()
        {
            var img = new ImageView(this);
            char[] types = { 's', 'c', 'h', 'd' };
            int id = rnd.Next(1, 14);
            char type = types[rnd.Next(0, types.Length)];
            img.SetImageResource(Resources.GetIdentifier($"img{id}{type}", "drawable", this.PackageName));
            img.LayoutParameters = new LinearLayout.LayoutParams(0, 200, 1);
            return img;
        }
    }
}
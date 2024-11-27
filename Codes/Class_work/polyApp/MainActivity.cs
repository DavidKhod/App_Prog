using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace polyApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button wedCardBtn, birthCardBtn, showAllCardsBtn, toListViewBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Init();
        }

        public void Init()
        {
            wedCardBtn = FindViewById<Button>(Resource.Id.wedCardBtn);
            wedCardBtn.Click += WedCardBtn_Click;
            birthCardBtn = FindViewById<Button>(Resource.Id.birthCardBtn);
            birthCardBtn.Click += BirthCardBtn_Click;
            showAllCardsBtn = FindViewById<Button>(Resource.Id.showAllCardBtn);
            showAllCardsBtn.Click += ShowAllCardsBtn_Click;
            toListViewBtn = FindViewById<Button>(Resource.Id.toListViewBtn);
            toListViewBtn.Click += ToListViewBtn_Click;
        }

        private void ToListViewBtn_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(filterToListView));
            StartActivity(intent);
        }

        private void ShowAllCardsBtn_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(ShowCards));
            StartActivity(intent);
        }

        private void BirthCardBtn_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CreateCard));
            intent.PutExtra("type", "Birthday");
            StartActivity(intent);
        }

        private void WedCardBtn_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(CreateCard));
            intent.PutExtra("type", "Wedding");
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
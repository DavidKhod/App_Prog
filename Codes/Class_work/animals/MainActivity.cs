using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace animals
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button dogs, birds, fishes;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Init();
        }

        public void Init()
        {
            dogs = FindViewById<Button>(Resource.Id.toDogs);
            dogs.Click += Dogs_Click;
            birds = FindViewById<Button>(Resource.Id.toBirds);
            birds.Click += Birds_Click;
            fishes = FindViewById<Button>(Resource.Id.toFishes);
            fishes.Click += Fishes_Click;
        }

        private void Fishes_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(FishActivity));
            StartActivity(intent);
        }

        private void Birds_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Application.Context, typeof(BirdActivity));
            StartActivity(intent);
        }

        private void Dogs_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Application.Context, typeof(DogActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
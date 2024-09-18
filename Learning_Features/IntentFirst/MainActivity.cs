using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace IntentFirst
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btn1;
        string userName;
        string age;
        Intent intent;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Init()
        {
            btn1 = FindViewById<Button>(Resource.Id.btn1);
            btn1.Click += Btn1_Click;
        }

        private void Btn1_Click(object sender, System.EventArgs e)
        {
            userName = FindViewById<EditText>(Resource.Id.username).Text;
            age = FindViewById<EditText>(Resource.Id.age).Text;
            userName = !string.IsNullOrEmpty(userName) ? userName : "Guest";
            age = !string.IsNullOrEmpty(age) ? age : "-1";
            var intent = new Intent(this, typeof(SecondActivity));
            intent.PutExtra("age", age);
            intent.PutExtra("userName", userName);
            StartActivity(intent);
        }
    }
}
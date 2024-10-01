using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace shared_prefrence
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button logout;
        TextView introduction_msg;
        string username, password;
        bool saveDataChecked;
        ISharedPreferences sp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
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
            logout = FindViewById<Button>(Resource.Id.logout);
            logout.Click += Logout_Click;
            introduction_msg = FindViewById<TextView>(Resource.Id.introcudtion);
            sp = GetSharedPreferences("userData", FileCreationMode.Private);
            username = sp.GetString("username", "No username provided");
            password = sp.GetString("password", "None");
            saveDataChecked = sp.GetBoolean("saveDataChecked", false);
            introduction_msg.Text = $"Hello: {username}";
        }

        private void Logout_Click(object sender, System.EventArgs e)
        {
            if (!saveDataChecked)
                sp.Dispose();
            var intent = new Intent(this, typeof(LoginActivity));
            StartActivity(intent);
            Finish();
        }
    }
}
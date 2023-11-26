using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MakingButtonDoSomething
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button on;
        Button off;
        Button plus;
        Button min;
        TextView txtview1;
        int cnt = 0;
        bool onOff = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            off = FindViewById<Button>(Resource.Id.off);
            on = FindViewById<Button>(Resource.Id.on);
            plus = FindViewById<Button>(Resource.Id.up);
            min = FindViewById<Button>(Resource.Id.less);
            

            txtview1 = FindViewById<TextView>(Resource.Id.txtv1);
            on.Click += On_Click;
            off.Click += Off_Click;
            plus.Click += Plus_Click;
            min.Click += Min_Click;
        }

        private void Min_Click(object sender, System.EventArgs e)
        {
            if (onOff)
            {
                cnt--;
                txtview1.Text = cnt.ToString();
            }
        }

        private void Plus_Click(object sender, System.EventArgs e)
        {
            if (onOff)
            {
                cnt++;
                txtview1.Text = cnt.ToString();
            }
        }

        private void Off_Click(object sender, System.EventArgs e)
        {
            onOff = false;
            txtview1.Text = cnt.ToString();
        }

        private void On_Click(object sender, System.EventArgs e)
        {
            onOff = true;
            txtview1.Text = cnt.ToString();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
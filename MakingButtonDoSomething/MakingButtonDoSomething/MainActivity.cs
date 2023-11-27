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
        int tempValue = 0;
        bool onOff = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            InitControl();

            txtview1 = FindViewById<TextView>(Resource.Id.txtv1);
            on.Click += On_Click;
            off.Click += Off_Click;
            plus.Click += Plus_Click;
            min.Click += Min_Click;
        }

        void InitControl()
        {
            off = FindViewById<Button>(Resource.Id.off);
            on = FindViewById<Button>(Resource.Id.on);
            plus = FindViewById<Button>(Resource.Id.up);
            min = FindViewById<Button>(Resource.Id.less);
        }

        private void Min_Click(object sender, System.EventArgs e)
        {
            if (onOff && tempValue < 36 && tempValue > 16)
            {
                tempValue--;
                txtview1.Text = tempValue.ToString();
            }
        }

        private void Plus_Click(object sender, System.EventArgs e)
        {
            if (onOff && tempValue < 36 && tempValue > 16)
            {
                tempValue++;
                txtview1.Text = tempValue.ToString();
            }
        }

        private void Off_Click(object sender, System.EventArgs e)
        {
            onOff = false;
            txtview1.Text = "";
        }

        private void On_Click(object sender, System.EventArgs e)
        {
            onOff = true;
            txtview1.Text =tempValue.ToString();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
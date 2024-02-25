using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace MakingButtonDoSomething
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        Button on_off;
        Button plus;
        Button min;
        Button startScreenTwo;
        Button switchMode;
        TextView txtview1;
        AC ac = new AC(ACMode.heat, 25);
        ImageView modePic;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            InitControl();


            on_off.Click += On_Click;
            plus.Click += Plus_Click;
            min.Click += Min_Click;
            startScreenTwo.Click += StartScreenTwo_Click;
            switchMode.Click += SwitchMode_Click;
        }

        private void SwitchMode_Click(object sender, System.EventArgs e)
        {
            ac.SwitchMode();
            if (ac.GetMode() == ACMode.heat)
                modePic.SetImageResource(Resource.Drawable.sunForAC);
            else
                modePic.SetImageResource(Resource.Drawable.snowFlakeForAc);
        }

        private void StartScreenTwo_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(ScreenTwoActivity));
        }

        void InitControl()
        {
            on_off = FindViewById<Button>(Resource.Id.on);
            plus = FindViewById<Button>(Resource.Id.up);
            min = FindViewById<Button>(Resource.Id.less);
            txtview1 = FindViewById<TextView>(Resource.Id.txtv1);
            txtview1.Text = "";
            startScreenTwo = FindViewById<Button>(Resource.Id.nextScreen);
            modePic = FindViewById<ImageView>(Resource.Id.modePic);
            switchMode = FindViewById<Button>(Resource.Id.mode);
        }

        private void Min_Click(object sender, System.EventArgs e)
        {
            if (ac.IsOn())
            {
                ac.DecreaseTemp();
                txtview1.Text = ac.GetTemp().ToString();
            }
        }

        private void Plus_Click(object sender, System.EventArgs e)
        {
            if (ac.IsOn())
            {
                ac.IncreaseTemp();
                txtview1.Text = ac.GetTemp().ToString();
            }
        }


        private void On_Click(object sender, System.EventArgs e)
        {
            if (ac.IsOn())
            {
                ac.TurnOff();
                txtview1.Text = "";
            }
            else
            {
                ac.TurnOn();
                txtview1.Text = ac.GetTemp().ToString();
            }

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
using Android.App;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using Android.Widget;
namespace Dynamic_TicTacToe_Task13
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        LinearLayout main, top, mid, bottom;
        readonly int size = 5;
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
            main = FindViewById<LinearLayout>(Resource.Id.mainLayout);
            Button[,] buttons = new Button[size, size];
            for (int cnt = 0; cnt < size; cnt++)
            {
                LinearLayout tempLay = new LinearLayout(this);
                tempLay.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 1, 1);
                tempLay.Orientation = Orientation.Horizontal;
                for (int i = 0; i < size; i++)
                {
                    Button tempBtn = new Button(this);
                    var p = new LinearLayout.LayoutParams(1, LinearLayout.LayoutParams.MatchParent, 1);
                    tempBtn.LayoutParameters = p;
                    buttons[cnt, i] = tempBtn;
                    tempLay.AddView(tempBtn);
                    tempBtn.Click += Btn_Click;
                }
                main.AddView(tempLay);
            }


        }

        private void Btn_Click(object sender, System.EventArgs e)
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
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace TicTacToeGame
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button topLeft;
        Button top;
        Button topRight;
        Button middleLeft;
        Button middle;
        Button middleRight;
        Button bottomLeft;
        Button bottom;
        Button bottomRight;
        TicTacToe game;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();
            topLeft.Click += TopLeft_Click;
        }

        private void TopLeft_Click(object sender, System.EventArgs e)
        {
            if(topLeft.Text == " ")
            {
                topLeft.Text = game.turnNow();
                Update();
            }
            else
                Toast.MakeText(Application.Context, "Choose an Empty square!", ToastLength.Short).Show();

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void Update()
        {
            if (game.IfWin())
            {
                Toast.MakeText(Application.Context, game.WhoWon(), ToastLength.Short).Show();
                game.StartOver();
            }
            else
                game.SwitchTurn();

        }
        public void Init()
        {
            topLeft = FindViewById<Button>(Resource.Id.topLeft);
            top = FindViewById<Button>(Resource.Id.top);
            topRight = FindViewById<Button>(Resource.Id.topRight);
            middleLeft = FindViewById<Button>(Resource.Id.middleLeft);
            middle = FindViewById<Button>(Resource.Id.middle);
            middleRight = FindViewById<Button>(Resource.Id.middleRigh);
            bottomLeft = FindViewById<Button>(Resource.Id.bottomLeft);
            bottom = FindViewById<Button>(Resource.Id.bottom);
            bottomRight = FindViewById<Button>(Resource.Id.bottomRight);
        }
    }
}
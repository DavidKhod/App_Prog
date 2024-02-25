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
        Button[,] buttons;
        TicTacToe game;
        bool isX = true;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            isX = Intent.GetBooleanExtra("isX", true);//Recive bool of who starts
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Init();//Initiate all Buttons
            InitClick();//Initiate all buttons
        }

        private void Choice_Click(object sender, System.EventArgs e)
        {
            if (((Button)sender).Text == " ")
            {
                ((Button)sender).Text = game.TurnNow();
                game.SetChoice(sender, buttons);
                Update();
            }
            else
                Toast.MakeText(Application.Context, "Choose an Empty square!", ToastLength.Short).Show();
        }

        public void Update()
        {
            if (game.IfWin())
            {
                Toast.MakeText(Application.Context, game.WhoWon(), ToastLength.Short).Show();
                resetGame();
            }
            else
            {
                game.SwitchTurn();
            }
        }

        public void Init()
        {
            buttons = new Button[3, 3];
            buttons[0, 0] = FindViewById<Button>(Resource.Id.topLeft);
            buttons[0, 1] = FindViewById<Button>(Resource.Id.top);
            buttons[0, 2] = FindViewById<Button>(Resource.Id.topRight);
            buttons[1, 0] = FindViewById<Button>(Resource.Id.middleLeft);
            buttons[1, 1] = FindViewById<Button>(Resource.Id.middle);
            buttons[1, 2] = FindViewById<Button>(Resource.Id.middleRigh);
            buttons[2, 0] = FindViewById<Button>(Resource.Id.bottomLeft);
            buttons[2, 1] = FindViewById<Button>(Resource.Id.bottom);
            buttons[2, 2] = FindViewById<Button>(Resource.Id.bottomRight);
            game = new TicTacToe();
        }

        public void InitClick()
        {
            buttons[0, 0].Click += Choice_Click;
            buttons[0, 1].Click += Choice_Click;
            buttons[0, 2].Click += Choice_Click;
            buttons[1, 0].Click += Choice_Click;
            buttons[1, 1].Click += Choice_Click;
            buttons[1, 2].Click += Choice_Click;
            buttons[2, 0].Click += Choice_Click;
            buttons[2, 1].Click += Choice_Click;
            buttons[2, 2].Click += Choice_Click;
        }

        public void resetGame()
        {
            game.StartOver();
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    buttons[i, j].Text = " ";
                }
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}
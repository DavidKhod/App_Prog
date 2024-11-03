using Android.App;
using Android.OS;
using Android.Widget;

namespace animals
{
    [Activity(Label = "BirdActivity")]
    public class BirdActivity : Activity
    {
        Button move, talk;
        Bird bird;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.bird_layout);
            Init();
            bird = new Bird("Ostrich", Gender.Male, 100, "Grey", 1500);
        }
        public void Init()
        {
            move = FindViewById<Button>(Resource.Id.moveBtn);
            move.Click += Move_Click;
            talk = FindViewById<Button>(Resource.Id.talkBtn);
            talk.Click += Talk_Click;
        }

        private void Talk_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, bird.MakeSound(), ToastLength.Short).Show();
        }

        private void Move_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, bird.Move(), ToastLength.Short).Show();
        }
    }
}
using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace animals
{
    [Activity(Label = "DogActivity", Theme = "@style/AppTheme")]
    public class DogActivity : AppCompatActivity
    {
        Button nurseThePup, nurseFromMom, talk, move;
        Dog puppy, mom;
        ProgressBar puppyProg, momProg;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dog_layout);
            Init();
            puppy = new Dog("Cutie", Gender.Female, 0, 4, 0, "English Bulldog");
            mom = new Dog("Mum", Gender.Female, 100, 4, 100, "English Bulldog");
        }

        public void Init()
        {
            nurseThePup = FindViewById<Button>(Resource.Id.nursePup);
            nurseThePup.Click += NurseThePup_Click;
            nurseFromMom = FindViewById<Button>(Resource.Id.nurseFromMom);
            nurseFromMom.Click += NurseFromMom_Click;
            puppyProg = FindViewById<ProgressBar>(Resource.Id.pupProgBar);
            puppyProg.Progress = 0;
            momProg = FindViewById<ProgressBar>(Resource.Id.momProgBar);
            momProg.Progress = 100;
            talk = FindViewById<Button>(Resource.Id.talkBtn);
            talk.Click += Talk_Click;
            move = FindViewById<Button>(Resource.Id.moveBtn);
            move.Click += Move_Click;
        }

        private void Move_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, $"Mom: {mom.Move()}\nPup: {puppy.Move()}", ToastLength.Short).Show();
        }

        private void Talk_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, $"Mom: {mom.MakeSound()}\nPup: {puppy.MakeSound()}", ToastLength.Short).Show();
        }

        private void NurseFromMom_Click(object sender, System.EventArgs e)
        {
            puppy.NurseFrom(mom, 10);
            puppyProg.Progress = (int)puppy.Energy;
            momProg.Progress = (int)mom.Energy;
        }

        private void NurseThePup_Click(object sender, System.EventArgs e)
        {
            mom.NurseOther(puppy, 10);
            puppyProg.Progress = (int)puppy.Energy;
            momProg.Progress = (int)mom.Energy;
        }
    }
}
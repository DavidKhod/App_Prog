using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace animals
{
    [Activity(Label = "DispDogsActivity")]
    public class DispDogsActivity : Activity
    {
        TextView dispTextView;
        Button back, next;
        int currentDog = 0;
        string[] animals;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.dispDogs_layout);
            animals = Intent.GetStringArrayExtra("animalsStrings");
            Init();
            if (animals.Length > 0)
            {
                UpdateButtons();
                UpdateText();
            }
        }

        public void Init()
        {
            back = FindViewById<Button>(Resource.Id.back);
            back.Click += Back_Click;
            next = FindViewById<Button>(Resource.Id.next);
            next.Click += Next_Click;
            dispTextView = FindViewById<TextView>(Resource.Id.dispTextview);
        }

        public void UpdateText()
        {
            string[] allParams = animals[currentDog].Split(',');
            dispTextView.Text = "";
            foreach (string param in allParams)
            {
                dispTextView.Text += param;
                dispTextView.Text += "\n";
            }
        }
        private void Next_Click(object sender, System.EventArgs e)
        {
            currentDog++;
            UpdateButtons();
            UpdateText();
        }

        private void Back_Click(object sender, System.EventArgs e)
        {
            currentDog--;
            UpdateButtons();
            UpdateText();
        }

        public void UpdateButtons()
        {
            if (currentDog <= 0)
                back.Visibility = ViewStates.Invisible;
            else
                back.Visibility = ViewStates.Visible;
            if (currentDog == animals.Length - 1)
                next.Visibility = ViewStates.Invisible;
            else
                next.Visibility = ViewStates.Visible;
        }
    }
}
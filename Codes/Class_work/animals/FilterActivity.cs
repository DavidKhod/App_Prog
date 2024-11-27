using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace animals
{
    [Activity(Label = "FilterActivity")]
    public class FilterActivity : Activity
    {
        string[] allAnimals;
        List<string> filteredAnimals;
        RadioGroup filterChoices;
        Button filter, next, back;
        TextView AnimalTxt;
        int currentAnimal = 0;
        int choice;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.filter_layout);
            allAnimals = Intent.GetStringArrayExtra("animalsStrings");
        }
        public void Init()
        {
            filterChoices = FindViewById<RadioGroup>(Resource.Id.choices);
            filterChoices.CheckedChange += FilterChoices_CheckedChange;
            filter = FindViewById<Button>(Resource.Id.filter);
            filter.Click += Filter_Click;
            AnimalTxt = FindViewById<TextView>(Resource.Id.animalTxt);
            next = FindViewById<Button>(Resource.Id.next);
            next.Click += Next_Click;
            back = FindViewById<Button>(Resource.Id.back);
            back.Click += Back_Click;
        }
        public void UpdateText() => AnimalTxt.Text = filteredAnimals[currentAnimal];
        private void Next_Click(object sender, System.EventArgs e)
        {
            currentAnimal++;
            UpdateButtons();
            UpdateText();
        }

        private void Back_Click(object sender, System.EventArgs e)
        {
            currentAnimal--;
            UpdateButtons();
            UpdateText();
        }

        public void UpdateButtons()
        {
            if (currentAnimal <= 0)
                back.Visibility = ViewStates.Invisible;
            else
                back.Visibility = ViewStates.Visible;
            if (currentAnimal == filteredAnimals.Count - 1)
                next.Visibility = ViewStates.Invisible;
            else
                next.Visibility = ViewStates.Visible;
        }

        private void Filter_Click(object sender, System.EventArgs e)
        {
            filteredAnimals.Clear();
            foreach (string animal in allAnimals)
            {
                string type = animal.Split(' ')[0];
                switch (type)
                {
                    case "Dog":
                        filteredAnimals.Add(animal.Split(' ')[1]);
                        break;
                    case "Fish":
                        filteredAnimals.Add(animal.Split(' ')[1]);
                        break;
                    case "Bird":
                        filteredAnimals.Add(animal.Split(' ')[1]);
                        break;
                }
            }
            UpdateButtons();
            UpdateText();
        }

        private void FilterChoices_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            switch (e.CheckedId)
            {
                case Resource.Id.dog:
                    choice = 1;
                    break;
                case Resource.Id.bird:
                    choice = 2;
                    break;
                case Resource.Id.fish:
                    choice = 3;
                    break;
            }
        }
    }
}
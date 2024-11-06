using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace animals
{
    [Activity(Label = "AddAnimalActivity")]
    public class AddAnimalActivity : Activity
    {
        RadioGroup choices;
        Button addAnimal;
        byte choice;
        Intent data = new Intent(Application.Context, typeof(MainActivity));
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addAnimal_layout);
            Init();
        }

        public void Init()
        {
            choices = FindViewById<RadioGroup>(Resource.Id.choicePickGroup);
            choices.CheckedChange += Choices_CheckedChange;
            addAnimal = FindViewById<Button>(Resource.Id.addAnimal);
            addAnimal.Click += AddAnimal_Click;
        }

        private void AddAnimal_Click(object sender, EventArgs e)
        {
            switch (choice)
            {
                case 1:
                    AddDog();
                    break;
                case 2:
                    AddFish();
                    break;
                case 3:
                    AddBird();
                    break;
            }
            SetResult(Result.Ok, data);
            Finish();
        }

        private string[] TakeMainParams()
        {
            string[] mainParams = new string[3];
            string name = FindViewById<EditText>(Resource.Id.name).Text;
            string genderStr = FindViewById<EditText>(Resource.Id.gender).Text;
            string energyStr = FindViewById<EditText>(Resource.Id.energy).Text;
            double energy;
            double.TryParse(energyStr, out energy);
            mainParams[0] = name;
            mainParams[1] = genderStr;
            mainParams[2] = $"{energy}";
            return mainParams;
        }

        private void AddDog()
        {
            string[] mainParams = TakeMainParams();
            string name = mainParams[0];
            string genderStr = mainParams[1];
            string energy = mainParams[2];
            int legCount;
            int.TryParse(FindViewById<EditText>(Resource.Id.legCount).Text, out legCount);
            int milk;
            int.TryParse(FindViewById<EditText>(Resource.Id.milk).Text, out milk);
            string breed = FindViewById<EditText>(Resource.Id.breed).Text;
            data.PutExtra("animalParams", new string[] { name, genderStr, energy, $"{legCount}", $"{milk}", breed });
            data.PutExtra("choice", 1);
        }

        private void AddFish()
        {
            string[] mainParams = TakeMainParams();
            string name = mainParams[0];
            string genderStr = mainParams[1];
            string energy = mainParams[2];
            double depth;
            double.TryParse(FindViewById<EditText>(Resource.Id.depth).Text, out depth);
            data.PutExtra("animalParams", new string[] { name, genderStr, energy, $"{depth}" });
            data.PutExtra("choice", 2);
        }

        private void AddBird()
        {
            string[] mainParams = TakeMainParams();
            string name = mainParams[0];
            string genderStr = mainParams[1];
            string energy = mainParams[2];
            string colour = FindViewById<EditText>(Resource.Id.colour).Text;
            double maxFlightHeight;
            double.TryParse(FindViewById<EditText>(Resource.Id.maxFlightHeight).Text, out maxFlightHeight);
            data.PutExtra("animalParams", new string[] { name, genderStr, energy, colour, $"{maxFlightHeight}" });
            data.PutExtra("choice", 3);
        }

        private void Choices_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            FindViewById<LinearLayout>(Resource.Id.mainParams).Visibility = ViewStates.Visible;
            switch (e.CheckedId)
            {
                case Resource.Id.dog:
                    choice = 1;
                    FindViewById<LinearLayout>(Resource.Id.dogParams).Visibility = ViewStates.Visible;
                    FindViewById<LinearLayout>(Resource.Id.fishParams).Visibility = ViewStates.Invisible;
                    FindViewById<LinearLayout>(Resource.Id.birdParams).Visibility = ViewStates.Invisible;
                    break;
                case Resource.Id.fish:
                    choice = 2;
                    FindViewById<LinearLayout>(Resource.Id.dogParams).Visibility = ViewStates.Invisible;
                    FindViewById<LinearLayout>(Resource.Id.fishParams).Visibility = ViewStates.Visible;
                    FindViewById<LinearLayout>(Resource.Id.birdParams).Visibility = ViewStates.Invisible;
                    break;
                case Resource.Id.bird:
                    choice = 3;
                    FindViewById<LinearLayout>(Resource.Id.dogParams).Visibility = ViewStates.Invisible;
                    FindViewById<LinearLayout>(Resource.Id.fishParams).Visibility = ViewStates.Invisible;
                    FindViewById<LinearLayout>(Resource.Id.birdParams).Visibility = ViewStates.Visible;
                    break;
            }
        }
    }
}
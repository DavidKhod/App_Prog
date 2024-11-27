using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.Collections.Generic;
using System.Linq;
namespace animals
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button dogs, birds, fishes, toFilter;
        Button dispDogs, dispBirds, dispFishes, addAnimal;
        List<Animal> animalsList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Init();
        }

        public void Init()
        {
            dogs = FindViewById<Button>(Resource.Id.toDogs);
            dogs.Click += Dogs_Click;
            birds = FindViewById<Button>(Resource.Id.toBirds);
            birds.Click += Birds_Click;
            fishes = FindViewById<Button>(Resource.Id.toFishes);
            fishes.Click += Fishes_Click;
            dispDogs = FindViewById<Button>(Resource.Id.dispDogs);
            dispDogs.Click += DispDogs_Click;
            dispBirds = FindViewById<Button>(Resource.Id.dispBirds);
            dispBirds.Click += DispBirds_Click;
            dispFishes = FindViewById<Button>(Resource.Id.dispFishes);
            dispFishes.Click += DispFishes_Click;
            addAnimal = FindViewById<Button>(Resource.Id.addAnimal);
            addAnimal.Click += AddAnimal_Click;
            toFilter = FindViewById<Button>(Resource.Id.toFilter);
            toFilter.Click += ToFilter_Click;
            animalsList = new List<Animal>
            {
                new Dog("Cutie", Gender.Female, 0, 4, 0, "English Bulldog"),
                new Dog("Mum", Gender.Female, 100, 4, 100, "English Bulldog"),
                new Bird("Ostrich", Gender.Male, 100, "Grey", 1500),
                new Fish("Georgeius the 3rd", Gender.Other, -3, 666)
            };
        }

        private void ToFilter_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(FilterActivity));
            string[] serilizedAnimals = animalsList.Select(animal => animal.ToSerilizable()).ToArray();
            intent.PutExtra("animalsSerilized", serilizedAnimals);
            StartActivity(intent);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            int choice = data.GetIntExtra("choice", 1);
            string[] animalParams = data.GetStringArrayExtra("animalParams");
            Gender gender;
            switch (animalParams[1].ToUpper())
            {
                case "MALE":
                    gender = Gender.Male;
                    break;
                case "FEMALE":
                    gender = Gender.Female;
                    break;
                default:
                    gender = Gender.Other;
                    break;
            }
            switch (choice)
            {
                case 1:
                    animalsList.Add(new Dog(animalParams[0], gender, double.Parse(animalParams[2]), int.Parse(animalParams[3]), int.Parse(animalParams[4]), animalParams[5]));
                    break;
                case 2:
                    animalsList.Add(new Fish(animalParams[0], gender, double.Parse(animalParams[2]), double.Parse(animalParams[3])));
                    break;
                case 3:
                    animalsList.Add(new Bird(animalParams[0], gender, double.Parse(animalParams[2]), animalParams[3], double.Parse(animalParams[4])));
                    break;
            }
        }

        private void AddAnimal_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(AddAnimalActivity));
            StartActivityForResult(intent, 1);
        }

        private void DispDogs_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DispDogsActivity));
            string[] animalsStrings = animalsList.Where(animal => animal is Dog).Select(animal => animal.ToString()).ToArray<string>();
            intent.PutExtra("animalsStrings", animalsStrings);
            StartActivity(intent);
        }

        private void DispBirds_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Application.Context, typeof(DispDogsActivity));
            string[] animalsStrings = animalsList.Where(animal => animal is Bird).Select(animal => animal.ToString()).ToArray<string>();
            intent.PutExtra("animalsStrings", animalsStrings);
            StartActivity(intent);
        }

        private void DispFishes_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(DispDogsActivity));
            string[] animalsStrings = animalsList.Where(animal => animal is Fish).Select(animal => animal.ToString()).ToArray<string>();
            intent.PutExtra("animalsStrings", animalsStrings);
            StartActivity(intent);
        }

        private void Fishes_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(FishActivity));
            StartActivity(intent);
        }

        private void Birds_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(this, typeof(FishActivity));
            StartActivity(intent);
        }

        private void Dogs_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(Application.Context, typeof(DogActivity));
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
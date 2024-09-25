using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace dynamic_picture_adder
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        Button showPics;
        RadioGroup optionGroup;
        int amountToShow;
        byte optionPicked = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            init();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public void init()
        {
            showPics = FindViewById<Button>(Resource.Id.show);
            optionGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup1);

            optionGroup.CheckedChange += OptionGroup_CheckedChange;
            showPics.Click += ShowPics_Click;
        }

        private void OptionGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            switch (e.CheckedId)
            {
                case Resource.Id.galleryOption:
                    optionPicked = 1;
                    break;
                case Resource.Id.flipOption:
                    optionPicked = 2;
                    break;
                case Resource.Id.quizOption:
                    optionPicked = 3;
                    break;
                default:
                    optionPicked = 0;
                    break;
            }
        }

        private void ShowPics_Click(object sender, System.EventArgs e)
        {
            if (!int.TryParse(FindViewById<EditText>(Resource.Id.amountToshow).Text, out amountToShow))
                amountToShow = 0;
            Intent intent;
            if (optionPicked != 0)
            {
                switch(optionPicked)
                {
                    case 1:
                        intent = new Intent(this, typeof(galleryView));
                        break;
                    case 2:
                        intent = new Intent(this, typeof(flip_Page));
                        break;
                    case 3:
                        intent = new Intent(this, typeof(quizView));
                        break;
                    default:
                        intent = new Intent(this, typeof(MainActivity));
                        break;
                }
                intent.PutExtra("amountToShow", amountToShow);
                StartActivity(intent);
            }
        }
    }
}
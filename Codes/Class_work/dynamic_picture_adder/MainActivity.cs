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
            if (e.CheckedId == Resource.Id.galleryOption)
                optionPicked = 1;
            else if (e.CheckedId == Resource.Id.flipOption)
                optionPicked = 2;
            else
                optionPicked = 0;
        }

        private void ShowPics_Click(object sender, System.EventArgs e)
        {
            try
            {
                amountToShow = int.Parse(FindViewById<EditText>(Resource.Id.amountToshow).Text);
            }
            catch
            {
                amountToShow = 0;
            }
            var intent = new Intent(this, typeof(MainActivity));
            if (optionPicked != 0)
            {
                if (optionPicked == 1)
                    intent = new Intent(this, typeof(galleryView));
                else if (optionPicked == 2)
                    intent = new Intent(this, typeof(flip_Page));
                intent.PutExtra("amountToShow", amountToShow);
                StartActivity(intent);
            }
        }
    }
}
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Widget;
using AndroidX.AppCompat.App;
namespace DropDownList
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Spinner spin1;
        ArrayAdapter<string> arrAdapter;
        string[] strArr = { "itme1", "item2", "item3", "item4", "item5" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
        }

        void Init()
        {
            spin1 = FindViewById<Spinner>(Resource.Id.spinner1);
            arrAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, strArr);
            spin1.Adapter = arrAdapter;
            spin1.ItemSelected += Spin1_ItemSelected;
        }
        
        private void Spin1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Toast.MakeText(this, strArr[e.Position], ToastLength.Short).Show();
            Log.Debug("This computer", "Toast went succesfully");
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
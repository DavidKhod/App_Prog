using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace Memory_Game
{
    [Activity(Label = "HomePage", MainLauncher = true)]
    public class HomePage : Activity
    {
        Spinner mainSpinner;
        int[] arr = { 2, 4, 6, 8, 10 };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HomePage);
            InitSpinner();
        }

        public void InitSpinner()
        {
            mainSpinner = FindViewById<Spinner>(Resource.Id.mainSpinner);
            ArrayAdapter<int> adapterArr = new ArrayAdapter<int>(this, Android.Resource.Layout.SimpleSpinnerDropDownItem, arr);
            mainSpinner.ItemSelected += MainSpinner_ItemSelected;
        }

        private void MainSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Intent intent = new Intent(this, typeof(MainActivity));
            intent.PutExtra("SelectedItemIndex", e.Position);
            StartActivity(intent);
            Finish();
        }
    }
}
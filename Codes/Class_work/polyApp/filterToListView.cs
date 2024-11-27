using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;

namespace polyApp
{
    [Activity(Label = "filterToListView")]
    public class filterToListView : Activity
    {
        Button adultBtn, youthBtn, weddingBtn, allBtn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.filtetToListView_layout);
            Init();
        }

        public void Init()
        {
            adultBtn = FindViewById<Button>(Resource.Id.adultBirthOption);
            adultBtn.Click += AdultBtn_Click;
            youthBtn = FindViewById<Button>(Resource.Id.youthBirthOption);
            youthBtn.Click += YouthBtn_Click;
            weddingBtn = FindViewById<Button>(Resource.Id.weddingOption);
            weddingBtn.Click += WeddingBtn_Click;
            allBtn = FindViewById<Button>(Resource.Id.allOption);
            allBtn.Click += AllBtn_Click;
        }

        private void AllBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(listViewOfCards));
            intent.PutExtra("filterID", 0);
            StartActivity(intent);
        }

        private void WeddingBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(listViewOfCards));
            intent.PutExtra("filterID", 1);
            StartActivity(intent);
        }

        private void YouthBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(listViewOfCards));
            intent.PutExtra("filterID", 2);
            StartActivity(intent);
        }

        private void AdultBtn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(listViewOfCards));
            intent.PutExtra("filterID", 3);
            StartActivity(intent);
        }
    }
}
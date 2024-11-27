using Android.App;
using Android.OS;
using Android.Widget;
using polyApp.Classes;
using System.Collections.Generic;

namespace polyApp
{
    [Activity(Label = "ShowCards")]
    public class ShowCards : Activity
    {
        Button filter;
        RadioGroup radioGroup;
        ScrollView scrollView;
        int filterID;
        GreetingCards instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.showCards_layout);
            instance = GreetingCards.GetInstance();
            Init();
        }

        public void Init()
        {
            scrollView = FindViewById<ScrollView>(Resource.Id.scrollView1);
            filter = FindViewById<Button>(Resource.Id.filter);
            filter.Click += Filter_Click;
            radioGroup = FindViewById<RadioGroup>(Resource.Id.radioGroup);
            radioGroup.CheckedChange += RadioGroup_CheckedChange;
        }

        private void RadioGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            switch (e.CheckedId)
            {
                case Resource.Id.weddingCards:
                    filterID = 1;
                    break;
                case Resource.Id.adultBirth:
                    filterID = 2;
                    break;
                case Resource.Id.youthBirth:
                    filterID = 3;
                    break;
            }
        }

        private void Filter_Click(object sender, System.EventArgs e)
        {
            scrollView.RemoveAllViews();
            List<GreetingCard> filtered = new List<GreetingCard>();
            switch (filterID)
            {
                case 1: // WeddingCard
                    filtered = instance.Filter<WeddingCard>();
                    break;

                case 2: // AdultBirthdayCard
                    filtered = instance.Filter<AdultBirthdayCard>();
                    break;

                case 3: // YouthBirthdayCard
                    filtered = instance.Filter<YouthBirthdayCard>();
                    break;
                default:
                    return;
            }
            foreach (var card in filtered)
            {
                TextView cardTxtTemp = new TextView(Application.Context);
                cardTxtTemp.Text = card.GreetingMsg();
                cardTxtTemp.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, LinearLayout.LayoutParams.WrapContent);
                scrollView.AddView(cardTxtTemp);
            }
        }
    }
}
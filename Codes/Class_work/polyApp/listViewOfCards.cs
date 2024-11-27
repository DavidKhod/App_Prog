using Android.App;
using Android.OS;
using Android.Widget;
using polyApp.Classes;
using System.Collections.Generic;

namespace polyApp
{
    [Activity(Label = "listViewOfCards")]
    public class listViewOfCards : Activity
    {
        ListView listView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            GreetingCards instance = GreetingCards.GetInstance();
            int filterID = Intent.GetIntExtra("filterID", 0);
            List<GreetingCard> cards;
            switch (filterID)
            {
                case 1:
                    cards = instance.Filter<WeddingCard>();
                    break;
                case 2:
                    cards = instance.Filter<YouthBirthdayCard>();
                    break;
                case 3:
                    cards = instance.Filter<AdultBirthdayCard>();
                    break;
                default:
                    cards = null;
                    break;
            }
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.listViewOfCards_layout);
            CardAdapter cardAdapter = new CardAdapter(this, cards);
            listView = FindViewById<ListView>(Resource.Id.listView);
            listView.Adapter = cardAdapter;
        }
    }
}
using Android.App;
using Android.OS;
using Android.Widget;
using polyApp.Classes;

namespace polyApp
{
    [Activity(Label = "CreateCard")]
    public class CreateCard : Activity
    {
        EditText recipientView, senderView, brideView, ageView;
        Button addCard;
        string type;
        GreetingCards instance = GreetingCards.GetInstance();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.createCard_layout);
            Init();
        }

        public void Init()
        {
            type = Intent.GetStringExtra("type");
            recipientView = FindViewById<EditText>(Resource.Id.recipient);
            senderView = FindViewById<EditText>(Resource.Id.sender);
            brideView = FindViewById<EditText>(Resource.Id.bride);
            ageView = FindViewById<EditText>(Resource.Id.age);
            switch (type.ToLower())
            {
                case "wedding":
                    brideView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, (LinearLayout.LayoutParams.WrapContent));
                    recipientView.Hint = "Groom";
                    break;
                case "birthday":
                    ageView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent, (LinearLayout.LayoutParams.WrapContent));
                    break;
            }
            addCard = FindViewById<Button>(Resource.Id.addCard);
            addCard.Click += AddCard_Click;
        }

        private void AddCard_Click(object sender, System.EventArgs e)
        {
            if (type.ToLower() == "wedding")
            {
                string groom = recipientView.Text;
                string bride = recipientView.Text;
                string senderStr = senderView.Text;
                instance.Add(new WeddingCard(groom, bride, senderStr));
            }
            else
            {
                string recipientStr = recipientView.Text;
                string senderStr = senderView.Text;
                int age;
                int.TryParse(ageView.Text, out age);
                if (age > 18)
                    instance.Add(new AdultBirthdayCard(recipientStr, senderStr, age));
                else
                    instance.Add(new YouthBirthdayCard(recipientStr, senderStr, age));
            }
            Finish();
        }
    }
}
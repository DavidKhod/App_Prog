using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using polyApp.Classes;
using System;
using System.Collections.Generic;

namespace polyApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TabHost _tabHost;
        private TabWidget _tabWidget;
        private FrameLayout _tabContent;
        const int CREATE_TAB = 0, SHOW_CARDS_TAB = 1;
        GreetingCards instance = GreetingCards.GetInstance();
        //Create card attributes
        RadioGroup optionRadGroup;
        EditText recipientView, senderView, brideView, ageView;
        Button addCard;
        string type;
        //Show card attributes
        Spinner spinner;
        ListView listView;
        List<GreetingCard> cards;
        int filterID;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Init();
        }

        public void Init()
        {
            // Initialize TabHost and its components
            _tabHost = FindViewById<TabHost>(Resource.Id.tabHost);
            //_tabWidget = FindViewById<TabWidget>(Resource.Id.tabs);
            //_tabContent = FindViewById<FrameLayout>(Resource.Id.tabContent);

            // Set up the TabHost
            _tabHost.Setup();

            // Add Tab 1 - "Create Card"
            TabHost.TabSpec tabSpec1 = _tabHost.NewTabSpec("createCard");
            tabSpec1.SetIndicator("Create Card"); // Tab name
            tabSpec1.SetContent(Resource.Id.createCardLay); // Layout resource for the tab
            _tabHost.AddTab(tabSpec1);

            // Add Tab 2 - "Show Card"
            TabHost.TabSpec tabSpec2 = _tabHost.NewTabSpec("showCard");
            tabSpec2.SetIndicator("Show Card"); // Tab name
            tabSpec2.SetContent(Resource.Id.showCardLay); // Layout resource for the tab
            _tabHost.AddTab(tabSpec2);

            // Optionally, set the first tab to be selected by default
            _tabHost.CurrentTab = SHOW_CARDS_TAB;
            _tabHost.TabChanged += _tabHost_TabChanged;
            spinner = FindViewById<Spinner>(Resource.Id.optionSpinner);
            var options = new string[] { "Wedding", "Youth Birthday", "Adult Birthday", "All cards" };
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, options);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.ItemSelected += Spinner_ItemSelected;
        }

        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            filterID = e.Position;
            InitiateShowCardsTab();
        }

        public void InitiateShowCardsTab()
        {
            switch (filterID)
            {
                case 0:
                    cards = instance.Filter<WeddingCard>();
                    break;
                case 1:
                    cards = instance.Filter<YouthBirthdayCard>();
                    break;
                case 2:
                    cards = instance.Filter<AdultBirthdayCard>();
                    break;
                default:
                    cards = null;
                    break;
            }
            CardAdapter cardAdapter = new CardAdapter(this, cards);
            listView = FindViewById<ListView>(Resource.Id.listView);
            listView.Adapter = cardAdapter;
        }
        private void _tabHost_TabChanged(object sender, TabHost.TabChangeEventArgs e)
        {
            if (e.TabId == "createCard")
            {
                _tabHost.CurrentTab = CREATE_TAB;
                InitiateCreateCardTab();
            }
            else if (e.TabId == "showCard")
            {
                _tabHost.CurrentTab = SHOW_CARDS_TAB;
                InitiateShowCardsTab();
            }
        }

        public void UpdateCardCreationByOption()
        {
            switch (type.ToLower())
            {
                case "birthday":
                    ageView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, (LinearLayout.LayoutParams.WrapContent));
                    recipientView.Hint = "Recipient";
                    brideView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 0);
                    break;
                default:
                    brideView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, (LinearLayout.LayoutParams.WrapContent));
                    recipientView.Hint = "Groom";
                    ageView.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 0);
                    break;
            }
        }

        public void InitiateCreateCardTab()
        {
            type = "wedding";
            optionRadGroup = FindViewById<RadioGroup>(Resource.Id.optionRadGroup);
            optionRadGroup.CheckedChange += OptionRadGroup_CheckedChange;
            recipientView = FindViewById<EditText>(Resource.Id.recipient);
            senderView = FindViewById<EditText>(Resource.Id.sender);
            brideView = FindViewById<EditText>(Resource.Id.bride);
            ageView = FindViewById<EditText>(Resource.Id.age);
            UpdateCardCreationByOption();
            addCard = FindViewById<Button>(Resource.Id.addCard);
            addCard.Click += AddCard_Click;
        }

        private void OptionRadGroup_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            switch (e.CheckedId)
            {
                case Resource.Id.weddingOption:
                    type = "wedding";
                    UpdateCardCreationByOption();
                    break;
                case Resource.Id.birthdayOption:
                    type = "birthday";
                    UpdateCardCreationByOption();
                    break;
            }
        }

        private void AddCard_Click(object sender, EventArgs e)
        {
            if (type.ToLower() == "wedding")
            {
                string groom = recipientView.Text;
                string bride = brideView.Text;
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
            recipientView.Text = "";
            brideView.Text = "";
            ageView.Text = "";
            senderView.Text = "";
            _tabHost.CurrentTab = SHOW_CARDS_TAB;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
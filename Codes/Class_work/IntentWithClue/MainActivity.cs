using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace IntentWithClue
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button sendSms, openWebsite, sendMail, startVoiceCall;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Init();
        }

        public void Init()
        {
            sendSms = FindViewById<Button>(Resource.Id.sendSms);
            sendSms.Click += SendSms_Click;
            openWebsite = FindViewById<Button>(Resource.Id.openWebSite);
            openWebsite.Click += OpenWebsite_Click;
            sendMail = FindViewById<Button>(Resource.Id.sendMail);
            sendMail.Click += SendMail_Click;
            startVoiceCall = FindViewById<Button>(Resource.Id.startVoiceCall);
            startVoiceCall.Click += StartVoiceCall_Click;
        }

        private void StartVoiceCall_Click(object sender, System.EventArgs e)
        {
            var phoneUri = Android.Net.Uri.Parse("tel: 123456789");
            var callIntent = new Intent(Intent.ActionDial, phoneUri); // השתמש ב-ActionDial כדי לא לאלץ
            StartActivity(callIntent);
        }

        private void SendMail_Click(object sender, System.EventArgs e)
        {
            string[] emails = { "example@gmail.com" };
            var emailIntent = new Intent(Intent.ActionSend);
            emailIntent.PutExtra(Intent.ExtraEmail, emails);
            emailIntent.PutExtra(Intent.ExtraSubject, "Test Email");
            emailIntent.PutExtra(Intent.ExtraText, "Sent a test email");
            emailIntent.SetType("text/plain");//simple text

        }


        private void OpenWebsite_Click(object sender, System.EventArgs e)
        {
            var uri = Android.Net.Uri.Parse("https://www.X.com");
            var websiteIntent = new Intent(Intent.ActionView, uri);
            StartActivity(websiteIntent);
        }

        private void SendSms_Click(object sender, System.EventArgs e)
        {
            string msg = "Message to out god.";
            string phoneNumber = "0542427799";
            var smsIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("Sms" + phoneNumber));
            smsIntent.PutExtra("msg", msg);
            StartActivity(smsIntent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
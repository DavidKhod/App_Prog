using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace implicit_intent
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button openWebsite, sendSMS, sendEmail, startVoiceCall, shareText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Init();
        }
        public void Init()
        {
            openWebsite = FindViewById<Button>(Resource.Id.openWebsite);
            openWebsite.Click += OpenWebsite_Click;
            sendSMS = FindViewById<Button>(Resource.Id.sendSMS);
            sendSMS.Click += SendSMS_Click;
            sendEmail = FindViewById<Button>(Resource.Id.sendEmail);
            sendEmail.Click += SendEmail_Click;
            startVoiceCall = FindViewById<Button>(Resource.Id.startVoiceCall);
            startVoiceCall.Click += StartVoiceCall_Click;
            shareText = FindViewById<Button>(Resource.Id.shareText);
            shareText.Click += ShareText_Click;
        }

        private void ShareText_Click(object sender, System.EventArgs e)
        {
            string textToShare = "aaaa";
            Intent shareIntent = new Intent(Intent.ActionSend);
            shareIntent.SetType("text/plain");
            shareIntent.PutExtra(Intent.ExtraText, textToShare);
            Intent chooserIntent = Intent.CreateChooser(shareIntent, "Choose application to share with");
            StartActivity(chooserIntent);
        }

        private void StartVoiceCall_Click(object sender, System.EventArgs e)
        {
            string phoneNumber = "0542427799";
            Intent dialIntent = new Intent(Intent.ActionDial);
            Uri uri = Uri.Parse("tel:" + phoneNumber);
            dialIntent.SetData(uri);
            StartActivity(dialIntent);
        }

        private void SendEmail_Click(object sender, System.EventArgs e)
        {
            string subject = "Hi";
            string recipient = "anonymous";
            string message = "hello";
            string action = Intent.ActionSendto;
            Uri data = Uri.Parse("mailto:");
            Intent emailIntent = new Intent();
            emailIntent.SetAction(action);
            emailIntent.SetData(data);
            emailIntent.PutExtra(Intent.ExtraEmail, new string[] { recipient });
            emailIntent.PutExtra(Intent.ExtraSubject, subject);
            emailIntent.PutExtra(Intent.ExtraText, message);
            StartActivity(emailIntent);
        }

        private void SendSMS_Click(object sender, System.EventArgs e)
        {
            string message = "Hello world";
            string phoneNumber = "0542427799";
            string action = Intent.ActionSendto;
            Uri data = Uri.Parse("smsto:" + phoneNumber);
            Intent intent = new Intent();
            intent.SetAction(action);
            intent.SetData(data);
            intent.PutExtra("sms_body", message);
            StartActivity(intent);
        }

        private void OpenWebsite_Click(object sender, System.EventArgs e)
        {
            string action = Intent.ActionView;
            var data = Uri.Parse("https://guthib.com/");
            Intent intent = new Intent();
            intent.SetAction(action);
            intent.SetData(data);
            StartActivity(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
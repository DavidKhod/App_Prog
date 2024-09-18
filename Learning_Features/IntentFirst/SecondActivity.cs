using Android.App;
using Android.OS;
using Android.Widget;
namespace IntentFirst
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        TextView greetingMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.second_activity);
            greetingMessage = FindViewById<TextView>(Resource.Id.greetingMessage);
            greetingMessage.Text += Intent.GetStringExtra("userName");
            greetingMessage.Text += "\nAge: " + Intent.GetStringExtra("age");
        }
    }
}
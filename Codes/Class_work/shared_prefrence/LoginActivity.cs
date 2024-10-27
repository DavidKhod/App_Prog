using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
namespace shared_prefrence
{
    [Activity(Label = "Shared_Prefrences", MainLauncher = true)]

    public class LoginActivity : Activity
    {
        public const string spKey = "userData";
        Button loginBtn, signUpBtn;
        string username, password;
        CheckBox saveData;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_login);
            Init();
        }

        public void Init()
        {
            signUpBtn = FindViewById<Button>(Resource.Id.signUp);
            loginBtn = FindViewById<Button>(Resource.Id.login);
            saveData = FindViewById<CheckBox>(Resource.Id.saveData);
            loginBtn.Click += LoginBtn_Click;
            signUpBtn.Click += SignUpBtn_Click;
        }

        private void LoginBtn_Click(object sender, System.EventArgs e)
        {
            username = FindViewById<EditText>(Resource.Id.username).Text;
            password = FindViewById<EditText>(Resource.Id.password).Text;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var sp = GetSharedPreferences(spKey, FileCreationMode.Private);
                if (username == sp.GetString("username", "None") && password == sp.GetString("password", "None"))
                {
                    var editor = sp.Edit();
                    editor.PutBoolean("saveDataChecked", saveData.Checked);
                    editor.Apply();
                    GoToNextPage();
                }
                else
                {
                    Toast.MakeText(this, "This account doesn't exist", ToastLength.Short).Show();
                    Toast.MakeText(this, "Please sign up first", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(this, "Please input your username and password", ToastLength.Short).Show();
            }
        }

        private void SignUpBtn_Click(object sender, System.EventArgs e)
        {
            username = FindViewById<EditText>(Resource.Id.username).Text;
            password = FindViewById<EditText>(Resource.Id.password).Text;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var sp = GetSharedPreferences(spKey, FileCreationMode.Private);
                if (username == sp.GetString("username", "None") && password == sp.GetString("password", "None"))
                {
                    Toast.MakeText(this, "This account already exists", ToastLength.Short).Show();
                }
                else
                {
                    var editor = sp.Edit();
                    editor.PutString("username", username);
                    editor.PutString("password", password);
                    editor.PutBoolean("saveDataChecked", saveData.Checked);
                    editor.Apply();
                    GoToNextPage();
                }
            }
            else
            {
                Toast.MakeText(this, "Please input your username and password", ToastLength.Short).Show();
            }
        }

        private void GoToNextPage()
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace dynamic_picture_adder
{
    [Activity(Label = "quizView")]
    public class quizView : Activity
    {
        static System.Random rnd = new System.Random();
        RadioGroup options;
        LinearLayout toShowLay;
        Button home, next;
        char currentImageType;
        bool currentAnswerIsRight = false;
        int rightAnswers, quizes = 0;
        TextView scoreBox;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.quiz_View);
            Init();
            ShowNextImage();
            rightAnswers = 0;
        }

        public void ShowNextImage()
        {
            toShowLay.RemoveAllViews();
            toShowLay.AddView(generateRandomPic());
        }

        public void Init()
        {
            options = FindViewById<RadioGroup>(Resource.Id.optionsRadGroup);
            home = FindViewById<Button>(Resource.Id.homePage);
            next = FindViewById<Button>(Resource.Id.next);
            toShowLay = FindViewById<LinearLayout>(Resource.Id.toShowLay);
            scoreBox = FindViewById<TextView>(Resource.Id.scoreBox);
            options.CheckedChange += Options_CheckedChange;
            next.Click += Next_Click;
            home.Click += Home_Click;
        }

        private void Home_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }


        private async void Next_Click(object sender, EventArgs e)
        {
            if (currentAnswerIsRight)
            {
                Toast.MakeText(this, "Right answer", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Wrong answer", ToastLength.Short).Show();
                string correctAnswer = "";
                switch (currentImageType)
                {
                    case 'c':
                        correctAnswer = "Clubs";
                        break;
                    case 'h':
                        correctAnswer = "Hearts";
                        break;
                    case 'd':
                        correctAnswer = "Dimonds";
                        break;
                    case 's':
                        correctAnswer = "Spades";
                        break;
                }
                Toast.MakeText(this, $"Correct answer was {correctAnswer}", ToastLength.Short).Show();
            }

            rightAnswers += currentAnswerIsRight ? 1 : 0;
            options.ClearCheck();
            currentAnswerIsRight = false;
            next.Clickable = false;
            quizes++;
            if (quizes < 10)
            {
                ShowNextImage();
            }
            else
            {
                toShowLay.RemoveAllViews();
                currentImageType = 'f';
                options.Enabled = false;
                next.Text = "Finished";
                scoreBox.Text = $"Your score: {rightAnswers}";
            }
        }

        private void Options_CheckedChange(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            //for (int i = 0; i < 4; i++)
            //{
            //    if (options.GetChildAt(i).Tag.ToString()[0] == currentImageType)//it looks very bad, but I am proud of this line
            //    {
            //        currentAnswerIsRight = true;
            //        break;
            //    }
            //}
            next.Clickable = true;
            switch (e.CheckedId)
            {
                case Resource.Id.spades:
                    currentAnswerIsRight = currentImageType == 's';
                    break;
                case Resource.Id.dimonds:
                    currentAnswerIsRight = currentImageType == 'd';
                    break;
                case Resource.Id.hearts:
                    currentAnswerIsRight = currentImageType == 'h';
                    break;
                case Resource.Id.clubs:
                    currentAnswerIsRight = currentImageType == 'c';
                    break;
                default:
                    currentAnswerIsRight = false;
                    break;
            }
        }

        public ImageView generateRandomPic()
        {
            const int FILL_PARENT = LinearLayout.LayoutParams.FillParent;
            const int MATCH_PARENT = LinearLayout.LayoutParams.MatchParent;
            var img = new ImageView(this);
            char[] types = { 's', 'c', 'h', 'd' };
            int id = rnd.Next(1, 14);
            char type = types[rnd.Next(0, types.Length)];
            currentImageType = type;
            img.SetImageResource(Resources.GetIdentifier($"img{id}{type}", "drawable", this.PackageName));
            img.LayoutParameters = new LinearLayout.LayoutParams(FILL_PARENT, MATCH_PARENT, 1);
            return img;
        }
    }
}
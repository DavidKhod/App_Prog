using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;

namespace polyApp.Classes
{
    internal class CardAdapter : BaseAdapter<GreetingCard>
    {
        private List<GreetingCard> _greetingCards;
        private readonly Context _context;

        public CardAdapter(Context context = null, List<GreetingCard> greetingCards = null)
        {
            _context = context == null ? Application.Context : context;
            _greetingCards = greetingCards == null ? GreetingCards.GetInstance().Filter<GreetingCard>() : greetingCards;
        }

        public override GreetingCard this[int position] => _greetingCards[position];
        public override int Count => _greetingCards.Count;
        public override long GetItemId(int position) => position;
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            GreetingCard greetingCard = _greetingCards[position];//greeting card picked
            convertView = convertView ?? LayoutInflater.From(_context).Inflate(Resource.Layout.item_draft, parent, false);
            var cardImage = convertView.FindViewById<ImageView>(Resource.Id.cardImageIV);
            //sender to recipient textview initialization
            var senderToRecipientTV = convertView.FindViewById<TextView>(Resource.Id.fromToDataTV);
            senderToRecipientTV.LayoutParameters = new LinearLayout.LayoutParams(650, -2);
            //greeting message textview initialization
            var greetingMessageTV = convertView.FindViewById<TextView>(Resource.Id.greetingMessageTV);
            greetingMessageTV.LayoutParameters = new LinearLayout.LayoutParams(650, -2);
            //initiating the button that shows the dialog
            var showBtn = convertView.FindViewById<TextView>(Resource.Id.showBtn);
            showBtn.Tag = position;
            showBtn.Click += ShowBtn_Click;
            cardImage.SetImageResource(greetingCard.imageViewID);//setting the dialog picture to the picture of the picked card type
            cardImage.LayoutParameters = new LinearLayout.LayoutParams(200, 200);
            senderToRecipientTV.Text = greetingCard.ToString();
            greetingMessageTV.Text = greetingCard.GreetingMsg();
            return convertView;
        }

        private void ShowBtn_Click(object sender, System.EventArgs e)
        {
            Button btn = (Button)sender;
            int tag = (int)btn.Tag;
            ImageView img;
            TextView greetingMessageTV;
            var dialog = new Dialog(_context);
            dialog.SetContentView(Resource.Layout.dialogPopUo_layout);
            img = dialog.FindViewById<ImageView>(Resource.Id.imgPopUp);
            img.SetImageResource(_greetingCards[tag].imageViewID);
            img.LayoutParameters = new FrameLayout.LayoutParams(-2, -2);
            greetingMessageTV = dialog.FindViewById<TextView>(Resource.Id.greetingMessage);
            greetingMessageTV.Text = _greetingCards[tag].GreetingMsg();//setting the dialog text to the card picked greeting message
            dialog.Show();
        }
    }
}
using Android.App;
using Android.Widget;

namespace polyApp.Classes
{
    public abstract class GreetingCard
    {
        public string recipient { get; protected set; }
        public string sender { get; protected set; }
        public int imageViewID { get; protected set; }
        public GreetingCard(string recipient, string sender)
        {
            this.recipient = recipient;
            this.sender = sender;
            this.imageViewID = Resource.Drawable.greetingCardBackground;
        }

        public ImageView GetImageView(Android.Content.Context context)
        {
            context = context ?? Application.Context;
            ImageView img = new ImageView(context);
            img.SetImageResource(imageViewID);
            img.LayoutParameters = new LinearLayout.LayoutParams(200, 200);
            return img;
        }

        public abstract string GreetingMsg();

        public override string ToString() => $"To: {recipient}, From: {sender}";
    }
}
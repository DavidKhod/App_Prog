namespace polyApp.Classes
{
    public class BirthdayCard : GreetingCard
    {
        public int age { get; private set; }

        public BirthdayCard(string recipient, string sender, int age) : base(recipient, sender)
        {
            this.age = age;
            this.imageViewID = Resource.Drawable.adultBirthdayCardBackground;
        }

        public override string GreetingMsg() => $"Happy {age}th birthday {recipient}";

        public override string ToString() => base.ToString() + $", Age: {age}";
    }
}
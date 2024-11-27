namespace polyApp.Classes
{
    public class YouthBirthdayCard : BirthdayCard
    {
        public YouthBirthdayCard(string recipient, string sender, int age) : base(recipient, sender, age) => this.imageViewID = Resource.Drawable.youthBirthdayCardBackground;
        public override string GreetingMsg() => $"Happy {age}th birthday my child";

    }
}
namespace polyApp.Classes
{
    public class AdultBirthdayCard : BirthdayCard
    {
        public AdultBirthdayCard(string recipient, string sender, int age) : base(recipient, sender, age) => imageViewID = Resource.Drawable.adultBirthdayCardBackground;
        public override string GreetingMsg() => $"Happy {age}th birthday you cunt";
    }
}
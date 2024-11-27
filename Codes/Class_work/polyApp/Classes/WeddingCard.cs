namespace polyApp.Classes
{
    public class WeddingCard : GreetingCard
    {
        public string groom { get; private set; }
        public string bride { get; private set; }

        public WeddingCard(string groom, string bride, string sender) : base($"{groom} and {bride}", sender)
        {
            this.groom = groom;
            this.bride = bride;
            this.imageViewID = Resource.Drawable.weddingCardBackground;
        }

        public override string GreetingMsg()
        {
            return $"Dear {groom} and {bride},\n\nWishing you a wonderful life filled with joy and happiness!\n\nBest regards,\n{sender}";
        }

        public override string ToString() => base.ToString() + $", Groom: {groom}, Bride: {bride}";
    }
}
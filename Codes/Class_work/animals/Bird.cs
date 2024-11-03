using System;

namespace animals
{
    public class Bird : Animal
    {
        public string colour { get; set; }
        public double currentFlightHeight { get; private set; }
        public readonly double maxFlightHeight;
        private static readonly Random _rnd = new Random();

        public Bird(string name, Gender gender, double energy, string colour, double maxFlightHeight) : base(name, gender, energy)
        {
            this.colour = colour;
            this.maxFlightHeight = maxFlightHeight;
        }
        public override string MakeSound() => "Chick Chirick motherfucker";
        public override string Move()
        {
            string rtn = $"Bird current height: {currentFlightHeight}\nBird flying...\n";
            Fly(_rnd.Next(1, (int)maxFlightHeight));
            return rtn + $"Bird current height: {currentFlightHeight}";
        }
        public virtual void Fly(double height) => currentFlightHeight = height > 0 && height <= maxFlightHeight ? height : currentFlightHeight;
    }
}
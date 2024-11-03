using System;

namespace animals
{
    public class Fish : Animal
    {
        public double depth { get; private set; }
        private static readonly Random rnd = new Random();
        public Fish(string name, Gender gender, double energy, double depth) : base(name, gender, energy) => this.depth = depth;
        public override string MakeSound() => "Making fish sound...";
        public override string Move()
        {
            string rtn = $"Fish current depth: {depth}";
            rtn += "Swimming...\n";
            swim();
            return rtn + $"Fish is now at depth: {depth}";
        }
        private void swim()
        {
            if (rnd.Next(0, 11) % 2 == 0)
                depth += rnd.Next(0, 101);
            else
                depth -= rnd.Next(0, (int)depth);
        }
    }
}
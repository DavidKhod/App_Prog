namespace Inheritence
{
    public enum Gender
    {
        Male, Female, Other
    }

    public class Animal
    {
        public string name { get; set; }
        public readonly Gender gender;
        public double energy { get => energy; set { energy = energy >= 0 ? value : energy; } }

        public Animal(string name, Gender gender, double energy)
        {
            this.name = name;
            this.gender = gender;
            this.energy = energy;
        }

        public Animal(Animal copy)
        {
            this.name = copy.name;
            this.gender = copy.gender;
            this.energy = copy.energy;
        }

        public virtual void MakeSound() => Console.WriteLine("Making animal sound...");

        public override string ToString()
        {
            string strGender = "";
            switch (this.gender)
            {
                case Gender.Male:
                    strGender = "Male";
                    break;

                case Gender.Female:
                    strGender = "Female";
                    break;
                default:
                    strGender = "Other";
                    break;

            }
            return $"Name: {name}, Gender: {strGender}, Energy: {energy}";
        }
    }

    public class Mammal : Animal
    {
        public int legCount { get; private set; }
        public int milk { get; set; }
        public const int CALC_IN_MILK = 500;

        public Mammal(Animal baseAnimal, int legCount, int milk) : base(baseAnimal)
        {
            this.milk = milk;
            this.legCount = legCount;
        }

        public void ChangeLegCount(int legCount) => this.legCount = legCount <= 4 && legCount >= 0 ? legCount : this.legCount;

        public bool NurseFrom(Mammal mom)
        {
            if (mom.gender == Gender.Female)
            {
                this.energy += mom.milk * CALC_IN_MILK;
                mom.energy -= mom.milk * CALC_IN_MILK;
                return true;
            }
            return false;
        }

        public bool NurseOther(Mammal baby)
        {
            if (this.gender == Gender.Female)
            {
                baby.energy += this.milk * CALC_IN_MILK;
                this.energy -= this.milk * CALC_IN_MILK;
                return true;
            }
            return false;
        }

        public override void MakeSound() => Console.WriteLine("Making mammal sound...");

        public override string ToString() => base.ToString() + $"Milk amount: {milk}, Leg count: {legCount}";
    }

    public class Bird : Animal
    {
        public string colour { get; set; }
        public double currentFlightHeight { get; private set; }
        public readonly double maxFlightHeight;

        public Bird(Animal baseAnimal, string colour, double maxFlightHeight) : base(baseAnimal)
        {
            this.colour = colour;
            this.maxFlightHeight = maxFlightHeight;
        }

        public override void MakeSound() => Console.WriteLine("Making bird sound...");

        public virtual void Fly(double height) => currentFlightHeight = height > 0 ? height : maxFlightHeight;
    }

    public class Fish : Animal
    {
        public double depth { get; private set; }
        private static readonly Random rnd = new Random();
        public Fish(Animal baseAnimal, double depth) : base(baseAnimal) => this.depth = depth;
        public void swim()
        {
            Console.WriteLine("Swimming...");
            if (rnd.Next(0, 11) % 2 == 0)
                depth += rnd.Next(0, 101);
            else
                depth -= rnd.Next(0, (int)depth);
            Console.WriteLine($"Fish is now at depth: {depth}");
        }
    }
}
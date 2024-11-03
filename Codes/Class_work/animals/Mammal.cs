namespace animals
{
    public class Mammal : Animal
    {
        public int legCount { get; private set; }
        public double milk { get; set; }
        public const int CALC_IN_MILK = 1;
        private readonly double milkAtStart;

        public Mammal(string name, Gender gender, double energy, int legCount, int milk) : base(name, gender, energy)
        {
            this.legCount = legCount;
            this.milk = milk;
            milkAtStart = milk;
        }

        public Mammal(Animal baseAnimal, int legCount, int milk) : base(baseAnimal)
        {
            this.milk = milk;
            this.legCount = legCount;
        }

        public Mammal(Animal baseAnimal, Mammal copy) : base(baseAnimal)
        {
            this.legCount = copy.legCount;
            this.milk = copy.milk;
            milkAtStart = copy.milk;
        }

        public void ChangeLegCount(int legCount) => this.legCount = legCount <= 4 && legCount >= 0 ? legCount : this.legCount;

        public bool NurseFrom(Mammal mom, double amountToNurse)
        {
            if (mom.gender == Gender.Female)
            {
                this.Energy += (mom.milkAtStart * (amountToNurse / 100)) * CALC_IN_MILK;
                mom.Energy -= (mom.milkAtStart * (amountToNurse / 100)) * CALC_IN_MILK;
                mom.milk -= (mom.milkAtStart * (amountToNurse / 100));
                return true;
            }
            return false;//If the mammal that was asked to be nursed from is not a female
        }

        public bool NurseOther(Mammal baby, double amountToNurse)
        {
            if (this.gender == Gender.Female)
            {
                baby.Energy += (this.milkAtStart * (amountToNurse / 100)) * CALC_IN_MILK;
                this.Energy -= (this.milkAtStart * (amountToNurse / 100)) * CALC_IN_MILK;
                this.milk -= (this.milkAtStart * (amountToNurse / 100));
                return true;
            }
            return false;//If the mammal that was asked to be nursed from is not a female
        }

        public override string MakeSound() => "Making mammal sound...";
        public override string Move() => "I am walking...";
        public override string ToString() => base.ToString() + $"Milk amount: {milk}, Leg count: {legCount}";
    }
}
namespace animals
{
    public class Dog : Mammal
    {
        public readonly string breed;
        public Dog(Mammal baseMammal, string breed) : base((Animal)baseMammal, baseMammal) => this.breed = breed;
        public Dog(string name, Gender gender, double energy, int legCount, int milk, string breed) : base(name, gender, energy, legCount, milk) => this.breed = breed;
        public override string Move() => "I am running";
        public override string MakeSound() => "Woof woof!";
        public override string ToString()
        {
            return base.ToString() + $",Breed: {this.breed}";
        }
    }
}
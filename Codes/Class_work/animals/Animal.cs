namespace animals
{
    public enum Gender
    {
        Male, Female, Other
    }
    public class Animal
    {
        public string name { get; set; }
        public readonly Gender gender;
        private double energy;

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

        public double Energy
        {
            get { return this.energy; }
            protected set
            {
                this.energy = value >= 0 ? value : this.energy;
            }
        }

        public virtual string MakeSound() => "Making animal sound...";
        public virtual string Move() => "I am moving...";
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
            return $"Name: {name},Gender: {strGender},Energy: {energy}";
        }
    }
}
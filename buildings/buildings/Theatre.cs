using System;

namespace buildings
{
    public class Theatre : PublicBuilding
    {

        public String Name { get; }
        public String Grade { get; }

        public Theatre(
            int cost,
            int level, 
            double strength,
            Location location,
            string address,
            string fiasId, 
            string name, 
            string grade
            ) : base(cost, level, strength, location, address, fiasId)
        {
            Name = name;
            Grade = grade;
        }

        public override string Visit()
        {
            return "Theature visited";
        }
        
        public string GetAdds()
        {
            return "Visit teature";
        }    
        
        public string Entertain()
        {
            return "Theature intertaining";
        }

        public override string ToString()
        {
            return $"Name: {Name}, Grade: {Grade}, {base.ToString()}";
        }
    }
}
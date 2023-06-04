using System;

namespace buildings
{
    public class Theatre : PublicBuilding
    {
        public String Name { get; }
        public String Grade { get; }


        public Theatre() : this(
            100,
            1,
            0.7,
            new Location(10, 20),
            "St. Anton,2",
            "adsfsdf-ds-fsd-fds-fd-f",
            "Greate teaater",
            "the biggest"
        )
        {
        }

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
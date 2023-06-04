namespace buildings
{
    public class Cafe : PublicBuilding
    {
        public int Capacity { get; }

        public int MishlenStar { get; }


        public Cafe() : this(
            100,
            1,
            0.7,
            new Location(10, 20),
            "St. Anton,4",
            "adsfsdf-ds-fsd-fds-fd-f",
            50,
            3
        )
        {
        }


        public Cafe(
            int cost,
            int level,
            double strength,
            Location location,
            string address,
            string fiasId,
            int capacity,
            int mishlenStar
        ) : base(cost, level, strength, location, address, fiasId)
        {
            Capacity = capacity;
            MishlenStar = mishlenStar;
        }

        public override string Visit()
        {
            return $"Super cafe with {MishlenStar} mishlen star visited";
        }

        public string Rate(int rating)
        {
            return rating > MishlenStar ? "You are fool? We are the champions" : "God bless you! We are so happy";
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Capacity: {Capacity}, MishlenStar: {MishlenStar}";
        }
    }
}
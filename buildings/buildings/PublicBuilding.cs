using System;

namespace buildings
{
    public abstract class PublicBuilding : IBuilding
    {
        protected PublicBuilding(
            int cost,
            int level,
            double strength,
            Location location,
            string address,
            string fiasId
        )
        {
            Cost = cost;
            Level = level;
            Strength = strength;
            Location = location;
            Address = address;
            FiasId = fiasId;
        }

        public double Cost { get; }
        public int Level { get; set; }
        public double Strength { get; set; }
        public Location Location { get; }
        public string Address { get; }
        public string FiasId { get; }


        public void Repair(double money)
        {
            if (money < Cost * 0.7)
            {
                throw new AggregateException("Not enouth money");
            }

            Strength = 1.0;
        }

        public void Upgrade(double money)
        {
            if (money < Cost * 2)
            {
                throw new AggregateException("Not enouth money");
            }

            Level += (int) (money / (Cost * 2));
        }


        public abstract String Visit();


        public override string ToString()
        {
            return $"Cost: {Cost}, Level: {Level}, Strength: {Strength}, Location: {Location}, Address: {Address}, FiasId: {FiasId}";
        }
    }
}
namespace buildings
{
    public interface IBuilding
    {
        double Cost { get; }
        int Level { get; set; }

        double Strength { get; set; }
        Location Location { get; }

        void Repair(double money);

        void Upgrade(double money);
    }
}
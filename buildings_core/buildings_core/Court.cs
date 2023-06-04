using System;

namespace buildings
{
    public class Court : PublicBuilding
    {
        public double Luck
        {
            get => _innocent / _sentences;
        }

        public string JudgeName { get; }


        public Court() : this(
            100,
            1,
            0.7,
            new Location(10, 20),
            "St. Anton,3",
            "adsfsdf-ds-fsd-fds-fdsdsada-f",
            "Mr propper"
        )
        {
        }
        public Court(int cost, int level, double strength, Location location, string address, string fiasId,
            string judgeName) : base(cost, level, strength, location, address, fiasId)
        {
            JudgeName = judgeName;
            _innocent = 0;
            _sentences = 0;
        }

        private double _innocent;
        private double _sentences;

        public override string Visit()
        {
            return "All animals are equal, but some animals are more equal than others. Court visited";
        }


        public string Judge(string humanName)
        {
            _sentences++;
            var random = new Random();
            if (random.NextDouble() > 0.7)
            {
                return "Themis is not favorable, the head off the shoulders!";
            }

            _innocent++;
            return "You are innocent";
        }

        public string Pray(string humanName)
        {
            return "Are you serious? Its court mother fucker";
        }
    }
}
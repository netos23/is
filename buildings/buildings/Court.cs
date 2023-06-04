using System;

namespace buildings
{
    public class Court : PublicBuilding
    {
        public double Luck
        {
            get => _innocent / _sentences;
        }

        public double JudgeName { get; }

        public Court(int cost, int level, double strength, Location location, string address, string fiasId,
            double judgeName) : base(cost, level, strength, location, address, fiasId)
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
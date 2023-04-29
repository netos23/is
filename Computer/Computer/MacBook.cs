namespace Computer
{
    public class MacBook
    {
        private readonly string _processorName;
        private readonly double _frequency;
        private readonly int _ramSize;

        public MacBook(string processorName, double frequency, int ramSize)
        {
            _processorName = processorName;
            _frequency = frequency;
            _ramSize = ramSize;
        }

        public string ProcessorName => _processorName;

        public double Frequency => _frequency;

        public int RamSize => _ramSize;

        public virtual double GetQuality()
        {
            return 0.1 * _frequency + _ramSize;
        }

        public override string ToString()
        {
            return $"Macbook = Q:{GetQuality()}, ProcessorName: {ProcessorName}, " +
                   $"Frequency: {Frequency}, RamSize: {RamSize}";
        }
    }
}
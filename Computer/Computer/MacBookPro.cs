namespace Computer
{
    public class MacBookPro : MacBook
    {
        public MacBookPro(string processorName, double frequency, int ramSize, int romSize)
            : base(processorName, frequency, ramSize)
        {
            RomSize = romSize;
        }

        public override double GetQuality()
        {
            return base.GetQuality() + 0.5 * RomSize;
        }

        public int RomSize { get; }

        public override string ToString()
        {
            return $"Pro: {base.ToString()}, RomSize: {RomSize}";
        }
    }
}
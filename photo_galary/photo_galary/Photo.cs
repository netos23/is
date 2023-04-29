namespace photo_galary
{
    public enum PaperType
    {
        Glossy,
        Matte,
    }

    public class Photo
    {
        private byte[] _data;
        private double _quality;
        private double _width;
        private double _height;
        private PaperType _type;


        public string Name { get; set; }

        public byte[] Data => _data;

        public double Width => _width;

        public double Height => _height;

        public PaperType Type => _type;


        private Photo()
        {
        }

        public class PhotoBuilder
        {
            private readonly Photo _instance;

            public PhotoBuilder()
            {
                _instance = new Photo();
            }

            public PhotoBuilder SetName(string name)
            {
                _instance.Name = name;
                return this;
            }

            public PhotoBuilder SetWidth(double width)
            {
                _instance._width = width;
                return this;
            }

            public PhotoBuilder SetHeight(double height)
            {
                _instance._height = height;
                return this;
            }

            public PhotoBuilder SetType(PaperType paper)
            {
                _instance._type = paper;
                return this;
            }

            public PhotoBuilder SetQuality(double quality)
            {
                _instance._quality = quality;
                return this;
            }

            public PhotoBuilder SetData(byte[] data)
            {
                _instance._data = data;
                return this;
            }

            public Photo Build()
            {
                return _instance;
            }
        }
    }
}
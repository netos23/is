using System;
using System.Collections;
using System.Collections.Generic;

namespace photo_galary
{
    public class PageConfiguration
    {
        private readonly double _pictureWidth;
        private readonly double _pictureHeight;
        private readonly int _pictureRowLenght;
        private readonly int _pictureColumnLength;

        public double PictureWidth => _pictureWidth;

        public double PictureHeight => _pictureHeight;

        public int PictureRowLenght => _pictureRowLenght;

        public int PictureColumnLength => _pictureColumnLength;

        public PageConfiguration(
            double pictureWidth,
            double pictureHeight,
            int pictureRowLenght,
            int pictureColumnLength
        )
        {
            _pictureWidth = pictureWidth;
            _pictureHeight = pictureHeight;
            _pictureRowLenght = pictureRowLenght;
            _pictureColumnLength = pictureColumnLength;
        }
    }

    public class Page : IEnumerable<Photo>
    {
        private readonly Photo[][] _layout;
        private int _pictureCount;

        public double PictureWidth { get; }

        public double PictureHeight { get; }

        public int PictureRowLenght { get; }

        public int PictureColumnLength { get; }

        public Page(PageConfiguration configuration) : this(
            configuration.PictureWidth,
            configuration.PictureHeight,
            configuration.PictureRowLenght,
            configuration.PictureColumnLength
        )
        {
        }

        public Page(
            double pictureWidth,
            double pictureHeight,
            int pictureRowLenght,
            int pictureColumnLength
        )
        {
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            PictureRowLenght = pictureRowLenght;
            PictureColumnLength = pictureColumnLength;

            _layout = new Photo[pictureRowLenght][];
            for (var r = 0; r < _layout.Length; r++)
            {
                _layout[r] = new Photo[pictureColumnLength];
            }

            _pictureCount = 0;
        }


        public PagePictureRow this[int index]
        {
            get => new PagePictureRow(this, index);
        }

        public int PictureCount
        {
            get => _pictureCount;
        }

        public Photo removePicture(int r, int c)
        {
            var picture = _layout[r][c];
            _layout[r][c] = null;
            _pictureCount--;

            return picture;
        }

        public bool HasPhotoSupport(Photo value)
        {
            return value.Height <= PictureHeight || value.Width <= PictureWidth;
        }


        public class PagePictureRow
        {
            private readonly Page _page;
            private readonly int _row;

            protected internal PagePictureRow(Page page, int row)
            {
                _page = page;
                _row = row;
            }

            public Photo this[int index]
            {
                get => _page._layout[_row][index];
                set
                {
                    if (!_page.HasPhotoSupport(value))
                    {
                        throw new ArgumentException("Picture too big");
                    }

                    _page._pictureCount++;
                    _page._layout[_row][index] = value;
                }
            }
        }

        public IEnumerator<Photo> GetEnumerator()
        {
            return new PageEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        class PageEnumerator : IEnumerator<Photo>
        {
            private int _index;
            private readonly Page _page;
            private readonly int _length;

            public PageEnumerator(Page page)
            {
                _page = page;
                _index = 0;
                _length = _page.PictureRowLenght * _page.PictureColumnLength;
            }


            public bool MoveNext()
            {
                while (++_index < _length && Current == null)
                {
                }

                return _index < _length;
            }

            public void Reset()
            {
                _index = 0;
            }

            public Photo Current => _page[_index / _page.PictureColumnLength][_index % _page.PictureColumnLength];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}
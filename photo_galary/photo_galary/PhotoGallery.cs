using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace photo_galary
{
    public class PhotoGallery : IEnumerable
    {
        private readonly Page[] _pages;

        public PageConfiguration PageConfiguration { get; }

        public PhotoGallery(int length, PageConfiguration pageConfiguration)
        {
            PageConfiguration = pageConfiguration;
            _pages = new Page[length];
            for (var i = 0; i < length; i++)
            {
                _pages[i] = new Page(PageConfiguration);
            }
        }

        public int GetPictureCount()
        {
            return _pages.Sum(page => page.PictureCount);
        }

        public Page this[int index] => _pages[index];


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _pages.GetEnumerator();
        }
    }
}
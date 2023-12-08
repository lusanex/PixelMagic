using PixelMagic.utility;
using System;

namespace PixelMagic
{
    public class ImageProcessor
    {
        public Bitmap OriginalBitmap { get; private set; }
        public  Bitmap FilteredBitmap { get; private set; }

        public ImageProcessor(string inputFilePath)
        {
            OriginalBitmap = new Bitmap(inputFilePath);
        }

        public void ApplyFilter(string filterType)
        {
            switch (filterType.ToLower())
            {
                case "--sepia":
                    SepiaToneFilter sepiaFilter = new SepiaToneFilter();
                    FilteredBitmap = sepiaFilter.Apply(OriginalBitmap);
                    break;

                case "--blackandwhite":
                    BlackAndWhiteFilter bwFilter = new BlackAndWhiteFilter();
                    FilteredBitmap = bwFilter.Apply(OriginalBitmap);
                    break;

                case "--invert":
                    InvertColorsFilter invertFilter = new InvertColorsFilter();
                    FilteredBitmap = invertFilter.Apply(OriginalBitmap);
                    break;

                default:
                    Console.WriteLine("Invalid filter type. Available options are --sepia, --blackandwhite, --invert.");
                    FilteredBitmap = OriginalBitmap;
                    break;
            }
        }

        public void SaveFilteredBitmap(string outputFilePath)
        {
            FilteredBitmap.Save(outputFilePath);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.utility
{
    // The BlackAndWhiteFilter class inherits from the Filter class.
    public class BlackAndWhiteFilter : Filter
    {
        // Implement the Apply method to convert the image to black and white.
        public override Bitmap Apply(Bitmap originalBitmap)
        {
            Bitmap bwBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    Color originalColor = originalBitmap.GetPixel(x, y);

                    int grayScale = (int)((originalColor.R * 0.3) + (originalColor.G * 0.59) + (originalColor.B * 0.11));

                    Color bwColor = Color.FromArgb(grayScale, grayScale, grayScale);

                    bwBitmap.SetPixel(x, y, bwColor);
                }
            }

            return bwBitmap;
        }
    }
}

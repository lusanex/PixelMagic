using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.utility
{
    public class InvertColorsFilter : Filter
    {
        public override Bitmap Apply(Bitmap originalBitmap)
        {
            Bitmap invertedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    Color originalColor = originalBitmap.GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    invertedBitmap.SetPixel(x, y, invertedColor);
                }
            }

            return invertedBitmap;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.utility
{
     public class SepiaToneFilter : Filter
    {
        public override Bitmap Apply(Bitmap originalBitmap)
        {
            Bitmap sepiaBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    Color originalColor = originalBitmap.GetPixel(x, y);
                    int red = (int)(originalColor.R * 0.393 + originalColor.G * 0.769 + originalColor.B * 0.189);
                    int green = (int)(originalColor.R * 0.349 + originalColor.G * 0.686 + originalColor.B * 0.168);
                    int blue = (int)(originalColor.R * 0.272 + originalColor.G * 0.534 + originalColor.B * 0.131);

                    // Clamping the RGB values to 255
                    red = red > 255 ? 255 : red;
                    green = green > 255 ? 255 : green;
                    blue = blue > 255 ? 255 : blue;

                    Color sepiaColor = Color.FromArgb(red, green, blue);
                    sepiaBitmap.SetPixel(x, y, sepiaColor);
                }
            }

            return sepiaBitmap;
        }
    }
}

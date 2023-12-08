using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.utility
{
    public abstract class Filter
    {
        // The Apply method will be implemented by derived classes to apply specific filters.
        // It takes a Bitmap object and returns a new Bitmap with the filter applied.
        public abstract Bitmap Apply(Bitmap originalBitmap);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.tests
{
    static class TestRunner
    {
        private static BitmapTests tests = new BitmapTests();

        public static void Run()
        {
            tests.TestBitmap();
            tests.TestBlackAndWhiteFilter();
            tests.TestInvertColorsFilter();
            tests.TestSepiaToneFilter();
        }
    }
}

using PixelMagic.utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.tests
{
    public class BitmapTests
    {
        private static string filePath = "resources\\penguin_jump01.bmp";
        private static string outFilePath = "resources\\out_penguin.bmp";
        public void TestBlackAndWhiteFilter()
        {


            try
            {

                // Step 1: Create an instance of the Bitmap class
                Bitmap originalBitmap = new Bitmap(filePath);

                // Step 2: Instantiate the BlackAndWhiteFilter class
                BlackAndWhiteFilter bwFilter = new BlackAndWhiteFilter();

                // Step 3: Apply the black and white filter
                Bitmap bwBitmap = bwFilter.Apply(originalBitmap);

                // Step 4: Save the resulting image
                bwBitmap.Save(outFilePath);

                Console.WriteLine("Black and white filter applied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        public void TestBitmap()
        {
            string testOutputFilePath = "resources\\testing_bitmap_class.bmp";

            try
            {
                // Load the bitmap
                Bitmap testBitmap = new Bitmap(filePath);

                // Perform test operations
                // Example: Get and Set a pixel
                Color originalColor = testBitmap.GetPixel(0, 0);
                testBitmap.SetPixel(0, 0, Color.FromArgb(255, 0, 0, 0)); // Set to black

                // Save the modified bitmap
                bool saveResult = testBitmap.Save(testOutputFilePath);

                // Assert conditions to check if the test passed
                if (saveResult && File.Exists(testOutputFilePath))
                {
                    Console.WriteLine("TestBitmap: Passed");
                }
                else
                {
                    Console.WriteLine("TestBitmap: Failed");
                }

                // Optionally, clean up test output file
                //File.Delete(testOutputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("TestBitmapFunctionality: Failed with exception - " + ex.Message);
            }
        }

        public void TestInvertColorsFilter()
        {
            string outputFilePath = "resources\\inverted_image.bmp";

            try
            {
                Bitmap originalBitmap = new Bitmap(filePath);
                InvertColorsFilter invertFilter = new InvertColorsFilter();
                Bitmap invertedBitmap = invertFilter.Apply(originalBitmap);
                bool saveResult = invertedBitmap.Save(outputFilePath);

                if (saveResult && File.Exists(outputFilePath))
                {
                    Console.WriteLine("TestInvertColorsFilter: Passed");
                }
                else
                {
                    Console.WriteLine("TestInvertColorsFilter: Failed");
                }

                //File.Delete(outputFilePath); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("TestInvertColorsFilter: Failed with exception - " + ex.Message);
            }
        }

        public void TestSepiaToneFilter()
        {
            
            string outputFilePath = "resources\\sepia_image.bmp";

            try
            {
                Bitmap originalBitmap = new Bitmap(filePath);
                SepiaToneFilter sepiaFilter = new SepiaToneFilter();
                Bitmap sepiaBitmap = sepiaFilter.Apply(originalBitmap);
                bool saveResult = sepiaBitmap.Save(outputFilePath);

                if (saveResult && File.Exists(outputFilePath))
                {
                    Console.WriteLine("TestSepiaToneFilter: Passed");
                }
                else
                {
                    Console.WriteLine("TestSepiaToneFilter: Failed");
                }

                //File.Delete(outputFilePath); // Optional: Cleanup
            }
            catch (Exception ex)
            {
                Console.WriteLine("TestSepiaToneFilter: Failed with exception - " + ex.Message);
            }
        }
    }
}




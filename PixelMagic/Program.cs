namespace PixelMagic
{
    class Program
    {
        static void DisplayHelpMessage()
        {
            Console.WriteLine("Usage: PixelMagic [filterType] [inputFilePath] [outputFilePath]");
            Console.WriteLine("Apply a filter to an image and save the result to a specified file.");
            Console.WriteLine();
            Console.WriteLine("Arguments:");
            Console.WriteLine("  filterType      The type of filter to apply. Options are:");
            Console.WriteLine("                    --sepia         Apply a sepia tone filter.");
            Console.WriteLine("                    --blackandwhite Convert the image to black and white.");
            Console.WriteLine("                    --invert        Invert the colors of the image.");
            Console.WriteLine("  inputFilePath   The path to the input image file (in .bmp format).");
            Console.WriteLine("  outputFilePath  The path where the filtered image will be saved (in .bmp format).");
            Console.WriteLine();
            Console.WriteLine("Example:");
            Console.WriteLine("  PixelMagic --sepia input.bmp output.bmp");
            Console.WriteLine("  This will apply a sepia tone filter to 'input.bmp' and save the result to 'output.bmp'.");
        }
    
    static void Main(string[] args)
        {
#if DEBUG
            // Run tests
            PixelMagic.tests.TestRunner.Run();

#else // Default values
            string filterType = "--sepia"; // Default filter
            string inputFilePath = "resources\\penguin_jump01.bmp"; 
            string outputFilePath = "resources\\default_output.bmp"; 

            // If no arguments, use default values; if incorrect number of arguments, display help
            if (args.Length == 0)
            {
                //Console.WriteLine("No arguments provided. Using default values.");
            }
            else if (args.Length != 3)
            {
                DisplayHelpMessage();
                return;
            }
            else 
            {
                filterType = args[0];
                inputFilePath = args[1];
                outputFilePath = args[2];
            }

            try
            {
                ImageProcessor processor = new ImageProcessor(inputFilePath);
                processor.ApplyFilter(filterType);
                processor.SaveFilteredBitmap(outputFilePath);
                string fullOutputPath = Path.GetFullPath(outputFilePath);

                Console.WriteLine($"Filtered image saved to {fullOutputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

#endif
        }
    }
}
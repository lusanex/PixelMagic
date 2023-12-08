using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelMagic.utility
{
    public class Bitmap
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Color[,]? Pixels { get; private set; }

        public Bitmap(string filePath)
        {
            ReadBitmap(filePath);
        }
        // Constructor to create an empty bitmap with specified width and height.
        public Bitmap(int width, int height)
        {
            Width = width;
            Height = height;

            // Initialize the Pixels array.
            Pixels = new Color[Width, Height];

            // Set all pixels to a default state (e.g., fully transparent).
            Color defaultColor = Color.FromArgb(0, 0, 0, 0); // ARGB for fully transparent
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixels[x, y] = defaultColor;
                }
            }
        }


        private void ReadBitmap(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (BinaryReader br = new BinaryReader(fs))
            {
                // Read the BMP header
                br.ReadBytes(2);  // Type
                br.ReadBytes(4);  // Size
                br.ReadBytes(4);  // Reserved
                int offset = BitConverter.ToInt32(br.ReadBytes(4), 0);  // Offset to start of image data

                // Read the DIB header
                int headerSize = BitConverter.ToInt32(br.ReadBytes(4), 0);
                Width = BitConverter.ToInt32(br.ReadBytes(4), 0);
                Height = BitConverter.ToInt32(br.ReadBytes(4), 0);
                br.ReadBytes(2);  // Color planes
                int bitsPerPixel = BitConverter.ToInt16(br.ReadBytes(2), 0);
                br.ReadBytes(headerSize - 16);  // Skip the rest of the header

                // Initialize the Pixels array
                Pixels = new Color[Width, Height];

                // Read the pixel data
                fs.Seek(offset, SeekOrigin.Begin);
                int bytesPerPixel = bitsPerPixel / 8;
                int padding = (4 - (Width * bytesPerPixel) % 4) % 4;
                for (int y = Height - 1; y >= 0; y--)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        byte[] colorBytes = br.ReadBytes(bytesPerPixel);
                        Color color = bytesPerPixel == 3 ? Color.FromArgb(colorBytes[2], colorBytes[1], colorBytes[0])
                                                         : Color.FromArgb(colorBytes[3], colorBytes[2], colorBytes[1], colorBytes[0]);
                        Pixels[x, y] = color;
                    }
                    br.ReadBytes(padding);  // Skip padding
                }
            }
        }
        public Color GetPixel(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException("Pixel are out of bounds");
            }
            return Pixels[x, y];
        }

        // Method to set the color of a specific pixel
        public void SetPixel(int x, int y, Color color)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException("Pixel are out of bounds");
            }
            Pixels[x, y] = color;
        }
        public bool Save(string outputFilePath)
        {
            try
            {
                using (FileStream fs = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    int bytesPerPixel = 4;
                    int padding = (4 - (Width * bytesPerPixel) % 4) % 4;
                    int fileSize = 54 + (Width * bytesPerPixel + padding) * Height;

                    // Writing the BMP header
                    bw.Write(new char[] { 'B', 'M' }); // BM signature
                    bw.Write(fileSize); // File size
                    bw.Write((int)0); // Unused
                    bw.Write((int)54); // Offset to start of pixel data

                    // Writing the DIB header
                    bw.Write((int)40); // Header size
                    bw.Write(Width); // Image width
                    bw.Write(Height); // Image height
                    bw.Write((short)1); // Color planes
                    bw.Write((short)(bytesPerPixel * 8)); // Bits per pixel
                    bw.Write((int)0); // No compression
                    bw.Write((int)(Width * Height * bytesPerPixel)); // Image size
                    bw.Write((int)0); // Horizontal resolution
                    bw.Write((int)0); // Vertical resolution
                    bw.Write((int)0); // Colors in color table
                    bw.Write((int)0); // Important color count

                    // Writing the pixel data
                    for (int y = Height - 1; y >= 0; y--)
                    {
                        for (int x = 0; x < Width; x++)
                        {
                            Color color = Pixels[x, y];
                            bw.Write(color.B);
                            bw.Write(color.G);
                            bw.Write(color.R);
                            bw.Write(color.A); // Writing the alpha value
                        }
                        bw.Write(new byte[padding]); // Write padding
                    }
                }

                // If everything goes well, return true
                return true;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during saving
                Console.WriteLine($"Error saving file: {ex.Message}");
                return false;
            }
        }
    }
}




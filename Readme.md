# PixelMagic - Image Processing Tool

## Overview
PixelMagic is a command-line tool for applying various filters to bitmap images.PixelMagic allows users to transform bitmap images with different artistic filters such as sepia tone, black and white, and color inversion.

## Features
- **Multiple Filters**: Apply different filters including sepia, black and white, and color inversion.
- **Command-Line Interface**: Easy-to-use command-line interface for quick operations.
- **Custom Input and Output**: Specify your own input and output file paths for flexibility.
- **Extensible Design**: Inherintace, the program modular design makes it easy to add new filters.

## Getting Started
### Prerequisites
- .NET Framework or .NET Core installed on your machine.

### Installation
- Clone the repository to your local machine.
- Build the solution using Visual Studio 
- Run Debug mode to run the test.
- Run Realese to run the actuall program.

## Topics Checklist
PixelMagic utilizes core programming concepts and features, ensuring a straightforward and educational codebase:
- **Branching**: For loop.
- **Switch Statements**.
- **Classes**: Objects, Constructors.
- **Inheritance**.
- **Array**.
- **Text File I/O**: Reading and writing image data using a basic `Bitmap` class.
- **Formatted Output**.

## Key Functionalities and High-Level Pseudocode
### Loading the Bitmap
The application starts by loading a bitmap image from a given file path. Here's a high-level overview of how it works in pseudocode:

```
FUNCTION ReadBitmap(filePath):
OPEN file at filePath
READ file header to determine the starting point of pixel data
INITIALIZE a 2D array 'Pixels' to store the color of each pixel
FOR each pixel in the image:
READ the color data from the file starting at the pixel data offset
STORE the color data in the corresponding position in 'Pixels'
CLOSE file
END FUNCTION
```
This pseudocode represents the following steps:
- The function `ReadBitmap` opens the specified bitmap file.
- It reads the file's header to find out where the pixel data starts. Bitmap files have a specific format where the pixel data is often preceded by metadata.
- A 2D array, `Pixels`, is initialized. Its dimensions match the width and height of the image.
- The function then loops through each pixel in the image. For each pixel, it reads the color data (like RGBA values) from the file.
- This color data is stored in the `Pixels` array at the appropriate position, corresponding to each pixel's location in the image.
- Finally, after all pixel data is read and stored, the file is closed.

This process ensures that the bitmap image is loaded into an array, with each element representing the color of a single pixel, allowing for easy manipulation later in the application.

## Applying a Filter
Once the bitmap is loaded, PixelMagic applies the chosen filter. Here's a simplified view of how a filter is applied:
```
public Bitmap ApplyFilter(Bitmap originalBitmap)
{
    // Example: Applying the Black and White Filter
    for each pixel in originalBitmap {
        calculate grayscale value;
        set new pixel color to grayscale;
    }
    return modifiedBitmap;
}
```
### Usage
Run PixelMagic from the command line with the following format:
#### Available Filter Types
- `--sepia`: Applies a sepia tone filter
- `--blackandwhite`: Converts the image to black and white
- `--invert`: Inverts the colors of the image

```
PixelMagic [filterType] [inputFilePath] [outputFilePath]
```
## Showcase of Image Filters
### Original file:
![original file](PixelMagic/resources/penguin_jump01.bmp)
## Filters:
![Black and White Filter](PixelMagic/resources/blackAndWhiteFilter.bmp)
![Inverted Filter](PixelMagic/resources/inverted_image.bmp)
![Sepia Filter](PixelMagic/resources/sepia_image.bmp)

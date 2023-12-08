# PixelMagic - Image Processing Tool

## Overview
PixelMagic is a command-line tool for applying various filters to bitmap images. Designed with simplicity and ease of use in mind, PixelMagic allows users to transform their images with different artistic filters such as sepia tone, black and white, and color inversion.

## Features
- **Multiple Filters**: Apply different filters including sepia, black and white, and color inversion.
- **Command-Line Interface**: Easy-to-use command-line interface for quick operations.
- **Custom Input and Output**: Specify your own input and output file paths for flexibility.
- **Extensible Design**: Built in C#, the tool's modular design makes it easy to add new filters.

## Getting Started
### Prerequisites
- .NET Framework or .NET Core installed on your machine.

### Installation
- Clone the repository to your local machine.
- Build the solution using Visual Studio 

## Topics Checklist
PixelMagic utilizes core programming concepts and features, ensuring a straightforward and educational codebase:
- **Branching**: For loop.
- **Switch Statements**.
- **Classes**: Objects, Constructors.
- **Inheritance**.
- **Array**.
- **Text File I/O**: Reading and writing image data using a basic `Bitmap` class.
- **Formatted Output**.
- 
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

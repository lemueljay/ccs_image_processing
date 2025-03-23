using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_processing
{
    public static class BasicDIP
    {
        public static Bitmap PixelCopy(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color pixel = input.GetPixel(x, y);
                    output.SetPixel(x, y, pixel);
                }
            }
            return output;
        }

        public static Bitmap Greyscale(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color pixel = input.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    output.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }
            return output;
        }

        public static Bitmap Invert(Bitmap input)
        {
            Bitmap output = new Bitmap(input.Width, input.Height);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color pixel = input.GetPixel(x, y);
                    output.SetPixel(x, y, Color.FromArgb(255 - pixel.R, 255 - pixel.G, 255 - pixel.B));
                }
            }
            return output;
        }

        public static Bitmap Histogram(Bitmap input)
        {
            int width = input.Width;
            int height = input.Height;
            int[] histdata = new int[256];

            // Compute histogram data from a greyscale conversion.
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color sample = input.GetPixel(x, y);
                    byte grey = (byte)((sample.R + sample.G + sample.B) / 3);
                    histdata[grey]++;
                }
            }
            Bitmap histBitmap = new Bitmap(256, 800);
            for (int x = 0; x < 256; x++)
            {
                for (int y = 0; y < 800; y++)
                {
                    histBitmap.SetPixel(x, y, Color.White);
                }
            }
            // Plot histogram based on histdata
            for (int x = 0; x < 256; x++)
            {
                int barHeight = Math.Min(histdata[x] / 5, histBitmap.Height - 1);
                for (int y = 0; y < barHeight; y++)
                {
                    histBitmap.SetPixel(x, histBitmap.Height - 1 - y, Color.Black);
                }
            }

            return histBitmap;
        }

        public static Bitmap Sepia(Bitmap input)
        {
            // Steps to convert to sepia (based on internet):
            // 1. Apply the sepia formula to each pixel
            // newR = 0.393 * R + 0.769 * G + 0.189 * B
            // newG = 0.349 * R + 0.686 * G + 0.168 * B
            // newB = 0.272 * R + 0.534 * G + 0.131 * B
            // 2. Clamp the values to 255 to avoid overflow

            Bitmap output = new Bitmap(input.Width, input.Height);
            for (int x = 0; x < input.Width; x++)
            {
                for (int y = 0; y < input.Height; y++)
                {
                    Color original = input.GetPixel(x, y);
                    int newR = (int)(original.R * 0.393 + original.G * 0.769 + original.B * 0.189);
                    int newG = (int)(original.R * 0.349 + original.G * 0.686 + original.B * 0.168);
                    int newB = (int)(original.R * 0.272 + original.G * 0.534 + original.B * 0.131);

                    // Clamp the values to 255 to avoid overflow
                    newR = (newR > 255) ? 255 : newR;
                    newG = (newG > 255) ? 255 : newG;
                    newB = (newB > 255) ? 255 : newB;

                    output.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }
            return output;
        }
    }
}

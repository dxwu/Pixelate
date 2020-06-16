using System;
using System.Drawing;

namespace pixelate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bitmap img;
            int boxSizeW;
            int boxSizeH;

            try {
                img = new Bitmap(args[0]);
                boxSizeW = int.Parse(args[1]);
                boxSizeH = int.Parse(args[2]);
            } catch (Exception e) {
                Console.WriteLine("Invalid arguments. Usage: dotnet run [image path] [box width size] [box height size].\n" + e);
                return;
            }

            int numRows = img.Height / boxSizeH + 1;
            int numCols = img.Width / boxSizeW + 1;

            var colors = new Color[numRows, numCols];

            for (int row=0; row<img.Height; row++) {
                for (int col=0; col<img.Width; col++) {
                    Color pixel = img.GetPixel(col, row);
                    colors[row/boxSizeH, col/boxSizeW] = Blend(colors[row/boxSizeH, col/boxSizeW], pixel, 0.5);
                }
            }

            using Image newImage = new Bitmap(img.Width, img.Height);
            using Graphics drawing = Graphics.FromImage(newImage);

            for (int row=0; row<numRows; row++) {
                for (int col=0; col<numCols; col++) {
                    using (Brush brush = new SolidBrush(colors[row,col])) {
                        drawing.FillRectangle(brush, col * boxSizeW, row * boxSizeH, boxSizeW, boxSizeH);
                    }
                }
            }

            newImage.Save(@"result.jpg");
        }

        /// <summary>Blends the specified colors together.</summary>
        /// <param name="color">Color to blend onto the background color.</param>
        /// <param name="backColor">Color to blend the other color onto.</param>
        /// <param name="amount">How much of <paramref name="color"/> to keep,
        /// “on top of” <paramref name="backColor"/>.</param>
        /// <returns>The blended colors.</returns>
        /// From https://stackoverflow.com/questions/3722307/is-there-an-easy-way-to-blend-two-system-drawing-color-values
        public static Color Blend(Color color, Color backColor, double amount)
        {
            byte r = (byte) ((color.R * amount) + backColor.R * (1 - amount));
            byte g = (byte) ((color.G * amount) + backColor.G * (1 - amount));
            byte b = (byte) ((color.B * amount) + backColor.B * (1 - amount));
            return Color.FromArgb(r, g, b);
        }
    }
}

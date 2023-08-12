
namespace RayTracing.Core
{
    public static class Render
    {
        public const int ImageWidth = 256;
        public const int ImageHeight = 256;
        public const double ToIConversionFactor = 255.999;
        private const string ImageName = "./image.ppm";
        
        public static async Task RenderSimpleImage()
        {
            await using var stream = new StreamWriter(ImageName);
            await stream.WriteLineAsync("P3");
            await stream.WriteLineAsync(ImageWidth + " " + ImageHeight);
            await stream.WriteLineAsync("255");
            for (int i = 0; i < ImageHeight; ++i)
            {
                for (int j = 0; j < ImageWidth; ++j)
                {
                    Console.WriteLine("\rScanlines remaining: " + (ImageHeight - j));

                    var red = (float)i / (ImageWidth - 1);
                    var green = (float)j / (ImageHeight - 1);
                    var blue = 0f;
                    
                    var color = new Vec3(red, green, blue);
                    await Color.WriteColor(stream, color);
                }
            }
            Console.WriteLine("Done! Access on: " + Path.GetFullPath(ImageName));
        }
    }
}

namespace RayTracing.Core
{
    public static class Render
    {
        public const double ToIConversionFactor = 255.999;
        private const string ImageName = "./image.ppm";
        
        public static async Task RenderSimpleImage()
        {
            var aspectRatio = 16.0 / 9.0;
            var imageWidth = 400;
            
            var imageHeight = (int)(imageWidth / aspectRatio);
            imageHeight = imageHeight < 1 ? 1 : imageHeight;
            
            var viewportWidth = ImageSettings.ViewportHeight * ((double)imageWidth / imageHeight);
            var cameraCenter = new Vec3(0, 0, 0);
            
            var viewPortU = new Vec3(viewportWidth, 0, 0);
            var viewPortV = new Vec3(0, -ImageSettings.ViewportHeight, 0);
            
            var pixelDeltaU = viewPortU / imageWidth;
            var pixelDeltaV = viewPortV / imageHeight;
            
            var viewPortUpperLeft = (cameraCenter - new Vec3(0,0, ImageSettings.FocalLength)) - (viewPortU / 2) - (viewPortV / 2);
            var pixel100Loc = viewPortUpperLeft + 0.5 * (pixelDeltaU + pixelDeltaV);

            await using var stream = new StreamWriter(ImageName);
            await stream.WriteLineAsync("P3");
            await stream.WriteLineAsync(imageWidth + " " + imageHeight);
            await stream.WriteLineAsync("255");
            for (int i = 0; i < imageHeight; ++i)
            {
                for (int j = 0; j < imageWidth; ++j)
                {
                    Console.WriteLine("\rScanlines remaining: " + (imageHeight - j));

                    var pixelCenter = pixel100Loc + (i * pixelDeltaU) + (j * pixelDeltaV);
                    var rayDirection = pixelCenter - cameraCenter;
                    var ray = new Ray(cameraCenter, rayDirection);
                    
                    var color = Vec3.Ray_color(ray);
                    await Color.WriteColor(stream, color);
                }
            }
            Console.WriteLine("Done! Access on: " + Path.GetFullPath(ImageName));
        }
        
    }
}
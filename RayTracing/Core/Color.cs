namespace RayTracing.Core
{
    public class WriteHandler
    {
        private const double ToIConversionFactor = 255.999;

        /// <summary>
        /// Write the translated [0,255] value of each color component.
        /// </summary>
        public static async Task WriteColor(StreamWriter @out, Vec3 color)
        {
            var x = ToIConversionFactor * color.X;
            var y = ToIConversionFactor * color.Y;
            var z = ToIConversionFactor * color.Z;
            await @out.WriteLineAsync($"{x} {y} {z}");
        }
    }
}
namespace RayTracing.Core
{
    public class Color
    {
        /// <summary>
        /// Write the translated [0,255] value of each color component.
        /// </summary>
        public static async Task WriteColor(StreamWriter @out, Vec3 color)
        {
            var x = Render.ToIConversionFactor * color.X;
            var y = Render.ToIConversionFactor * color.Y;
            var z = Render.ToIConversionFactor * color.Z;
            await @out.WriteLineAsync($"{x} {y} {z}");
        }
    }
}
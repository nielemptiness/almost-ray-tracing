using RayTracing.Core;

namespace RayTracing;

public class Startup
{
    public static async Task Main(string[] args)
    {
        await Render.RenderSimpleImage();
    }
}
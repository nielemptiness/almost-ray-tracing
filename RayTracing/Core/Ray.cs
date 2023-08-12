using Point3 = RayTracing.Core.Vec3;

namespace RayTracing.Core
{
    public class Ray
    {
        private Vec3 _direction;
        private Vec3 _origin;
        
        public Ray(Point3 origin, Vec3 direction)
        {
            _origin = origin;
            _direction = direction;
        }
        
        public Point3 At(float t)
        {
            return _origin + _direction * t;
        }

        public Point3 Origin => _origin;
        public Vec3 Direction => _direction;
    }
}
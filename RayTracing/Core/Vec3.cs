namespace RayTracing.Core
{
    public struct Vec3
    {
        private readonly double[] _vector = new double[3];
     
        public Vec3()
        {
            _vector[0] = 0;
            _vector[1] = 0;
            _vector[2] = 0;
        }
        public Vec3(double e0, double e1, double e2)
        {
            _vector[0] = e0;
            _vector[1] = e1;
            _vector[2] = e2;
        }
        
        public double X => _vector[0]; 
        public double Y => _vector[1]; 
        public double Z => _vector[2];

        public double Get(int i)
        {
            return _vector[i];
        }
        
        public static double Dot(Vec3 u, Vec3 v) {
            return u.X * v.X +
                   u.Y * v.Y +
                   u.Z * v.Z;
        }

        public static Vec3 Cross(Vec3 u, Vec3 v) {
            return new Vec3(
                u.Y * v.Z - u.Z * v.Y,
                u.Z * v.X - u.X * v.Z,
                u.X * v.Y - u.Y * v.X
            );
        }

        public static Vec3 Unit_vector(Vec3 v)
        {
            return v / v.Length();
        }

        public Vec3 Increment(Vec3 add)
        {
            _vector[0] += add.X;
            _vector[1] += add.Y;
            _vector[2] += add.Z;
            return this;
        }

        public static Vec3 Ray_color(Ray ray)
        {
            var unitDirection = Unit_vector(ray.Direction);
            var lerp = 0.5 * (unitDirection.Y + 1.0);
            return (1.0 - lerp) * new Vec3(1.0, 1.0, 1.0) + lerp * new Vec3(0.5, 0.7, 1.0);
        }

        public static Vec3 operator --(Vec3 left)
        {
            return new Vec3(-left.X, -left.Y, -left.Z);
        }
        
        public static Vec3 operator +(Vec3 left, Vec3 right)
        {
            return new Vec3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vec3 operator -(Vec3 left, Vec3 right)
        {
            return new Vec3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vec3 operator *(Vec3 left, double t)
        {
            return new Vec3(left.X * t, left.Y * t, left.Z * t);
        }
        
        public static Vec3 operator *(double t, Vec3 left)
        {
            return new Vec3(left.X * t, left.Y * t, left.Z * t);
        }
        
        public static Vec3 operator *(Vec3 left, Vec3 right)
        {
            return new Vec3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static Vec3 operator / (Vec3 left, double right)
        {
            return (1 / right) * left;
        }

        double Length()
        {
            var result = Math.Sqrt(SquaredLength());
            return double.IsNaN(result) ? 1 : result;
        }

        double SquaredLength() => _vector[0] * _vector[0] + _vector[1] * _vector[1] + _vector[2] * _vector[2];

    }
}
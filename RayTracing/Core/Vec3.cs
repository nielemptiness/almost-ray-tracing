namespace RayTracing.Core
{
    public struct Vec3
    {
        private static readonly float[] Vector = new float[3];
     
        public Vec3()
        {
            Vector[0] = 0;
            Vector[1] = 0;
            Vector[2] = 0;
        }
        public Vec3(float e0, float e1, float e2)
        {
            Vector[0] = e0;
            Vector[1] = e1;
            Vector[2] = e2;
        }
        
        public float X => Vector[0]; 
        public float Y => Vector[1]; 
        public float Z => Vector[2];

        public static float Get(int i)
        {
            return Vector[i];
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
            Vector[0] += add.X;
            Vector[1] += add.Y;
            Vector[2] += add.Z;
            return this;
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

        public static Vec3 operator *(Vec3 left, float t)
        {
            return new Vec3(left.X * t, left.Y * t, left.Z * t);
        }
        
        public static Vec3 operator *(Vec3 left, Vec3 right)
        {
            return new Vec3(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static Vec3 operator / (Vec3 left, float right)
        {
            return left * (1 / right);
        }
        
        float Length() => (float) Math.Sqrt(SquaredLength());
        float SquaredLength() => Vector[0] * Vector[0] + Vector[1] * Vector[1] + Vector[2] * Vector[2];

    }
}
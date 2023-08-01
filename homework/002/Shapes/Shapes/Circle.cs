using Shapes.Shapes.Exceptions;

namespace shapes.Shapes
{
    public class Circle : IShape
    {
        private Point _p;
        private double _radius;

        public Circle(Point center, double radius)
        {
            if (radius <= 0)
            {
                throw new InvalidCircleException();
            }

            _p = center;
            _radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}

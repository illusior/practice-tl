using Shapes.Shapes.Exceptions;

namespace shapes.Shapes
{
    public class Triangle : IShape
    {
        private Point _p1, _p2, _p3;
        private TriangleDimensionsAndPerimeter _triangleInfo;

        public Point Point1
        {
            private set { _p1 = value; }
            get { return _p1; }
        }

        public Point Point2
        {
            private set { _p2 = value; }
            get { return _p2; }
        }

        public Point Point3
        {
            private set { _p3 = value; }
            get { return _p3; }
        }

        public Triangle(Point p1, Point p2, Point p3)
        {
            if (!TriangleChecker.IsTriangleValid(p1, p2, p3))
            {
                throw new InvalidTriangleException();
            }

            _p1 = p1;
            _p2 = p2;
            _p3 = p3;

            _triangleInfo = GetTriangleInfo();
        }

        public double GetArea()
        {
            double p_2 = _triangleInfo.Perimeter / 2;
            var a = _triangleInfo.Distance1;
            var b = _triangleInfo.Distance2;
            var c = _triangleInfo.Distance3;

            return Math.Sqrt(p_2 * (p_2 - a) * (p_2 - b) * (p_2 - c));
        }

        public double GetPerimeter()
        {
            return _triangleInfo.Perimeter;
        }

        private TriangleDimensionsAndPerimeter GetTriangleInfo()
        {
            double a = _p1.Distance(_p2);
            double b = _p2.Distance(_p3);
            double c = _p3.Distance(_p1);

            double perimeter = a + b + c;

            return new TriangleDimensionsAndPerimeter(a, b, c, perimeter);
        }

        private class TriangleDimensionsAndPerimeter
        {
            public double Distance1, Distance2, Distance3, Perimeter;

            public TriangleDimensionsAndPerimeter(double distance1, double distance2, double distance3, double perimeter)
            {
                Distance1 = distance1;
                Distance2 = distance2;
                Distance3 = distance3;
                Perimeter = perimeter;
            }
        }

        private class TriangleChecker
        {
            public static bool IsTriangleValid(Point p1, Point p2, Point p3)
            {
                var d1 = p1.Distance(p2);
                var d2 = p2.Distance(p3);
                var d3 = p3.Distance(p1);

                return (d1 + d2 > d3) && (d2 + d3 > d1) && (d1 + d3 > d2);
            }
        }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

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

        public double CalculateArea()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

        public double CalculatePerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}

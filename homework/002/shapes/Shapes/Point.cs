// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace shapes.Shapes
{
    public class Point
    {
        public double X, Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Distance(Point other)
        {
            return Math.Sqrt(
                Math.Pow(other.X - X, 2) +
                Math.Pow(other.Y - Y, 2)
            );
        }
    }
}

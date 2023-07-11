// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace shapes.Shapes
{
    public class Square : IShape
    {
        private Point _pTopLeft, _pRightBottom;

        public Square(Point topLeft, double size)
        {
            if (size <= 0)
            {
                throw new InvalidSquareException();
            }

            _pTopLeft = topLeft;
            _pRightBottom = new Point(_pTopLeft.X + size, _pTopLeft.Y + size);
        }

        public double CalculateArea()
        {
            return Math.Pow(GetSize(), 2);
        }

        public double CalculatePerimeter()
        {
            return GetSize() * 4;
        }

        private double GetSize()
        {
            return _pRightBottom.X - _pTopLeft.X;
        }
    }
}

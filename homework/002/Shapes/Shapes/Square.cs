using Shapes.Shapes.Exceptions;

namespace shapes.Shapes
{
    public class Square : IShape
    {
        private Point _topLeft, _rightBottom;

        public Square(Point topLeft, double size)
        {
            if (size <= 0)
            {
                throw new InvalidSquareException();
            }

            _topLeft = topLeft;
            _rightBottom = new Point(_topLeft.X + size, _topLeft.Y + size);
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
            return _rightBottom.X - _topLeft.X;
        }
    }
}

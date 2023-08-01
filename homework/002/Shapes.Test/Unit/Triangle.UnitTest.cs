// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Shapes.Shapes.Exceptions;

namespace shapes.test
{
    internal class TriangleTests
    {
        private readonly Point _p1 = new(0, 10), _p2 = new(10, 0), _p3 = new(2, 4);
        private readonly double _size = 110;
        private Triangle _triangle;

        [SetUp]
        public void Setup()
        {
            _triangle = new Triangle(_p1, _p2, _p3);
        }

        [Test]
        public void TryCreateInvalidTriangle_ThrowTest()
        {
            Assert.Throws<InvalidTriangleException>(() => {
                Point atZero = new(0, 0);
                new Triangle(atZero, atZero, atZero);
            }, "The triangle inequality property should be applicable to any triangle");
        }

        [Test]
        public void GetTriangleArea_EqualTest()
        {
            double expectedArea = 20;

            var actualArea = _triangle.GetArea();

            Assert.That(actualArea,
                Is.EqualTo(expectedArea).Within(Settings.s_TestAccuracy).Percent,
                "Expected area doesn't match with actual");
        }

        [Test]
        public void GetTrianglePerimeter_EqualTest()
        {
            double expectedPerimeter = 29.411;

            var actualPerimeter = _triangle.GetPerimeter();

            Assert.That(actualPerimeter,
                Is.EqualTo(expectedPerimeter).Within(Settings.s_TestAccuracy).Percent,
                "Expected perimeter doesn't match with actual");
        }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace shapes.test
{
    public class CircleTests
    {
        private readonly Point _pCenter = new(0, 10);
        private readonly double _radius = 1234;
        private Circle _circle;

        [SetUp]
        public void Setup()
        {
            _circle = new Circle(_pCenter, _radius);
        }

        [TestCase(-100)]
        [TestCase(-100.123)]
        [TestCase(0)]
        [TestCase(-0)]
        [TestCase(-0.00001)]
        public void TryCreateInvalidCircle_ThrowTest(double invalidRadius)
        {
            Assert.Catch<InvalidCircleException>(() =>
            {
                var regularPoint = new Point(100, -200);
                new Circle(regularPoint, invalidRadius);
            }, "Circle must have positive radius");
        }

        [Test]
        public void GetCircleArea_EqualTest()
        {
            double expectedArea = 4783879.062;

            var actualArea = _circle.CalculateArea();

            Assert.That(actualArea,
                Is.EqualTo(expectedArea).Within(Settings.s_TestAccuracy).Percent,
                "Expected area doesn't match with actual");
        }

        [Test]
        public void GetCirclePerimeter_EqualTest()
        {
            double expectedPerimeter = 7753.450;

            var actualPerimeter = _circle.CalculatePerimeter();

            Assert.That(actualPerimeter,
                Is.EqualTo(expectedPerimeter).Within(Settings.s_TestAccuracy).Percent,
                "Expected perimeter doesn't match with actual");
        }
    }
}

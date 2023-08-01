// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace shapes.test
{
    internal class SqaureTests
    {
        private readonly Point _leftTop = new(0, 10);
        private readonly double _size = 110;
        private Square _square;

        [SetUp]
        public void Setup()
        {
            _square = new Square(_leftTop, _size);
        }

        [Test]
        public void TryCreateInvalidSquare_ThrowTest()
        {
            Assert.Throws<InvalidSquareException>(() => {
                double invalidSize = -200;
                new Square(_leftTop, invalidSize);
            }, "Square must have positive size");
        }

        [Test]
        public void GetSquareArea_EqualTest()
        {
            double expectedArea = 12100;

            var actualArea = _square.CalculateArea();

            Assert.That(actualArea,
                Is.EqualTo(expectedArea).Within(Settings.s_TestAccuracy).Percent,
                "Expected area doesn't match with actual");
        }

        [Test]
        public void GetSquarePerimeter_EqualTest()
        {
            double expectedPerimeter = 440;

            var actualPerimeter = _square.CalculatePerimeter();

            Assert.That(actualPerimeter,
                Is.EqualTo(expectedPerimeter).Within(Settings.s_TestAccuracy).Percent,
                "Expected perimeter doesn't match with actual");
        }
    }
}

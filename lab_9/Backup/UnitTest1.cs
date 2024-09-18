using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab_9;

namespace lab_9.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateDistance_StaticMethod_ReturnsCorrectDistance()
        {
            // Arrange
            double x = 3.0;
            double y = 4.0;

            // Act
            double distance = Point.CalculateDistanceStatic(x, y);

            // Assert
            Assert.AreEqual(5.0, distance);
        }

        [TestMethod]
        public void CalculateDistance_InstanceMethod_ReturnsCorrectDistance()
        {
            // Arrange
            Point point = new Point(3.0, 4.0);

            // Act
            double distance = point.CalculateDistance();

            // Assert
            Assert.AreEqual(5.0, distance, 0.001);
        }

        [TestMethod]
        public void UnaryOperators_DecrementCoordinates_ReturnsCorrectResult()
        {
            // Arrange
            Point point = new Point(3.0, 4.0);

            // Act
            Point result = --point;

            // Assert
            Assert.AreEqual(2.0, result.X, 0.001);
            Assert.AreEqual(3.0, result.Y, 0.001);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindboxTestTask.Tests
{
    [TestClass()]
    public class CircleTests
    {
        [TestMethod("Проверка правильности диаметра.")]
        [DataRow(10, DisplayName = "Нормальное значение радиуса")]
        [DataRow(0, DisplayName = "Слишком малое значение радиуса")]
        [DataRow(Double.NaN, DisplayName = "Неверное значение радиуса (NaN)")]
        [DataRow(Double.NegativeInfinity, DisplayName = "Неверное значение радиуса (NegativeInfinity)")]
        [DataRow(Double.PositiveInfinity, DisplayName = "Неверное значение радиуса. (PositiveInfinity)")]
        public void RadiusTest(double radius)
        {
            Circle circle = new Circle();

            if (Double.IsNaN(radius) || Double.IsInfinity(radius))
            {
                Assert.ThrowsException<ArgumentException>(() => circle.Radius = radius);
            }
            else if (radius <= 0)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => circle.Radius = radius);
            }
            else
            {
                circle.Radius = radius;
                Assert.AreEqual(radius, circle.Radius, $"{radius} != {circle.Radius}");
            }
        }

        [TestMethod("Проверка на получение площади круга.")]
        [DataRow(10, DisplayName = "Нормальное значение радиуса")]
        [DataRow(Double.MaxValue, DisplayName = "Слишком большое значение радиуса")]
        public void GetAreaTest(double radius)
        {
            Circle circle = new Circle(radius);

            try
            {
                double expected = Math.PI * Math.Pow(radius, 2);
                double actual = circle.GetArea();
                Assert.AreEqual(expected, actual, $"{expected} != {actual}");
            }
            catch (Exception ex)
            {
                Assert.ThrowsException<OverflowException>(() => throw ex);
            }
        }
    }
}
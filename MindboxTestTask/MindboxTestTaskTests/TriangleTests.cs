using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindboxTestTask.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod("Проверка правильности размера сторон.")]
        [DataRow(0, 1, 1, DisplayName = "Неверный параметр sideA (значение слишком мало)")]
        [DataRow(1, 0, 1, DisplayName = "Неверный параметр sideB (значение слишком мало)")]
        [DataRow(1, 1, 0, DisplayName = "Неверный параметр sideC (значение слишком мало)")]
        [DataRow(Double.NaN, 1, 1, DisplayName = "Неверный параметр sideA (значение NaN)")]
        [DataRow(1, Double.NaN, 1, DisplayName = "Неверный параметр sideB (значение NaN)")]
        [DataRow(1, 1, Double.NaN, DisplayName = "Неверный параметр sideC (значение NaN)")]
        [DataRow(Double.NegativeInfinity, 1, 1, DisplayName = "Неверный параметр sideA (значение NegativeInfinity)")]
        [DataRow(1, Double.NegativeInfinity, 1, DisplayName = "Неверный параметр sideB (значение NegativeInfinity)")]
        [DataRow(1, 1, Double.NegativeInfinity, DisplayName = "Неверный параметр sideC (значение NegativeInfinity)")]
        [DataRow(Double.PositiveInfinity, 1, 1, DisplayName = "Неверный параметр sideA (значение PositiveInfinity)")]
        [DataRow(1, Double.PositiveInfinity, 1, DisplayName = "Неверный параметр sideB (значение PositiveInfinity)")]
        [DataRow(1, 1, Double.PositiveInfinity, DisplayName = "Неверный параметр sideC (значение PositiveInfinity)")]
        [DataRow(5, 1, 1, DisplayName = "Треугольника не существует.")]
        [DataRow(1, 5, 1, DisplayName = "Треугольника не существует.")]
        [DataRow(1, 1, 5, DisplayName = "Треугольника не существует.")]
        public void SidesTest(double sideA, double sideB, double sideC)
        {
            if (Double.IsNaN(sideA) || Double.IsNaN(sideB) || Double.IsNaN(sideC) ||
                Double.IsInfinity(sideA) || Double.IsInfinity(sideB) || Double.IsInfinity(sideC))
            {
                Assert.ThrowsException<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
            }
            else if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(sideA, sideB, sideC));
            }
            else
            {
                try
                {
                    Triangle triangle = new Triangle(sideA, sideB, sideC);
                    bool result = sideA == triangle.SideA && sideB == triangle.SideB && sideC == triangle.SideC;
                    Assert.IsTrue(result);
                }
                catch (Exception ex)
                {
                    Assert.ThrowsException<Exception>(() => throw ex);
                }
            }
        }

        [TestMethod("Проверка на получение площади треугольника.")]
        [DataRow(2, 3, 4, 2.9047375096555625, DisplayName = "Безошибочное вычисление площади треугольника")]
        [DataRow(Double.MaxValue, Double.MaxValue, Double.MaxValue, -1, DisplayName = "Ошибка переполнения")]
        public void GetAreaTest(double sideA, double sideB, double sideC, double result)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);

            try
            {
                double actual = triangle.GetArea();
                Assert.AreEqual(result, actual, $"{result} != {actual}.");
            }
            catch (Exception ex)
            {
                Assert.ThrowsException<OverflowException>(() => throw ex);
            }
        }

        [TestMethod("Проверка на прямоугольный треугольник.")]
        [DataRow(3, 4, 5, true, DisplayName = "Прямоугольный треугольник.")]
        [DataRow(4, 4, 5, false, DisplayName = "Не прямоугольный треугольник.")]
        public void IsRightTriangleTest(double sideA, double sideB, double sideC, bool result)
        {
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            bool actual = triangle.IsRightTriangle;
            Assert.AreEqual(result, actual, $"{result} != {actual}.");
        }
    }
}
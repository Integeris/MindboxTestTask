using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MindboxTestTask.Tests
{
    [TestClass()]
    public class GeneralTests
    {
        [TestMethod("Проверка на неизвестную фигуру.")]
        [DataRow(typeof(Circle), 314.1592653589793, 10, DisplayName = "Площадь круга")]
        [DataRow(typeof(Triangle), 2.9047375096555625, 2, 3, 4, DisplayName = "Площадь треугольника")]
        public void UnknownShapeTest(Type type, double area, params object[] paremeters)
        {
            IShape shape = (IShape)Activator.CreateInstance(type, paremeters)!;
            double actual = shape.GetArea();
            Assert.AreEqual(area, actual, $"{area} != {actual}");
        }
    }
}

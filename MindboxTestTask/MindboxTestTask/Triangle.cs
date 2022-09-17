namespace MindboxTestTask
{
    /// <summary>
    /// Треугольник.
    /// </summary>
    public class Triangle : IShape
    {
        /// <summary>
        /// Сторона A.
        /// </summary>
        private double sideA;

        /// <summary>
        /// Сторона B.
        /// </summary>
        private double sideB;

        /// <summary>
        /// Сторона C.
        /// </summary>
        private double sideC;

        /// <summary>
        /// Сторона A.
        /// </summary>
        public double SideA
        {
            get => sideA;
            set
            {
                IsValidSide(value, nameof(SideA));
                Exist(value, sideB, sideC);
                sideA = value;

                ExaminationRightTriangle();
            }
        }

        /// <summary>
        /// Сторона B.
        /// </summary>
        public double SideB
        {
            get => sideB;
            set
            {
                IsValidSide(value, nameof(SideB));
                Exist(sideA, value, sideC);
                sideB = value;

                ExaminationRightTriangle();
            }
        }

        /// <summary>
        /// Сторона C.
        /// </summary>
        public double SideC
        {
            get => sideC;
            set
            {
                IsValidSide(value, nameof(SideC));
                Exist(sideA, sideB, value);
                sideC = value;

                ExaminationRightTriangle();
            }
        }

        /// <summary>
        /// Прямоугольный ли треугольник.
        /// </summary>
        public bool IsRightTriangle { get; set; }

        /// <summary>
        /// Создание треугольника.
        /// </summary>
        public Triangle()
        {
            sideA = 1;
            sideB = 1;
            sideC = 1;
        }

        /// <summary>
        /// Создание треугольника.
        /// </summary>
        /// <param name="sideA">Сторона A.</param>
        /// <param name="sideB">Сторона B.</param>
        /// <param name="sideC">Сторона C.</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            IsValidSide(sideA, nameof(sideA));
            IsValidSide(sideB, nameof(sideB));
            IsValidSide(sideC, nameof(sideC));
            Exist(sideA, sideB, sideC);

            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;

            ExaminationRightTriangle();
        }

        /// <summary>
        /// Получение площади треугольника.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        /// <exception cref="OverflowException">Значения сторон слишком большие чтобы посчитать площадь треугольника.</exception>
        public double GetArea()
        {
            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double subtotal = semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC);

            if (Double.IsInfinity(subtotal))
            {
                throw new OverflowException("Значения сторон слишком большие чтобы посчитать площадь треугольника.");
            }

            return Math.Sqrt(subtotal);
        }

        /// <summary>
        /// Проверка на прямоугольный треугольник.
        /// </summary>
        private void ExaminationRightTriangle()
        {
            List<double> sides = new List<double>() { sideA, sideB, sideC };
            double bigestSide = sides.Max();
            sides.Remove(bigestSide);

            double rigthTringleSide = Math.Sqrt(Math.Pow(bigestSide, 2) - Math.Pow(sides[0], 2));
            IsRightTriangle = sides[1] == rigthTringleSide;
        }

        /// <summary>
        /// Существует ли треугольник.
        /// </summary>
        private static void Exist(double sideA, double sideB, double sideC)
        {
            if (sideA + sideB <= sideC ||
                sideA + sideC <= sideB ||
                sideB + sideC <= sideA)
            {
                throw new Exception("Треугольника не существует.");
            }
        }

        /// <summary>
        /// Проверка стороны на правильность.
        /// </summary>
        /// <param name="side">Сторона.</param>
        /// <param name="paramName">Название параметра.</param>
        /// <exception cref="ArgumentException">Сторона треугольника не может быть равна NaN или бесконечности.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Сторона треугольника не может быть меньше или равной 0.</exception>
        private static void IsValidSide(double side, string paramName)
        {
            if (Double.IsNaN(side) || Double.IsInfinity(side))
            {
                throw new ArgumentException("Сторона треугольника не может быть равна NaN или бесконечности.", paramName);
            }
            else if (side <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, "Сторона треугольника не может быть меньше или равной 0.");
            }
        }
    }
}

namespace MindboxTestTask
{
    /// <summary>
    /// Круг.
    /// </summary>
    public class Circle : IShape
    {
        /// <summary>
        /// Радиус.
        /// </summary>
        private double radius;

        /// <summary>
        /// Радиус.
        /// </summary>
        public double Radius
        {
            get => radius;
            set
            {
                if (double.IsNaN(value) || Double.IsInfinity(value))
                {
                    throw new ArgumentException("Радиус круга не может быть NaN или Infinity.", nameof(Radius));
                }
                else if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Radius), "Радиус круга не может быть меньше или равен нулю.");
                }

                radius = value;
            }
        }

        /// <summary>
        /// Создание круга.
        /// </summary>
        public Circle() 
        {
            radius = 1;
        }

        /// <summary>
        /// Создание круга.
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Получение площади круга.
        /// </summary>
        /// <returns>Площадь круга.</returns>
        /// <exception cref="Exception">Значение площади слишком огромно чтобы хрангить его в типе данных Double.</exception>
        public double GetArea()
        {
            double area = Math.PI * Math.Pow(radius, 2);

            if (Double.IsInfinity(area))
            {
                throw new OverflowException($"Значение площади слишком огромно чтобы хрангить его в типе данных {nameof(Double)}.");
            }

            return area;
        }
    }
}

using System;
using Lab_9;

namespace Lab_9
{
    public class PointArray
    {
        private Point[] arr;

        // конструктор без параметров
        public PointArray()
        {
            arr = new Point[0];
        }

        // конструктор с параметрами, заполняющий элементы случайными значениями
        public PointArray(int size)
        {
            arr = new Point[size];
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                arr[i] = new Point(random.NextDouble() * 10, random.NextDouble() * 10);
            }
        }

        // конструктор с параметрами, позволяющий заполнить массив элементами, заданными пользователем с клавиатуры
        public PointArray(int size, UserInterface ui)
        {
            arr = new Point[size];

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Введите координаты точки {i + 1}:");
                arr[i] = ui.GetPointFromUser();
            }
        }

        // метод для просмотра элементов массива
        public void DisplayArray()
        {
            foreach (var point in arr)
            {
                UserInterface ui = new UserInterface();
                ui.DisplayPoint(point);
            }
        }

        // индексатор для доступа к элементам массива с проверкой выхода индекса за пределы массива
        public Point this[int index]
        {
            get
            {
                 if (index < 0 || index >= arr.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");

                return arr[index];
            }
            set
            {
                 //if (index < 0 || index >= arr.Length)
                 //   throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");

                arr[index] = value;
            }
        }

        // функция для нахождения точки, наиболее близкой к центру координат
        public Point FindClosestToPoint()
        {
            Point closestPoint = arr[0];
            double minDistance = DistanceToCenter(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                double currentDistance = DistanceToCenter(arr[i]);

                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    closestPoint = arr[i];
                }
            }
            return closestPoint;
        }
        // функция для вычисления расстояния от точки до центра координат
        public double DistanceToCenter(Point point)
        {
            return Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y, 2));
        }
    }
}

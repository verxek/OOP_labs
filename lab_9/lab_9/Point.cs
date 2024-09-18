using System;
using Lab_9;

namespace Lab_9
{
    public class Point
    {
        private double x;
        private double y;
        private static int count = 0;

        // конструктор класса Point
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
            count++; // увеличиваем счетчик объектов при создании нового объекта
        }

        // свойства для доступа к закрытым атрибутам
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        // статическая компонента класса для подсчета количества созданных объектов
        public static int Count
        {
            get { return count; }
        }

        public bool Equals(Point p)
        {
            if (this.X == p.X && this.Y == p.Y)
                return true;
            return false;
        }

        // Метод для вычисления расстояния от точки до начала координат
        public double CalculateDistance()
        {
            return Math.Sqrt(x * x + y * y);
        }

        // cтатическая функция для вычисления расстояния от точки до начала координат
        public static double CalculateDistanceStatic(double x, double y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        // Перегруженные унарные операции

        // уменьшить координаты x и y на
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }

        // поменять координаты х и у местами
        public static Point operator -(Point p)
        {
            double temp = p.X;
            p.X = p.Y;
            p.Y = temp;
            return p;
        }

        // перегруженные операции приведения типа
        public static implicit operator int(Point p)
        {
            return (int)p.X; // неявное преобразование - целая часть координаты X
        }

        public static explicit operator double(Point p)
        {
            return p.Y; // явное преобразование - координата Y
        }

        // перегруженные бинарные операции

        // левосторонняя операция, уменьшается координата х
        public static Point operator -(Point p, int value)
        {
            p.X -= value;
            return p;
        }

        // правосторонняя операция, уменьшается координата y
        public static Point operator -(int value, Point p)
        {
            p.Y -= value;
            return p;
        }

        // вычисляется расстояние от точки p1 до точки p2, результатом должно быть вещественное число
        public static double operator -(Point p1, Point p2)
        {
            double distance = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
            return distance;
        }
    }
}





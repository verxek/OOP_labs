using System;
using Lab_9;


namespace Lab_9
{
    public class UserInterface
    {
        static int CorrectInputInt()
        {
            int userInput;
            bool isValidInput = false;
            do
            {
                string input = Console.ReadLine();

                isValidInput = int.TryParse(input, out userInput);

                if (!isValidInput)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                }

            } while (!isValidInput);
            return userInput;
        }

        static double CorrectInputDouble()
        {
            double userInput;
            bool isValidInput = false;
            do
            {
                string input = Console.ReadLine();

                isValidInput = double.TryParse(input, out userInput);

                if (!isValidInput)
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите вещественное число.");
                }

            } while (!isValidInput);
            return userInput;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Ввод точки");
            Console.WriteLine("2. Расстояние от точки до начала координат");
            Console.WriteLine("3. Количество созданных объектов");
            Console.WriteLine("4. Унарные операции");
            Console.WriteLine("5. Операции приведения типа");
            Console.WriteLine("6. Бинарные операции");
            Console.WriteLine("7. Создать массив точек вручную");
            Console.WriteLine("8. Создать массив точек случайно");
            Console.WriteLine("9. Вывести массив точек");
            Console.WriteLine("10. Доступ к элементу массива");
            Console.WriteLine("11. Найти ближайшую точку к центру");
            Console.WriteLine("0. Выход");
        }
        public static int GetMenuChoice()
        {
            int choice = CorrectInputInt();
            return choice;
        }
        public Point GetPointFromUser()
        {
            Console.WriteLine("Введите координату X:");
            double x = CorrectInputDouble();

            Console.WriteLine("Введите координату Y:");
            double y = CorrectInputDouble();

            return new Point(x, y);
        }

        public void DisplayPoint(Point point)
        {
            Console.WriteLine($"Точка: X = {point.X}, Y = {point.Y}");
        }

        public void DisplayDistance(double distance)
        {
            Console.WriteLine($"Расстояние: {distance}");
        }

        public void DisplayCount(int count)
        {
            Console.WriteLine($"Количество: {count}");
        }

        public void DisplayArray(Point[] array)
        {
            Console.WriteLine("Массив точек:");
            foreach (var point in array)
            {
                DisplayPoint(point);
            }
        }

        public int GetArraySizeFromUser()
        {
            Console.WriteLine("Введите размер массива:");
            return int.Parse(Console.ReadLine());
        }

        public int GetIndexToAccess()
        {
            Console.WriteLine("Введите индекс элемента для доступа:");
            return int.Parse(Console.ReadLine());
        }

        public void DisplayError(string message)
        {
            Console.WriteLine($"Ошибка: {message}");
        }

        public void DisplayClosestPoint(Point closestPoint)
        {
            Console.WriteLine("Наиболее близкая к центру точка:");
            DisplayPoint(closestPoint);
        }
    }
}

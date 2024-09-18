using System;
using Lab_9;


class Program
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
    static void Main()
    {
        
        PointArray pointArray = null;
        Point point = null;

        
        while (true)
        {
            UserInterface ui = new UserInterface();
            ui.DisplayMenu();
            
            int choice = UserInterface.GetMenuChoice();

            switch (choice)
            {
                case 1:
                   // создание объектов класса Point и вывод информации о них
                    point = ui.GetPointFromUser();
                    ui.DisplayPoint(point);
                    break;
                

                case 2:
                    
                    if (point != null)
                    {
                        double distance = point.CalculateDistance();
                        ui.DisplayDistance(distance);
                    }
                    else
                        Console.WriteLine("Точки не существует!");
                    
                    break;

                case 3:
                    //  количества созданных объектов
                    ui.DisplayCount(Point.Count);
                    break;

                case 4:
                    // унарные операции
                    point = ui.GetPointFromUser();
                    ui.DisplayPoint(point);

                    --point;
                    Console.WriteLine("Уменьшить координаты х и у на 1: ");
                    ui.DisplayPoint(point);

                    point = -point;
                    Console.WriteLine("Поменять координаты х и у местами: ");
                    ui.DisplayPoint(point);
                    break;

                case 5:
                    // операции приведения типа
                    Point conversionPoint = ui.GetPointFromUser();
                    int intResult = conversionPoint; // неявное преобразование (возврат целой части Х)
                    double doubleResult = (double)conversionPoint;   // явное преобразование (возврат целой части Y)
                    Console.WriteLine($"Int result (неявное преобразование (целая часть х)): {intResult}");
                    Console.WriteLine($"Double result (явное преобразование (целая часть у)): {doubleResult}");
                    break;

                case 6:
                    // бинарные операции
                    Point binaryOperationPoint = ui.GetPointFromUser();
                    Console.WriteLine("binaryoperationpoint");
                    ui.DisplayPoint(binaryOperationPoint);

                    Point pointForDistance = new Point(binaryOperationPoint.X, binaryOperationPoint.Y);

                    Console.WriteLine("На сколько уменьшить Х?");
                    int xSubstraction = CorrectInputInt();
                    Point subtractionResult = binaryOperationPoint - xSubstraction;
                    Console.WriteLine("Результат: ");
                    ui.DisplayPoint(subtractionResult);

                    Console.WriteLine("На сколько уменьшить У?");
                    int ySubstraction = CorrectInputInt();
                    Point subtractionResult2 = ySubstraction - binaryOperationPoint;
                    Console.WriteLine("Результат: ");
                    ui.DisplayPoint(subtractionResult2);

                    double distanceResult = pointForDistance - subtractionResult2;
                    Console.WriteLine($"Расстояние от начальной точки до конечной: {distanceResult} ");
                 
                    
                    break;

                case 7:
                    // Работа с массивом
                    int size = ui.GetArraySizeFromUser();
                    pointArray = new PointArray(size, ui);
                    pointArray.DisplayArray();
                    break;

                case 8:
                    size = ui.GetArraySizeFromUser();
                    pointArray = new PointArray(size);
                    pointArray.DisplayArray();
                    break;
                case 9:
                    if (pointArray != null)
                    {
                        pointArray.DisplayArray();
                    }
                    else
                        Console.WriteLine("Массива не существует!");
                    break;

                case 10:


                    int indexToAccess = ui.GetIndexToAccess();
                    try
                    {
                        Point accessedPoint = pointArray[indexToAccess-1];
                        ui.DisplayPoint(accessedPoint);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        ui.DisplayError(e.Message);
                    }
                    break;

                case 11:

                    Point closestPoint = pointArray.FindClosestToPoint();
                    ui.DisplayClosestPoint(closestPoint);
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    ui.DisplayError("Неверный выбор. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }
}
        
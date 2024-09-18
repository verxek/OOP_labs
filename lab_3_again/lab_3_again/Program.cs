using System;
using System.Runtime.CompilerServices;

namespace lab_3
{
    class Program
    {

        static double Function(double x)
        {
            // Формула для вычисления
            double result = (1.0 / 4.0) * Math.Log((1.0 + x) / (1.0 - x)) + (1.0 / 2.0) * Math.Atan(x);
            return result;
        }

        static double PowerSeriesSum(double x, int n) // сумма степенного ряда
        {
            double sum = 0.0;
            double powerX = x; // Начальное значение y
            for (int i = 0; i <= n; i++)
            {
                double an = SeriesMember(x, i);
                sum += an;
                powerX *= x; //  Получаем следующую степень x для следующего члена ряда
            }
            return sum;
        }

        // формула общего члена суммы ряда
        static double SeriesMember(double x, int n)
        {
            double result = Math.Pow(x, 4 * n + 1) / (4 * n + 1);
            return result;
        }
        static double PowerSeriesSumWithPrecision(double x, double e)
        {
            double sum = 0.0;
            double powerX = x; // Начальное значение степени x
            double prevSum; //  Приближенное значение суммы
            int n = 0; // Текущий номер члена ряда
            do
            {
                double an = SeriesMember(x, n);
                prevSum = sum;
                sum += an;
                powerX *= x; // Обновляем значение степени х для следующего члена
                n++;
            }
            while (Math.Abs(sum - prevSum) >= e); // Проверяем точность
            return sum;
        }

        static void Main()
        {
            Console.WriteLine("Вычисление функции f(x) и суммы членов ряда с использованием рекуррентного соотношения:");
            Console.WriteLine();

            // Интервал [a, b] и количество шагов k
            double a = 0.1;
            double b = 0.8;
            int k = 10;

            double step = (double)((b - a) / k);
            for (double x = a; x <= b; x += step)
            {
                // точное значение функции
                double exactValue = Function(x);

                // а) Вычисление для заданного n
                int n = 3;
                double approxValueN = PowerSeriesSum(x, n);

                // б) Вычисление для заданной точности e
                double e = 0.0001;
                double approxValueE = PowerSeriesSumWithPrecision(x, e);

                Console.WriteLine("X = " + x + " SN = " + approxValueN + " SE = " + approxValueE + " Y = " + exactValue);
            }
        }
    }
}
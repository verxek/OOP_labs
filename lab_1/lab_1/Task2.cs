using System;

namespace lab_1
{
    internal class Task2
    {
        static void Main1(string[] args)
        {
            Console.Write("X1? "); double X1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Y1? "); double Y1 = Convert.ToDouble(Console.ReadLine());

            bool res = (Y1 - X1 <= 2 && Y1 + X1 <= 2 && Y1 >= 0);
            Console.WriteLine(res);


        }
    }
}
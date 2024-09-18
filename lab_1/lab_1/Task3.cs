using System;

namespace lab_1
{
    internal class Task3
    {
        static void Main1(string[] args)
        {
            int A = 1000;
            float floatB = 0.0001f;
            double doubleB = 0.0001;

            var resFloat = (Math.Pow(A + floatB, 2) - (Math.Pow(A,2) + 2*A*floatB)) / Math.Pow(floatB, 2);

            var resDouble = (Math.Pow(A + doubleB, 2) - (Math.Pow(A, 2) + 2 * A * doubleB)) / Math.Pow(doubleB, 2);

            Console.WriteLine("float = " + resFloat);
            Console.WriteLine("double = " + resDouble);
        }
    }
}
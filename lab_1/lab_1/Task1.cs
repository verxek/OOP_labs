using System;

namespace lab_1
{
    internal class Task1
    {
        static void Main(string[] args)
        {
            double m, n, forUsingM, forUsingN, x;
            Console.Write("m? "); m = Convert.ToDouble(Console.ReadLine());
            Console.Write("n? "); n = Convert.ToDouble(Console.ReadLine());
            Console.Write("x? "); x = Convert.ToDouble(Console.ReadLine());


            void SetUsingVariables(double setM,double setN) // установка изначальных значений  m и n 
            {
                forUsingM = setM;
                forUsingN = setN;
            }

            void Res1(double m1, double n1)  // 1)
            {
                SetUsingVariables(m1, n1);
                if (forUsingN == 0) //  на ноль делить нельзя
                    Console.WriteLine("Нельзя вычислить");
                else
                {
                    Console.Write("1) m = " + m1 + " n = " + n1 + "    m++ / n-- = ");
                    double res1 = forUsingM++ / forUsingN--;
                    Console.WriteLine(Convert.ToString(res1));
                }
            }
            
            void Res2(double m1, double n1)
            {
                SetUsingVariables(m1, n1);
                bool res2 = ++forUsingM < forUsingN--;
                Console.WriteLine("2) m = " + m + " n = " + n + "    ++m < n-- = " + res2);

            }


            void Res3(double m1, double n1)
            {
                SetUsingVariables(m1, n1);
                bool res3 = forUsingN-- > forUsingM;
                Console.WriteLine("3) m = " + m + " n = " + n + "    n-- > m = " + res3);
            }
            
            void Res4(double m1, double n1)
            {
                SetUsingVariables(m1, n1);
                double res4 = Math.Pow(Math.Sin(x), 3) + Math.Pow(x, 4) + Math.Pow((x * x + x * x * x), 0.2);
                Console.WriteLine("4) x = " + x + "   sinx^3 + x^4 + (x^2 + x^3)^0.2 = " + res4);
            }

            Res1(m, n);
            Res2(m, n);
            Res3(m, n);
            Res4(m, n);

        }
    }
}

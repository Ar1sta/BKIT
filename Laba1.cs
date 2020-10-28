using System;

namespace Laba_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int  A=0, B, C;
            Console.WriteLine("Гришин Станислав Васильевич ИУ5-31Б");
            while (A == 0)
            {
                Console.Write("A:");
                A = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("B:");
            B = Convert.ToInt32(Console.ReadLine());
            Console.Write("C:");
            C = Convert.ToInt32(Console.ReadLine());
            if (B * B - 4 * A * C < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет"); 
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Корни биквадратного уравнения:");
                double x1, x2, x3, x4;
                if ((((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A)) >= 0)&&(((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A)) >= 0)&& (((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A)) >= 0))
                {
                    x1 = -Math.Sqrt((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    x2 = Math.Sqrt((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    x3 = -Math.Sqrt((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    x4 = Math.Sqrt((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("x1=" + x1);
                    Console.WriteLine("x2=" + x2);
                    Console.WriteLine("x3=" + x3);
                    Console.WriteLine("x4=" + x4);
                    Console.ResetColor();
                }
                else if ((((-B + Math.Sqrt(B * B - 4 * A * C)) / 2 * A)<0)&& (((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A)) >= 0))
                {
                    x3 = -Math.Sqrt((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    x4 = Math.Sqrt((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("x1=" + x3);
                    Console.WriteLine("x2=" + x4);
                    Console.ResetColor();
                }
                else if ((((-B - Math.Sqrt(B * B - 4 * A * C)) / (2 * A)) < 0)&& (((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A)) >= 0))
                {
                    x1 = -Math.Sqrt((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    x2 = Math.Sqrt((-B + Math.Sqrt(B * B - 4 * A * C)) / (2 * A));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("x1=" + x1);
                    Console.WriteLine("x2=" + x2);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет");
                    Console.ResetColor();
                }
            }
        }
    }
}

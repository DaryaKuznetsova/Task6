using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static double sum(int i, double a1, double a2, double a3)
        {
            double result=0;
            if (i == 2) return a3;
            if (i == 1) return a2;
            if (i == 0) return a1;
            result = (sum(i - 1, a1, a2, a3) + 1) / (sum(i - 2, a1, a2, a3) + 2) * sum(i - 3, a1, a2, a3);
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Номер последнего элемента последовательности: "); int n = ReadAnswer();
            double[] mas = new double[n];
            Console.Write("Первый элемент последовательности: "); mas[0] = ReadAnswerD();
            Console.Write("Второй элемент последовательности: "); mas[1] = ReadAnswerD();
            Console.Write("Третий элемент последовательности: "); mas[2] = ReadAnswerD();
            try
            {
                for (int i = 0; i < 3; i++)
                    Console.WriteLine(mas[i]);
                for (int i = 3; i < n; i++)
                {
                    mas[i] = sum(i, mas[0], mas[1], mas[2]);
                    Console.WriteLine(mas[i]);
                }
                int k=2;
                bool equal = false;
                bool ex = false;
                double max = mas[0];
                for (int i=0; i<n;i++)
                {
                    if (mas[i] >= max)
                    {
                        if (mas[i] == max)
                            equal = true;
                        max = mas[i];
                        ex = true;
                    }
                    else
                    {
                        ex = false;
                        break;
                    }
                     
                }
                if (ex&&!equal)
                    Console.WriteLine("Последовательность строго возрастающая");
                else if(ex) Console.WriteLine("Последовательность монотонно неубывающая");
            }
            catch(StackOverflowException)
            {
                Console.WriteLine("Очень жаль, что стек переполнился");
            }
        }
        public static int ReadAnswer()
        {
            int a = 0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToInt32(Console.ReadLine());
                    if(a>=0)
                    ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите целое число.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }

        public static double ReadAnswerD()
        {
            double a = 0;
            bool ok = false;
            do
            {
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                        ok = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Пожалуйста, введите число.");
                    ok = false;
                }
            } while (!ok);
            return a;
        }

    }
}

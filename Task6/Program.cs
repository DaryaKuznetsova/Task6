using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Первый элемент последовательности: "); arr.Add(ReadAnswerD());
            double s = 0;
            do
            {
                Console.Write("Второй элемент последовательности: "); // ограничим ввод -2 для соблюдения ОДЗ
                s = ReadAnswerD(); ;
            }
            while (s == -2);
            arr.Add(s);
            Console.Write("Третий элемент последовательности: "); arr.Add(ReadAnswerD());
            Console.Write("Номер последнего элемента последовательности: "); int n = ReadAnswer();
            bool ok = true;

            for (int i = 3; i < n; i++)
                try
                {
                    s = Item(i, arr); // найдем следующие элементы последовательности
                }
                 catch(DivideByZeroException )
                {
                    ok = false;
                    break;
                }
            if (ok)
            {

                DPrint(arr, n);

                switch (Decide(arr, n))
                {
                    case 1:
                        Console.WriteLine("Последовательность возрастает");
                        break;
                    case 0:
                        Console.WriteLine("Последовательность не убывает");
                        break;
                    default:
                        Console.WriteLine("Последовательноcть общего вида или убывает");
                        break;
                }
            }
            else
                Console.WriteLine("К сожалению, произошло деление на 0");
        }

        public static void DPrint(List<double> mas, int n)
        {
            bool ok = false;
            do
            {
                Console.WriteLine("Вывести последовательность?\n 1. Да\n 0. Нет");
                switch (ReadAnswer())
                {
                    case 1:
                        Print(mas, n);
                        ok = true;
                        break;
                    case 0:
                        ok = true;
                        break;
                    default:
                        ok = false; ;
                        break;
                }
            } while (!ok);

        }

        public static int Decide(List<double> mas, int n)
        {
            if (n < 2) return -1;
            bool equal = false;
            bool ex = false;
            double max = Double.MinValue;
            for (int i = 0; i < n; i++)
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
            if (ex && !equal)
                return 1;
            else if (ex) return 0;
            else return -1;
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
                    if (a >= 0&&a<=1000000)
                        ok = true;
                    else Console.WriteLine("Пожалуйста, введите целое число больше 0 и меньше 1000000");
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

        static List<double> arr = new List<double>();

        static double Item(int i, List<double> arr)
        {
            try
            {
                return arr[i]; 
            }
            catch(Exception)
            {
                double s = (Item(i - 1, arr) + 1) / (Item(i - 2, arr) + 2) * Item(i - 3, arr);
                {                   
                    if (s == -2) // если хотя бы один элемент в стеке, который будет в знаменателе =-2
                    {
                        throw new DivideByZeroException();
                    }
                    else
                        arr.Add(s);
                }                
                return arr[i];
            }
        }

        static void Print(List<double> arr, int n)
        {
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.WriteLine(arr[i]);
        }

    }
}

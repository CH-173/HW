using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distinction
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Введите количество элементов массива:");
                try
                {
                    int arrLength = int.Parse(Console.ReadLine());
                    if (arrLength < 0)
                    {
                        Console.WriteLine("Количество элементов массива не может быть отрицательным числом!");
                    }
                    else if (arrLength == 0)
                    {
                        Console.WriteLine("Количество элементов массива не может равняться нулю!");
                    }
                    else
                    {
                        int[] Elements = new int[arrLength];
                        Console.WriteLine("Введите целочисленные элементы массива (по одному) в порядке возрастания");
                        for (int i = 0; i < arrLength; i++)
                        {
                            Elements[i] = int.Parse(Console.ReadLine());
                        }
                        bool allRight = true;
                        for (int f = 1; f < arrLength; f++)
                        {
                            if (Elements[f] < Elements[f - 1])
                            {
                                allRight = false;
                                break;
                            }
                        }
                        if (allRight == true)
                        {
                            int distinction = 1;
                            for (int t = 1; t < arrLength; t++)
                            {
                                if (Elements[t] != Elements[t - 1])
                                {
                                    distinction++;
                                }
                            }
                            Console.WriteLine("В массиве " + distinction + " уникальных элементов.");
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели элементы не в порядке возрастания!");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Вы ввели не целое число элементов массива либо не целочисленный элемент массива!");
                }
            } 
            while (true);

            // Сложность алгоритма равна O(n)
        }
    }
}

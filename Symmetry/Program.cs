using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symmetry
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.WriteLine("Введите размер квадратной матрицы (ширина и высота):");
                    int size = int.Parse(Console.ReadLine());
                    if (size < 0)
                    {
                        Console.WriteLine("Ошибка! Вы ввели отрицательное значение!");
                    }
                    else if (size == 0)
                    {
                        Console.WriteLine("Ошибка! Вы ввели нулевое значение!");
                    }
                    else
                    {
                        double[,] Matrix = new double[size, size];
                        for (int i = 0; i < size; i++)
                        {
                            Console.WriteLine("Введите числовые элементы " + (i + 1) + "-го ряда массива (по одному!):");
                            for (int t = 0; t < size; t++)
                            {
                                Matrix[i, t] = double.Parse(Console.ReadLine());
                            }
                        }
                        bool isSymmetric = true;
                        for (int a = 0; a < size; a++)
                        {
                            for (int b = 0; b < size; b++)
                            {
                                if (Matrix[a, b] != Matrix[b, a])
                                {
                                    isSymmetric = false;
                                }
                            }
                        }
                        switch (isSymmetric)
                        {
                            case false:
                                Console.WriteLine("Матрица, заданная вами, не симметрична!");
                                break;
                            default:
                                Console.WriteLine("Матрица, заданная вами, симметрична!");
                                break;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введенный вами размер квадратной матрицы не является целым числом, либо один из элементов матрицы не является числом.");
                }
            }
            while (true);

            // Сложность алгоритма равна O(N^2)
        }
    }
}

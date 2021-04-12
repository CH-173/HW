using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[50];
            Random randElem = new Random();
            startPoint:
            for (int i = 0; i < 50; i++)
            {
                numbers[i] = randElem.Next(0, 25);
            }
            Console.WriteLine("Для вывода элементов массива на экран нажмите любую клавишу...");
            Console.ReadKey();
            Console.WriteLine("Список элементов массива:");
            foreach (int elem in numbers)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("Для вывода максимального и минимального элементов массива на экран нажмите любую клавишу...");
            Console.ReadKey();
            var sortedNumbers = numbers.OrderBy(number => number);
            var min = sortedNumbers.First(); 
            var max = sortedNumbers.Last();
            Console.WriteLine("Минимальный элемент массива: " + min);
            Console.WriteLine("Максимальный элемент массива: " + max);
            Console.WriteLine("Для вывода числа различных элементов массива на экран нажмите любую клавишу...");
            Console.ReadKey();
            IEnumerable<int> distinctNumbers = numbers.Distinct();
            int countDistinctNumbers = distinctNumbers.Count();
            Console.WriteLine("В массиве " + countDistinctNumbers + " различающихся элементов.");
            Console.WriteLine("Для вывода списка элементов, значения которых варьируют от 10 до 20, в порядке убывания, нажмите любую клавишу...");
            Console.ReadKey();
            List<int> selectedDistinctNumbers = new List<int>();
            foreach (int elem in distinctNumbers)
            {
                if ((elem >= 10) & (elem <= 20))
                {
                    selectedDistinctNumbers.Add(elem);
                }
            }
            var sortedSelectedDistinctNumbers = selectedDistinctNumbers.OrderByDescending(distnumber => distnumber);
            foreach (int elem in sortedSelectedDistinctNumbers)
            {
                Console.WriteLine(elem);
            }
            Console.WriteLine("Для возвращения к началу, нажмите клавишу 1, для выхода из программы нажмите клавишу 2...");
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        goto startPoint;
                    default: continue;
                }
            } while (key != ConsoleKey.D2);
            Console.WriteLine("Удачи!");
        }
    }
}

using System;
using System.Collections.Generic;


namespace Post
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Введите длительность работы почты (в минутах):");
                    int time = int.Parse(Console.ReadLine());
                    if (time > 0)
                    {
                    Number:
                        Console.WriteLine("Введите число посетителей:");
                        int numberOfVisitors = int.Parse(Console.ReadLine());
                        if (numberOfVisitors > 0)
                        {
                            Console.WriteLine("Введите для каждого посетителя время (в минутах), необходимое для его обслуживания:");
                            Queue<int> timeOfVisitors = new Queue<int>();
                            for (int i = 0; i < numberOfVisitors; i++)
                            {
                                Console.WriteLine("Введите время для " + (i + 1) + "-го посетителя:");
                                int a = int.Parse(Console.ReadLine());
                                if (a > 0)
                                {
                                    timeOfVisitors.Enqueue(a);
                                }
                                else
                                {
                                    Console.WriteLine("Время, отведенное на обслуживание посетителя, должно быть больше нуля! Введите повторно!");
                                    i--;
                                }
                            }
                            do
                            {
                                time = time - timeOfVisitors.Dequeue();
                                if (timeOfVisitors.Count == 0)
                                {
                                    break;
                                }
                            }
                            while (time >= 0);
                            switch (timeOfVisitors.Count)
                            {
                                case 0:
                                    Console.WriteLine("Все посетители получат посылки!");
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.WriteLine("Уйдут без посылки " + timeOfVisitors.Count + " человек.");
                                    Console.WriteLine("Нажмите любую клавишу...");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                        else if (numberOfVisitors == 0)
                        {
                            Console.WriteLine("Число посетителей не может равняться нулю! Попробуйте снова!");
                            goto Number;
                        }
                        else
                        {
                            Console.WriteLine("Число посетителей не может быть отрицательным числом! Попробуйте снова!");
                            goto Number;
                        }
                    }
                    else if (time == 0)
                    {
                        Console.WriteLine("Время работы почты не может равняться нулю! Попробуйте снова!");
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Время работы почты не может быть отрицательным числом! Попробуйте снова!");
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка! Возможно, вы ввели нецелое число (либо не число). Попробуйте снова!");
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
            while (true);
        }
    }
}

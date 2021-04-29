using System;
using System.Collections.Generic;
using System.IO;

namespace TVSales_Library
{
    public class Producer
    {
        public string Name { get; set; }
        public string Resume { get; set; }
        public void PrintProducer()
        {
            Console.WriteLine($"{Name} {Resume}");
        }

        public Producer(string name, string resume)
        {
            Name = name;
            Resume = resume;
        }
    }

    public class TV
    {
        public string Name { get; set; }
        public string Producer_Name { get; set; }
        public string Resume { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public void PrintTV()
        {
            Console.WriteLine($"{Name} {Producer_Name} {Resume} {Price} {Quantity}");
        }

        public TV(string name, string producer_name, string resume, double price, int quantity)
        {
            Name = name;
            Producer_Name = producer_name;
            Resume = resume;
            Price = price;
            Quantity = quantity;
        }

    }

    public static class DataBase
    {
        public static string ProducerPath { get; set; } = "Producers.txt";
        public static string TVPath { get; set; } = "TVs.txt";
        public static bool SaveProducers(List<Producer> producers)
        {
            StreamWriter fileIn;
            try
            {
                fileIn = new StreamWriter(ProducerPath);
                foreach (var elem in producers)
                {
                    fileIn.WriteLine(elem.Name);
                    fileIn.WriteLine(elem.Resume);
                }
                fileIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
                return false;
            }
            return true;
        }

        public static bool SaveTVs(List<TV> tvs)
        {
            StreamWriter fileIn;
            try
            {
                fileIn = new StreamWriter(TVPath);
                foreach (var elem in tvs)
                {
                    fileIn.WriteLine(elem.Name);
                    fileIn.WriteLine(elem.Producer_Name);
                    fileIn.WriteLine(elem.Resume);
                    fileIn.WriteLine(elem.Price);
                    fileIn.WriteLine(elem.Quantity);
                }
                fileIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
                return false;
            }
            return true;
        }

        public static List<Producer> LoadProducers()
        {
            List<Producer> producers = new List<Producer>();
            StreamReader fileOut;
            try
            {
                if (File.Exists(ProducerPath))
                {
                    fileOut = new StreamReader(ProducerPath);
                    while (!fileOut.EndOfStream)
                    {
                        string name = fileOut.ReadLine();
                        string resume = fileOut.ReadLine();
                        producers.Add(new Producer(name, resume));
                    }
                    fileOut.Close();
                }
                else
                    throw new Exception("Файла не существует!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
                return null;
            }
            return producers;
        }

        public static List<TV> LoadTVs()
        {
            List<TV> tvs = new List<TV>();
            StreamReader fileOut;
            try
            {
                if (File.Exists(TVPath))
                {
                    fileOut = new StreamReader(ProducerPath);
                    while (!fileOut.EndOfStream)
                    {
                        string name = fileOut.ReadLine();
                        string producer_name = fileOut.ReadLine();
                        string resume = fileOut.ReadLine();
                        double price = int.Parse(fileOut.ReadLine());
                        int quantity = int.Parse(fileOut.ReadLine());
                        tvs.Add(new TV(name, producer_name, resume, price, quantity));
                    }
                    fileOut.Close();
                }
                else
                    throw new Exception("Файла не существует!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
                return null;
            }
            return tvs;
        }
    }
    public class GeneralMenu
    {
        static public string[] MenuStrings =
        {
            "1 - Войти как Пользователь",
            "2 - Войти как Администратор",
            "3 - Выход из программы"
        };

        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт меню:");
            foreach (var menuString in MenuStrings)
            {
                Console.WriteLine(menuString);
            }
        }
        public static void Start()
        {

            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        UserMenu.Start();
                        break;
                    case ConsoleKey.D2:
                        AdminMenu.Start();
                        break;
                    default:
                        continue;
                }
            }
            while (key != ConsoleKey.D3);
            Environment.Exit(0);
        }
    }

    public class AdminMenu
    {
        static public string[] MenuStrings =
        {
            "1 - Просмотр списка производителей",
            "2 - Просмотр списка товаров",
            "3 - Назад",
            "4 - Выход"
        };

        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт меню:");
            foreach (var menuString in MenuStrings)
            {
                Console.WriteLine(menuString);
            }
        }
        public static void Start()
        {

            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        //здtсь будет меню манипуляций с производителями
                        break;
                    case ConsoleKey.D2:
                        //здесь будет меню манипуляций с товарами
                        break;
                    case ConsoleKey.D3:
                        GeneralMenu.Start();
                        break;
                    default:
                        continue;
                }
            }
            while (key != ConsoleKey.D4);
            Environment.Exit(0);
        }
    }

    public class UserMenu
    {
        static public string[] MenuStrings =
        {
            "1 - Сортировать по названию",
            "2 - Сортировать по возрастанию цены",
            "3 - Сортировать по убыванию цены",
            "4 - Фильтр по производителю",
            "5 - Посмотреть товары в наличии",
            "6 - Купить товар",
            "7 - Выход"
        };

        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт меню:");
            foreach (var menuString in MenuStrings)
            {
                Console.WriteLine(menuString);
            }
        }
        public static void Start()
        {

            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                List<TV> tvs = DataBase.LoadTVs();
                if (tvs == null)
                    Console.WriteLine("Список товаров пуст.");
                foreach (var elem in tvs)
                {
                    elem.PrintTV();
                }
                PrintMenu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        //здесь будет возможность сортировки товаров по названию
                        break;
                    case ConsoleKey.D2:
                        //здесь будет возможность сортировки товаров по возрастанию цены
                        break;
                    case ConsoleKey.D3:
                        //здесь будет возможность сортировки товаров по убыванию цены
                    case ConsoleKey.D4:
                        //здесь будет возможность отобрать из списка товары с нужным производителем
                    case ConsoleKey.D5:
                        //здесь будет возможность вывести список товаров в наличии
                    case ConsoleKey.D6:
                        //здесь будет реализована покупка товара
                        break;
                    default:
                        continue;
                }
            }
            while (key != ConsoleKey.D7);
            Environment.Exit(0);
        }
    }

}

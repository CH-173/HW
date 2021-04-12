using System;
using System.Collections.Generic;

namespace Formats
{
    class Program
    {
        static public string[] MenuStrings =
                {
            "1 - Вывести список форматов на экран",
            "2 - Добавить новый формат",
            "3 - Удалить формат",
            "4 - Найти формат",
            "5 - Выйти из программы"
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
        static public void PrintDictionary(Dictionary<string, string> dictionary)
        {
            Console.Clear();
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Список форматов пуст.");
            }
            else
            {
                foreach (KeyValuePair<string, string> elem in dictionary)
                {
                    Console.WriteLine(elem);
                }
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void SetElem(Dictionary<string, string> dictionary)
        {
            try
            {
                Console.Clear();
                Console.Write("Введите короткое наименование формата: ");
                string shortName = Console.ReadLine();
                while (shortName.Trim() == "")
                {
                    Console.Write("Попробуйте снова ввести наименование: ");
                    shortName = Console.ReadLine();
                }
                FullName:
                Console.Write("Введите полное наименование формата: ");
                string longName = Console.ReadLine();
                if (longName == "")
                {
                    Console.WriteLine("Вы ввели пустое значение! Попробуйте снова!");
                    goto FullName;
                }
                else
                {
                    dictionary.Add(shortName, longName);
                    Console.Write("Элемент успешно добавлен!");
                    Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
            catch
            {
                Console.WriteLine("Такой формат уже существует!");
                Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        static public void RemoveElem(Dictionary<string, string> dictionary)
        {
            Console.Clear();
            EmptyShortName:
            Console.Write("Введите короткое наименование формата: ");
            string shortName = Console.ReadLine();
            if (shortName != "")
            {
                if (dictionary.ContainsKey(shortName))
                {
                    dictionary.Remove(shortName);
                    Console.Write("Элемент успешно удален!");
                }
                else
                {
                    Console.Write("Такого элемента не существует!");
                }
            }
            else
            {
                Console.WriteLine("Вы ничего не ввели! Попробуйте снова!");
                goto EmptyShortName;
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static public void FindElem(Dictionary<string, string> dictionary)
        {
            Console.Clear();
            EmptyName:
            Console.Write("Введите короткое наименование формата: ");
            string shortName = Console.ReadLine();
            if (shortName != "")
            {
                if (dictionary.ContainsKey(shortName))
                {
                    Console.WriteLine(dictionary[shortName]);
                }
                else
                {
                    Console.Write("Такого элемента не существует!");
                }
            }
            else
            {
                Console.WriteLine("Вы ничего не ввели! Попробуйте снова!");
                goto EmptyName;
            }
            Console.WriteLine("Для прехода в меню нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> formats = new Dictionary<string, string>();
            formats.Add(".png", "portable network graphics");
            formats.Add(".tmp", "temporary file");
            formats.Add(".db", "database file");
            formats.Add(".txt", "text file");
            formats.Add(".exe", "executable file");
            ConsoleKey key = ConsoleKey.Enter;
            do
            {
                PrintMenu();
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        PrintDictionary(formats);
                        break;
                    case ConsoleKey.D2:
                        SetElem(formats);
                        break;
                    case ConsoleKey.D3:
                        RemoveElem(formats);
                        break;
                    case ConsoleKey.D4:
                        FindElem(formats);
                        break;
                    default:
                        continue;
                }
            }
            while (key != ConsoleKey.D5);
            Environment.Exit(0);
        }
    }
}

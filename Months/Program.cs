using System;

namespace Months
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
                int monthNum = 0;
                Console.WriteLine("Введите порядковый номер месяца: ");
                monthNum = int.Parse(Console.ReadLine());
                monthNum--;
                Console.WriteLine(months[monthNum]);
            } while (true);
        }
    }
}

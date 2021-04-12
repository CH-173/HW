using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coordinates
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0, y = 0, step;
            double distance;
            for (step = 0; step < 10; step++)
            {
                Console.WriteLine("Введите координату (С / Ю / З / В): ");
                char way = char.Parse(Console.ReadLine());
                switch (way)
                {
                    case 'С':
                    case 'с':
                        y++;
                        break;
                    case 'Ю':
                    case 'ю':
                        y--;
                        break;
                    case 'З':
                    case 'з':
                        x--;
                        break;
                    case 'В':
                    case 'в':
                        x++;
                        break;
                }
            }
            
            distance = Math.Sqrt(x * x + y * y);
            Console.WriteLine("Расстояние от начала координат до точки составляет " + distance + " метров.");
            Console.ReadKey();
        }
    }
}

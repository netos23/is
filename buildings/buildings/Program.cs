using System;
using System.Collections.Generic;

namespace buildings
{
    internal class Program
    {
        private static Random _random = new Random();
        private static List<IBuilding> _buildings;
        private static double _money;

        public static void Main(string[] args)
        {
            
            _buildings = new List<IBuilding>();

            for (int i = 0; i < 10; i++)
            {
                _buildings.Add(new Theatre(
                    _random.Next(minValue: 1000000, maxValue: 1999999999),
                    1,
                    0.5 + 0.5 * _random.NextDouble(),
                    new Location(_random.NextDouble() * 60, _random.NextDouble() * 60),
                    null,
                    Guid.NewGuid().ToString(),
                    "Главный театр",
                    "Муниципальный"
                ));
            }
            
            var methods = new Action[3];

            methods[0] = Repair;
            methods[1] = Upgrade;
            methods[2] = PrintHelp;

            int chose = 0;
            do
            {
                try
                {
                    _money = _random.Next(minValue: 90000000, maxValue: 900000000);
                    PrintMoney(_money);
                    _buildings.ForEach(Console.WriteLine);
                    PrintHelp();
                    chose = (Math.Abs(ReadInt()) % methods.Length) - 1;
                    methods[chose].Invoke();

                }
                catch (Exception _)
                {
                    Console.WriteLine("Вы что то сделали не так посмотрите помощь и попробуйте снова");
                }
            } while (chose != -1);
        }

        private static void PrintMoney(double money)
        {
            Console.WriteLine($"You have at least {money}");
        }    
        
        
        private static void Upgrade()
        {
            foreach (var b in _buildings)
            {
                try
                {
                    b.Upgrade(_money);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
              
            }
        }
        
        private static void Repair()
        {
            foreach (var b in _buildings)
            {
                try
                {
                    b.Repair(_money);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
              
            }
        }

        private static int ReadInt(int defaultValue = 4)
        {
            int n;
            try
            {
                n = int.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception _)
            {
                Console.WriteLine($"Введено неверное число, исспользуется значение поумолчанию: {defaultValue}");
                n = defaultValue;
            }

            return n;
        }

        public static void PrintHelp()
        {
            Console.WriteLine(
                "0 - Выход\n" +
                "1 - Починить\n" +
                "2 - Повысить\n" +
                "Выбор >"
            );
        }
    }
}
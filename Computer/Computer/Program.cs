using System;
using System.Collections.Generic;

namespace Computer
{
    internal class Program
    {
        private static List<MacBook> list = new List<MacBook>();

        public static void Main(string[] args)
        {
            var methods = new Action[5];

            methods[0] = ReadMacbook;
            methods[1] = ReadProMacbook;
            methods[2] = PrintAll;
            methods[3] = PrintHelp;

            var chose = 3;

            do
            {
                try
                {
                    methods[chose].Invoke();
                    chose = ReadInt() - 1;
                }
                catch (Exception _)
                {
                    Console.WriteLine("Вы что то сделали не так посмотрите помощь и попробуйте снова");
                }
            } while (chose != -1);
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

        private static double ReadDouble(double defaultValue = 4)
        {
            double n;
            try
            {
                n = double.Parse(Console.ReadLine() ?? "");
            }
            catch (Exception _)
            {
                Console.WriteLine($"Введено неверное число, исспользуется значение поумолчанию: {defaultValue}");
                n = defaultValue;
            }

            return n;
        }

        private static void PrintAll()
        {
            list.ForEach(Console.WriteLine);
        }


        private static (string name, double frequency, int ram) ReadMacbookBase()
        {
            Console.WriteLine("Введите имя процессора:");
            var name = Console.ReadLine();
            Console.WriteLine("Введите частоту:");
            var frequency = ReadDouble(2.5);
            Console.WriteLine("Введите количество оперативной памяти:");
            var ram = ReadInt(4096);
            return (name, frequency, ram);
        }

        private static void ReadProMacbook()
        {
            var (name, frequency, ram) = ReadMacbookBase();
            Console.WriteLine("Введите количество размер винчестера:");
            var rom = ReadInt(256);

            list.Add(new MacBookPro(name, frequency, ram, rom));
        }

        private static void ReadMacbook()
        {
            var (name, frequency, ram) = ReadMacbookBase();
            list.Add(new MacBook(name, frequency, ram));
        }

        private static void PrintHelp()
        {
            Console.WriteLine(
                "0 - Выход\n" +
                "1 - Добавить Macbook\n" +
                "2 - Добавить Pro Macbook\n" +
                "3 - Показать все Mackbook\n" +
                "4 - Показать помощь\n" +
                "Выбор >"
            );
        }
    }
}
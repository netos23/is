using System;

namespace chess_matrix
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            var n = ReadInt();

            var matrix = ChessMatrix.CreateMatrix(n);
            Console.WriteLine("Полученная матрица:");
            PrintMatrix(matrix);
        }

        private static int ReadInt(int defaultValue = 3)
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

        private static void PrintMatrix(
            int[][] matrix,
            string horizontalSeparator = " ",
            string verticalSeparator = "\r\n"
        )
        {
            foreach (var row in matrix)
            {
                foreach (var element in row)
                {
                    Console.Write(element);
                    Console.Write(horizontalSeparator);
                }

                Console.Write(verticalSeparator);
            }
        }
    }
}
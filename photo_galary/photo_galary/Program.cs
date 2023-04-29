using System;

namespace photo_galary
{
    internal class Program
    {
        private static PhotoGallery _gallery;

        public static void Main(string[] args)
        {
            var format = new PageConfiguration(15.0, 10.0, 2, 2);
            _gallery = new PhotoGallery(100, format);

            var methods = new Action[5];

            methods[0] = PrintCount;
            methods[1] = PrintAddSubmenu;
            methods[2] = PrintNameSubmenu;
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

        private static byte[] GeneratePicture()
        {
            var random = new Random();
            byte[] buffer = new byte[1000];
            for (var i = 0; i < 1000; i++)
            {
                buffer[i] = (byte) (byte.MaxValue * random.NextDouble());
            }

            return buffer;
        }

        public static void PrintCount()
        {
            Console.WriteLine(
                $"Количество изображений в альбоме: {_gallery.GetPictureCount()}"
            );
        }

        public static void PrintNameSubmenu()
        {
            var (page, r, c) = GetPosition();
            Console.WriteLine(
                $"Введите имя > "
            );

            var photo = _gallery[page][r][c];
            photo.Name = Console.ReadLine();
        }

        private static (int page, int r, int c) GetPosition()
        {
            Console.WriteLine(
                "Выбирете страницу"
            );

            var page = ReadInt();

            Console.WriteLine(
                "Выбирете позицию по горизонтале"
            );
            var r = ReadInt();

            Console.WriteLine(
                "Выбирете позицию по вертикале"
            );
            var c = ReadInt();

            return (page, r, c);
        }

        public static void PrintAddSubmenu()
        {
            var random = new Random();
            var (page, r, c) = GetPosition();
            var builder = new Photo.PhotoBuilder()
                .SetHeight(10)
                .SetWidth(15)
                .SetName($"Picture {random.Next()}")
                .SetType(PaperType.Glossy)
                .SetData(GeneratePicture())
                .SetQuality(10);

            _gallery[page][r][c] = builder.Build();
        }


        public static void PrintHelp()
        {
            Console.WriteLine(
                "0 - Выход\n" +
                "1 - Количество фото\n" +
                "2 - Добавть фото\n" +
                "3 - Переименовать фото\n" +
                "4 - Показать помощь\n" +
                "Выбор >"
            );
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
    }
}
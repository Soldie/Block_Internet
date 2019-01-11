namespace IEque
{
    using System;

    internal static class Program
    {
        private static void Main()
        {
            Console.Title = "Internet Fake Proxy by Antlion";
            Console.WriteLine("0 - Разблокирует | 1 - Блокирует выход в интернет");
            do
            {
                Console.Write("Выберите пункт: ");
                try
                {
                    switch (Convert.ToInt16(Console.ReadLine()))
                    {
                        case 0: BlockIE.Enabled(0); break; // Unlock IE
                        case 1: BlockIE.Enabled(1); break; // Block IE
                        default: Console.Clear(); Main(); break; 
                    }
                }
                catch { Console.Clear(); Main(); }
            }
            while (!int.TryParse(Console.ReadLine(), out int a));
        }
    }
}
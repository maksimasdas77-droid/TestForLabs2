using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForLabs2.Input;
using TestForLabs2.Menu;

namespace TestForLabs2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");



            bool running = true;
            while (running)
            {
                Menu.MainMenu.ShowMainMenu();


                int choice = ReadClass.ReadValue<int>(int.TryParse);

                switch (choice)
                {
                    case 0:
                        Console.WriteLine("завершение программы");
                        running = false;
                        break;

                    case 1:
                        Console.Clear();

                        break;

                    case 2:
                        Console.Clear();

                        break;

                    case 3:
                        Console.Clear();

                        break;

                    case 4:
                        Console.Clear();

                        break;

                    case 5:
                        Console.Clear();

                        break;

                    case 6:
                        Console.Clear();

                        break;

                    default:
                        Console.WriteLine("Не правильный пункт меню.");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForLabs2.Input;
using TestForLabs2.Menu;
using TestForLabs2.Utills;

namespace TestForLabs2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            CultureInfo.CurrentUICulture = new CultureInfo("ru-RU");
            CarManager manager = new CarManager(); //создание объекта кар менеджер для выполнения его функций
            Utills.Utill utils = new Utills.Utill(manager); //что бы работали методы из Utills (теперь все методы из Utills.Utill вызываются через utils.(название метода)


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
                        if (!Utill.CheckCars(manager.Cars))
                        {
                            Console.ReadLine();
                            break;
                        }
                        manager.ShowCars();
                        Console.Write("Выберите автомобиль(0 - возврат в основное меню): ");
                        //int carIndex = ReadClass.ReadValueWithCondition<int>(int.TryParse, x => x >= 1 && x <= manager.Cars.Count, $"Введите число от 1 до {manager.Cars.Count}: ");
                        int carIndex = ReadClass.ReadValue<int>(int.TryParse);
                        if(carIndex == 0)
                        {
                            break;
                        } else if(carIndex < 0 || carIndex > manager.Cars.Count)
                        {
                            Console.WriteLine("Нет такого автомобиля");
                            Console.ReadLine();
                            break;
                        }
                            utils.ShowCarSubMenu(carIndex - 1);
                        break;

                    case 2:
                        Console.Clear();
                        utils.AddCar();
                        break;

                    case 3:
                        Console.Clear();
                        //Console.WriteLine("Введите номер автомобиля для удаления");
                        manager.ShowCars();
                        utils.RemoveCar();
                        break;

                    case 4:
                        Console.Clear();
                        utils.UpdateCar();
                        break;

                    case 5:
                        Console.Clear();
                        manager.SaveToFile();
                        Console.ReadLine();
                        break;

                    case 6:
                        Console.Clear();
                        manager.LoadFromFile();
                        Console.ReadLine();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForLabs2;
using TestForLabs2.Classes;
using TestForLabs2.Input;


namespace TestForLabs2.Utills
{
    internal class Utill
    {
        private CarManager manager; //для вызова методов из менеджера

        public Utill(CarManager manager) 
        {
            this.manager = manager;
        }

        public static bool CheckCars(List<Car> Cars) //вызывать потом Utill.CheckCars(Cars);
        {
            if (!Cars.Any())
            {
                Console.WriteLine("Список техники пуст.");
                return false;
            }
            return true;
        }
        public void AddCar() //обложка метода из менеджера для добавления в мейне
        {
            Console.WriteLine("добавление автомобиля");
            Car newCar = new Car();

            Console.Write("Введите название автомобиля: ");
            newCar.Name = Console.ReadLine();

            Console.Write("Введите гос.номер автомобиля: "); 
            newCar.Number = Console.ReadLine();

            Console.Write("Введите года автомобиля: ");
            newCar.Year = Input.ReadClass.ReadValue<int>(int.TryParse);

            Console.Write("Введите владельца автомобиля: ");
            newCar.Owner = Console.ReadLine();

            manager.AddCar(newCar);

        }

        public void RemoveCar()
        {
            if (manager.Cars.Any())
            {
                int index = ReadClass.ReadValueWithCondition<int>(
                    int.TryParse,
                    x => x >= 1 && x <= manager.Cars.Count,
                    $"Введите число от 1 до {manager.Cars.Count}: ");
                manager.RemoveCar(index);
                Console.ReadLine();
            } else
            {
                Console.ReadLine();
            }
        }

        public void UpdateCar()
        {
            if (Utill.CheckCars(manager.Cars) == true)
            {
                manager.ShowCars();

                int index = ReadClass.ReadValueWithCondition<int>("Введите номер автомобиля для изменения: ",
                    int.TryParse, value => value >= 1 && value <= manager.Cars.Count,
                    "Нет такой машины. Попробуйте снова: ");

                Console.WriteLine("Редактирование автомобиля (ввод пустого значения для оставления без изменений)");
                Car oldCar = manager.Cars[index - 1]; //старый автомобиль
                Car newCar = new Car(); //новый автомобиль

                Console.Write($"Введите новое название автомобиля ({oldCar.Name}): ");
                string nametemp = Console.ReadLine();
                newCar.Name = string.IsNullOrWhiteSpace(nametemp) ? oldCar.Name : nametemp;

                Console.Write($"Введите новый гос.номер автомобиля ({oldCar.Number}): ");
                string numbertemp = Console.ReadLine();
                newCar.Number = string.IsNullOrWhiteSpace(numbertemp) ? oldCar.Number : numbertemp;

                Console.Write($"Введите новый год автомобиля ({oldCar.Year}): ");
                string yeartemp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(yeartemp))
                {
                    newCar.Year = oldCar.Year;
                }
                else
                {
                    newCar.Year = int.Parse(yeartemp);
                }


                Console.Write($"Введите нового владельца автомобиля ({oldCar.Owner}): ");
                string ownertemp = Console.ReadLine();

                newCar.Owner = string.IsNullOrWhiteSpace(ownertemp) ? oldCar.Owner : ownertemp;

                manager.UpdateCar(index, newCar);
            }
            else 
            {
                Console.ReadLine();
                return;
            }
        }
        public void AddFault(int index)
        {
            Console.WriteLine("Введите описание неисправности:");
            string desc = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(desc))
            {
                Console.WriteLine("Описание не должно быть пустым.");
                Console.ReadLine();
                return;
            }
            if (manager.Cars[index].Faults == null)
                manager.Cars[index].Faults = new List<Fault>();

            manager.Cars[index].Faults.Add(new Fault { Description = desc, Date = DateTime.Now });
            Console.WriteLine("Неисправность добавлена.");
            Console.ReadLine();
        }

        public void ShowFaults(int index)
        {
            var faults = manager.Cars[index].Faults;
            if (faults == null || faults.Count == 0)
            {
                Console.WriteLine("Неисправностей нет.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Список неисправностей:");
            for (int i = 0; i < faults.Count; i++)
            {
                Console.WriteLine($"{i + 1}.({faults[i].Date}) {faults[i].Description}");
                
            }
            Console.ReadLine();
        }
        public void ShowCarSubMenu(int index)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Информация об автомобиле:\n");
                Console.WriteLine(manager.Cars[index].ToPrettyString());
                Console.WriteLine();

                Console.WriteLine("1. Добавить неисправность");
                Console.WriteLine("2. Показать неисправности");
                Console.WriteLine("0. Назад");

                int choice = ReadClass.ReadValue<int>("Выберите действие: ", int.TryParse);

                switch (choice)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:
                        AddFault(index);
                        break;

                    case 2:
                        ShowFaults(index);
                        break;

                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        Console.ReadLine();
                        break;
                }
            }
        }




    }
}

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
                int index = ReadClass.ReadValue<int>("Введите номер автомобиля для удаления: ", int.TryParse);
                manager.RemoveCar(index);
                Console.ReadLine();
            } else
            {
                Console.ReadLine();
            }
        }
    }
}

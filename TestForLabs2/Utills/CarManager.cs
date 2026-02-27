using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestForLabs2.Classes;


namespace TestForLabs2.Utills
{
    internal class CarManager
    {
        public List<Car> Cars { get; private set; } = new List<Car>();

        private const string FileName = @"D:\projekts\testforlabs\cars.bin"; //объявление абсолютного пути к файлу для будущих сохранений в файл и чтения из файла

        public void ShowCars()
        {
            if (Cars.Count == 0)
            {
                Console.WriteLine("Список техники пуст.");
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < Cars.Count; i++)
            {
                Car car = Cars[i];
                Console.WriteLine($"{i+1}. {car.Name}, {car.Number}, {car.Year} г.в., {car.Owner}");
            }
            Console.ReadLine();

        }

        public void AddCar(Car car) //добавление машины
        {
            car.CreatedAt = DateTime.Now;
            car.LastUpdatedAt = DateTime.Now;
            Cars.Add(car);
        }

        public void RemoveCar(int index) //удаление машины по индексу
        {
            if (index >= 0 && index <= Cars.Count) //необходимо еще дописать обложку метода в утиллс для записи в мейне
            {
                Cars.RemoveAt(index-1);
            }



        }
    }
}

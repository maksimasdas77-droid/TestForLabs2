using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestForLabs2.Classes;
using Newtonsoft.Json;
using System.IO;


namespace TestForLabs2.Utills
{
    internal class CarManager
    {

        public List<Car> Cars { get; private set; } = new List<Car>();

        private const string FileName = @"D:\projekts\testforlabs2\cars.bin"; //объявление абсолютного пути к файлу для будущих сохранений в файл и чтения из файла

        public void ShowCars()
        {
            Utill.CheckCars(Cars);
            for (int i = 0; i < Cars.Count; i++)
            {
                Car car = Cars[i];
                Console.WriteLine($"{i+1}. {car.Name}, {car.Number}, {car.Year} г.в., {car.Owner}");
            }


        }
        public void ShowAllCars()
        {
            Utill.CheckCars(Cars);
            for (int i = 0; i < Cars.Count; i++)
            {
                //Car car = Cars[i];
                Console.WriteLine($"[{i + 1}]");
                Console.WriteLine(Cars[i].ToPrettyString());
                Console.WriteLine();
            }
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
                    Cars.RemoveAt(index - 1);
                    Console.WriteLine("Автомобиль успешно удален");
                }
                else
                {
                Console.WriteLine("Такого автомобиля не существует");
                }
        }

        public void UpdateCar(int index, Car newCar)
        {
            //Utill.CheckCars(Cars);
            newCar.CreatedAt = Cars[index - 1].CreatedAt;
            newCar.LastUpdatedAt = DateTime.Now;
            Cars[index -1] = newCar;
        }

        public void SaveToFile()
        {
            string json = JsonConvert.SerializeObject(Cars, Formatting.Indented);
            File.WriteAllText(FileName, json);
            Console.WriteLine("Данные успешно сохранены.");
        }

        public void LoadFromFile()
        {
            if (!File.Exists(FileName))
            {
                Console.WriteLine("Файл не найден");
                return;
            }

            string json = File.ReadAllText(FileName);
            Cars = JsonConvert.DeserializeObject<List<Car>>(json);
            Console.WriteLine("Данные успешно загружены.");
        }
    }
}

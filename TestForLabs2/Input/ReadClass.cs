using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForLabs2.Input
{
    internal class ReadClass
    {
        public delegate bool UniTryParse<T>(string input, out T value); //дженерик для readvalue<T>
        public static T ReadValue<T>(string message, UniTryParse<T> parser) //самый универсальный метод ввода и безопасный на данный момент который я знаю
        {
            Console.Write(message);
            T value;

            while (!parser(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }
        public static T ReadValue<T>(UniTryParse<T> parser)
        {
            T value;
            while (!parser(Console.ReadLine(), out value)) //цикл для зацикливания ввода если введены не правильные данные и не выдает ошибку
            {
                Console.Write("Некорректный ввод. Попробуйте снова: ");
            }
            return value;
        }
    }
}

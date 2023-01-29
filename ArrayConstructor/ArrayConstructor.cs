using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Constructor
{
    class ArrayConstructor
    {
        int[]? Array { get; set; }
        Random random = new Random();

        public void PrintArray(int[] array)
        {               
            Array = array;
            Console.WriteLine(String.Join(", ", Array));            
        }

        public int[] CreateArray()
        {
            int length;
            Console.Write("Введите количество элементов массива: ");
            while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
            {
                Console.Write("Ошибка! Введите целое положительное число: ");
            }
            Array = new int[length];
            for(int i = 0; i < Array.Length; i++)
            {
                Console.Write($"Введите {i} элемент массива: ");
                if(int.TryParse(Console.ReadLine(), out Array[i])) {}
                else Console.WriteLine("Неверный формат числа! Записывается значение по-умолчанию...");
            }
            return Array;
        }
        public int[] CreateArray(int length, int randomA, int randomB)
        {
            Array = new int[length];
            for(int i = 0; i < Array.Length; i++)
            {
                Array[i] = random.Next(randomA, randomB);
            }
            return Array;
        }
        public int[] CreateArray(int length)
        {
            Array = new int[length];
            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write($"Введите {i} элемент массива: ");
                if (int.TryParse(Console.ReadLine(), out Array[i])) { }
                else Console.WriteLine("Неверный формат числа! Записывается значение по-умолчанию...");
            }
            return Array;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Constructor
{
    static class ArrayConstructor
    {
        static int[]? IntArray { get; set; }
        static Random random = new Random();

        public static void PrintArray(int[] array)
        {               
            IntArray = array;
            Console.WriteLine(String.Join(" ", IntArray));            
        }

        public static int[] CreateArray()
        {
            int length;
            Console.Write("Введите количество элементов массива: ");
            while (!int.TryParse(Console.ReadLine(), out length) || length <= 0)
            {
                Console.Write("Ошибка! Введите целое положительное число: ");
            }
            IntArray = new int[length];
            for(int i = 0; i < IntArray.Length; i++)
            {
                Console.Write($"Введите {i} элемент массива: ");
                if(int.TryParse(Console.ReadLine(), out IntArray[i])) {}
                else Console.WriteLine("Неверный формат числа! Записывается значение по-умолчанию...");
            }
            return IntArray;
        }
        public static int[] CreateArray(int length, int randomA, int randomB)
        {
            IntArray = new int[length];
            for(int i = 0; i < IntArray.Length; i++)
            {
                IntArray[i] = random.Next(randomA, randomB);
            }
            return IntArray;
        }
        public static int[] CreateArray(int length)
        {
            IntArray = new int[length];
            for (int i = 0; i < IntArray.Length; i++)
            {
                Console.Write($"Введите {i} элемент массива: ");
                if (int.TryParse(Console.ReadLine(), out IntArray[i])) { }
                else Console.WriteLine("Неверный формат числа! Записывается значение по-умолчанию...");
            }
            return IntArray;
        }
    }
}

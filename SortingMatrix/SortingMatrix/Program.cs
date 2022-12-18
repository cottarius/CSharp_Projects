using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMatrix
{
    internal class Program
    {
        public static void SortMatrix(int[,] array)
        {
            Console.WriteLine("Сортировка матрицы от начального элемента до конечного по возрастанию:");
            for (int i = 0; i < array.GetLength(0); i++)
            {                
                for (int j = 0; j < array.GetLength(1); j++)
                {                   
                    for(int k = 0; k < array.GetLength(0); k++)
                    {
                        for (int l = 0; l < array.GetLength(1); l++)
                        {
                            if (array[i, j] <= array[k, l])
                            {
                                int temp = array[i, j];
                                array[i, j] = array[k, l];
                                array[k,l] = temp;
                            }
                        }
                    }
                }
            }
        }
        public static void PrintMatrix(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j], 2}");
                }
                Console.WriteLine();
            }
            
        }
        public static void SortMatrixByRows(int[,] array)
        {
            Console.WriteLine("Сортировка матрицы отдельно по строкам:");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(1) - 1; k++)
                    {
                        if (array[i, k] > array[i, k + 1])
                        {
                            int temp = array[i, k];
                            array[i, k] = array[i, k + 1];
                            array[i, k + 1] = temp;
                        }
                    }
                }
            }
        }
        public static void SortMatrixByColumns(int[,] array)
        {
            Console.WriteLine("Сортировка матрицы по столбцам:");
            for(int i = 0; i < array.GetLength(1); i++)
            {
                for( int j = 0; j < array.GetLength(0); j++)
                {
                    for(int k = j; k < array.GetLength(0); k++)
                    {
                        if (array[j, i] > array[k, i])
                        {
                            int temp = array[k,i];
                            array[k, i] = array[j, i];
                            array[j, i] = temp;
                        }
                    }
                }
            }
        }        
        public static int[,] CreateRandomMatrix()
        {
            Random rand = new Random();
            int n = rand.Next(3, 6);
            int m = rand.Next(3, 6);
            int[,] array = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    array[i, j] = rand.Next(1, 10);
                }                
            }
            return array;
        }
            
        static void Main(string[] args)
        {                      
            var matrix = CreateRandomMatrix();

            PrintMatrix(matrix);
            Console.WriteLine();

            SortMatrixByRows(matrix);            
            PrintMatrix(matrix);
            Console.WriteLine();   
            
            SortMatrixByColumns(matrix);
            PrintMatrix(matrix);
            Console.WriteLine();

            SortMatrix(matrix);
            PrintMatrix(matrix);
            
            Console.ReadLine();
        }
    }
}

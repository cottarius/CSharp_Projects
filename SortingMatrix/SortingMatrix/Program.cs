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
        public static void PrintMatrix(int[,] array )
        {
            for (int i = 0; i < array.GetLength(0); i++) 
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }
            
        }
        public static void SortMatrixByRows(int[,] array, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m - 1; j++)
                {
                    for (int k = 0; k < m - j - 1; k++)
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
            
        static void Main(string[] args)
        {
            int n = 4, m = 5;
            int[,] matrix = new int[n, m];
            Random rand = new Random();
            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrix[j, i] = rand.Next(1, 20);
                }
                Console.WriteLine();
            }
            

            PrintMatrix(matrix);
            Console.WriteLine();
            SortMatrix(matrix);            
            PrintMatrix(matrix);
            SortMatrix(matrix);
        }
    }
}

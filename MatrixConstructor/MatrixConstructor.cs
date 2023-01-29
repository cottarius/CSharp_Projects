using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Constructor
{
    class MatrixConstructor
    {
        int[,]? Matrix { get; set; }
        Random random = new Random();

        public int[,] CreateMatrix(int rowLength, int columnLength, int randomA, int randomB)
        {
            Matrix = new int[rowLength, columnLength];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = random.Next(randomA, randomB);
                }
            }
            return Matrix;
        }

        public int[,] CreateMatrix(int randomA, int randomB)
        {
            int row, column;
            Console.Write("Введите количество строк матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out row))
            {
                Console.Write("Введите целое число больше нуля: ");
            }
            Console.Write("Введите количество строк матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out column))
            {
                Console.Write("Введите целое число больше нуля: ");
            }
            Matrix = new int[row, column];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Matrix[i, j] = random.Next(randomA, randomB);
                }
            }
            return Matrix;
        }

        public int[,] CreateMatrix()
        {
            int row, column;
            Console.Write("Введите количество строк матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out row))
            {
                Console.Write("Введите целое число больше нуля: ");
            }
            Console.Write("Введите количество строк матрицы: ");
            while (!int.TryParse(Console.ReadLine(), out column))
            {
                Console.Write("Введите целое число больше нуля: ");
            }
            Matrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (int.TryParse(Console.ReadLine(), out Matrix[i, j])) { }
                    else Console.Write("Неверный формат числа! Записывается значение по-умолчанию (0)...");
                }
            }
            return Matrix;
        }

        public void PrintMatrix(int[,] matrix)
        {
            Matrix = matrix;
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write($"{Matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

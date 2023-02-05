using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Constructor
{
    static class MatrixConstructor
    {
        static int[,]? intMatrix { get; set; }
        static double[,]? doubleMatrix { set; get; } 
        static Random random = new Random();

        public static int[,] CreateMatrix(int rowLength, int columnLength, int randomA, int randomB)
        {
            intMatrix = new int[rowLength, columnLength];
            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    intMatrix[i, j] = random.Next(randomA, randomB);
                }
            }
            return intMatrix;
        }

        public static double[,] CreateMatrix(int rowLength, int columnLength, int index)
        {
            doubleMatrix = new double[rowLength, columnLength];
            for (int i = 0; i < doubleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < doubleMatrix.GetLength(1); j++)
                {
                    doubleMatrix[i, j] = Math.Round(random.NextDouble() * index, 2);
                }
            }
            return doubleMatrix;
        }

        public static int[,] CreateMatrix(int randomA, int randomB)
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
            intMatrix = new int[row, column];
            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    intMatrix[i, j] = random.Next(randomA, randomB);
                }
            }
            return intMatrix;
        }

        public static int[,] CreateMatrix()
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
            intMatrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (int.TryParse(Console.ReadLine(), out intMatrix[i, j])) { }
                    else Console.Write("Неверный формат числа! Записывается значение по-умолчанию (0)...");
                }
            }
            return intMatrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            intMatrix = matrix;
            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    Console.Write($"{intMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void PrintMatrix(double[,] matrix)
        {
            doubleMatrix = matrix;
            for (int i = 0; i < doubleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < doubleMatrix.GetLength(1); j++)
                {
                    Console.Write($"{doubleMatrix[i, j], -5} ");
                }
                Console.WriteLine();
            }
        }

        public static int[,] SortMatrix(int[,] matrix)
        {
            intMatrix = matrix;
            Console.WriteLine("Сортировка матрицы от начального элемента до конечного по возрастанию:");
            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < intMatrix.GetLength(0); k++)
                    {
                        for (int l = 0; l < intMatrix.GetLength(1); l++)
                        {
                            if (intMatrix[i, j] <= intMatrix[k, l])
                            {
                                int temp = intMatrix[i, j];
                                intMatrix[i, j] = intMatrix[k, l];
                                intMatrix[k, l] = temp;
                            }
                        }
                    }
                }
            }
            return intMatrix;
        }

        public static double[,] SortMatrix(double[,] matrix)
        {
            doubleMatrix = matrix;
            Console.WriteLine("Сортировка матрицы от начального элемента до конечного по возрастанию:");
            for (int i = 0; i < doubleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < doubleMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < doubleMatrix.GetLength(0); k++)
                    {
                        for (int l = 0; l < doubleMatrix.GetLength(1); l++)
                        {
                            if (doubleMatrix[i, j] <= doubleMatrix[k, l])
                            {
                                double temp = doubleMatrix[i, j];
                                doubleMatrix[i, j] = doubleMatrix[k, l];
                                doubleMatrix[k, l] = temp;
                            }
                        }
                    }
                }
            }
            return doubleMatrix;
        }

        public static int[,] SortMatrixByRows(int[,] matrix)
        {
            intMatrix = matrix;
            Console.WriteLine("Сортировка матрицы отдельно по строкам:");
            for (int i = 0; i < intMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < intMatrix.GetLength(1) - 1; k++)
                    {
                        if (intMatrix[i, k] > intMatrix[i, k + 1])
                        {
                            int temp = intMatrix[i, k];
                            intMatrix[i, k] = intMatrix[i, k + 1];
                            intMatrix[i, k + 1] = temp;
                        }
                    }
                }
            }
            return intMatrix;
        }

        public static double[,] SortMatrixByRows(double[,] matrix)
        {
            doubleMatrix = matrix;
            Console.WriteLine("Сортировка матрицы отдельно по строкам:");
            for (int i = 0; i < doubleMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < doubleMatrix.GetLength(1); j++)
                {
                    for (int k = 0; k < doubleMatrix.GetLength(1) - 1; k++)
                    {
                        if (doubleMatrix[i, k] > doubleMatrix[i, k + 1])
                        {
                            double temp = doubleMatrix[i, k];
                            doubleMatrix[i, k] = doubleMatrix[i, k + 1];
                            doubleMatrix[i, k + 1] = temp;
                        }
                    }
                }
            }
            return doubleMatrix;
        }

        public static int[,] SortMatrixByColumns(int[,] matrix)
        {
            intMatrix = matrix;
            Console.WriteLine("Сортировка матрицы по столбцам:");
            for (int i = 0; i < intMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < intMatrix.GetLength(0); j++)
                {
                    for (int k = j; k < intMatrix.GetLength(0); k++)
                    {
                        if (intMatrix[j, i] > intMatrix[k, i])
                        {
                            int temp = intMatrix[k, i];
                            intMatrix[k, i] = intMatrix[j, i];
                            intMatrix[j, i] = temp;
                        }
                    }
                }
            }
            return intMatrix;
        }

        public static double[,] SortMatrixByColumns(double[,] matrix)
        {
            doubleMatrix = matrix;
            Console.WriteLine("Сортировка матрицы по столбцам:");
            for (int i = 0; i < doubleMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < doubleMatrix.GetLength(0); j++)
                {
                    for (int k = j; k < doubleMatrix.GetLength(0); k++)
                    {
                        if (doubleMatrix[j, i] > doubleMatrix[k, i])
                        {
                            double temp = doubleMatrix[k, i];
                            doubleMatrix[k, i] = doubleMatrix[j, i];
                            doubleMatrix[j, i] = temp;
                        }
                    }
                }
            }
            return doubleMatrix;
        }
    }
}

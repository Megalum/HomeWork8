using System;

namespace HomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {

            int task;
            int[,] matrixFirst, matrixSecond;
            
            do
            {
                Task();
                task = Input("Введите номер задания");
                Console.Clear();
                switch (task)
                {
                    case 1:
                        matrixFirst = InputMatrix();
                        Console.WriteLine("Исходная матрица:");
                        PrintMatrix(matrixFirst);                       
                        Sort(matrixFirst);
                        Console.WriteLine("Отсортироанная матрица:");
                        PrintMatrix(matrixFirst);
                        break;

                    case 2:
                        matrixFirst = InputMatrix();
                        PrintMatrix(matrixFirst);
                        int[] array = new int[matrixFirst.GetLength(0)];
                        int sumMinI = 0;
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = 0;
                        }
                        for (int i = 0; i < matrixFirst.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixFirst.GetLength(1); j++)
                            {
                                array[i] += matrixFirst[i, j];
                            }
                        }
                        for (int i = 1; i < array.Length; i++)
                        {
                            if(array[i] < array[sumMinI])
                            {
                                sumMinI = i;
                            }
                        }
                        Console.WriteLine($"В строке {sumMinI + 1} наименьшая сумма элементов, которая равна {array[sumMinI]}");
                        break;

                    case 3:
                        Console.WriteLine("Первая матрица: ");
                        matrixFirst = InputMatrix();
                        PrintMatrix(matrixFirst);
                        Console.WriteLine("Вторая матрица: ");
                        matrixSecond = InputMatrix();
                        PrintMatrix(matrixSecond);
                        int[,] matrixProduct = MatrixProduct(matrixFirst, matrixSecond);                                                                                                                      
                        if (matrixFirst.GetLength(1) == matrixSecond.GetLength(0))
                        {
                            Console.WriteLine("Произведение матрица: ");
                            PrintMatrix(matrixProduct);
                        }
                        else Console.WriteLine("Перемножение невозможно!");
                        break;

                    case 4:
                        int[,,] threeDimensionalArray = CreateThreeDimensionalArray();
                        int number = 100 - 10;
                        if (threeDimensionalArray.GetLength(0) * threeDimensionalArray.GetLength(1) * threeDimensionalArray.GetLength(2) <= number)
                        {
                            PrintThreeDimensionalArray(threeDimensionalArray);
                        }
                        else Console.WriteLine("Превышен диапозон!");
                        break;

                    case 5:
                        matrixFirst = CreateSpiralMatrix();
                        PrintMatrix(matrixFirst);
                        break;
                }

                Console.WriteLine("Press key to continue...");
                Console.ReadKey();
            } while (task < 6);


            int Input(string str)
            {
                Console.WriteLine(str);
                return Convert.ToInt32(Console.ReadLine());
            }

            int[,] InputMatrix()
            {
                int row = Input("Введите колличество строк ");
                int column = Input("Введите колличество столбцов ");
                int[,] matrix = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        matrix[i, j] = new Random().Next(0, 100);
                    }
                }
                return matrix;
            }

            int[,] MatrixProduct(int[,] matrixFirst, int[,] matrixSecond)
            {
                int[,] matrixProduct = new int[matrixFirst.GetLength(0), matrixSecond.GetLength(1)];
                int sum = 0;
                if (matrixFirst.GetLength(1) == matrixSecond.GetLength(0))
                {
                    for (int i = 0; i < matrixProduct.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrixProduct.GetLength(1); j++)
                        {
                            for (int k = 0; k < matrixFirst.GetLength(1); k++)
                            {
                                sum += matrixFirst[i, k] * matrixSecond[k, j];
                            }
                            matrixProduct[i, j] = sum;
                            sum = 0;
                        }
                    }
                }
                return matrixProduct;
            }

            int[,,] CreateThreeDimensionalArray()
            {
                int table = Input("Введите колличество матриц ");
                int row = Input("Введите колличество строк ");
                int column = Input("Введите колличество столбцов ");
                int count, index = 0;
                bool flag;
                int[] mas = new int[table * row * column];
                mas[0] = 1;
                int[,,] array = new int[table, row, column];
                if (mas.Length <= 90)
                {
                    for (int i = 0; i < table; i++)
                    {
                        for (int j = 0; j < row; j++)
                        {
                            for (int k = 0; k < column; k++)
                            {
                                while (array[i, j, k] == 0)
                                {
                                    count = new Random().Next(10, 100);
                                    flag = true;
                                    for (int z = 0; z < mas.Length; z++)
                                    {
                                        if (mas[z] == 0)
                                        {
                                            break;
                                        }
                                        else if (mas[z] == count)
                                        {
                                            flag = false;
                                        }
                                    }
                                    if (flag == true)
                                    {
                                        array[i, j, k] = count;
                                        mas[index++] = count;
                                    }
                                }
                            }
                        }
                    }
                }
                return array;
            }
            
            int[,] CreateSpiralMatrix()
            {
                int row = Input("Введите размерность матрицы ");
                int[,] array = new int[row, row];
                int i = 0, j, count = row - 1, number = 1;
                for(j = 0; j < row; j++)
                {
                    array[i, j] = number;
                    number++;
                }
                j--;
                while (count != 0)
                {                   
                    if(i < j)
                    {
                        for (int k = 0; k < count; k++)
                        {
                            i++;
                            array[i, j] = number++;
                        }
                        for (int k = 0; k < count; k++)
                        {
                            j--;
                            array[i, j] = number++;
                        }
                        count--;
                    }
                    else
                    {
                        for (int k = 0; k < count; k++)
                        {
                            i--;
                            array[i, j] = number++;
                        }
                        for (int k = 0; k < count; k++)
                        {
                            j++;
                            array[i, j] = number++;
                        }
                        count--;
                    }
                }
                return array;
            }

            void Sort(int[,] matrix)
            {
                int count, variable;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    count = matrix.GetLength(1);
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        for (int j = 1; j < count; j++)
                        {
                            if(matrix[i, j] > matrix[i, j - 1])
                            {
                                variable = matrix[i, j];
                                matrix[i, j] = matrix[i, j - 1];
                                matrix[i, j - 1] = variable;
                            }
                        }
                        count--;
                    }                    
                }
            }

            void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0:00} ", matrix[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            void PrintThreeDimensionalArray(int[,,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        for (int k = 0; k < array.GetLength(2); k++)
                        {
                            Console.Write($"[{i},{j},{k}]{array[i,j,k]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }

            void Task()
            {
                Console.Clear();
                Console.WriteLine("Номера заданий:");
                Console.WriteLine("1: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
                Console.WriteLine("2: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
                Console.WriteLine("3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
                Console.WriteLine("4: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.Напишите программу, " +
                    "которая будет построчно выводить массив, добавляя индексы каждого элемента.");
                Console.WriteLine("5: Заполните спирально массив 4 на 4.");
            }
        }
    }
}

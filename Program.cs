int[,] CreateRandom2dArray()
{

    int[,] array = new int[4, 6];

    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = new Random().Next(1, 9 + 1);

    return array;
}

void Show2dArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write(array[i, j] + "\t");

        Console.WriteLine();
    }
    Console.WriteLine();
}

Console.WriteLine("Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
Console.WriteLine();
Console.WriteLine("Для продолжения нажмите Enter...");
Console.ReadKey();
Console.WriteLine();

void SortArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int j2 = 0; j2 < array.GetLength(1) - 1; j2++)
                if (array[i, j2] < array[i, j2 + 1])
                {
                    int temp = array[i, j2 + 1];
                    array[i, j2 + 1] = array[i, j2];
                    array[i, j2] = temp;
                }
}

int[,] array = CreateRandom2dArray();
Console.WriteLine("Не отсортированный массив:");
Show2dArray(array);
SortArray(array);
Console.WriteLine("Отсортированный массив:");
Show2dArray(array);



Console.WriteLine("Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
Console.WriteLine();
Console.WriteLine("Для продолжения нажмите Enter...");
Console.ReadKey();
Console.WriteLine();

int MinSumRow(int[,] array)
{
    int minRow = 0;
    int minSumRow = 0;
    int sumRow = 0;
    for (int i = 0; i < array.GetLength(1); i++)
        minRow += array[0, i];

    for (int i = 1; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++) 
            sumRow += array[i, j];
        if (sumRow < minRow)
        {
            minRow = sumRow;
            minSumRow = i;
        }
        sumRow = 0;
    }
    return minSumRow;
}

int[,] arrayMinSum = CreateRandom2dArray();
Show2dArray(arrayMinSum);
Console.WriteLine($"Строка с наименьшей суммой элементов: {MinSumRow(arrayMinSum) + 1}");
Console.WriteLine();



Console.WriteLine("Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
Console.WriteLine();
Console.WriteLine("Для продолжения нажмите Enter...");
Console.ReadKey();
Console.WriteLine();

int[,] MultiplyMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int j = 0; j < result.GetLength(1); j++)
        for (int i = 0; i < result.GetLength(0); i++)
            for (int i2 = 0, j2 = 0; i2 < matrix2.GetLength(0); i2++, j2++)
            {
                result[i, j] += matrix1[i, j2] * matrix2[i2, j];
                int temp = result[i, j];
            }
    return result;
}

int[,] matrix1 = CreateRandom2dArray();
Show2dArray(matrix1);

int[,] matrix2 = CreateRandom2dArray();
Show2dArray(matrix2);

int[,] resultArray = MultiplyMatrix(matrix1, matrix2);
Show2dArray(resultArray);



Console.WriteLine("Сформируйте трёхмерный массив из неповторяющихся двузначных чисел."
                + " Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
Console.WriteLine();
Console.WriteLine("Для продолжения нажмите Enter...");
Console.ReadKey();
Console.WriteLine();

int[,,] CreateRandom3dArray()
{
    int[] arrayForRandom = new int[90];
    arrayForRandom[0] = 10;
    for (int n = 0; n < arrayForRandom.Length; n++)
        arrayForRandom[n] = arrayForRandom[0] + n;

    int[,,] array = new int[3, 3, 3];
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            for (int k = 0; k < array.GetLength(2); k++)
                while (array[i, j, k] == 0)
                {
                    int n = new Random().Next(0, 90);
                    array[i, j, k] = arrayForRandom[n];
                    arrayForRandom[n] = 0;
                }
    return array;
}

void Show3DArray(int[,,] array)
{
    Console.WriteLine();
    for (int k = 0; k < array.GetLength(2); k++)
    {
        Console.WriteLine();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j, k]}({i},{j},{k})" + "\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int[,,] arr = CreateRandom3dArray();
Show3DArray(arr);



Console.WriteLine("Напишите программу, которая заполнит спирально массив 4 на 4.");
Console.WriteLine("Для продолжения нажмите Enter...");
Console.WriteLine();
Console.ReadKey();
Console.WriteLine();

int[,] CreateSnakeArray()
{
    int[,] array = new int[4, 4];
    int count = 1;

    for (int frame = 0; frame < array.GetLength(0) - 2; frame++)
    {
        for (int i = 0 + frame; i < array.GetLength(0) - frame; i++, count++)
            array[0 + frame, i] = count;
        count--;

        for (int i = 0 + frame; i < array.GetLength(1) - frame; i++, count++)
            array[i, array.GetLength(1) - 1 - frame] = count;
        count--;

        for (int i = array.GetLength(1) - 1 - frame; i >= 0 + frame; i--, count++)
            array[array.GetLength(1) - 1 - frame, i] = count;
        count--;

        for (int i = array.GetLength(1) - 1 - frame, n = array.GetLength(1) - array.GetLength(1); i >= 1 + frame; i--, count++)
            array[i, n + frame] = count;
    }
    return array;
}

int[,] snakeArray = CreateSnakeArray();
Show2dArray(snakeArray);
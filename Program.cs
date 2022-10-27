Console.WriteLine("===========> Задача 47 <============ ");

// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9 
Console.WriteLine("Введите количество строк и столбцов, и я выведу 2х мерный массив, заполненный случайными вещественными числами");

Console.WriteLine("введите количество строк M");
int lines = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("введите количество столбцов N");
int columns = Convert.ToInt32(Console.ReadLine());
double[,] DoubleArray = GetArrayDouble(lines, columns, -99, 99);
PrintArrayDouble(DoubleArray);

//=========== МЕТОДЫ к задаче 47 ============ 

double [,] GetArrayDouble(int m, int n, int minValue, int maxVolue)
{
    double[,] result = new double[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            //result[i, j] = new Random().Next(minValue, maxVolue + 1);
            result[i, j] = Convert.ToDouble(new Random().Next(minValue, maxVolue + 1))/10;
        }
    }
    return result;
}
// вывод массива в консоль
void PrintArrayDouble(double[,] Array) 
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($" {Array[i, j]:F1}");
        } 
        Console.WriteLine();
    }
    
}

Console.WriteLine("===========> Задача 50 <============ ");

// Задача 50. Напишите программу, которая на вход принимает позиции элемента
// в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// i = 4, j = 2 -> такого числа в массиве нет
// i = 1, j = 2 -> 2 

Console.WriteLine("Введите количество строк и столбцов, и я выведу 2х меный массив, заполненный случайными числами от 0 до 9");
Console.WriteLine("введите количество строк M");
int M = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("введите количество столбцов N");
int N = Convert.ToInt32(Console.ReadLine());
int[,] IntArray = GetArray(M, N, 0, 9); //значения в массиве от 0 до 9
Console.WriteLine("сгенерированный массив:");
PrintArray(IntArray);

Console.WriteLine("Введите индексы числа из массива, и я выведу Вам это число");
Console.WriteLine("Индекс строки необходимого числа:");
int userI = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Индекс столца необходимого числа:");
int userJ = Convert.ToInt32(Console.ReadLine());

if (CheckIndexValidity(userI, userJ, IntArray)) Console.WriteLine($"число в ячейке с индексами i = {userI}, j = {userJ} -> {NumInArray(userI, userJ, IntArray)}");
else Console.WriteLine("Упс.. Кажется числа с такими индексами в нашем массиве нет :*(");


//=========== МЕТОДЫ к задаче 50 ============

// проверка индексов на валидность
bool CheckIndexValidity(int i, int j, int[,] Array)
{
    if (i < Array.GetLength(0) && j < Array.GetLength(1)) return true;
    else return false;
}

// извлекаю число с нужными индексами из массива
int NumInArray(int userI, int userJ, int[,] Array)
{
int number = 0;
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            if (i == userI && j == userJ) number = Array[i, j];
        }
    } 
    return number;
}

// заполнение массива случайными значениями
int[,] GetArray(int m, int n, int minValue, int maxVolue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxVolue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] Array) 
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($" {Array[i, j]:F0}");
        } 
        Console.WriteLine();
    }
    
}

Console.WriteLine("===========> Задача 52 <============ ");

// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

Console.WriteLine("Введите количество строк и столбцов, и я выведу 2х меный массив, заполненный случайными числами от 0 до 9 и рассчитаю ср арифметическое по столбцам.");

Console.WriteLine("введите количество строк L");
int L = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("введите количество столбцов C");
int C = Convert.ToInt32(Console.ReadLine());

int[,] SimpleArray = GetSimpleArray(L, C, 0, 9); //значения в массиве от 0 до 9
PrintArr(SimpleArray);
Console.WriteLine($"сумма значений по столбцам => [{String.Join("; ", SumOfColumnValues(SimpleArray))}]");
Console.WriteLine($"среднее арифметическое значений по столбцам => [{String.Join("; ", GetArithmeticMean(SimpleArray, SumOfColumnValues(SimpleArray)))}]");



//=========== МЕТОДЫ к задаче 52 ============


// решение из чата
// double[] Srednee1(int[,] array)
// {
//     double[] res = new double[array.GetLength(1)];
//     for (int i = 0; i < array.GetLength(1); i++)
//     {
//         double sum = 0;
//         for (int j = 0; j < array.GetLength(0); j++)
//         {
//          sum +=array[j,i];   
//         }
//         res[i] = Math.Round(sum/array.GetLength(0),2);
//     }
//     return res;
// } 

//сумма значений по столбцам

double[] SumOfColumnValues(int[,] array)
{
    double[] sum = new double[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum[j] += array[i, j];
        }
    }
    return sum;
}

//ср арифметическое
double[] GetArithmeticMean(int[,] generatedArray, double[] sumArray)
{
    double[] arithmeticMean = new double[generatedArray.GetLength(1)];
    for (int i = 0; i < generatedArray.GetLength(1); i++)
    {
        arithmeticMean[i] = Math.Round(sumArray[i] / generatedArray.GetLength(0), 2);
    }
    return arithmeticMean;
}
// заполнение массива случайными значениями    
int[,] GetSimpleArray(int m, int n, int minValue, int maxVolue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxVolue + 1);
        }
    }
    return result;
}


void PrintArr(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($" {Array[i, j]:F0}");
        }
        Console.WriteLine();
    }

}
Console.WriteLine("=======Задача 60==============");
Console.WriteLine("гегнерирую трёхмерный массив из неповторяющихся двузначных чисел");
// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.

// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

//входные данные
int SizeX = 4;
int SizeY = 4;
int SizeZ = 4;
int minNumber = 10;
int maxNumber = 99;

// генерирую одномерный массив последоватовательных 2х значных чисел
int[] Array = GetVolues(SizeX, SizeY, SizeZ, minNumber, maxNumber);

// перемешиваю значения в массиве что бы получить массив с неповторяющимися значениями
Shuffle(Array);

//вывожу массив в консоль
Console.WriteLine($"Сгенерированный и перемешанный массив => [{String.Join(",", Array)}]");

//создаю и последовательно заполняю новый 3х мерный массив числами из одномерного массива с перемешанными значеними
int[,,] Array3d = GetArray3D(SizeX, SizeY, SizeZ, Array);

//вывожу массив в консоль
Console.WriteLine("VV 3d массив VV");
Print3dArray(Array3d);


//=========== МЕТОДЫ к задаче 60 ============

//метод для получения одномерного массива с последовательными значениями
int[] GetVolues(int SizeX, int SizeY, int SizeZ, int minNumber, int maxNumber){
    int[] result = new int[SizeX * SizeY * SizeZ];
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = minNumber + i;
    }
    return result;
}

// метод для перемешивания одномерного массива
void Shuffle(int[] array){

    Random rand = new Random();
    for (int i = array.Length - 1; i >= 1; i--)
    {
        int j = rand.Next(i + 1);
        int tmp = array[j];
        array[j] = array[i];
        array[i] = tmp;
    }
}

// метод для заполнения трехмерного массива
int[,,] GetArray3D(int SizeX, int SizeY, int SizeZ, int[] array){
    int[,,] result = new int[SizeX, SizeY, SizeZ];
    int count = 0;
    for (int i = 0; i < SizeX; i++)
    {
        for (int j = 0; j < SizeY; j++)
        {
            for (int k = 0; k < SizeZ; k++)
            {
                result[i, j, k] = array[count];
                count++;
            }
        }
    }
    return result;
}

//метод для вывода трех мерного массива
void Print3dArray(int[,,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            for (int k = 0; k < Array.GetLength(2); k++)
            {
                  Console.Write($" {Array[i, j, k]}({i}, {j}, {k});");
            }
            Console.WriteLine();
        } 
        Console.WriteLine();
    }
}

Console.WriteLine("=======Задача 62==============");
//  Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

Console.WriteLine("размер 2х мерного массива 4 x 4, заполняю его по спирали:");
int arraySize = 4;

//заполняю массив
int[,] SpiralArray = GetSpiralArray(arraySize);

//вывожу его в консоль
PrintSpiralArr(SpiralArray);

//=========== МЕТОДЫ к задаче 62 ============

// метод заплнения массива по спирали
int[,] GetSpiralArray(int size){
    int[,] resultArr = new int[size, size];

    int number = 10;

    for (int i = 0; i <= size / 2; i++)
    {
        //вправо
        for (int j = i; j < size - i; j++) resultArr[i, j] = number++;
        //вниз
        for (int k = i + 1; k < size - i; k++) resultArr[k, size - 1 - i] = number++;
        //влево
        for (int j = size - i - 1 - 1; j >= i; j--) resultArr[size - 1 - i, j] = number++;
        //вверх
        for (int k = size - i - 1 - 1; k > i; k--) resultArr[k, i] = number++;
    }
    return resultArr;
}

//метод вывода массива в консоль
void PrintSpiralArr(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($" {Array[i, j]:F0}");
        }
        Console.WriteLine();
    }

}
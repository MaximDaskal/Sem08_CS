//тут пишем все функции которые потребуются для решения задач данного урока. Функции не надо закомментировать, нужно только закоментировать Пользовательские интерфейсы соответствующих залдпач 
//Создаём масив
int [,] Create2DArrayIntNums(int raw, int column,  int minVal, int maxVal)
{
    int [,] Result = new int[raw, column];
       
    for(int i = 0; i<Result.GetLength(0); i++)
    {
        for(int j =0; j<Result.GetLength(1); j++)
        {
            Result[i,j] = new Random().Next(minVal, maxVal+1);
        }
    }
    return Result;
}

// Сортипруем данные в строках
void sortArraysRows(int [,] intArray)
{
    for(int i =0; i<intArray.GetLength(0); i++)
    {
        for(int j =1; j<intArray.GetLength(1); j++)
        {
            // В цикле do - while перебираем все элементы от текущего до нулевого в этой строке Если текущий элемент меньше предыдущего в этой строке, то меняем их местами
            int count =j;
            do 
            {
                if(intArray[i,count]>intArray[i,count-1]) // Если текущий элемент меньше предыдущего в этой строке, то меняем их местами
                {
                    int temp = intArray[i,count-1];
                    intArray[i,count-1] = intArray[i,count];
                    intArray[i,count] = temp;
                    count--;
                }
                else break;
            }
            while(count>0);
        }
    }
    
}

// Выводим массив на экран
void Show2DIntArray(int [,] array, string message)
{
    Console.WriteLine(message);
    for(int i =0; i< array.GetLength(0); i++)
    {
        for(int j =0; j<array.GetLength(1); j++)
        {
            Console.Write($"{array[i,j]} ");
        }
        Console.WriteLine("");        
    }
    Console.WriteLine("");
}

//Создаём одномерный массив сумм строке из двумерного массива
int [] Array2DIntoArray(int [,] array) //MinSunItemsOfRaw
{
    int [] Result = new int[array.GetLength(0)];
    int nowSum = 0; // Сумма элементов текущей строки
    for(int i =0; i< array.GetLength(0); i++)
    {
        for(int j =0; j<array.GetLength(1); j++)
        {
            nowSum = nowSum + array[i,j];
        }
        Result[i] = nowSum;
        nowSum = 0;               
    }
    return Result;
}

//находим номер строки с наименьшим значением элемента
int MinSunItemsOfRaw(int [] array)
{
    int minNum = 0;
    //int minItem = array[0];
    for(int i =1; i<array.Length; i++)
    {
        if (array[i] < array[minNum]) minNum = i;
    }

    return minNum+1;//добавили единицу т.к. в задании вроде показано что строки массива в ответе должны начинаться не с нуля а с единицы
}

int [] From2DToArr(int [,] array2D)
{
    int [] Result = new int[array2D.GetLength(0)*array2D.GetLength(1)];// одномерный массив для всех элементов двумерного массива
    int a=0;// Индекс одномерного массива
    for(int i =0; i< array2D.GetLength(0); i++)
    {
        for(int j =0; j<array2D.GetLength(1); j++)
        {
            Result[a] = array2D[i,j];
            a++;
        }
                      
    }

    //for(int k = 0; k<Result.Length; k++) Console.Write(Result[k] + " ");
    //Console.WriteLine("");
    return Result;
}

// сортируем массив
void Sort1DArray(int [] array)
{
    for(int i =1; i<array.Length; i++)
        {
            // В цикле do - while перебираем все элементы от текущего до нулевого в этой строке Если текущий элемент меньше предыдущего в этой строке, то меняем их местами
            int count =i;
            do 
            {
                if(array[count]<array[count-1]) // Если текущий элемент меньше предыдущего в этой строке, то меняем их местами
                {
                    int temp = array[count-1];
                    array[count-1] = array[count];
                    array[count] = temp;
                    count--;
                }
                else break;
            }
            while(count>0);
        }
    //for(int k = 0; k<array.Length; k++) Console.Write(array[k] + " ");
    //Console.WriteLine("");
}

//Количество неповторяющихся элементов в масиве
int NumberOfUnicElem(int [] array)
{
    int N = 1;
    for(int i =1; i<array.Length; i++)
    {
        if(array[i] != array[i-1]) N++;
    }
    //Console.WriteLine($"Количество неодинаковых элементов {N}");
    return N;
}

//Заполним кол-во элементов
int [,] Fill2DArray(int [] array, int n)
{
    int [,] Result = new int[2, n];
    int count = 0;
    Result[0, count] = array[0];
    Result[1, count] = 1;
    for(int i =1; i<array.Length; i++)
    {
        if(array[i] == array[i-1]) Result[1, count] ++;
        else
        {
            count++;
            Result[0, count] = array[i];
            Result[1, count] = 1;
        }
    }
    return Result;
}

//выводим на экран
void ShowDictionary(int [,] Array2D)
{
    for(int i =0; i<Array2D.GetLength(1); i++)
    {
        Console.WriteLine($"{Array2D[0,i]} Встречается {Array2D[1,i]} раз");
    }
}






// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Пользовательский интерфейс
Console.Write("Input raw size of your array: ");
int RawSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Input column size of your array: ");
int ColSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Input min value of your array: ");
int minV = Convert.ToInt32(Console.ReadLine());
Console.Write("Input max value of your array: ");
int maxV = Convert.ToInt32(Console.ReadLine());

int [,] Res = Create2DArrayIntNums(RawSize, ColSize, minV, maxV);
Show2DIntArray(Res, "Your origin array is: ");
sortArraysRows(Res);
Show2DIntArray(Res, "Your sorted array is: ");
//окончание пользовательского интерфейса Задачи 54


/*
//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
//Пользовательский интерфейс
Console.Write("Input raw size of your array: ");
int RawSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Input column size of your array: ");
int ColSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Input min value of your array: ");
int minV = Convert.ToInt32(Console.ReadLine());
Console.Write("Input max value of your array: ");
int maxV = Convert.ToInt32(Console.ReadLine());

int [,] Res = Create2DArrayIntNums(RawSize, ColSize, minV, maxV);
Show2DIntArray(Res, "Your array is: ");
int [] tempArray = Array2DIntoArray(Res);
int minRaw = MinSunItemsOfRaw(tempArray);
Console.WriteLine($"Номер строки наименьшей суммой элементов: {minRaw}");
//окончание пользовательского интерфейса Задачи 56
*/


/*
//Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
//Пользовательский интерфейс
Console.Write("Input raw size of your array: ");
int RawSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Input column size of your array: ");
int ColSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Input min value of your array: ");
int minV = Convert.ToInt32(Console.ReadLine());
Console.Write("Input max value of your array: ");
int maxV = Convert.ToInt32(Console.ReadLine());

int [,] Res = Create2DArrayIntNums(RawSize, ColSize, minV, maxV);
Show2DIntArray(Res, "Your array is: ");
int [] resArr1D = From2DToArr(Res);
Sort1DArray(resArr1D);
int colVo = NumberOfUnicElem(resArr1D);
int [,] Result = Fill2DArray(resArr1D, colVo);
ShowDictionary(Result);
//окончание пользовательского интерфейса Задачи 57
*/



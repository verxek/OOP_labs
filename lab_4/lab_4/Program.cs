using System;
using System.Threading;
using System.Xml.Linq;

// одномерные массивы - удалить нечетные элементы
// двумерные массивы - добавить k строк в начало массива
// рваные массивы - удалить строку с заданным номером

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Работа с одномерными массивами");
            Console.WriteLine("2. Работа с двумерными массивами");
            Console.WriteLine("3. Работа с рваными массивами");
            Console.WriteLine("0. Выход");

            int choice;
            while (true)
            {
                bool isRead = int.TryParse(Console.ReadLine(), out choice);
                if (!isRead) { Console.WriteLine("Недопустимый символ!"); }
                else
                    break;
            }
            
            

            switch (choice)
            {
                case 1:
                    OneDimensionalArray();
                    break;
                case 2:
                    TwoDimensionalArray();
                    break;
                case 3:
                    JaggedArray();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ошибка, такого варианта ответа нет. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }


    static void OneDimensionalArray()
    {
        int[] array = null;
        while (true)
        {
            Console.WriteLine("Одномерные массивы:");
            Console.WriteLine("1. Создать массив вручную");
            Console.WriteLine("2. Создать массив случайно");
            Console.WriteLine("3. Напечатать массив");
            Console.WriteLine("4. Удалить нечетные элементы");
            Console.WriteLine("0. Вернуться в меню");

            int choice;
            while (true)
            {
                bool isRead = int.TryParse(Console.ReadLine(), out choice);
                if (!isRead) { Console.WriteLine("Недопустимый символ!"); }
                else
                    break;
            }

            switch (choice)
            {
                case 1:
                    array = CreateOneDimensionalArray();
                    break;
                case 2:
                    array = RandomOneDimensionalArray();
                    break;
                case 3:
                    PrintOneDimensionalArray(array);
                    break;
                case 4:
                    if (array != null)
                    {
                        array = RemoveOddElements(array);
                    }
                    else
                        Console.WriteLine("Массив не создан.");
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Ошибка, такого варианта ответа нет. Пожалуйста, выюерите снова.");
                    break;
            }
        }
    }

    static int[] CreateOneDimensionalArray()
    {
        Console.Write("Введите длину массива: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            Console.Write($"Введите элемент {i + 1}: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    array[i] = number;
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Введите корректное число.");
                }
            }
        }
        PrintOneDimensionalArray(array);
        return array;
    }
    static int[] RandomOneDimensionalArray()
    {
        Console.Write("Введите длину массива: ");
        int lengthRandom = int.Parse(Console.ReadLine());
        int[] array = new int[lengthRandom];
        Random random = new Random();
        for (int i = 0; i < lengthRandom; i++)
        {
            array[i] = random.Next(1, 101); // случайные числа от 1 до 100
        }
        PrintOneDimensionalArray(array); 
        return array;
    }

    static void PrintOneDimensionalArray(int[] array)
    {
        if (array != null)
        {
            if (array.Length == 0)
                    Console.WriteLine("Массив пуст!");
            else
            {
                Console.WriteLine("Элементы массива:");
                foreach (var element in array)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine();
            }   
        }
        else
            Console.WriteLine("Массив не создан.");
    }
    static int[] RemoveOddElements(int[] array)
    {
        int oddCount = 0;
        foreach (int element in array)
        {
            if (element % 2 != 0)
                oddCount++;
        }

        // новый массив, который будет хранить только четные элементы.
        int[] newArray = new int[array.Length - oddCount];
        int newIndex = 0;
        if (oddCount == 0)
            Console.WriteLine("Нечетных элементов нет!");
        else
        {
            foreach (int element in array)
            {
                if (element % 2 == 0)
                {
                    newArray[newIndex] = element;
                    newIndex++;
                }
            }
            Console.WriteLine("Нечетные элементы удалены.");
        }
        
        return newArray;
    }

    // ---------------------------------------------------------------------------------------------------------------------------------------------------------


    static void TwoDimensionalArray()
    {
        int[,] array = null;
        while (true)
        {
            Console.WriteLine("Двумерные массивы:");
            Console.WriteLine("1. Создать массив");
            Console.WriteLine("2. Напечатать массив");
            Console.WriteLine("3. Добавить k строк в начало массива");
            Console.WriteLine("0. Вернуться в меню");

            int choice;

            while (true)
            {
                bool isRead = int.TryParse(Console.ReadLine(), out choice);
                if (!isRead) { Console.WriteLine("Недопустимый символ!"); }
                else
                    break;
            }

            switch (choice)
            {
                case 1:
                    array = CreateTwoDimensionalArray();
                    break;
                case 2:
                    PrintTwoDimensionalArray(array);
                    break;
                case 3:
                    if (array != null)
                    {
                        Console.WriteLine("Введите количество строк, которые нужно добавить в массив: ");
                        int addRows = int.Parse(Console.ReadLine());
                        if (array != null)
                        {
                            array = AddRows(array, addRows);
                            Console.WriteLine("Добавлено.");
                        }
                    }
                    else                   
                        Console.WriteLine("Массив не создан.");                    
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Ошибка, такого варианта ответа нет. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }
    static int[,] CreateTwoDimensionalArray()
    {

        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int columns = int.Parse(Console.ReadLine());
        int[,] array = new int[rows, columns];

        while (true)
        {
            Console.WriteLine("Выберите способ заполнения:");
            Console.WriteLine("1. Вручную");
            Console.WriteLine("2. Случайно");

            int fillChoice;

            while (true)
            {
                bool isRead = int.TryParse(Console.ReadLine(), out fillChoice);
                if (!isRead) { Console.WriteLine("Недопустимый символ!"); }
                else
                    break;
            }

            switch (fillChoice)
            {
                case 1:
                    array = ManualFillTwoDimensional(rows, columns);
                    break;
                case 2:
                    array = RandomFillTwoDimensional(rows, columns);
                    break;
                default:
                    Console.WriteLine("Ошибка, такого варианта ответа нет.");
                    break;
            }   
            return array;
        }

    }
    static int[,] ManualFillTwoDimensional(int rows, int columns)
    {
        int[,] array = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Введите элемент [{i},{j}]: ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        array[i,j] = number;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите корректное число.");
                    }
                }
            }
        }
        PrintTwoDimensionalArray(array);
        return array;
    }

    static int[,] RandomFillTwoDimensional(int rows, int columns)
    {
        int[,] array = new int[rows, columns];
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                array[i, j] = random.Next(1, 101);
            }
        }
        PrintTwoDimensionalArray(array);
        return array;
    }

    static void PrintTwoDimensionalArray(int[,] array)
    {
        if (array != null)
        {
            if (array.GetLength(0) == 0)
                Console.WriteLine("Массив пуст!");
            else
            {
                Console.WriteLine("Элементы массива:");
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }     
        }
        else
            Console.WriteLine("Массив не создан");
        
    }

    static int[,] AddRows(int[,] array, int addedRows)
    {
        int originalRows = array.GetLength(0);
        int columns = array.GetLength(1);
        int newRows = originalRows + addedRows;

        int[,] newArray = new int[newRows, columns];

        for (int i = 0; i < addedRows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"Введите элемент [{i},{j}]: ");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        newArray[i,j] = number;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введите корректное число.");
                    }
                }
            }
        }

        for (int i = addedRows; i < newRows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                newArray[i, j] = array[i - addedRows, j];
            }
        }
        
        PrintTwoDimensionalArray(newArray);
        return newArray;
    }

    // ------------------------------------------------------------------------------------------------------------------------------------------------------------------

    static void JaggedArray()
    {
        int[][] array = null;
        while (true)
        {
            Console.WriteLine("Рваные массивы:");
            Console.WriteLine("1. Создать массив вручную");
            Console.WriteLine("2. Создать массив случайно");
            Console.WriteLine("3. Напечатать массив");
            Console.WriteLine("4. Удалить строку с заданным номером");
            Console.WriteLine("0. Вернуться в меню");

            int choice;

            while (true)
            {
                bool isRead = int.TryParse(Console.ReadLine(), out choice);
                if (!isRead) { Console.WriteLine("Недопустимый символ!"); }
                else
                    break;
            }


            switch (choice)
            {
                case 1:
                    array = CreateJaggedArray();
                    break;
                case 2:
                    array = CreateRandomJaggedArray();
                    break;
                case 3:
                    if (array != null)
                        PrintJaggedArray(array);
                    else
                        Console.WriteLine("Массив не создан");
                    break;
                case 4:
                    if (array != null)
                    {
                        Console.WriteLine("Введите номер строки, которую нужно удалить: ");
                        int rowNum = int.Parse(Console.ReadLine());
                        if (array != null)
                        {
                            array = RemoveRow(array, rowNum - 1);
                            
                        }
                    }
                    else
                        Console.WriteLine("Массив не создан!");
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Ошибка, такого варианта ответа нет. Пожалуйста, выберите снова.");
                    break;
            }
        }
    }
    static int[][] CreateJaggedArray()
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());
        int[][] array = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            Console.Write($"Введите количество элементов в строке {i + 1}: ");
            int elements = int.Parse(Console.ReadLine());
            array[i] = new int[elements];

            for (int j = 0; j < elements; j++)
            {
                Console.Write($"Введите элемент {j + 1} для строки {i + 1}: ");
                while (true)
                {
                    string input = Console.ReadLine();                 
                    if (int.TryParse(input, out int number))
                    {
                        array[i][j] = number;
                        break;
                    }
                    else                   
                        Console.WriteLine("Ошибка! Введите корректное число.");                  
                }
            }
        }
        Console.WriteLine("Элементы массива: ");
        PrintJaggedArray(array);
        return array;
    }

    static int[][] CreateRandomJaggedArray()
    {
        Random random = new Random();
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());
        int[][] array = new int[rows][];

        for (int i = 0; i < rows; i++)
        {
            int elements = random.Next(1, 20);
            array[i] = new int[elements];

            for (int j = 0; j < elements; j++)
            {
                array[i][j] = random.Next(1, 100);
            }
        }
       
        PrintJaggedArray(array);
        return array;
    }

    static void PrintJaggedArray(int[][] jaggedArray)
    {
        if (jaggedArray != null)
        {
            if (jaggedArray.GetLength(0) == 0)
                Console.WriteLine("Массив пуст!");
            else
            {
                Console.WriteLine("Элементы массива: ");
                for (int i = 0; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        Console.Write(jaggedArray[i][j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
            
        }
        else
            Console.WriteLine("Массив не создан!");
        
    }

    static int[][] RemoveRow(int[][] array, int rowNum)
    {
        if (rowNum >= 0 && rowNum < array.Length)
        {
            int[][] newArray = new int[array.Length - 1][];
            int newIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i != rowNum)
                {
                    newArray[newIndex] = array[i];
                    newIndex++;
                }
            }
            Console.WriteLine("Удалено");
            PrintJaggedArray(newArray);
            return newArray;            
        }
        else
        {
            Console.WriteLine("Недопустимый номер строки");
            return array; 
        }
    }
}

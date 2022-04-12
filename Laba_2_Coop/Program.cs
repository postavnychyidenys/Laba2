using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2_Coop
{
    class Program
    {
        // Вивидення масивiв
        static void PrintOne(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
        static void PrintTwo(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        // Заповнення масивiв
        static int[] ArrayFillingOne()
        {
            int[] array = new int[0];
            Console.WriteLine("Як заповнити масив?");
            Console.WriteLine("1 - заповнити масив випадковим чином");
            Console.WriteLine("2 - заповнити масив вручну i в окремих рядках");
            Console.WriteLine("3 - заповнити масив вручну i в одному рядку");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Введiть кiлькiсть елементiв масиву");
                    int x = Convert.ToInt32(Console.ReadLine());
                    array = new int[x];
                    Random rand = new Random();
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = rand.Next(-50, 50);
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintOne(array);
                    break;
                case 2:
                    Console.WriteLine("Введiть кiлькiсть елементiв масиву");
                    int y = Convert.ToInt32(Console.ReadLine());
                    array = new int[y];
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.WriteLine("Введiть елемент масиву");
                        array[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintOne(array);
                    break;
                case 3:
                    Console.WriteLine("Введiть елементи масиву через пробiл");
                    string str = Console.ReadLine();
                    string[] split = str.Split();
                    array = new int[split.Length];
                    for (int i = 0; i < split.Length; i++)
                    {
                        array[i] = Convert.ToInt32(split[i]);
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintOne(array);
                    break;
            }
            return array;
        }
        static int[][] ArrayFillingTwo()
        {
            Console.WriteLine("Як заповнити масив?");
            Console.WriteLine("1 - заповнити масив вручну i в окремих рядках");
            Console.WriteLine("2 - заповнити масив випадковим чином");
            Console.WriteLine("3 - заповнити масив вручну i в одному рядку");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть рядкiв");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпчикiв");
            int m = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            switch (a)
            {
                case 1:
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine("Введiть {0} елементiв {1}-го рядка(всi в один рядок через пробiли)", m, i + 1);
                        array[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintTwo(array);
                    break;
                case 2:
                    Random rand = new Random();
                    for (int i = 0; i < n; i++)
                    {
                        array[i] = new int[m];
                        for (int j = 0; j < m; j++)
                        {
                            array[i][j] = rand.Next(-50, 50);
                        }
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintTwo(array);
                    break;
                case 3:
                    int count = 0;
                    Console.WriteLine("Введiть {0} елементiв(всi в один рядок через пробiли)", n * m);
                    string str = Console.ReadLine();
                    string[] split = str.Split();
                    for (int i = 0; i < n; i++)
                    {
                        array[i] = new int[m];
                        for (int j = 0; j < m; j++)
                        {
                            array[i][j] = Convert.ToInt32(split[count]);
                            count++;
                        }
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintTwo(array);
                    break;
            }
            return array;
        }

        // Студент: Гриб С. Варiант: 5
        // Блок 1
        static int[] DeletePairIndex(int[] array)
        {
            int count = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i % 2 == 0)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        array[j - 1] = array[j];
                    }
                    count++;
                }
            }
            Array.Resize(ref array, array.Length - count);
            return array;
        }
        // Блок 2
        static int[][] Remove(int[][] array)
        {
            Console.WriteLine("Введiть дiапазон видалення рядкiв");
            Console.WriteLine("Вiд");
            int K1 = int.Parse(Console.ReadLine());
            Console.WriteLine("До");
            int K2 = int.Parse(Console.ReadLine());
            if (array.Length < K1 || array.Length < K2 || K1 <= 0 || K2 <= 0)
            {
                Console.WriteLine("Видалити неможливо, iндекс поза допустимими межами");
                return array;
            }
            int[][] array2 = new int[array.Length - (K2 - K1 + 1)][];
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (K1 < K2)
                {
                    if (i + 1 < K1 || i + 1 > K2)
                    {
                        array2[count] = array[i];
                        count++;
                    }
                }
                if (K1 > K2)
                {
                    if (i + 1 < K1 || i + 1 > K2)
                    {
                        array2[count] = array[i];
                        count++;
                    }
                }
            }
            return array2;
        }

        // Студент: Поставничий Д. Варiант: 7
        // Блок 1
        static void EraseOne(ref int[] array)
        {
            int count = 0;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    for (int j = i + 1; j < array.Length; j++)
                    {
                        array[j - 1] = array[j];
                    }
                    count++;
                }
            }
            Array.Resize(ref array, array.Length - count);
        }
        // Блок 2
        static void EraseTwo(ref int[][] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] == 0)
                    {
                        for (int x = i + 1; x < array.Length; x++)
                        {
                            array[x - 1] = array[x];
                        }
                        count++;
                        break;
                    }
                }
            }
            Array.Resize(ref array, array.Length - count);
        }

        // Студент: Гончаренко К. Варiант: 11
        // Блок 1
        static void IndexOfMax(int[] array)
        {
            int max = array[0];
            int count = 0;
            int count1 = 0;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] >= max)
                {
                    max = array[i];
                }
            }
            foreach (int elem in array)
            {
                if (elem == max)
                {
                    count++;
                }
            }
            if (max % 2 == 0)
            {
                int[] array1 = new int[array.Length + count];
                for (int i = 0; i < array1.Length; i++)
                {
                    if (array[i - count1] == max)
                    {
                        array1[i] = max / 2;
                        array[i - count1] = max / 2;
                        i++;
                        count1++;
                    }
                    array1[i] = array[i - count1];
                }
                Console.WriteLine();
                foreach (int elem in array1)
                {
                    Console.Write(elem + " ");
                }
            }
        }
        // Блок 2
        static int IndexMax(int[][] array, int m, ref int indexMax)
        {
            int max = array[0][0];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (array[i][j] > max)
                    {
                        max = array[i][j];
                        indexMax = i;
                    }
                }
            }
            return indexMax;
        }
        static int[][] AddingALine(ref int[][] array, ref int indexMax, int m)
        {
            Array.Resize(ref array, array.Length + 1);
            for (int i = array.Length - 2; i >= indexMax + 1; i--)
            {
                array[i + 1] = array[i];
            }
            array[indexMax + 1] = new int[m];
            return array;
        }
        // MAIN
        static void Main(string[] args)
        {
            int choise;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - вибрати перший блок\n2 - вибрати другий блок\n0 - закiнчити виконання програми");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            ChooseStudentOne(ArrayFillingOne());
                            break;
                        }
                    case 2:
                        {
                            ChooseStudentTwo(ArrayFillingTwo());
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Завершення програми");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неправильне число");
                            break;
                        }
                }
            } while (choise != 0);
        }
        static void ChooseStudentOne(int[] arrayOne)
        {
            int choise;
            int[] array = new int[arrayOne.Length];
            do
            {
                Console.WriteLine("\nВиберiть студента:");
                Console.WriteLine("1 - Студент: Гриб С. Варiант: 5");
                Console.WriteLine("2 - Студент: Поставничий Д. Варiант: 7");
                Console.WriteLine("3 - Студент: Гончаренко К. Варiант: 11");
                Console.WriteLine("0 - Повернутись назад");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            arrayOne.CopyTo(array, 0);
                            PrintOne(DeletePairIndex(array));
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            arrayOne.CopyTo(array, 0);
                            EraseOne(ref array);
                            PrintOne(array);
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            arrayOne.CopyTo(array, 0);
                            IndexOfMax(array);
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Повертаємось до вибору блоку");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неправильне число");
                            break;
                        }
                }
            } while (choise != 0);
        }
        static void ChooseStudentTwo(int[][] arrayTwo)
        {
            int choise;
            int[][] array = new int[arrayTwo.Length][];
            do
            {
                Console.WriteLine("\nВиберiть студента:");
                Console.WriteLine("1 - Студент: Гриб С. Варiант: 5");
                Console.WriteLine("2 - Студент: Поставничий Д. Варiант: 7");
                Console.WriteLine("3 - Студент: Гончаренко К. Варiант: 11");
                Console.WriteLine("0 - Повернутись назад");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            for (int i = 0; i < arrayTwo.Length; i++)
                            {
                                array[i] = new int[arrayTwo[i].Length];
                                arrayTwo[i].CopyTo(array[i], 0);
                            }
                            PrintTwo(Remove(array));
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < arrayTwo.Length; i++)
                            {
                                array[i] = new int[arrayTwo[i].Length];
                                arrayTwo[i].CopyTo(array[i], 0);
                            }
                            EraseTwo(ref array);
                            if (array.Length != 0)
                            {
                                Console.WriteLine("\nПеретворений масив");
                                PrintTwo(array);
                            }
                            else
                            {
                                Console.WriteLine("\nМасиву не iснує");
                            }
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            for (int i = 0; i < arrayTwo.Length; i++)
                            {
                                array[i] = new int[arrayTwo[i].Length];
                                arrayTwo[i].CopyTo(array[i], 0);
                            }
                            int indexMax = 0;
                            IndexMax(array, array[0].Length, ref indexMax);
                            AddingALine(ref array, ref indexMax, array[0].Length);
                            PrintTwo(array);
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Повертаємось до вибору блоку");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неправильне число");
                            break;
                        }
                }
            } while (choise != 0);
        }
    }
}
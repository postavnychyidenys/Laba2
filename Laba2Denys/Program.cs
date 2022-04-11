using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Laba_2
{
    class Program
    {
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
        static int[] ArrayFillingOne()
        {
            int[] array = new int[0];
            Console.WriteLine("Як заповнити масив?");
            Console.WriteLine("1 - заповнити масив випадковим чином");
            Console.WriteLine("2 - заповнити масив вручну і в окремих рядках");
            Console.WriteLine("3 - заповнити масив вручну і в одному рядку");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Введіть кількість елементів масиву");
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
                    Console.WriteLine("Введіть кількість елементів масиву");
                    int y = Convert.ToInt32(Console.ReadLine());
                    array = new int[y];
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.WriteLine("Введіть елемент масиву");
                        array[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("\nВаш масив");
                    PrintOne(array);
                    break;
                case 3:
                    Console.WriteLine("Введіть елементи масиву через пробіл");
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
            Console.WriteLine("1 - заповнити масив вручну і в окремих рядках");
            Console.WriteLine("2 - заповнити масив випадковим чином");
            Console.WriteLine("3 - заповнити масив вручну і в одному рядку");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введіть кількість рядків");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введіть кількість стовпчиків");
            int m = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            switch (a)
            {
                case 1:
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Введіть {0} елементів {1}-го рядка(всi в один рядок через пробiли)", m, i+1);
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
                        Console.WriteLine("Введіть {0} елементів(всi в один рядок через пробiли)", n * m);
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
        static int[][] ArrayFillingThree(ref int[][] arrayThree, int[] rRr, int m, int[] columns)
        {
            int y = 0;
            for (int i = 0; i < arrayThree.Length; i++)
            {
                arrayThree[i] = new int[m];
                for (int j = 0; j < columns[i]; j++)
                {
                    arrayThree[i][j] = rRr[y + 1];
                    y += 1;
                }
                y += 1;
            }
            return arrayThree;
        }
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
        static void CreateAndСalculate(out int[] rRr, out int[] columns, out int max)
        {
            Console.WriteLine("Заповніть масив: кількість елементів першого рядка, перелік елементів першого рядка, кількість елементів другого рядка, перелік елементів другого рядка і т.д.(всi елементи в один рядок через пробiли)");
            string str = Console.ReadLine();
            string[] split = str.Split();
            rRr = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                rRr[i] = Convert.ToInt32(split[i]);
            }

            columns = new int[rRr.Length / 2 - 1];
            columns[0] = rRr[0];
            int x = rRr[0];
            int count = 0;
            for (int j = 1; j < columns.Length; j++)
            {
                if (x + 1 > rRr.Length - 1)
                {
                    continue;
                }
                columns[j] = rRr[x + 1];
                x += columns[j] + 1;
                count++;
            }
            Array.Resize(ref columns, count + 1);

            max = columns[0];
            for (int g = 1; g < columns.Length; g++)
            {
                if (columns[g] > max)
                {
                    max = columns[g];
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Виберіть завдання(1-3): ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    int[] arrayOne = ArrayFillingOne();
                    EraseOne(ref arrayOne);
                    Console.WriteLine();
                    PrintOne(arrayOne);
                    break;
                case 2:
                    int[][] arrayTwo = ArrayFillingTwo();
                    EraseTwo(ref arrayTwo);
                    if (arrayTwo.Length != 0)
                    {
                        Console.WriteLine("\nПеретворений масив");
                        PrintTwo(arrayTwo);
                    }
                    else
                    {
                        Console.WriteLine("\nМасиву не існує");
                    }              
                    break;
                case 3:
                    int[] rRr, columns;
                    int m;
                    CreateAndСalculate(out rRr, out columns, out m);
                    int[][] arrayThree = new int[columns.Length][];
                    ArrayFillingThree(ref arrayThree, rRr, m, columns);
                    Console.WriteLine("\nВаш масив");
                    PrintTwo(arrayThree);
                    IComparer myComparer = new myReverserClass();
                    Array.Sort(columns, arrayThree, myComparer);
                    Console.WriteLine("\nВідсортований масив");
                    PrintTwo(arrayThree);
                    break;// 1 8 2 8 8 3 8 8 8 1 8 4 8 8 8 8
            }
        }
        public class myReverserClass : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                return ((new CaseInsensitiveComparer()).Compare(y, x));
            }
        }

    }
}

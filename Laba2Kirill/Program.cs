using System;

namespace Laba_2_block_1
{
    class Program
    {

        //Block_1
        static double[] ArrayInput_1(double[] array, int n, int x)
        {
            switch (x)
            {
                case 1:
                    {
                        Console.WriteLine("\nВведiть масив\n");
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    break;
                case 2:
                    {
                        Random rand = new Random();
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = rand.Next(-10, 10);
                        }
                        foreach (int elem in array)
                        {
                            Console.Write(elem + " ");
                        }
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("\nВведiть масив\n");
                        string str = Console.ReadLine();
                        string[] split = str.Split();
                        for (int i = 0; i < split.Length; i++)
                        {
                            array[i] = Convert.ToInt32(split[i]);
                        }
                    }
                    break;
            }
            return array;
        }
        static void IndexOfMax(double[] array)
        {
            double max = array[0];
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
                double[] array1 = new double[array.Length + count];
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
        //Block_1

        //Block_2
        static int[][] ArrayInput_2(int[][] array, int x, int n, int m)
        {

            switch (x)
            {
                case 1:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Введiть елементи {0}-го рядка", i + 1);
                            array[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                        }
                    }
                    break;
                case 2:
                    {
                        Random rand = new Random();
                        for (int i = 0; i < n; i++)
                        {
                            array[i] = new int[m];
                            for (int j = 0; j < m; j++)
                            {
                                array[i][j] = rand.Next(-10, 10);
                            }
                        }
                        Print(array);
                    }
                    break;
                case 3:
                    {
                        int count = 0;
                        Console.WriteLine("\nВведiть елементи масиву\n");
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
                        Print(array);
                    }
                    break;
            }
            return array;
        }
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
        static void Print(int[][] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        //Block_2

        //Block_3
        static void NamberOfUnpairedElements(int[][] array, ref int[] CountOfnumb)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int c = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] % 2 != 0 && array[i][j] != 0)
                    {
                        c++;
                    }
                }
                CountOfnumb[i] = c;
            }
        }
        static int[][] UnpairedElements(int[][] array, int[][] Q, ref int[] CountOfnumb)
        {
            for (int i = 0; i < Q.Length; i++)
            {
                Q[i] = new int[CountOfnumb[i]];
            }
            for (int i = 0; i < array.Length; i++)
            {
                int u = 0;
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] % 2 != 0)
                    {
                        Q[i][u] = array[i][j];
                        u++;
                    }
                }
            }
            return Q;
        }
        static void PrintQ(int[][] Q)
        {
            for (int i = 0; i < Q.Length; i++)
            {
                for (int j = 0; j < Q[i].Length; j++)
                {
                    Console.Write(Q[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Sort(ref int[][] Q)
        {
            for (int i = 0; i < Q.Length; i++)
            {
                Array.Sort(Q[i]);
            }
        }
        static void One_Dimensional_Array(int[] CountOfnumb, int[][] Q)
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < CountOfnumb.Length; i++)
            {
                sum += CountOfnumb[i];
            }
            int[] one_array = new int[sum];
            Console.WriteLine("\nОдновимiрний масив:");
            for (int i = 0; i < Q.Length; i++)
            {
                for (int j = 0; j < Q[i].Length; j++)
                {
                    one_array[count] = Q[i][j];
                    Console.Write(one_array[count] + " ");
                    count++;
                }
            }
            bool flag = true;
            for (int i = 0; i < one_array.Length; i++)
            {
                if (one_array[i] == i)
                {
                    Console.WriteLine($"\nЧисло що вiдпоiдає власному iндексу: {one_array[i]}");
                    flag = false;
                }
            }
            if (flag)
            {
                Console.WriteLine("\n\nЖодне число не вiдповiдає власному iндексу");
            }
        }
        //Block_3
        static void Main(string[] args)
        {
            Console.WriteLine(".................................");
            Console.WriteLine("Виберiть номер завдання (1, 2, 3)");
            int choise = int.Parse(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    {
                        Console.WriteLine("1 - заповнити масив вручну\n2 - заповнити масив випадковим чином\n3 - заповнити масив вручну в одному рядку");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Введiть кiлькiсть елементiв масиву: ");
                        int n = int.Parse(Console.ReadLine());
                        double[] array = new double[n];
                        ArrayInput_1(array, n, x);
                        IndexOfMax(array);
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("1 - заповнити масив вручну\n2 - заповнити масив випадковим чином\n3 - заповнити масив вручну в одному рядку");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Введiть кiлькiсть рядкiв : ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введiть кiлькiсть стовпчикiв : ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        int[][] array = new int[n][];
                        ArrayInput_2(array, x, n, m);
                        int indexMax = 0;
                        IndexMax(array, m, ref indexMax);
                        AddingALine(ref array, ref indexMax, m);
                        Print(array);

                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("1 - заповнити масив вручну\n2 - заповнити масив випадковим чином\n3 - заповнити масив вручну в одному рядку");
                        int x = int.Parse(Console.ReadLine());
                        Console.Write("Введiть кiлькiсть рядкiв : ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введiть кiлькiсть стовпчикiв : ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        int[][] array = new int[n][];
                        int[][] Q = new int[n][];
                        int[] CountOfnumb = new int[array.Length];
                        ArrayInput_2(array, x, n, m);
                        NamberOfUnpairedElements(array, ref CountOfnumb);
                        UnpairedElements(array, Q, ref CountOfnumb);
                        Console.WriteLine("\nНе вiдсортований масив:");
                        PrintQ(Q);
                        Sort(ref Q);
                        Console.WriteLine("\nВiдсортований масив:");
                        PrintQ(Q);
                        One_Dimensional_Array(CountOfnumb, Q);
                    }
                    break;
            }
        }
    }
}

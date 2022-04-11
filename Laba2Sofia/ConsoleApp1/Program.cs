using System;

namespace ConsoleApp1
{
    class Program
    {   // блок 1
        static int[] Input1()
        {
            Console.WriteLine("Виберiть спосiб заповнення масиву");
            Console.WriteLine("1 - заповнити масив випадковим чином");
            Console.WriteLine("2 - заповнити масив вручну i в окремих рядках");
            Console.WriteLine("3 - заповнити масив вручну i в одному рядку");
            int[] array = new int[0];
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.WriteLine("Введiть кiлькiсть елементiв масиву");
                        int x = Convert.ToInt32(Console.ReadLine());
                        array = new int[x];
                        Random rand = new Random();
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = rand.Next(-50, 50);
                        }
                        foreach (int elem in array)
                        {
                            Console.Write(elem + " ");
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Введiть кiлькiсть елементiв масиву");
                        int x = Convert.ToInt32(Console.ReadLine());
                        array = new int[x];
                        for (int i = 0; i < array.Length; i++)
                        {
                            Console.WriteLine("Введiть елемент масиву");
                            array[i] = Convert.ToInt32(Console.ReadLine());
                        }
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Введiть елементи масиву в одному рядку");
                        string str = Console.ReadLine();
                        string[] split = str.Split();
                        array = new int[split.Length];
                        for (int i = 0; i < split.Length; i++)
                        {
                            array[i] = Convert.ToInt32(split[i]);
                        }
                    }
                    break;
            }
            return array;
        }
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
        static void Print1(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        //блок 2
        static int[][] Input2()
        {
            Console.WriteLine("1 - заповнити масив вручну i в окремих рядках");
            Console.WriteLine("2 - заповнити масив випадковим чином");
            Console.WriteLine("3 - заповнити масив вручну i в одному рядку");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть рядкiв");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпчикiв");
            int m = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            switch (x)
            {
                case 1:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Введiть {0} елементи рядок", m, i + 1);
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
                                array[i][j] = rand.Next(-50, 50);
                            }
                        }
                        Console.WriteLine("Матриця");
                        Print2(array);
                    }
                    break;
                case 3:
                    {
                        int count = 0;
                        Console.WriteLine("Введiть {0} елемента(iв) в один рядок", n * m);
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
                        Console.WriteLine("Матриця");
                        Print2(array);
                    }
                    break;
            }
            return array;
        }
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
        static void Print2(int[][] array)
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
        // блок 3         
        static int[][] Input3(out int b)
        {
            Console.WriteLine("1 - заповнити масив вручну i в окремих рядках");
            Console.WriteLine("2 - заповнити масив випадковим чином");
            Console.WriteLine("3 - заповнити масив вручну i в одному рядку");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть рядкiв");
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] array = new int[n][];
            Console.WriteLine("Дiапазон [1:5]");
            int a = 1;
            b = 5;
            int sum = 0;
            Random rand = new Random();
            for (int i = 0; i < n - 1; i++)
            {
                int m = rand.Next(a, b);
                array[i] = new int[m];
                sum += m;
            }
            bool flag = true;
            while (flag)
            {
                flag = false;
                if (sum < b * b)
                {
                    flag = true;
                    b--;
                }
            }
            b++;
            array[n - 1] = new int[b * b - sum];
            switch (x)
            {
                case 1:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Введiть {0} елементи(ів) в рядок", array[i].Length);
                            array[i] = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                        }
                        Console.WriteLine("Матриця");
                        Print2(array);
                    }
                    break;
                case 2:
                    {
                        Random rand1 = new Random();
                        for (int i = 0; i < n; i++)
                        {
                            array[i] = new int[array[i].Length];
                            for (int j = 0; j < array[i].Length; j++)
                            {
                                array[i][j] = rand1.Next(-50, 50);
                            }
                        }
                        Console.WriteLine("Матриця");
                        Print2(array);
                    }
                    break;
                case 3:
                    {
                        int cnt = 0;
                        Console.WriteLine("Введiть {0} елемента(iв) в один рядок", sum + array[array.Length - 1].Length);
                        string str = Console.ReadLine();
                        string[] split = str.Split();
                        for (int i = 0; i < n; i++)
                        {
                            array[i] = new int[array[i].Length];
                            for (int j = 0; j < array[i].Length; j++)
                            {
                                array[i][j] = Convert.ToInt32(split[cnt]);
                                cnt++;
                            }
                        }
                        Console.WriteLine("Матриця");
                        Print2(array);
                    }
                    break;
            }            
            return array;
        }
        static int[] Mass(int[][] array, int b)
        {
            int count = 0;
            int[] arr = new int[b * b];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    arr[count++] = array[i][j];
                }
            }
            Array.Sort(arr);             
            return arr;
        }        
        static void Print3(int[,] array)
        {
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Виберiть блок 1-3");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        int[] array = Input1();
                        Print1(DeletePairIndex(array));
                    }
                    break;
                case 2:
                    {
                        int[][] array = Input2();
                        Print2(Remove(array));
                    }
                    break;
                case 3:
                    {
                        int b;
                        int[][] array = Input3(out b);
                        int[] arr = Mass(array,b);
                        int[,] sqmass = new int[b,b];
                        int count = 0;
                        for (int i = 0; i < b; i++)
                        {
                            for (int j = 0; j < b; j++)
                            {
                                sqmass[i, j] = arr[count++];
                            }
                        }
                        Print3(sqmass);
                    }
                    break;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2_Coop
{
    class Program
    {
        // Вивід масивів
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
        // Заповнення масивів
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
                        Console.WriteLine("Введіть {0} елементів {1}-го рядка(всi в один рядок через пробiли)", m, i + 1);
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
        
        // Студент: Гриб С. Варіант: 5
        // Блок 1

        // Блок 2
        
        
        // Студент: Поставничий Д. Варіант: 7
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
        
        // Студент: Гончаренко К. Варіант: 11
        // Блок 1
        
        // Блок 2
        
        // MAIN
        static void Main(string[] args)
        {
            int choise;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - вибрати перший блок\n2 - вибрати другий блок\n0 - закінчити виконання програми");
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
                Console.WriteLine("\nВиберіть студента:");
                Console.WriteLine("1 - Студент: Гриб С. Варіант: 5");
                Console.WriteLine("2 - Студент: Поставничий Д. Варіант: 7");
                Console.WriteLine("3 - Студент: Гончаренко К. Варіант: 11");
                Console.WriteLine("0 - Повернутись назад");
                choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            arrayOne.CopyTo(array, 0);

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
                Console.WriteLine("\nВиберіть студента:");
                Console.WriteLine("1 - Студент: Гриб С. Варіант: 5");
                Console.WriteLine("2 - Студент: Поставничий Д. Варіант: 7");
                Console.WriteLine("3 - Студент: Гончаренко К. Варіант: 11");
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
                                Console.WriteLine("\nМасиву не існує");
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

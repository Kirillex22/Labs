using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    class Program
    {
        public static void ArrMeth(string[] arr)
        {
            char k = 'g';
            while (k != '0')
            {
                Console.Clear();
                int n = arr.GetLength(0);
                Console.WriteLine("Sort - 1");
                Console.WriteLine("BinarySearch - 2");
                Console.WriteLine("Copy - 3");
                Console.WriteLine("IndexOf - 4");
                Console.WriteLine("LastIndexOf - 5");
                Console.WriteLine("Length - 6");
                Console.WriteLine("Rank - 7");
                Console.WriteLine("Reverse - 8");
                Console.WriteLine("Clear - 9");
                Console.WriteLine("Выход - 0");
                k = Console.ReadKey(true).KeyChar;

                if (k == '1')
                {
                    Console.Clear();
                    Array.Sort(arr, 0, n - 1);
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(arr[i]);
                        Console.Write(" ");
                    }
                    Console.ReadKey();
                }
                else if ( k == '2')
                {
                    Console.Clear();
                    Console.WriteLine("введите элемент");
                    Console.WriteLine(Array.BinarySearch(arr, Console.ReadLine()));
                    Console.ReadKey();

                }
                else if (k == '3')
                {
                    string[] a = new string[n];
                    Console.Clear();
                    Array.Copy(arr, 0, a, 0, n);
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(arr[i]);
                        Console.Write(" ");
                    }
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(a[i]);
                        Console.Write(" ");
                    }
                    Console.ReadKey();
                }
                else if (k == '4')
                {
                    Console.Clear();
                    Console.WriteLine("введите элемент");
                    Console.WriteLine(Array.IndexOf(arr, int.Parse(Console.ReadLine())));
                    Console.ReadKey();
                }
                else if (k == '5')
                {
                    Console.Clear();
                    Console.WriteLine("введите элемент");
                    Console.WriteLine(Array.LastIndexOf(arr, int.Parse(Console.ReadLine())));
                    Console.ReadKey();
                }
                else if (k == '6')
                {
                    Console.Clear();
                    Console.WriteLine(arr.Length);
                    Console.ReadKey();

                }
                else if (k == '7')
                {
                    Console.Clear();
                    Console.WriteLine(arr.Rank);
                    Console.ReadKey();
                }
                else if (k == '8')
                {
                    Console.Clear();
                    Array.Reverse(arr);
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(arr[i]);
                        Console.Write(" ");
                    }
                    Console.ReadKey();
                }
                else if (k == '9')
                {
                    Console.Clear();
                    Array.Clear(arr, 0, n);
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(arr[i]);
                        Console.Write(" ");
                    }
                    Console.ReadKey();
                }
                else if (k == 'a')
                {
                    Console.Clear();
                    
                    Console.ReadKey();
                }
                else if (k == '0')
                {
                    Console.Clear();
                    break;
                }

            }
            

        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                int a = int.Parse(Console.ReadLine());
                Array arr = new string[a];
                Console.WriteLine("введите массив");
                for (int i = 0; i < a; i++)
                {
                    arr[i] = Console.ReadLine();
                }
                ArrMeth(arr);
                

            }
        }
    }
}

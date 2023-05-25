using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication34
{
    interface IMath{
        double Plus(double a, double b);

        double Minus(double a, double b);
        
        double Del(double a, double b);

        double Multiply(double a, double b);
    }
    class Operations : IMath
    {
        public double Plus(double a, double b){
            return a + b;
        }
        public double Minus(double a, double b){
            return a - b;
        }
        public double Del(double a, double b){
            if (b != 0){
                return a / b;
            }
            else {
                throw new Exception("stroka with error");
            }
        }
        public double Multiply(double a, double b){
            return a * b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Operations();
            double a,b;
            operation ops = obj.Plus;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("слож //1");
                Console.WriteLine("минус //2");
                Console.WriteLine("делен //3");
                Console.WriteLine("умнож //4");
                char k = Console.ReadKey(true).KeyChar;
                switch (k)
                {
                    case '1':
                        Console.Clear();
                        ops = null;
                        ops += obj.Plus;
                        a = double.Parse(Console.ReadLine());
                        b = double.Parse(Console.ReadLine());
                        Console.WriteLine(ops(a, b));
                        Console.ReadKey();
                        ops -= obj.Plus;
                        break;
                    case '2':
                        Console.Clear();
                        ops = null;
                        ops += obj.Minus;
                        a = double.Parse(Console.ReadLine());
                        b = double.Parse(Console.ReadLine());
                        Console.WriteLine(ops(a, b));
                        ops -= obj.Minus;
                        Console.ReadKey();
                        break;
                    case '3':
                        Console.Clear();
                        ops = null;
                        ops = obj.Del;
                        a = double.Parse(Console.ReadLine());
                        b = double.Parse(Console.ReadLine());
                        Console.WriteLine(ops(a, b));
                        ops -= obj.Del;
                        Console.ReadKey();
                        break;
                    case '4':
                        Console.Clear();
                        ops = null;
                        ops += obj.Multiply;
                        a = double.Parse(Console.ReadLine());
                        b = double.Parse(Console.ReadLine());
                        Console.WriteLine(ops(a, b));
                        ops -= obj.Multiply;
                        Console.ReadKey();
                        break;
            }
            
            }
        }
    }
    delegate double operation(double a, double b);
}

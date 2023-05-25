using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = 0;
            string word = "";
            string[] mas = new string[10];
            for (int i = 0; i < 10; i++)
            {
                word = "word" + Convert.ToString(i);
                mas[i] = word;
            }
            Hashtable sample = new Hashtable();
            Object sample1 = new Hashtable();
            sample.Add("key1", "22042004");
            sample.Add("key2", "23042004");
            sample.Add("key3", "24042004");
            sample.Add("key4", "25042004");
            string key, value, name;
            int index;
            while (t == 0)
            {
                Console.WriteLine("Your Hashtable:");
                foreach (var i in sample.Keys)
                {
                    Console.Write(" {0},{1} |", i, sample[i]);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Add(Object, Object) //1");
                Console.WriteLine("Clear() //2");
                Console.WriteLine("Clone() //3");
                Console.WriteLine("ContainsKey(Object) //4");
                Console.WriteLine("ContainsValue(Object) //5");
                Console.WriteLine("CopyTo(Array, Int32) //6");//
                Console.WriteLine("Hashtable[key].GetHashCode //7");
                Console.WriteLine("GetType() //8");
                Console.WriteLine("Remove(Object) //9");
                Console.WriteLine("выход //любая клавиша");

                char k = Console.ReadKey(true).KeyChar;

                switch (k)
                {
                    case '1':
                        value = " ";
                        key = " ";
                        while ((value != "")||(key != ""))
                        {
                            Console.Clear();
                            Console.WriteLine("новый элемент key value //чтобы закончить, нажмите enter");
                            key = Console.ReadLine();
                            value = Console.ReadLine();
                            if (key != ""){
                                sample.Add(key, value);
                            }
                            Console.Clear();
                        }
                        break;
                    case '2':
                        Console.Clear();
                        sample.Clear();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '3':
                        Console.Clear();
                        sample1 = sample.Clone();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '4':
                        Console.Clear();
                        key = Console.ReadLine();
                        Console.WriteLine(sample.ContainsKey(key));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '5':
                        Console.Clear();
                        value = Console.ReadLine();
                        Console.WriteLine(sample.ContainsKey(value));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '6':
                        Console.Clear();
                        index = int.Parse(Console.ReadLine());
                        name = Console.ReadLine();
                        if (name == "values"){
                            sample.Values.CopyTo(mas, index);
                        }
                        else if (name == "keys"){
                            sample.Keys.CopyTo(mas, index);
                        }
                        foreach(var i in mas)
                        {
                            Console.Write(i+" ");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '7':
                        Console.Clear();
                        key = Console.ReadLine();
                        Console.WriteLine(sample[key].GetHashCode());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '8':
                        Console.Clear();
                        Console.WriteLine(sample.GetType());
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '9':
                        Console.Clear();
                        key = Console.ReadLine();
                        sample.Remove(key);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        t = 1;
                        break;
                }




            }

        }
    }
}

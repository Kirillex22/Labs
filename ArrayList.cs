
namespace ArrayList{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.Metrics;
    internal class Program{
        public dynamic Type(string type, string enter){
            switch (type){
                case "int":
                    int k1;
                    k1 = int.Parse(enter);
                    return k1;
                case "double":
                    double k2;
                    k2 = Convert.ToDouble(enter);
                    return k2;
                case "bool":
                    bool k3;
                    k3 = bool.Parse(enter);
                    return k3;
                case "string":
                    return enter;
                case "char":
                    char k4;
                    k4 = char.Parse(enter);
                    return k4;
                default:
                    return null;
            }
        }
        static void Main(string[] args){
            int count;
            var obj = new Program();
            List<string> col = new List<string>();
            string type;
            string enter;
            int t = 0;
            ArrayList sample = new ArrayList();
            sample.Add("object1_string");
            sample.Add(2);
            sample.Add(3.005);
            sample.Add('?');
            sample.Add(true);
            while (t == 0){
                Console.WriteLine("Your ArrayList:");
                foreach (var i in sample){
                    Console.Write(" {0} |", i);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Add(Object) //1");
                Console.WriteLine("Clear() //2"); 
                Console.WriteLine("Contains(Object) //3");
                Console.WriteLine("FixedSize(ArrayList) //4"); 
                Console.WriteLine("Remove(Object) //5");
                Console.WriteLine("AddRange(ICollection col) //6");
                Console.WriteLine("IndexOf(Object) //7");
                Console.WriteLine("Sort() [если тип одинаков для всех элементов] //8");
                Console.WriteLine("выход //любая клавиша");

                char k = Console.ReadKey(true).KeyChar;

                switch (k){
                    case '1':
                        type = " ";
                        while (true){
                            Console.Clear();
                            Console.WriteLine("введите первой строкой тип, второй - новый элемент //чтобы закончить, нажмите enter");
                            type = Console.ReadLine();
                            if (type == "")
                                break;
                            enter = Console.ReadLine();
                            if (obj.Type(type, enter) != null){
                                sample.Add(obj.Type(type, enter));
                            }
                            else
                                break;
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
                        type = " ";
                        while (type != ""){
                            Console.Clear();
                            Console.WriteLine("введите первой строкой тип, второй - элемент //чтобы закончить, нажмите enter");
                            type = Console.ReadLine();
                            enter = Console.ReadLine();
                            Console.WriteLine(sample.Contains(obj.Type(type, enter)));
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case '4':
                        Console.Clear();
                        sample = ArrayList.FixedSize(sample);
                        Console.WriteLine("теперь экземпляр arraylist имеет фиксированную размерность");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '5':
                        Console.Clear();
                        type = Console.ReadLine();
                        enter = Console.ReadLine();
                        sample.Remove(obj.Type(type, enter));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '6':
                        Console.Clear();
                        Console.WriteLine("введите число элементов коллекции,а затем заполните ее (тип string для упрощения");
                        enter = Console.ReadLine();
                        for (int i = 0; i < int.Parse(enter); i++){
                            Console.WriteLine("элемент {0}", i + 1);
                            col.Add(Console.ReadLine());
                        }
                        Console.Clear();
                        sample.AddRange(col);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '7':
                        Console.Clear();
                        type = Console.ReadLine();
                        enter = Console.ReadLine();
                        Console.WriteLine(sample.IndexOf(obj.Type(type,enter)));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case '8':
                        Console.Clear();
                        sample.Sort();
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

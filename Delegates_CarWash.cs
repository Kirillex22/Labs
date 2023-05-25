namespace Delegates_CARWASH
{
    delegate void carwasher(Car car);
    class Car{
        public string name { get; }
        public string id { get; }
        public string host{ get; }
        public int dirt_degree { get; }

        public Car(string name, string id, string host, int dirt_degree){
            this.name = name;
            this.id = id;
            this.host = host;
            this.dirt_degree = dirt_degree; //от 1 до 5
        }
    }
    class Garage{
        public List<Car> car { get; set; }
        public Garage(){
            car = new List<Car>();
        }

    }
    class CarWash{
        public static void WashCar(Car car){
            Console.WriteLine("{0}, мойка вашей {1} турбореактивным пылесосом займет {2} секунд"
                , car.host, car.name, car.dirt_degree);
            Thread.Sleep(1000*car.dirt_degree);
            Console.WriteLine("{0} с номером {1} готова", car.name, car.id);
            Console.ReadKey();
            Console.Clear();
        }
    }
    internal class Program{
        static void Main(string[] args){
            carwasher carwasher1 = CarWash.WashCar;
            Car volks = new Car("Boeing 747", "А341BC 55", "Кирилл Сергеевич", 2);
            Car ferra = new Car("Toyota", "L054PA", "Егор Алексеевич", 5);
            Garage mygarage = new Garage();
            mygarage.car.Add(volks);
            mygarage.car.Add(ferra);
            foreach(Car car in mygarage.car){
                carwasher1(car);
            }
        }
    }
}

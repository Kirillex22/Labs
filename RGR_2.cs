using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace RGR
{
    class Person
    {
        public string Name { get;}
        public string Surname { get; }
        public string Patronymic { get; }
        public string Phone { get;} 
        public string Date { get;}
        public string Adress { get;}
        public Person(string surname, string name, string patronymic, string phone, string date, string adress){
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Phone = phone;
            Date = date;
            Adress = adress;
        }
        public string Print(){
            string u = "";
            u += (Surname + "/" +Name + "/" + Patronymic + "/" + Phone + "/" + Date + "/" + Adress);
            return u;
        }
    }
    internal class Program
    {
        public static int DateD(string date)
        {

            string day, month, year;
            if (date[0] == '0')
            {
                day = date[1] + ""; //19.02.1982
            }
            else
            {
                day = Convert.ToString(date[0]) + Convert.ToString(date[1]) + "";
            }

            if (date[3] == '0')
            {
                month = date[3] + "";
            }
            else
            {
                month = Convert.ToString(date[3]) + Convert.ToString(date[4]) + "";
            }

            year = Convert.ToString(date[6]) + Convert.ToString(date[7]) + Convert.ToString(date[8]) + Convert.ToString(date[9]) + "";

            int final = int.Parse(day) + int.Parse(month) * 31 + int.Parse(year) * 365;

            return final;
        }
            //Разработать электронную "записную книжку", содержащую фамилии, имена, отчества; номера телефонов, адрес; год, месяц и день рождения.
            //По запросу должен выдаваться на экран ПК номер телефона, фамилия по номеру телефона или другая информация;
            //список лиц с днями рождения в одном месяце в порядке возрастания дат.
            static void Main(string[] args)
        {
            string nsp, phone, date, adress;
            string[] nsp1;
            Dictionary<int, Person> peop = new Dictionary<int, Person>();
            List<int> peopkeys = new List<int>();
            List < Person > people = new List<Person>();
            string path = "C:/Users/ziabr/Desktop/data.txt";

            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null) //Фамилия/Имя/Отчество/телефон/дата/адрес
                {
                    string[] words = line.Split(new char[] { '/' });
                    Person mrdak = new Person(words[0], words[1], words[2], words[3], words[4], words[5]);
                    people.Add(mrdak);
                }
            }

            int t = 0;

            while (t==0){
                string temp;
                Console.WriteLine("1 - поиск по номеру телефона");
                Console.WriteLine("2 - поиск по фамилии");
                Console.WriteLine("3 - поиск по имени");
                Console.WriteLine("4 - поиск людей по месяцу рождения");
                Console.WriteLine("5 - добавить человека");
                Console.WriteLine("6 - список контактов");
                Console.WriteLine("7 - выход");

                var k = Console.ReadKey().KeyChar;

                switch (k){
                    case '1':
                        Console.Clear();
                        Console.WriteLine("введите номер телефона");
                        temp = Console.ReadLine();
                        Console.WriteLine();
                        foreach (Person i in people)
                        {
                            if (i.Phone == temp)
                            {
                                Console.WriteLine(i.Print());
                                Console.WriteLine();
                            }
                        }
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case '2':
                        Console.Clear();
                        Console.WriteLine("введите фамилию");
                        temp = Console.ReadLine();
                        Console.WriteLine();
                        foreach (Person i in people)
                        {
                            if (i.Surname == temp)
                            {
                                Console.WriteLine(i.Print());
                                Console.WriteLine();
                            }
                        }
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case '3':
                        Console.Clear();
                        Console.WriteLine("введите имя");
                        temp = Console.ReadLine();
                        Console.WriteLine();
                        foreach (Person i in people)
                        {
                            if (i.Name == temp)
                            {
                                Console.WriteLine(i.Print());
                                Console.WriteLine();
                            }
                        }
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case '4':
                        int max = 999999999;
                        Console.Clear();
                        Console.WriteLine("введите месяц");
                        temp = Console.ReadLine();
                        Console.WriteLine();
                        foreach (Person i in people)
                        {
                            if (i.Date.Substring(3,2) == temp) //12.12.2022
                            {
                                peop.Add(DateD(i.Date), i);
                                peopkeys.Add(DateD(i.Date));
                            }
                        }
                        peopkeys.Sort();
                        foreach (int i in peopkeys)
                        {
                            foreach (var j in peop)
                            {
                                if (i == j.Key)
                                {
                                    Console.WriteLine(j.Value.Print());
                                }
                            }
                        }
                        Console.ReadKey(true);
                        Console.Clear();
                        peop.Clear();
                        peopkeys.Clear();
                        break;
                    case '5':
                        Console.Clear();
                        Console.WriteLine("введите ФИО");
                        nsp = Console.ReadLine();
                        nsp1 = nsp.Split(new char[] { ' ' });
                        Console.Clear();
                        Console.WriteLine("введите номер телефона");
                        phone = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("введите дату рождения");
                        date = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("введите адрес");
                        adress = Console.ReadLine();
                        Console.Clear();
                        Person noname = new Person(nsp1[0], nsp1[1], nsp1[2], phone, date, adress);
                        people.Add(noname);
                        Console.WriteLine("данные успешно добавлены");
                        Console.ReadKey(true);
                        break;
                    case '6':
                        Console.Clear();
                        foreach (Person i in people)
                        {
                            Console.WriteLine(i.Print());
                            Console.WriteLine();
                        }
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    case '7':
                        using (StreamWriter writer = new StreamWriter(path, false))
                        {
                            foreach (Person i in people){
                                writer.WriteLine(i.Print());
                            }
                        }
                        t = 1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("неверный ввод");
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                }

            }

        }
    }
}
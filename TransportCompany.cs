using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{

    class Cars
    {
        public string name; // название 
        string d_tech; // дата техосмотра
        string remonter; // имя ремонтника 
        string[] driver = new string[2];

        public Cars(string nam, string d_tec, string remonte, string[] drive) { name = nam; d_tech = d_tec; remonter = remonte; driver = drive; }

        public void Print(int k)
        {
            if (k == 0)
            {
                Console.WriteLine(name);
                Console.WriteLine("Дата последнего техосмотра: {0}", d_tech);
                Console.WriteLine("Механик: {0}", remonter);
            }

            else if (k == 1)
            {
                Console.WriteLine(name);
                foreach (string i in driver)
                {
                    Console.WriteLine(i);
                }
            }
        }

    }

    class Workers
    {
        public string name; //имя работника
        public string[] stage = new string[4]; //стаж

        public Workers(string nam, string[] stag) { name = nam; stage = stag; }
    }

    class Driver : Workers
    {
        string[] transport = new string[2]; //история транспорта

        public Driver(string[] transpor, string name, string[] stage) : base(name, stage) { transport = transpor; this.name = name; this.stage = stage; }

        public void Print()
        {
            Console.WriteLine(name);
            foreach (string i in transport)
            {
                Console.WriteLine(i);
            }
        } 
    }

    class Manager : Workers
    {
        string[] prikazlb = new string[5]; //дата наименование

        public Manager(string[] prikaz, string name, string[] stage) : base(name, stage) { prikazlb = prikaz; this.name = name; this.stage = stage; }

        public void Print()
        {
            Console.WriteLine(name);
            foreach (string i in prikazlb)
            {
                Console.WriteLine(i);
            }
        }
    }

    class Program
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

        public static int[] Stage(string date, string rec)
        {
            int[] ret = new int[3];
            int stage, stageD, stageM, stageY;
            stage = DateD(date) - DateD(rec); //rec - recruiting 28.02.2023 29.02.2023
            stageY = stage / 365;
            stageM = (stage % 365) / 31;
            stageD = (stage % 365) % 31;

            ret[0] = stageD;
            ret[1] = stageM;
            ret[2] = stageY;

            return ret;


        }
        /*  - для каждого трансп опр дату последннего техосмотра? кто ремонтировал?

            - кто являлся водителем данного трансп?

            - по запросу о водителе выдать историю используем трансп?

            - определить стаж работника (2 стажа: работа на предпр и общий (должны знать где он работал раньше)?

            - необходимо опр какие приказы были изданы управл составом и кем? (дата издания, наименование)     */

        static void Main(string[] args)
        {    
            string name;
            string date;
            string[] kayneprikaz = new string[] { "01.12.2022/Зачислен механиком Егор Алексеевич", "03.12.2022/Зачислен водителем Кирилл Сергеевич", "04.12.2022/Зачислен водителем Александр Браниславович", "01.12.2022/Учредил компанию Канье Уэст" };
            string[] kanyestage = new string[] { "9 лет - Музыкалити", "01.12.2022" };
            string[] yegorstage = new string[] { "4 года - ООО ШИНЫ", "01.12.2022" };
            string[] kirillstage = new string[] { "9 лет - Московский Кремль", "03.12.2022" };
            string[] MANLIST = new string[] { "Кирилл Сергеевич", "Александр Браниславович" };
            string[] Volvolist = new string[] { "Кирилл Сергеевич", "Александр Браниславович" };
            string[] kirilltransp = new string[] { "Volvo", "MAN" };
            string[] alextransp = new string[] { "Volvo", "MAN" };
            string[] alexstage = new string[] { "0 лет", "01.02.2023" };

            Manager Kanye = new Manager(kayneprikaz, "Канье Уэст", kanyestage);
            Workers Yegor = new Workers("Егор Алексеевич", yegorstage);
            Driver Kirill = new Driver(kirilltransp, "Кирилл Сергеевич", kirillstage);
            Driver Alex = new Driver(alextransp, "Александр Браниславович", alexstage);
            Cars MAN = new Cars("MAN", "27.02.2023", "Егор Алексеевич", MANLIST);
            Cars Volvo = new Cars("Volvo", "01.01.2023", "Егор Алексеевич", Volvolist);

            List<Workers> a = new List<Workers> { Kanye, Yegor, Kirill, Alex };
            List<Cars> b = new List<Cars> { MAN, Volvo };
            List<Driver> a1 = new List<Driver> { Kirill, Alex };
            List<Manager> a2 = new List<Manager> { Kanye };


            while (true)
            {
                string exit = "default";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вас приветствует ТК 'Cyberbulling Delivery Inc'! \n");
                Console.ResetColor();
                Console.WriteLine("Для просмотра даты ТС транспорта и данных о механике нажмите 1");
                Console.WriteLine("Для просмотра списка водителей транспорта нажмите 2");
                Console.WriteLine("Для просмотра истории транспорта, который использовал водитель, нажмите 3");
                Console.WriteLine("Для просмотра стажа сотрудника нажмите 4"); 
                Console.WriteLine("Для просмотра истории приказов менеджмента нажмите 5");
                Console.WriteLine("Для ознакомления со списком сотрудников и ТС нажмите 6");
                Console.WriteLine("Для добавления сотрудника нажмите 7 (требуется пароль)");//пароль kanyewest
                Console.WriteLine("Для выхода нажмите 8");
             
                try
                {
                    int v = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (v == 1)
                    {
                        while (exit != "q")
                        {
                            Console.WriteLine("Введите наименование транспортного средства");
                            name = Console.ReadLine();
                            foreach (Cars i in b)
                            {
                                if (i.name == name)
                                {
                                    i.Print(0);
                                    Console.WriteLine("для выхода введите q");
                                    exit = Console.ReadLine();
                                    Console.Clear();
                                }
                            }

                        }

                    }

                    else if (v == 2)
                    {
                        while (exit != "q")
                        {
                            Console.WriteLine("Введите наименование транспортного средства");
                            name = Console.ReadLine();
                            foreach (Cars i in b)
                            {
                                if (i.name == name)
                                {
                                    i.Print(1);
                                    Console.WriteLine("для выхода введите q");
                                    exit = Console.ReadLine();
                                    Console.Clear();
                                }
                            }

                        }

                    }

                    else if (v == 3)
                    {
                        while (exit != "q")
                        {
                            Console.WriteLine("Введите имя водителя");
                            name = Console.ReadLine();
                            foreach (Driver i in a1)
                            {
                                if (i.name == name)
                                {
                                    i.Print();
                                    Console.WriteLine("для выхода введите q");
                                    exit = Console.ReadLine();
                                    Console.Clear();
                                }
                            }

                        }


                    }
                    else if (v == 4) 
                    {
                        while (exit != "q")
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя сотрудника ");
                            name = Console.ReadLine();
                            Console.WriteLine("Введите сегодняшнюю дату");
                            date = Console.ReadLine();

                            foreach (Workers i in a)
                            {
                                if (name == i.name)
                                {

                                    Console.WriteLine("стаж в 'Cyberbulling Delivery Inc':");
                                    Console.WriteLine("{0} дней", Stage(date, i.stage[1])[0]);
                                    Console.WriteLine("{0} месяцев", Stage(date, i.stage[1])[1]);
                                    Console.WriteLine("{0} лет", Stage(date, i.stage[1])[2]);
                                    Console.WriteLine("общий стаж:");
                                    Console.WriteLine("{0} дней", Stage(date, i.stage[1])[0]);
                                    Console.WriteLine("{0} месяцев", Stage(date, i.stage[1])[1]);
                                    Console.WriteLine("{0} лет", Stage(date, i.stage[1])[2] + int.Parse((i.stage[0])[0] + ""));
                                    Console.WriteLine("для выхода введите q");
                                    exit = Console.ReadLine();
                                    Console.Clear();
                                }
                            }
                        }

                    }
                    else if (v == 5)
                    {
                        while (exit != "q")
                        {
                            Console.WriteLine("Введите имя менеджера");
                            name = Console.ReadLine();
                            foreach (Manager i in a2)
                            {
                                if (i.name == name)
                                {
                                    i.Print();
                                    Console.WriteLine("для выхода введите q");
                                    exit = Console.ReadLine();
                                    Console.Clear();
                                }
                            }

                        }
                    }
                    else if (v == 6)
                    {
                        Console.WriteLine("Работники:");
                        foreach (Workers i in a)
                        {
                            Console.WriteLine(i.name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Транспортные средства:");
                        foreach (Cars i in b)
                        {
                            Console.WriteLine(i.name);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Чтобы закрыть, нажмите любую клавишу");
                        Console.ReadKey();
                    }
                    else if (v == 7)
                    {
                        int c = 3;
                        while (c != 0)
                        {
                            if (exit == "q")
                            {
                                break;
                            }
                            Console.WriteLine("пароль:");
                            if (Console.ReadLine() == "kanyewest")
                            {
                                Console.Clear();
                                string[] u = new string[2];
                                string[] u1 = new string[2];
                                string h1, h2, h3;
                                while (exit != "q")
                                {
                                    Console.WriteLine("Car/Worker?");
                                    string t = Console.ReadLine();
                                    if (t == "Car")
                                    {
                                        while (exit != "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Название");
                                            h1 = Console.ReadLine();
                                            Console.WriteLine("Зарегистрированные водители (до 2)");
                                            for (int i = 0; i < 2; i++)
                                            {
                                                u[i] = Console.ReadLine();
                                            }
                                            Console.WriteLine("Дата последнего ТС");
                                            h2 = Console.ReadLine();
                                            Console.WriteLine("Механик, проводивший ТС");
                                            h3 = Console.ReadLine();
                                            Cars car = new Cars(h1, h2, h3, u);
                                            b.Add(car);
                                            Console.WriteLine("транспорт добавлен");
                                            Console.WriteLine("желаете продолжить? q выход");
                                            exit = Console.ReadLine();
                                            Console.Clear();

                                        }

                                    }
                                    else if (t == "Worker")
                                    {
                                        while (exit != "q")
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Должность (Worker/Driver)");
                                            t = Console.ReadLine();
                                            if (t == "Worker")
                                            {
                                                Console.Clear();
                                                while (exit != "q")
                                                {
                                                    Console.WriteLine("Имя (Фам, отч)");
                                                    h1 = Console.ReadLine();
                                                    Console.WriteLine("Прошлый стаж(формат год - компания), дата приема на работу");
                                                    for (int i = 0; i < 2; i++)
                                                    {
                                                        u[i] = Console.ReadLine();
                                                    }
                                                    Workers worker = new Workers(h1, u);
                                                    a.Add(worker);
                                                    Console.WriteLine("Worker добавлен");
                                                    Console.WriteLine("желаете продолжить? q выход");
                                                    exit = Console.ReadLine();
                                                    Console.Clear();

                                                }
                                                
                                            }
                                            else if (t == "Driver")
                                            {
                                                Console.Clear();
                                                while (exit != "q")
                                                {
                                                    Console.WriteLine("Имя (Фам, отч)");
                                                    h1 = Console.ReadLine();
                                                    Console.WriteLine("Прошлый стаж(формат год - компания), дата приема на работу");
                                                    for (int i = 0; i < 2; i++)
                                                    {
                                                        u[i] = Console.ReadLine();
                                                    }
                                                    Console.WriteLine("Транспорт, на который зарегистрирован");
                                                    for (int i = 0; i < 2; i++)
                                                    {
                                                        u1[i] = Console.ReadLine();
                                                    }
                                                    Driver ryangosling = new Driver(u1, h1, u);
                                                    a.Add(ryangosling);
                                                    a1.Add(ryangosling);
                                                    Console.WriteLine("Worker добавлен");
                                                    Console.WriteLine("желаете продолжить? q выход");
                                                    exit = Console.ReadLine();
                                                    Console.Clear();

                                                }

                                            }

                                        }


                                    }

                                }
                            }

                            else
                            {
                                c--;
                                Console.WriteLine("неверный пароль, осталось {0} попыток", c);
                            }

                        }                       
                       
                    }
                    else if (v == 8)
                    {
                        break;
                    }

                }
                catch
                {
                    Console.WriteLine("Некорректный ввод");
                }




            }
        }
    }
}


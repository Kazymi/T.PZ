using System;
using System.Collections.Generic;

namespace LB3
{
    class Program
    {
        private static List<ClientMedCentr> Clients = new List<ClientMedCentr>(); //создаем список клиентов.
        private static List<ClientMedCentr> CopyClients = new List<ClientMedCentr>(); //список для копирования.
        static void Main(string[] args)
        {
            Clients.Add(new ClientMedCentr("Дмитрий", "Сергиенко", 654235, true, 6));
            Clients.Add(new ClientMedCentr("Василий", "Мортин", 656543, false, 3));
            Clients.Add(new ClientMedCentr("Даниил", "Черников", 654523, true, 12));
            while (true)
            {
                int Count = 0;
            Todo:
                Console.Clear();
                Console.WriteLine("Выберите действия...");
                Console.WriteLine("1: Работа со списком... \n2: Создать нового клиента \n3: Выход");

                try
                {
                    Count = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверные данные...");
                    Console.ReadLine();
                    goto Todo;
                }
                switch (Count)
                {
                    case 1:
                        ListSet();
                        break;
                    case 2:
                        NewClient();
                        break;
                    case 3: return; break;
                }
            }
            void ListSet()
            {
                int Count = 0;
                while (true)
                {
                    try {
                    Todo:
                        Console.Clear();
                        Console.WriteLine("Выберите действия...");
                        Console.WriteLine("1: Добавить несколько клиентов \n2: Вывод всех клиентов \n3: Удаление по номеру \n4: Поиск по номеру \n5: Копировать список. \n6: Очистить списки \n7: Сортировки \n8: Выход");
                        try
                        {
                            Count = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Неверные данные...");
                            Console.ReadLine();
                            goto Todo;
                        }
                        switch (Count)
                        {

                            case 1:
                                try
                                {
                                    Console.WriteLine("Вставить из копировоного списка? \n1: Да \n2: Нет");
                                    int Coun = 0;
                                    Coun = Convert.ToInt32(Console.ReadLine());
                                    if (Coun == 1)
                                    {
                                        if (CopyClients.Count != 0)
                                            for (int CopParent = 0; CopParent != CopyClients.Count; CopParent++) //добавляет в список Client данные из CopyClient. Так как клиент содержит уникальные ID, при копировании неполучиться их сохранить, так-что мы просто создаем новый. 
                                            {
                                                Clients.Add(new ClientMedCentr(CopyClients[CopParent].Name, CopyClients[CopParent].Fio, CopyClients[CopParent].Mobile, CopyClients[CopParent].IsPrice, CopyClients[CopParent].Days));
                                            }
                                        else Console.WriteLine("Буфер пуст.");
                                        break;
                                    }
                                    Console.Clear();
                                    Console.WriteLine("Количество новых клиентов?");
                                    int i = 0;
                                    i = Convert.ToInt32(Console.ReadLine());
                                    if (i < 0) i = 0;
                                    for (int j = 0; j != i; j++) //количесто новых клиентов.
                                    {
                                        NewClient();
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Вы ввели неверные данные...");
                                    Console.ReadLine();
                                    goto Todo;
                                }
                                break;
                            case 2:
                                foreach (ClientMedCentr i in Clients)
                                {
                                    i.print();
                                }
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Введите номер");
                                int X = Convert.ToInt32(Console.ReadLine());
                                bool IsFound = false;
                                for (int i = 0; i != Clients.Count; i++)
                                {
                                    if (Clients[i].ID == X) { Clients.RemoveAt(i); IsFound = true; Console.WriteLine("Удалено"); break; }
                                }
                                if (!IsFound) Console.WriteLine("Клиент с таким номером не найден");
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Введите номер");
                                int Z = Convert.ToInt32(Console.ReadLine());
                                bool IsFound1 = false;
                                for (int i = 0; i != Clients.Count; i++) //поиск по норму и вывод на экран
                                {
                                    if (Clients[i].ID == Z) { Clients[i].print(); IsFound1 = true; break; }
                                }
                                if (!IsFound1) Console.WriteLine("Клиент с таким номером не найден");
                                break;
                            case 5:
                                CopyClients = new List<ClientMedCentr>(); foreach (ClientMedCentr client in Clients)
                                {
                                    CopyClients.Add(client); //добавляем данные в список CopyClient
                                }
                                Console.WriteLine("Успешно.");
                                break;
                            case 6:
                                Console.WriteLine("Вы уверены? \n1: Да \n2: нет");
                                int B = 0;
                                B = Convert.ToInt32(Console.ReadLine());
                                if (B == 1) Clients = new List<ClientMedCentr>(); //обнуляем данные


                                break;
                            case 7:

                                Console.WriteLine("Выбрите вариант сортивки");
                                Console.WriteLine("1: ФИО> А-Я \n2: ФИО> Я-А \n3: ID: 0*...");
                                int countSort = Convert.ToInt32(Console.ReadLine());
                                switch (countSort)
                                {
                                    case 1:
                                        ClientMedCentr.Sort1 = ClientMedCentr.SortSetting.SortFio1;
                                        Clients.Sort();
                                        Console.WriteLine("Сортировка по фамилии...");
                                        break;
                                    case 2:
                                        ClientMedCentr.Sort1 = ClientMedCentr.SortSetting.SortFio2;
                                        Clients.Sort();
                                        Console.WriteLine("Сортировка по фамилии...");
                                        break;
                                    case 3:
                                        ClientMedCentr.Sort1 = ClientMedCentr.SortSetting.SortID;
                                        Clients.Sort();
                                        Console.WriteLine("Сортировка по номеру...");
                                        break;
                                }


                                break;
                        }
                        Console.ReadLine();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Вы ввели не верный параметр.");
                        Console.ReadLine();

                    }
                    }
            }
            void NewClient() //создание нового клиента. Тут есть проверка, на случай если данные будут введены не верно, номер в 2 символа, там, пустые строчки
            {
                Console.Clear();
                Console.WriteLine("Введите имя");
                string Name = Console.ReadLine();
                Console.WriteLine("Введите фамилию");
                string FIO = Console.ReadLine();
                Console.WriteLine("Введите норме телефона");
                int Mobile = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Количество проведенных дней в больнице");
                int Days = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Оплата True||False");
                bool isPrice = Convert.ToBoolean(Console.ReadLine());
                if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(FIO) && Mobile.ToString().Length > 4 && Days >= 4)
                {
                    Clients.Add(new ClientMedCentr(Name, FIO, Mobile, isPrice, Days));
                    Console.WriteLine("Добавление успешно...");
                }
                else
                {
                    Console.WriteLine("Внимание, данные что вы ввели, неверны, желаете продолжить? \n 1: Да \n 2: Нет");
                    int i = Convert.ToInt32(Console.ReadLine());
                    if (i == 1)
                    {

                        Clients.Add(new ClientMedCentr(Name, FIO, Mobile, isPrice, Days));
                        Console.WriteLine("Добавление успешно...");
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }


    }



    public class ClientMedCentr : IComparable
    {
        public enum SortSetting
        {
            SortFio1 = 0,
            SortFio2 = 1,
            SortID = 2,
        }

        private static int _id; //количество всех клиентов

        public static SortSetting Sort1 = SortSetting.SortFio1;
        public string Name; //Имя клиента
        public string Fio; //Фамилия клиента
        public int Mobile; //Номер клиента
        public int Days; //Количество дней проведенных в больнице
        public bool IsPrice; //Оплата
        public int ID; //Номер клиента


        public ClientMedCentr(string Name, string Fio, int Mobile, bool IsPrice, int Days) //конструктор
        {
 
            this.Name = Name;
            this.Fio = Fio;
            this.Mobile = Mobile;
            this.IsPrice = IsPrice;
            this.Days = Days;

            _id++;
            ID = _id; //присваиваем номер клиента.
        }
        public void print() //метод для вывода всех клиентов.
        {
            Console.WriteLine("ID>{0}, Имя >{1} Фамилия >{2}, Телефон {3},Количество дней в больнице {5}. Оплата? {4}", ID, Name, Fio, Mobile, IsPrice, Days);
        }

        public int CompareTo(object o)
        {
            ClientMedCentr CompClient = o as ClientMedCentr;
            if (CompClient != null)
            {
                switch (Sort1)
                {
                    case SortSetting.SortFio1:
                        return this.Name.CompareTo(CompClient.Name);

                    case SortSetting.SortFio2:
                        return CompClient.Name.CompareTo(this.Name);

                    case SortSetting.SortID:
                        return this.ID.CompareTo(CompClient.ID);

                    default:  return this.Name.CompareTo(CompClient.Name);

                }
            }
            else throw new Exception("Внимания, сортировка по каким-либо причинам неовозможна, уточните данные.");
        }
    }
}
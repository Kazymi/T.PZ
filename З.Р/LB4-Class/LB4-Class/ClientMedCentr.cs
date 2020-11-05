using System;


namespace LB4_Class
{
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

                    default: return this.Name.CompareTo(CompClient.Name);

                }
            }
            else throw new Exception("Внимания, сортировка по каким-либо причинам неовозможна, уточните данные.");
        }
    }
}

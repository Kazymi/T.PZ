using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LB1_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tanker> tankers = new List<Tanker>();
            tankers.Add(new Tanker()); //создаем один танкер, с пустым конструктором.
            tankers.Add(new Tanker("Avrora",15,15,4)); //создаем один таннкер, с заполненым конструктором
            tankers.Add(new Tanker("Arkadia")); //танкер с заполненым именим

            while (true) //бесконечный цикл, пока не выйдет через параметр.
            {
                TodoReturn:
                Console.Clear();
                Console.WriteLine("Выберите нужно действие...");
                Console.WriteLine("1: Вывести данные о всех танкерах. \n2: Вывести данные о танкере по его номеру. \n3: Показать таймер заполнения всех танкеров. \n4: Показать таймер заполнения танкера по номеру");
                int Count = 0;
                try
                {
                    Count = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Данные не верны...");
                    Console.ReadLine();
                    goto TodoReturn;
                }
                switch (Count)
                {
                    case 1: foreach(Tanker i in tankers) //кейс, на случай если нужно вывести все.
                        {
                            i.Print();
                        } 
                        break;

                    case 2: //кейс на выбор определнный таннкер
                        int J = 0;
                        try //отлов ошибок...
                        {
                            Console.Clear();
                            Console.WriteLine("Введите номер танкера");
                            J = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Данные не верны...");
                            Console.ReadLine();
                            goto TodoReturn;
                        }
                        bool IsCheck1 = false;
                        foreach (Tanker i in tankers) //поиск танкера с таким id
                        {
                            if(i.ThisCountTanker == J)
                            {
                                i.Print();
                                IsCheck1 = true;
                                break;
                            }
                        }
                        if (!IsCheck1) Console.WriteLine("Танкер, с таким номером не найден...");
                        break;
                    case 3:
                        foreach(Tanker i in tankers) //просто вывод времени всех танкеров
                        {
                            Console.WriteLine("Название танкера {0}, время до заполения {1} минута", i.Name, i.CheckTimer());
                        }
                        break;
                    case 4:
                        int L = 0;
                        try //отлов ошибок...
                        {
                            Console.Clear();
                            Console.WriteLine("Введите номер танкера");
                            L = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Данные не верны...");
                            Console.ReadLine();
                            goto TodoReturn;
                        }
                        bool IsCheck = false;
                        foreach (Tanker i in tankers)
                        {
                            
                            if (i.ThisCountTanker == L)
                            {
                                Console.WriteLine("Название танкера {0}, время до заполения {1} минута", i.Name, i.CheckTimer());
                                IsCheck = true;
                                break;
                            }
                           
                        }
                        if(!IsCheck) Console.WriteLine("Танкер, с таким номером не найден...");
                        break;
                }
                Console.ReadLine();
            }
        }
    }

    public class Tanker
    {  
        private float _tankerValume; //Объем на текущий момент.
        private float _maxTankerValume; //Максимальный объем танкера.

        public float SpeedValume; //Скорость загрузки в минуту.
        public string Name = " "; //Название.
        public static int CountTanker = 0; //количество танкеров всего
        public int ThisCountTanker;
        public float MaxTankerValume //set для приватной переменной _maxTankerValume
        {
            set
            {
                float ReturnValue = 0;
                if (value < 0) ReturnValue = 0;
                else
                {
                    if (value > 20) ReturnValue = 20; else ReturnValue = value;
                }
                _maxTankerValume = ReturnValue;
            }
        }
        public float TankerValume //get для приватной переменной _tankerValume
        {
            get { return _tankerValume; }
        }
        //Конструкторы и их перегрузки.
        #region Конструкторы definitio
        public Tanker(string Name, float MaxTankerValue, float TankerValue, float SpeedValume)
        {
            //присваивам значения для текущего обьекта.
            this.Name = Name;
            MaxTankerValume = MaxTankerValue;
            _tankerValume = TankerValue;
            this.SpeedValume = SpeedValume;
            
            CountTanker++; //увеличиваем количество танкеров. 
            ThisCountTanker = CountTanker;
        }

        public Tanker()
        {
            //присваивам значения для текущего обьекта по стандарту.
            this.Name = "Name";
            MaxTankerValume = 20f;
            _tankerValume = 5f;
            this.SpeedValume = 4f;

            CountTanker++; //увеличиваем количество танкеров. 
            ThisCountTanker = CountTanker;
        }

        public Tanker(string Name)
        {
            //присваивам значения для текущего обьекта c учетом того что для конструктора есть только 1 параметр.
            this.Name = Name;
            MaxTankerValume = 20f;
            _tankerValume = 5f;
            this.SpeedValume = 4f;

            CountTanker++; //увеличиваем количество танкеров. 
            ThisCountTanker = CountTanker;
        }

        #endregion
        //Метод для вывода всех полей.
        public void Print()
        {
            Console.WriteLine("ID {4}, Tanker name > {0}, MaxValume > {1}, Valume > {2}, Speed > {3}",Name,_maxTankerValume, _tankerValume, SpeedValume, ThisCountTanker);
        }

        //Метод для проверки на количество
        public float CheckTimer()
        {
            float Min = 0;
            while(_maxTankerValume >= _tankerValume) //выполняем пока текущие количество топливо, не будет больше или равно максимальному количеству топлива.
            {
                Min++;
                _tankerValume += SpeedValume;
            }
            return Min;
        }
    }
}

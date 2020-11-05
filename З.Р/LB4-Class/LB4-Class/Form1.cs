using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Reflection;

namespace LB4_Class
{
    public partial class Form1 : Form
    {
        Random RandomCount = new Random(); //создаем переменную для рандомных чисел
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter BF = new BinaryFormatter(); //создаем бинарный файл. В него загружаем данные и сохраняем. Не пытайтесь прочесть его, там будет бред)

                    if(textBox1.Text.Length != 0)
                    StaticLibrary.NameFile = textBox1.Text;
                    StaticLibrary.Patch = @"" + StaticLibrary.NameFile + ".txt"; //создаем сслыку на файл.
                    FileStream file = new FileStream(StaticLibrary.Patch, FileMode.Create); //создаем filestream, указываем что при каждом новом сохранении, он создавал новый файл, удаляя при этом старый
                    int[] Massiv = new int[10]; //создаем массив из 10 символов
                    for (int i = 0; i != Massiv.Count(); i++) //заполняем рандомными числами от 0 ... 9
                    {
                        Massiv[i] = RandomCount.Next(0, 10);
                    }
                    Save SaveValue = new Save(Massiv); //сохраняем
                    BF.Serialize(file, SaveValue);
                    MessageBox.Show("Вы успешно сохранили файл");
                    file.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения.Проверьте введеные файлы, в случае неулачи, запустите приложение от имени администратора.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length != 0)
                {
                    StaticLibrary.Patch = @"" + textBox1.Text + ".txt"; //создаем сслыку на файл.
                    StaticLibrary.NameFile = textBox1.Text;
                }
                else
                {
                    MessageBox.Show("Вы не ввели имя файла...");
                }
                if (File.Exists(StaticLibrary.Patch)) //проверяем на наличие файла
                {
                    StaticLibrary.TextBoxLoad = textBox2;
                    BinaryFormatter BF = new BinaryFormatter();
                    FileStream file = new FileStream(StaticLibrary.Patch, FileMode.Open); //создаем filestream, указываем что при старте он открывает.
                    Save Load = (Save)BF.Deserialize(file); //просто загружаем файл, явно приводя его к тиму Save
                    Load.Load();
                    file.Close();
                }
                else
                {
                    MessageBox.Show("Файла с таким именем нет. Указывать тип файла не нужно.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения.Проверьте введеные файлы, в случае неулачи, запустите приложение от имени администратора.");
            }
        }
        [Serializable]
        public class Save //сериализованный класс
        {
            public int[] Massiv; //масив для сохранения и загрузки

            public Save(int[] i) //созраняем
            {
                Massiv = i;
            }
            public void Load() //загружаем
            {
                int a = 0;
                StaticLibrary.TextBoxLoad.Text = "";
                foreach (int i in Massiv)
                {
                    a++;
                    if((a % 2)==0)//выводим каждое 2 число
                    StaticLibrary.TextBoxLoad.Text += " " + i; //просто добавляем текс в textbox.
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)//очень странный код. StaticLibrary.TextBoxLoad.Text += Environment.NewLine; отвечает за новую строку, чтоб не было наложения слов;
        {
            Type type = Type.GetType("LB4_Class.ClientMedCentr");
            var Types = type.GetEvents();
            StaticLibrary.TextBoxLoad = textBox3;
            StaticLibrary.TextBoxLoad.Text = "";
            StaticLibrary.TextBoxLoad.Text += "Класс ClientMedCentr содержит следующие события: ";
            StaticLibrary.TextBoxLoad.Text += Environment.NewLine;
            foreach (MemberInfo i in Types) //notwotk Так как в классе нет событий, то тут пусто.
            {
                StaticLibrary.TextBoxLoad.Text += " " + i.Name;
            }
            StaticLibrary.TextBoxLoad.Text += Environment.NewLine; //Выводит все поля.
            StaticLibrary.TextBoxLoad.Text += "Все поля кода:";
            var Types3 = type.GetFields();
            foreach (MemberInfo i in Types3)
            {
                StaticLibrary.TextBoxLoad.Text += Environment.NewLine;
                StaticLibrary.TextBoxLoad.Text += i.Name;
            }
            var Types2 = type.GetInterfaces();
            StaticLibrary.TextBoxLoad.Text += Environment.NewLine;
            StaticLibrary.TextBoxLoad.Text += "Все интерфейсы, что были использованы: ";
            foreach (MemberInfo i in Types2) //Выводит все интерфейссы
            {
                StaticLibrary.TextBoxLoad.Text += Environment.NewLine;
                StaticLibrary.TextBoxLoad.Text += i.Name;
                StaticLibrary.TextBoxLoad.Text += Environment.NewLine; //вывод хеш кода
                StaticLibrary.TextBoxLoad.Text += "HASH код:";
                type = i.GetType();
                StaticLibrary.TextBoxLoad.Text += (type.GetHashCode());
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrEmpty(textBox7.Text)) //проверка, на случай, если не все данные введены
                {

                }
                else
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    FileStream file = new FileStream(textBox4.Text + ".txt", FileMode.Create);
                    Book book = new Book();
                    string parseset = textBox8.Text;
                    book.SaveBook(textBox4.Text, textBox5.Text, textBox6.Text, int.Parse(textBox7.Text), parseset.Split(',')); //загружаем данные для сохранения
                    bf.Serialize(file, book);
                    MessageBox.Show("Успешно!");
                    file.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели неверные данные!");
            }
        }

        [Serializable]
        private class Book //класс книга, нужен для 3 задания
        {
            public string Name;//имя
            public string Avtor;//автор
            public string Izdatel;//издатель
            public int _date; //дата 
            public string[] Types; //жанры

            public void SaveBook(string Name, string Avtor, string Izdatel, int _date, string[] Types) //метод для заполнения, в теории можно и конструктор, 
            {
                this.Name = Name;
                this.Avtor = Avtor;
                this.Izdatel = Izdatel;
                this._date = _date;
                this.Types = Types;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                if (textBox4.Text.Length != 0)
                    if (File.Exists(textBox4.Text + ".txt"))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        FileStream file = new FileStream(textBox4.Text + ".txt", FileMode.Open);
                        Book book = (Book)bf.Deserialize(file);
                        textBox4.Text = "";
                        textBox4.Text = book.Name;
                        textBox5.Text = "";
                        textBox5.Text = book.Avtor;
                        textBox6.Text = "";
                        textBox6.Text = book.Izdatel;
                        textBox7.Text = "";
                        textBox7.Text = book._date.ToString();
                        textBox8.Text = "";
                        foreach (string i in book.Types)
                        {
                            textBox8.Text += i + ",";
                        }
                        file.Close();
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("Вы ввели неверные данные...");
            }
            }
    }
}
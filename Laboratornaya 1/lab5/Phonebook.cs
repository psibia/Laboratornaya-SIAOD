using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratornaya_1.lab5
{
    public class Phonebook
    {

        public Subscriber[] Users = new Subscriber[20];

        private protected string[] familys = new string[] {"Верхнев", "Степанов", "Гречников", "Гришин", "Мельников", "Степаненко", "Конюхов", "Герман", 
            "Сидоренко", "Куклин", "Мажонов", "Ибадулин", "Евпарсов", "Дулин", "Сталин", "Плутин", "Федоренко", "Класимов", "Сидорчук", 
            "Антропогенов", "Больцман", "Шольц", "Макфлай", "Крипченко", "Куняшев", "Эйнштейн", "Рубинштейн", "Мозгов", "Христос", "Магомаев" };

        private protected string[] names = new string[] { "Иван", "Андрей", "Павел", "Кирилл", "Герман", "Альберт", "Фёдор", "Максим", "Магомед", "Клим", 
            "Джерард", "Джеймс", "Евгений", "Владимир", "Ринат", "Умар", "Сергей", "Виталий", "Клавдий", "Ержан", "Мурат", "Пьер", "Михаил", 
            "Данила", "Пол", "Антон", "Александр", "Петр", "Плементий", "Геннадий", "Валентин"};

        public Phonebook()
        {
            this.CreateRandomPhonebookList();
        }

        public void CreateRandomPhonebookList()
        {
            for (int i = 0; i < Users.Length; i++)
            {
                Random rnd = new Random();
                string name = familys[rnd.Next(0, familys.Length - 1)] + " " + names[rnd.Next(0, names.Length - 1)];
                int phoneNumber = rnd.Next(2220000, 2229999);
                int adress = rnd.Next(0, 200);
                Subscriber user = new Subscriber(name, phoneNumber, adress);
                Users[i] = user;
            }
        }
        public void Sort(Actions action)
        {
            switch (action)
            {
                case Actions.NameUpSort:
                    Array.Sort(Users, (p1, p2) =>
                    {
                        int result = p1.Name.CompareTo(p2.Name);
                        return result;
                    });
                    break;
                case Actions.NumberUpSort:
                    Array.Sort(Users, (p1, p2) =>
                    {
                        int result = p1.PhoneNumber.CompareTo(p2.PhoneNumber);
                        return result;
                    });
                    break;
                case Actions.NumberDownSort:
                    Array.Sort(Users, (p1, p2) =>
                    {
                        int result = p2.PhoneNumber.CompareTo(p1.PhoneNumber);
                        return result;
                    });
                    break;
                case Actions.NameNumberUpSort:
                    Array.Sort(Users, (p1, p2) =>
                    {
                        int result = p1.Name.CompareTo(p2.Name);
                        if (result == 0)
                            result = p1.PhoneNumber.CompareTo(p2.PhoneNumber); // Второй критерий — дата
                        return result;
                    });
                    break;
                case Actions.AdressDownSort:
                    Array.Sort(Users, (p1, p2) =>
                    {
                        int result = p2.Adress.CompareTo(p1.Adress);
                        return result;
                    });
                    break;
            }
        }

        public void Sort(Actions action, string x1, string x2)
        {
            switch (action)
            {
                case Actions.AdressDiapasoneSort:
                    try
                    {
                        Console.WriteLine();
                        foreach (Subscriber e in Users)
                            if (e.Adress > int.Parse(x1) && e.Adress < int.Parse(x2))
                                Console.WriteLine("{0, -30} {1, -20} ул. Тюленина, д.{2}", e.Name, e.PhoneNumber.ToString("###-##-##"), e.Adress);
                        Console.WriteLine("\nЧтобы продолжить, нажмите Enter");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                    break;
                case Actions.NameDiapasoneSort:
                    try
                    {
                        Console.WriteLine();
                        foreach (Subscriber e in Users)
                        {   // Содержит ли строка подстроку...
                            if(e.Name.Contains(x1, StringComparison.OrdinalIgnoreCase))
                                Console.WriteLine("{0, -30} {1, -20} ул. Тюленина, д.{2}", e.Name, e.PhoneNumber.ToString("###-##-##"), e.Adress);
                        }    
                                
                        Console.WriteLine("\nЧтобы продолжить, нажмите Enter");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                    break;
                case Actions.NumberDiapasoneSort:
                    try
                    {
                        Console.WriteLine();
                        foreach (Subscriber e in Users)
                            if (e.PhoneNumber > int.Parse(x1) && e.PhoneNumber < int.Parse(x2))
                                Console.WriteLine("{0, -30} {1, -20} ул. Тюленина, д.{2}", e.Name, e.PhoneNumber.ToString("###-##-##"), e.Adress);
                        Console.WriteLine("\nЧтобы продолжить, нажмите Enter");
                        Console.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                    break;
            }

        }

        public void Print()
        {
            foreach (Subscriber e in Users)
            Console.WriteLine("{0, -30} {1, -20} ул. Тюленина, д.{2}", e.Name, e.PhoneNumber.ToString("###-##-##"), e.Adress);
        }
        public enum Actions
        {
            NameUpSort,
            NumberUpSort,
            NameNumberUpSort,
            NumberDownSort,
            AdressDownSort,
            NameDiapasoneSort,
            NumberDiapasoneSort,
            AdressDiapasoneSort
        };

    }
}

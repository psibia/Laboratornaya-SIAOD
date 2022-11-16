using Laboratornaya_1.Lab2;
using Laboratornaya_1.lab3;
using Laboratornaya_1.Lab4;
using Laboratornaya_1.lab5;
using Laboratornaya_1.lab6;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Laboratornaya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите работу, которую хотите открыть, введя её номер:");
                Console.WriteLine();
                Console.Write("- Лабораторная 1 (квадратичная сортировка)\n- Лабораторная 2 (быстрая сортировка)" +
                    "\n- Лабораторная 3 (стек, очередь)\n- Лабораторная 4 (сортировка списка)\n- Лабораторная 5 (телефонный справочник)" +
                    "\n- Лабораторная 6 (хеш таблица)\n\nНомер работы: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Laboratorka1();
                        break;
                    case "2":
                        Laboratorka2();
                        break;
                    case "3":
                        Laboratorka3();
                        break;
                    case "4":
                        Laboratorka4();
                        break;
                    case "5":
                        Laboratorka5();
                        break;
                    case "6":
                        Laboratorka6();
                        break;
                }
            }

            void Laboratorka1()
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №1\n\n");
                const int arraySize = 10;
                int[] randomArray = new int[arraySize];
                int[] orderedArray = new int[arraySize];

                Laba1.CreateRandomArray(ref randomArray);
                Laba1.CreateOrderedArray(ref orderedArray);

                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("SelectionSort Неупорядоченный массив");
                Console.ResetColor(); // сбрасываем в стандартный
                Laba1.SelectionSort(ref randomArray);
                Console.WriteLine("SelectionSort Упорядоченный массив");
                Laba1.SelectionSort(ref orderedArray);

                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("BubbleSort Неупорядоченный массив");
                Console.ResetColor(); // сбрасываем в стандартный
                Laba1.BubbleSort(ref randomArray);
                Console.WriteLine("BubbleSort Упорядоченный массив");
                Laba1.BubbleSort(ref orderedArray);

                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("ShakerSort Неупорядоченный массив");
                Console.ResetColor(); // сбрасываем в стандартный
                Laba1.ShakerSort(ref randomArray);
                Console.WriteLine("ShakerSort Упорядоченный массив");
                Laba1.ShakerSort(ref orderedArray);
                Console.WriteLine("\n\n\nДля выхода нажмите Enter");
                Console.ReadLine();
            }

            void Laboratorka2()
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №2\n\n");
                const int arraySize = 10;
                int[] randomArray = new int[arraySize];
                int[] orderedArray = new int[arraySize];

                Laba1.CreateRandomArray(ref randomArray);
                Laba1.CreateOrderedArray(ref orderedArray);

                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("ShellSort Неупорядоченный массив");
                Console.ResetColor(); // сбрасываем в стандартный
                Laba2.ShellSort(ref randomArray);
                Console.WriteLine("\nShellSort Упорядоченный массив");
                Laba2.ShellSort(ref orderedArray);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("HeapSort Неупорядоченный массив");
                Console.ResetColor(); // сбрасываем в стандартный
                Laba2.HeapSort(ref randomArray);
                Console.WriteLine("\nHeapSort Упорядоченный массив");
                Laba2.HeapSort(ref orderedArray);
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("QuickSort Неупорядоченный массив");
                Console.ResetColor(); // сбрасываем в стандартный
                Laba2.QuickSort(ref randomArray);
                Console.WriteLine("\nQuick Упорядоченный массив");
                Laba2.QuickSort(ref orderedArray);
                Console.WriteLine("\n\n\nДля выхода нажмите Enter");
                Console.ReadLine();
            }

            void Laboratorka3()
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №2\n\n");

                {
                    Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                    Console.WriteLine("Изначальные числа (возрастающие): ");
                    Console.ResetColor(); // сбрасываем в стандартный
                    for (int i = 0; i < 20; i++)
                        Console.Write($"{i} ");
                    Console.WriteLine("\n\nИзвлекаем и печатаем числа из стека:");
                }

                var stack = new MyStack();
                stack.InitializeIncreasing(20);
                Console.WriteLine($"Контрольная сумма элементов стека: {stack.CountValue}, количество серий в стеке: {stack.Series}");
                while (stack.Count > 0)
                    Console.Write($"{stack.Pop()} ");
                Console.WriteLine();

                Console.WriteLine("\nИзвлекаем и печатаем числа из очереди:");
                var queue = new MyQueue();
                queue.InitializeIncreasing(20);
                Console.WriteLine($"Контрольная сумма элементов очереди: {queue.CountValue}, количество серий в очереди: {queue.Series}");
                while (queue.Count > 0)
                    Console.Write($"{queue.Dequeue()} ");
                Console.WriteLine("\n\n");

                {
                    Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                    Console.WriteLine("Изначальные числа (убывающие): ");
                    Console.ResetColor(); // сбрасываем в стандартный
                    for (int i = 19; i >= 0; i--)
                        Console.Write($"{i} ");
                    Console.WriteLine("\n\nИзвлекаем и печатаем числа из стека:");
                }

                stack = new MyStack();
                stack.InitializeDecreasing(20);
                Console.WriteLine($"Контрольная сумма элементов стека: {stack.CountValue}, количество серий в стеке: {stack.Series}");
                while (stack.Count > 0)
                    Console.Write($"{stack.Pop()} ");
                Console.WriteLine();


                Console.WriteLine("\nИзвлекаем и печатаем числа из очереди:");
                queue = new MyQueue();
                queue.InitializeDecreasing(20);
                Console.WriteLine($"Контрольная сумма элементов очереди: {queue.CountValue}, количество серий в очереди: {queue.Series}");
                while (queue.Count > 0)
                    Console.Write($"{queue.Dequeue()} ");
                Console.WriteLine("\n\n\nДля выхода нажмите Enter");

                Console.ReadLine();
            }

            void Laboratorka4()
            {
                Console.Clear();
                Console.WriteLine("Лабораторная работа №4\n\n");

                Random rnd = new Random();
                List<int> Items = new List<int>();

                for (int i = 0; i < 10; i++) // Тут создаем список размера (указан в цикле) с рандомными значениями
                {
                    Items.Add(rnd.Next(0, 99));
                }


                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("MergeSort Не сортированная последовательность");
                Console.ResetColor(); // сбрасываем в стандартный

                foreach (int item in Items)
                    Console.Write($"{item} ");

                Console.WriteLine("\nMergeSort Отсортированная последовательность");

                // Мерч сортировка
                var merge = new MergeSort<int>();
                merge.Items.AddRange(Items);
                merge.Sort();

                for (int i = 0; i < Items.Count; i++)
                {
                    Console.Write($"{merge.Items[i]} ");
                }
                Console.WriteLine($"\nСравнений: {merge.Compares}, перестановок: {merge.Moves}");




                Console.ForegroundColor = ConsoleColor.Green; // устанавливаем цвет
                Console.WriteLine("\n\nRadixSort Не сортированная последовательность");
                Console.ResetColor(); // сбрасываем в стандартный
                foreach (int item in Items)
                    Console.Write($"{item} ");

                Console.WriteLine("\nRadixSort Отсортированная последовательность");

                // Цифровая сортировка (поразрядная)
                var msdRedix = new RadixSort<int>();
                msdRedix.Items.AddRange(Items);
                msdRedix.Sort();

                for (int i = 0; i < Items.Count; i++)
                {
                    Console.Write($"{msdRedix.Items[i]} ");
                }
                Console.WriteLine($"\nВзаимодействий с очередями (добавление в groups): {msdRedix.MoveToQueue}");

                Console.WriteLine("\n\n\nДля выхода нажмите Enter");
                Console.ReadLine();
            }

            void Laboratorka5()
            {
                Console.Clear();
                Phonebook book = new Phonebook();

                while (true)
                {
                    Console.WriteLine("Список абонентов:\n\n");
                    book.Print();
                    Console.Write($"\n\nВыберите действие:\n\n1 - Упорядочить по имени по возрастанию\n2 - Упорядочить по телефонному" +
                        $" номеру по возрастанию\n3 - упорядочить по телефонному номеру по убыванию\n4 - упорядочить по имени и по телефонному" +
                        $"номеру по возрастанию\n5 - Упорядочить по адресу по убыванию\n6 - Найти абонентов с адресом в диапазоне\n" +
                        $"7 - Найти абонентов по имени\n8 - Найти абонентов с номером в диапазоне\n0 - Выйти\n\nВведите номер действия: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            book.Sort(Phonebook.Actions.NameUpSort);
                            break;
                        case "2":
                            book.Sort(Phonebook.Actions.NumberUpSort);
                            break;
                        case "3":
                            book.Sort(Phonebook.Actions.NumberDownSort);
                            break;
                        case "4":
                            book.Sort(Phonebook.Actions.NameNumberUpSort);
                            break;
                        case "5":
                            book.Sort(Phonebook.Actions.AdressDownSort);
                            break;
                        case "6":
                            Console.Write("Введите начальное значение диапазона: ");
                            string x1 = Console.ReadLine();
                            Console.Write("Введите конечное значение диапазона: ");
                            string x2 = Console.ReadLine();
                            book.Sort(Phonebook.Actions.AdressDiapasoneSort, x1, x2);
                            break;
                        case "7":
                            Console.Write("Введите симолы: ");
                            x1 = Console.ReadLine();
                            book.Sort(Phonebook.Actions.NameDiapasoneSort, x1, x2 = "");
                            break;
                        case "8":
                            Console.Write("Введите начальное значение диапазона: ");
                            x1 = Console.ReadLine();
                            Console.Write("Введите конечное значение диапазона: ");
                            x2 = Console.ReadLine();
                            book.Sort(Phonebook.Actions.NumberDiapasoneSort, x1, x2);
                            break;
                        case "0":
                            return;

                    }
                    Console.Clear();
                }
                Console.ReadLine();
            }

            void Laboratorka6()
            {
                Random rnd = new Random();
                HashTable table = new HashTable(200);
                string[] theWords = null;
                while (theWords is null)
                    ReadWords(ref theWords);
                int[] keys = new int[200];
                for (int i = 0; i < 200; i++)
                {
                    keys[i]= rnd.Next(0, 1000);
                }

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите действие из списка: \n\n1 - Заполнить хеш-таблицу строками из файла методом линейных проб и вывести" +
                        "в консоль число коллизий\n2 - Заполнить хеш-таблицу строками из файла методом квадратичных проб и вывести" +
                        "в консоль число коллизий\n0 - Выйти");
                    Console.Write("\n\nВведите номер действия: ");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            table = new HashTable(200);
                            for (int i = 0; i < 200; i++)
                            {
                                table.LinearHashInsert(keys[i], theWords[i]);
                            }
                            Console.WriteLine($"\nТаблица успешно создана, в качестве ключей выбраны случайные числа от 0 до 1000," +
                                $" число возникших коллизий: {table.Collision}\n\nДля выхода нажмите Enter");
                            Console.ReadLine();
                            break;

                        case "2":
                            table = new HashTable(200);
                            for (int i = 0; i < 200; i++)
                            {
                                table.QuadraticHashInsert(keys[i], theWords[i]);
                            }
                            Console.WriteLine($"\nТаблица успешно создана, в качестве ключей выбраны случайные числа от 0 до 1000," +
                                $" число возникших коллизий: {table.Collision}\n\nДля выхода нажмите Enter");
                            Console.ReadLine();
                            break;
                        case "0":
                            return;
                    }
                }

                

                

                
                
                //Console.WriteLine(table.retrieve(20));

                Console.ReadLine();

                Console.ReadLine();


                void GenerateWordFile()
                {
                    string words = "участие взгляд том транспорт больной театр зарплата рабочий особенность уход характеристика" +
                        " краска понятие партия министерство кровать повышение растение оборудование сила " +
                        "коллега поворот реакция господь ситуация решение русский старуха труд список итог " +
                        "страница сюжет рисунок одежда испытание расстояние сторона интерес деньги душа улица " +
                        "образ книга уровень устройство элемент материал стена родитель шутка завод доклад кризис " +
                        "лидер конец весна баба ощущение желание разговор лицо ожидание выборы тип палата правительство" +
                        " слух выражение представитель опасность исполнение вывод явление создание появление наблюдение " +
                        "народ перевод зона жизнь пара мать период больница студент реальность фигура лицо дым капитан способ" +
                        " вход работа рубеж влияние состав век родитель достижение адрес друг школа корпус повод зло очки " +
                        "характеристика муж командир тип кольцо создание дурак образец сфера кровь движение волос куст воздействие " +
                        "закон аппарат отдых стекло окно природа ход чай буква улыбка лодка сотрудничество работник фраза задача июнь " +
                        "анализ хвост мощность лидер развитие фактор крест философия ноябрь устройство элемент государство рамка станция " +
                        "пара желание задача краска человечество уровень слой поездка объект лед группа тенденция суд чемпионат база звонок " +
                        "эпоха зависимость режиссер подруга сбор фактор транспорт событие журнал чиновник чтение соединение рост окно сознание" +
                        " печать производитель чай милиция работник человечество подруга метод шанс крыло создание взгляд пространство" +
                        " восток фирма мальчишка кредит поезд";
                    string[] theWords = words.Split(' ');

                    try
                    {
                        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"\words.json", JsonConvert.SerializeObject(theWords));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Не удалось сохранить файл!");
                    }
                }

                void ReadWords(ref string[] theWords)
                {
                    try
                    {
                        theWords = JsonConvert.DeserializeObject<string[]>(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\words.json"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        GenerateWordFile();
                    }
                }
            }




        }
        
    }
}
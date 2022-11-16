using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.lab6
{
    public class HashTable
    {
        public int Collision { get; set; } = 0;
        public int Count { get; set; } = 0;
        class Hashentry // Входящие данные
        {
            int key;
            string data;
            public Hashentry(int key, string data)
            {
                this.key = key;
                this.data = data;
            }
            public int getkey()
            {
                return key;
            }
            public string getdata()
            {
                return data;
            }
        }
        private protected int maxSize = 200; // Максимальный размер таблицы
        Hashentry[] table;

        public HashTable(int size) // Конструктор
        {
            maxSize = size;
            table = new Hashentry[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }
        
        /// <summary>
        /// Добавить ключ и заданную строку методом Линейных Проб
        /// </summary>
        public void LinearHashInsert(int key, string data)
        {
            if (!CheckOpenSpace()) // Если свободных мест НЕТ
            {
                Console.WriteLine("Не осталось свободного места!");
                return;
            }
            int hash = (key % maxSize);
            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
                Count++;
                Collision++;
            }
            table[hash] = new Hashentry(key, data);
            Count++;
        }
        /// <summary>
        /// Добавить ключ и заданную строку методом Квадратичных Проб
        /// </summary>
        public void QuadraticHashInsert(int key, string data)
        {
            //Метод квадратичных проб
            if (!CheckOpenSpace())
            {
                Console.WriteLine("Не осталось свободного места!");
                return;
            }

            int j = 0;
            int hash = key % maxSize;
            while (table[hash] != null && table[hash].getkey() != key)
            {
                j++;
                hash = (hash + j * j) % maxSize;
                Collision++;
                Count++;
            }
            if (table[hash] == null)
            {
                table[hash] = new Hashentry(key, data);
                Count++;
                return;
            }
        }
        private bool CheckOpenSpace() // Проверяет, осталось ли свободное место в таблице
        {
            bool isOpen = false;
            for (int i = 0; i < maxSize; i++)
            {
                if (table[i] == null)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }
        /// <summary>
        /// Возвращает строку по заданному ключу
        /// </summary>
        public string Retrieve(int key)
        {
            int hash = key % maxSize;
            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }
            if (table[hash] == null)
            {
                return "Не найдено!";
            }
            else
            {
                return table[hash].getdata();
            }
        }
        /// <summary>
        /// Печатает все элементы таблицы от индекса 0 до конца
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] == null && i <= maxSize)//Если есть нулевые ячейки, просто переходим к следующей итерации
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("{0}", table[i].getdata());
                }
            }
        }
        /*public bool Remove(int key)
        {
            int hash = key % maxSize;
            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }
            if (table[hash] == null)
            {
                return false;
            }
            else
            {
                table[hash] = null;
                return true;
            }
        }*/
    }
}

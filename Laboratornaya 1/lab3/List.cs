using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.lab3List
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class List<T> : IEnumerable
    {
        /// <summary>
        /// Первый элемент списка
        /// </summary>
        public Item<T>? Head { get; private set; }
        /// <summary>
        /// Последний элемент списка
        /// </summary>
        public Item<T>? Tail { get; private set; }
        /// <summary>
        /// Количество элементов в списке
        /// </summary>
        public int? Count { get; private set; }

        /// <summary>
        /// Создать пустой список
        /// </summary>
        public List()
        {
            Clear();
        }

        /// <summary>
        /// Создать список с начальным элементом
        /// </summary>
        /// <param name="data"></param>
        public List(T data)
        {
            SetHeadAndTail(data);
        }
        /// <summary>
        /// Добавить данные в конец списка
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (Tail is not null)
            {
                var item = new Item<T>(data);
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }
        /// <summary>
        /// Удалить первое вхождение данных в список
        /// </summary>
        /// <param name="data"></param>
        public void Delete(T data)
        {
            if (Head is not null)
            {
                if (Head.Data.Equals(data))
                {
                    Head = Head.Next;
                    Count--;
                    return;
                }

                var current = Head.Next;
                var previous = Head;


                while (current is not null)
                {
                    if (current.Data.Equals(data))
                    {
                        previous.Next = current.Next;
                        Count--;
                        return;
                    }
                    previous = current;
                    current = current.Next;
                }
            }
            else
            {
                // SetHeadAndTail(data);
            }
        }
        /// <summary>
        /// Добавить данные в начало списка
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data)
            {
                Next = Head
            };
            Head = item;
            Count++;
        }

        public void InsertAfter(T target, T data)
        {
            if (Head is not null)
            {
                var current = Head;
                while (current is not null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                // Нужно решить, что делать если список пустой
            }
        }

        /// <summary>
        /// Очистить список
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }



        /// <summary>
        /// Получить перечисление всех элементов списка
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current is not null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public IEnumerable<T> Take<T>(IEnumerable<T> list, int count)
        {
            foreach (var e in list)
            {
                if (count != 0) yield return e;
                else yield break;
                --count;
            }
        }

        public IEnumerable<T> Skip<T>(IEnumerable<T> list, int count)
        {
            foreach (var item in list)
            {
                if (count > 0) count--;
                else yield return item;
            }
        }

        public override string ToString()
        {
            return "Linked List" + Count + " элементов";
        }
        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }
    }
}

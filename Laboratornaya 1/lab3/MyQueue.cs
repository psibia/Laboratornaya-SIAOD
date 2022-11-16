using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laboratornaya_1.lab3
{
    internal class MyQueue 
    {
        private protected Node? Head { get; set; }
        private protected Node? Tail { get; set; }
        /// <summary>
        /// Общее количество элементов в списке
        /// </summary>
        public int Count { get; private protected set; }
        /// <summary>
        /// Сумма всех элементов списка
        /// </summary>
        public int CountValue { get; private protected set; }

        private protected int series;
        /// <summary>
        /// Количество серий всех элементов списка
        /// </summary>
        public int Series
        {
            get
            {
                if (Count == 0) return 0;
                else return series;
            }
            private protected set
            {
                series = value;
            }
        }
        public MyQueue()
        {
            Head = null;
            Count = 0;
            CountValue = 0;
            Series = 1;
        }
        /// <summary>
        /// Добавить элемент в конец очереди
        /// </summary>
        public void Enqueue(int data)
        {
            Node node = new Node(data);
            if (Count == 0)
            {
                Head = node;
                Tail = node;
                Count++;
                CountValue += node.Data;
            }
            else
            {
                if (Head?.Data > data)
                    Series += 1;
                Tail.ElementReference = node; // предыдущий
                Tail = node;
                Count++;
                CountValue += node.Data;
            }
        }
        /// <summary>
        /// Извлечь элемент из начала очереди
        /// </summary>
        public int Dequeue()
        {
            if (Count > 0)
            {
                var temp = Head;
                Head = Head.ElementReference;
                Count--;
                CountValue -= temp.Data;
                if (temp?.Data < temp?.ElementReference?.Data)
                    Series--;
                return temp.Data;
            }
            else
            {
                throw new InvalidOperationException("Очередь пуста");
            }
        }
        /// <summary>
        /// Инициализировать текущий список возрастающими числами с количеством элементов переданных в параметр
        /// </summary>
        public void InitializeIncreasing(int count)
        {
            Head = null;
            for (int i = 0; i < count; i++)
                this.Enqueue(i);
        }
        /// <summary>
        /// Инициализировать текущий список убывающими числами с количеством элементов переданных в параметр
        /// </summary>
        public void InitializeDecreasing(int count)
        {
            Head = null;
            for (int i = count - 1; i >= 0; i--)
                this.Enqueue(i);
        }
        /// <summary>
        /// Инициализировать текущий список случайными числами с количеством элементов переданных в параметр
        /// </summary>
        public void InitializeRandom(int count)
        {
            Head = null;
            for (int i = 0; i < count; i++)
            {
                Random randomValue = new Random();
                int value = randomValue.Next(-99, 99);
                this.Enqueue(value);
            }
        }
    }
}

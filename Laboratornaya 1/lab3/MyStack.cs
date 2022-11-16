using System;

namespace Laboratornaya_1.lab3
{
    public class MyStack
    {
        private protected Node? Head { get; set; }
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
                if(Count == 0) return 0;
                else return series;
            }
            private protected set
            {
                series = value;
            }
        }

        public MyStack() // ctor
        {
            Head = null;
            Count = 0;
            CountValue = 0;
            Series = 1;
        }

        /// <summary>
        /// Добавить элемент в список
        /// </summary>
        public virtual void Push(int data)
        {
            if (Head?.Data > data)
                Series += 1;
            var node = new Node(data);
            node.ElementReference = Head;
            Head = node;
            Count++;
            CountValue += node.Data;
        }
        /// <summary>
        /// Возвращает значение элемента и переходит к следующему
        /// </summary>
        public int Pop()
        {
            if (Count > 0)
            {
                var node = Head;
                Head = Head.ElementReference;
                Count--;
                CountValue -= node.Data;
                if(Head?.Data < Head?.ElementReference?.Data) // node?.Data 
                    Series--;
                return node.Data;
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }
        }
        /// <summary>
        /// Возвращает значение элемента
        /// </summary>
        public int Peek()
        {
            if (Count > 0)
            {
                return Head.Data;
            }
            else
            {
                throw new NullReferenceException("Стек пусто");
            }
        }
        /// <summary>
        /// Инициализировать текущий список возрастающими числами с количеством элементов переданных в параметр
        /// </summary>
        public void InitializeIncreasing(int count)
        {
            Head = null;
            for (int i = 0; i < count; i++)
                this.Push(i);
        }
        /// <summary>
        /// Инициализировать текущий список убывающими числами с количеством элементов переданных в параметр
        /// </summary>
        public void InitializeDecreasing(int count)
        {
            Head = null;
            for (int i = count-1; i >= 0; i--)
                this.Push(i);
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
                this.Push(value);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;

namespace Laboratornaya_1.Lab4
{
    public class RadixSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public RadixSort(IEnumerable<T> items) : base(items) { }

        public RadixSort() { }
        public int MoveToQueue { get; set; }
        public int Compares { get; set; }

        protected override void MakeSort()
        {
            int length = GetMaxLength(Items);
            var result = SortCollection(Items, length - 1);

            for (int i = 0; i < result.Count; i++)
            {
                Set(i, result[i]);
            }
        }

        private List<T> SortCollection(List<T> collection, int step)
        {
            // Вспомогательная коллекция (доп. выделение памяти)
            var result = new List<T>();

            // Создание групп (очередь)
            var groups = new List<List<T>>();
            for (int i = 0; i < 10; i++)
            {
                groups.Add(new List<T>());
            }

            // Распределение элементов по корзинам. 
            foreach (var item in collection)
            {
                // Вычисление разряда 
                var i = item.GetHashCode();
                var value = i % (int)Math.Pow(10, step + 1) / (int)Math.Pow(10, step);
                groups[value].Add(item);
                MoveToQueue++;
            }

            // Сборка элементов.
            foreach (var group in groups)
            {
                if (group.Count > 1 && step > 0)
                {
                    // Добавляем в резалт отсортированную коллекцию (рекурсивно вроде тут)
                    result.AddRange(SortCollection(group, step - 1));
                    continue;
                }

                result.AddRange(group);
            }
            return result;
        }

        private int GetMaxLength(List<T> collection)
        {
            int length = 0;
            foreach (var item in collection)
            {
                if (item.GetHashCode() < 0)
                {
                    throw new ArgumentException("Поразрядная сортировка поддерживает только целые числа (больше либо равно нуля)", nameof(Items));
                }

                //var l = Convert.ToInt32(Math.Log10(item.GetHashCode()) + 1); // Не работает со значением item = 0. Дает -infinite.
                var l = item.GetHashCode().ToString().Length;
                if (l > length)
                {
                    length = l;
                }
            }
            return length;
        }
    }
}

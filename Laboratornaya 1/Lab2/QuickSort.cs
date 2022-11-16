using Algorithm;
using Laboratornaya_1.lab3List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.Lab2
{
    /// <summary>
    /// Быстрая сортировка обобщений
    /// </summary>
    public class QuickSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public QuickSort(IEnumerable<T> items) : base(items) { }

        public QuickSort() { }

        protected override void MakeSort()
        {
            Qsort(0, Items.Count - 1); // Мы берем правый элемент как опорный
        }

        private void Qsort(int left, int right)
        {
            // Выходим, когда указатели либо совпадают, либо левый и правый выходят друг за друга (нужно, чтобы они шли друг на друга, но не дальше)
            if (left >= right)
            {
                return;
            }

            var pivot = Sorting(left, right); // Опорный элемент (принимает указатели left и right) 


            // Рекурсивный вызов, pivot - индекс
            Qsort(left, pivot - 1);  // Для левой части, которая меньше оп. элемента (от левой до оп. эл.) 
            Qsort(pivot + 1, right); // Для правой части, к-рая больше оп. элемента (от оп. эл. до конца)
        }

        // Не обязательно находится посередине, всё, что слева - меньше него, справа - больше него
        private int Sorting(int left, int right) // принимает указатели left и right
        {
            var pointer = left; // На какую позицию мы будем устанавливать элмент. Сначала идем слева последовательно направо по всем элементам

            // Опорный элемент находится под Right-адресом.
            for (int i = left; i <= right; i++)
            {
                // Если i < right, то == -1
                if (Compare(Items[i], Items[right]) == -1) //Элемент, который мы сравниваем Items[i], сравниваем с опорным элементом (правый) Items[right - 1]
                {
                    Swop(pointer, i);
                    pointer++;
                }
            }

            Swop(pointer, right); // Меняем опорный элемент
            return pointer; //Возвращаем новое значение опорного элемента
        }
    }
}

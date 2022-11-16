using Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.Lab4
{
    public class MergeSort<T> : AlgorithmBase<T> where T : IComparable
    {
        public int Compares { get; set; } = 0;
        public int Moves { get; set; } = 0;
        protected override void MakeSort()
        {
            var sorted = Sort(Items);
            for (int i = 0; i < sorted.Count; i++)
            {
                Set(i, sorted[i]);
            }
        }
        
        
        /// <summary>
        /// Сортировка методом прямого слияния (рекурсивно)
        /// </summary>
        private List<T> Sort(List<T> items)
        {
            // Выполняем рекурсивный спуск до тех пор, пока последовательность не будет состоять из одного элемента (50:20)

            if (items.Count == 1) // Если коллекция состоит из одного элемента - просто возвращаем его
                return items;
            // Делим коллекцию, если она больше 1 элемента, получаем центральный элемент
            var mid = items.Count / 2;
            // Левая коллекция (взять количество элементов от начала коллекциии (Таке) (методы Linq)
            var left = items.Take(mid).ToList();
            // Правая коллекция (пропустить количество элементов от начала колекции (Skip) и взять за неё
            var right = items.Skip(mid).ToList();

            // Принимаем 2 коллекции рекурсивно и сливаем их
            return Merge(Sort(left), Sort(right));
        }

        /// <summary>
        /// Слияние коллекций
        /// </summary>
        private List<T> Merge(List<T> left, List<T> right) // Метод на слияние
        {
            // Счетчик элементов
            var length = left.Count + right.Count;
            // Указатель на то, какой элемент в данный момент мы рассматриваем
            var leftPointer = 0;
            var rightPointer = 0;

            var result = new List<T>(); // Дополнительная вспомогательная память

            // Нужно пробежаться по всей коллекции (length)
            for (int i = 0; i < length; i++) // Основной цикл
            {
                //Чтобы не зайти за границы, нужно доп. условие. (если вышли - одна из коллекций завершилась)
                if (leftPointer < left.Count && rightPointer < right.Count)
                {
                    // Сравниваем элементы, находящиеся под указателями leftPointer и rightPointer
                    if (Compare(left[leftPointer], right[rightPointer]) == -1)
                    {
                        // Если левый меньше - добавляем правый элемент в итоговую коллекцию
                        // Добавляем элемент, который меньше. Если равны - не принципиально какой добавлять
                        result.Add(left[leftPointer]);
                        leftPointer++;
                        Moves++;
                    }
                    else
                    {
                        result.Add(right[rightPointer]);
                        rightPointer++;
                        Moves++;
                    }
                }
                else
                {
                    // Когда один из указателей перешел за пределы
                    if(rightPointer < right.Count)
                    {
                        // В правой подпоследовательности ещё остались элементы и их надо добавить
                        result.Add(right[rightPointer]);
                        rightPointer++;
                        Moves++;
                    }
                    else
                    {
                        // Иначе в левой коллекции остались элементы
                        result.Add(left[leftPointer]);
                        leftPointer++;
                        Moves++;
                    }
                }
                Compares += 3;
            }
            return result;
        }
    }
}

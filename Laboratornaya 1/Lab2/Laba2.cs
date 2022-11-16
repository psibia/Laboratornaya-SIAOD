using Laboratornaya;
using Laboratornaya_1.lab3List;
using System.Collections;
using System.Collections.Generic;

namespace Laboratornaya_1.Lab2
{
    public class Laba2 : Laba1 
    {
        /// <summary>
        /// Сортировка методом Шелла (улучшенный метод вставками)
        /// </summary>
        public static void ShellSort(ref int[] numbers)
        {
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = numbers[i];

            Print(ref array);

            int step = array.Length / 2; // шаг сортировки
            int compares = 0, moves = 0;
            while (step > 0)
            {
                for (int i = 0; i < (array.Length - step); i++) // количество выполнений (array.Length - step - 1)
                {
                    int j = i; // Индекс сравниваемого элемента
                    while ((j >= 0) && (array[j] > array[j + step]))
                    {
                        Swap(ref array[j], ref array[j + step]);
                        j -= step;
                        compares++;
                        moves += 3;
                    }
                    compares++;
                }
                step = step / 2;
            }

            Print(ref array, compares, moves);
        }

        /// <summary>
        /// Пирамидальная сортировка (сортировка кучей)
        /// </summary>
        public static void HeapSort(ref int[] numbers)
        {
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = numbers[i];

            Print(ref array);

            int compares = 0, moves = 0;
            for (int i = array.Length / 2 - 1; i >= 0; i--)
                Heapify(array, array.Length, i, ref compares, ref moves);
            for (int i = array.Length - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                Swap(ref array[0], ref array[i]);
                moves += 3;
                // вызываем процедуру heapify на уменьшенной куче
                Heapify(array, i, 0, ref compares, ref moves);
            }
            Print(ref array, compares, moves);

            void Heapify(int[] array, int n, int i, ref int compares, ref int moves)
            {
                int largest = i;
                // Инициализируем наибольший элемент как корень
                int l = 2 * i + 1; // left = 2*i + 1
                int r = 2 * i + 2; // right = 2*i + 2

                // Если левый дочерний элемент больше корня
                if (l < n && array[l] > array[largest])
                {
                    largest = l;
                    compares++;
                }

                // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
                if (r < n && array[r] > array[largest])
                {
                    largest = r;
                    compares++;
                }

                // Если самый большой элемент не корень
                if (largest != i)
                {
                    Swap(ref array[i], ref array[largest]);
                    moves += 3;
                    // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                    Heapify(array, n, largest, ref compares, ref moves);
                }
            }
        }

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        public static void QuickSort(ref int[] numbers) // Улучшенная версия сортировки пузырьком (появляется опорный элемент)
        {
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = numbers[i];

            Print(ref array);

            int compares = 0, moves = 0;

            Qsort(0, array.Length-1);

            void Qsort(int left, int right)
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

            int Sorting(int left, int right) // принимает указатели left и right
            {
                var pointer = left; // На какую позицию мы будем устанавливать элмент. Сначала идем слева последовательно направо по всем элементам

                // Опорный элемент находится под Right-адресом.
                for (int i = left; i <= right; i++)
                {
                    // Если i < right, то == -1
                    if (array[i] < array[right]) //Элемент, который мы сравниваем Items[i], сравниваем с опорным элементом (правый) Items[right - 1]
                    {
                        Swap(ref array[pointer], ref array[i]);
                        pointer++;
                        moves += 3;
                    }
                    compares++;
                }

                Swap(ref array[pointer], ref array[right]); // Меняем опорный элемент
                return pointer; //Возвращаем новое значение опорного элемента
            }


            Print(ref array, compares, moves);

        }
    }
}

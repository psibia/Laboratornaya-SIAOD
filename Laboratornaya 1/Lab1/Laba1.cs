using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya
{
    public class Laba1
    {
        /// <summary>
        /// Заполняет массив рандомными числами в диапазоне {-99; 99}
        /// </summary>
        public static void CreateRandomArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Random randomValue = new Random();
                int value = randomValue.Next(-99, 99);
                array[i] = value;
            }
        }
        /// <summary>
        /// Заполняет массив упорядоченными числами от 0 до Array.length-1
        /// </summary>
        public static void CreateOrderedArray(ref int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }
        }

        /// <summary>
        /// Сортировка методом прямого выбора
        /// </summary>
        public static void SelectionSort(ref int[] numbers)
        {
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = numbers[i];

            Print(ref array);


            int compares = 0, moves = 0;
            int minValueIndex; // Индекс массива с минимальным значением
            for (int i = 0; i < array.Length - 1; i++)
            {
                minValueIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minValueIndex])
                    {
                        minValueIndex = j;
                    }
                    compares++;
                }
                if (array[minValueIndex] < array[i]) // Чтобы значения перестановок и сравнений были постоянными - удалить это условие, всё что внутри - оставить
                {
                    Swap(ref array[i], ref array[minValueIndex]);
                    moves += 3;
                    compares++; // // Чтобы значения перестановок и сравнений были постоянными - удалить это
                }
            }

            Print(ref array, compares, moves);
            Console.WriteLine();
        }

        /// <summary>
        /// Пузырьковая сортировка
        /// </summary>
        public static void BubbleSort(ref int[] numbers)
        {
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = numbers[i];

            Print(ref array);

            int compares = 0, moves = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)  // -1 стоит т.к. мы в условии сравниваем j + 1. Иначе выйдем за пределы массива
                {
                    if (array[j] > array[j+1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        moves += 3;
                    }
                    compares++;
                }
            }
            Print(ref array, compares, moves);
            Console.WriteLine();
        }
        /// <summary>
        /// Шейкерная сортировка
        /// </summary>
        public static void ShakerSort(ref int[] numbers)
        {
            int[] array = new int[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
                array[i] = numbers[i];

            Print(ref array);

            int compares = 0, moves = 0;
            int left = 0, right = array.Length - 1;
            int last;
            while(left < right)
            {
                last = -1;
                for(int i = left; i < right; i++) // right НЕ длина массива, это индекс последнего элемента массива (length-1)
                {
                    if(array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        moves += 3;
                        last = i;
                    }
                    compares++;
                }
                right = last;

                last = array.Length;
                for(int i = right-1; i >= left; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                        moves += 3;
                        last = i;
                    }
                    compares++;
                }
                left = last + 1;
            }

            Print(ref array, compares, moves);
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит в консоль массив от 0 до n элемента, (если передано параметром) кол-во сравнений и перестановок, контр. сумму, кол-во серий
        /// </summary>
        
        private protected static void Print(ref int[] array, int? compares = null, int? moves = null)
        {
            foreach (int i in array)
                Console.Write($"{i} ");
            Console.WriteLine();
            if (compares is not null & moves is not null)
                Console.WriteLine($"Сравнений: {compares}, Перестановок: {moves}");
            Console.Write($"Контрольная сумма: {ControlValue(ref array)}   ");
            Console.WriteLine($"Количество серий в массиве: {ControlSeries(ref array)}");

            int ControlSeries(ref int[] array)
            {
                int series = 1;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                        series++;
                }
                return series;
            }

            int ControlValue(ref int[] array)
            {
                int result = 0;
                foreach (int i in array)
                    result += i;
                return result;
            }
        }
        /// <summary>
        /// Меняет значение элементов местами
        /// </summary>
        private protected static void Swap(ref int e1, ref int e2)
        {
            int temp = e1;
            e1 = e2;
            e2 = temp;
        }
    }
}

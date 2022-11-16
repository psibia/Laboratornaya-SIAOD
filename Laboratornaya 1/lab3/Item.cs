using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratornaya_1.lab3List
{
    /// <summary>
    /// Ячейка списка
    /// </summary>
    public class Item<T>
    {
        private T? data = default;
        /// <summary>
        /// Данные хранимые в ячейке списка
        /// </summary>
        private Item<T>? next = null;

        public T Data
        {
            get { return data; }
            set
            {
                if (value != null)
                    data = value;
                else throw new ArgumentNullException(nameof(value));
            }
        }
        /// <summary>
        /// Следующая ячейка списка
        /// </summary>
        public Item<T>? Next { get; set; }

        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}

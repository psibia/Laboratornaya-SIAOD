using System;

namespace Laboratornaya_1.lab3
{
    public class Node
    { 
        public int Data { get; set; }
        /// <summary>
        /// Ссылка на следующий элемент
        /// </summary>
        public Node? ElementReference { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }
}

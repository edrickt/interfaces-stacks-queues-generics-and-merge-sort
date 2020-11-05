using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    class GenericStack<T>
    {
       protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        protected Node _head;
        protected Node _tail;
        protected int _size;

        public bool IsEmpty
        {
            get
            {
                return _head == null && true;
            }
        }
        public int Size
        {
            get
            {
                return _size;
            }
        }

        public void Push(T Data)
        {
            Node oldHead = _head;
            _head = new Node();
            _head.Data = Data;
            _head.Next = oldHead;
            _size++;
            if (_size == 1)
            {
                _tail = _head;
            }
        }
        public T Pop()
        {
            if (IsEmpty)
            {
                Console.Clear();
                Console.WriteLine("LIST EMPTY"); ;
            }
            T returnData = _head.Data;
            _head = _head.Next;
            _size--;
            if (IsEmpty)
            {
                _tail = null;
            }
            return returnData;
        }
        public void Display()
        {
            Node current = _head;
            if (current != null)
            {
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("LIST EMPTY, PLEASE POPULATE FIRST" + Environment.NewLine);
            }
        }
    }
}

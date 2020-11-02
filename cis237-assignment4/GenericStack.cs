using System;
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
                throw new Exception("List is empty");
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
        // Outside referece: https://www.geeksforgeeks.org/write-a-function-to-get-nth-node-in-a-linked-list/
        public T GetList(int index)
        {
            Node current = _head;
            int count = 0;
            while (current != null)
            {
                if (count == index)
                {
                    return current.Data;
                }
                count++;
                current = current.Next;
                if (current == null)
                {
                    current = null;
                    return current.Data;
                }
            }
            return current.Data;
        }
        public void Display()
        {
            Node current = _head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}

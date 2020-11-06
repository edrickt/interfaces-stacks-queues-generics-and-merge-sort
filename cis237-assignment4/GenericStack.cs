// Edrick Tamayo
// Thursday 3:30PM
// November 6, 2020

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
    // First in first out
    class GenericStack<T>
    {
        // Properties
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

        // Push the data to the front of the list
        public void Push(T Data)
        {
            // new node called oldHead at head
            Node oldHead = _head;
            // Make new node for head
            _head = new Node();
            // Give that head the data
            _head.Data = Data;
            // Make head point to old head, creating new head
            _head.Next = oldHead;
            // Increase size
            _size++;
            // If only one item in list, then make tail point to head
            if (_size == 1)
            {
                _tail = _head;
            }
        }

        // Remove from list from front and return that data
        public T Pop()
        {
            // If list is empty, do this
            if (IsEmpty)
            {
                Console.Clear();
                Console.WriteLine("LIST EMPTY"); ;
            }
            // Return data from head
            T returnData = _head.Data;
            // Set head as the next node, remove last head
            _head = _head.Next;
            // Decrease size
            _size--;
            // If head points to null, set tail to null, list is empty
            if (IsEmpty)
            {
                _tail = null;
            }
            // Return data
            return returnData;
        }

        // Display the list
        public void Display()
        {
            // New node current = head
            Node current = _head;
            
            // If current isnt null
            if (current != null)
            {
                // While current isnt null, write data until empty
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
                Console.WriteLine();
            }
            // Else output list is empty
            else
            {
                Console.WriteLine("LIST EMPTY, PLEASE POPULATE FIRST" + Environment.NewLine);
            }
        }
    }
}

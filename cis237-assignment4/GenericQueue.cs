// Edrick Tamayo
// Thursday 3:30PM
// November 6, 2020

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment4
{
    // Last in first out
    class GenericQueue<T>
    {
        // Properties
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
        }

        // Beginning of node
        protected Node _head;
        // Tail of node
        protected Node _tail;
        // Size of linked list
        protected int _size;

        // Property if list is empty, will return null and true
        public bool IsEmpty
        {
            get
            {
                return _head == null && true;
            }
        }
        
        // Property of size of linked list
        public int Size
        {
            get
            {
                return _size;
            }
        }

        // Enqueue new data
        public void Enqueue(T Data)
        {
            // New node that points to tail
            Node oldTail = _tail;
            // Make new node for tail
            _tail = new Node();
            // Set new data to tail
            _tail.Data = Data;
            // Next node is null
            _tail.Next = null;
            // If head points to tail and is null, return null
            if (IsEmpty)
            {
                _head = _tail;
            }
            // Since _tail.Next points to null, set oldTail to become new tail and point to null
            else
            {
                oldTail.Next = _tail;
            }
            // Increase size
            _size++;
        }
        // Dequeue the linked list
        public T Dequeue()      
        {
            // If list is empty, then throw exception
            if (IsEmpty)
            {
                throw new Exception("List is empty");
            }
            // Will return the data on _head
            T returnData = _head.Data;
            // _head will point to the second item in the list
            _head = _head.Next;
            // Decrease size
            _size--;
            // If head is set to null, set tail to null too, empty list
            if (IsEmpty)
            {
                _tail = null;
            }
            // Return data
            return returnData;
        }
    }
}

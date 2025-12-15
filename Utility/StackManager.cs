using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerApp.Utility
{

    internal class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
    internal class StackManager<T>
    {
        
        private Node<T> top;   

        public StackManager()
        {
            top = null;
        }

      
        public void PushDeletedItem(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = top;
            top = newNode;
        }

        public T Pop()
        {
            if (top == null)
            {
                return default(T); 
            }

            T data = top.Data;
            top = top.Next;
            return data;
        }

        public T UndoDelete()
        {
            if (top == null)
                return default;

            T data = top.Data;
            top = top.Next;
            return data;
        }

        public bool HasItems()
        {
            return top != null;
        }
    }
}

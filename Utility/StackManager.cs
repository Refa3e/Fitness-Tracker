using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTrackerApp.Utility
{
    internal class StackManager<T>
    {
        private Stack<T> deletedItems;

        public StackManager()
        {
            deletedItems = new Stack<T>();
        }

        public void PushDeletedItem(T item)
        {
            deletedItems.Push(item);
        }

        public T UndoDelete()
        {
            if (deletedItems.Count == 0)
                return default;

            return deletedItems.Pop();
        }

        public bool HasItems()
        {
            return deletedItems.Count > 0;
        }
    }
}

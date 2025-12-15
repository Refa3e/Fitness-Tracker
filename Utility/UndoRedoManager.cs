using System;
using System.Collections.Generic;

namespace FitnessTrackerApp.Utility
{
    public class UndoAction
    {
        public string EntryGUID { get; set; }
        public string EntryData { get; set; }
        public string ActionType { get; set; } 
    }

    public class UndoManager<T> where T : class
    {
        private Stack<UndoAction> _undoStack;

        public UndoManager()
        {
            _undoStack = new Stack<UndoAction>();
        }

        public void Push(UndoAction action)
        {
            _undoStack.Push(action);
        }

        public UndoAction Pop()
        {
            if (_undoStack.Count > 0)
            {
                return _undoStack.Pop();
                 
            }
            return null;
        }

        public bool CanUndo()
        {
            return _undoStack.Count > 0;
        }

        

        public void Clear()
        {
            _undoStack.Clear();
        }

        public int UndoStackCount => _undoStack.Count;
    }
}
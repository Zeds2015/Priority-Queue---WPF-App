using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApplication.Common
{
    public class PriorityQueue<T> : IEnumerable<T>, ICollection where T : IComparable<T>
    {
        private LinkedList<T> _list;
        public PriorityQueue()
        {
            _list = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            if (_list.Count == 0)
            {
                _list.AddLast(item);
            }
            else
            {
                var current = _list.First;

                while (current != null && current.Value.CompareTo(item) > 0)
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    _list.AddLast(item);
                }
                else
                {
                    _list.AddBefore(current, item);
                }
            }
        }

        public T Dequeue()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Nothing to be removed!");
            }
            var result = _list.First.Value;
            _list.RemoveFirst();
            return result;
        }

        public T Peek()
        {
            if (_list.Count == 0)
            {
                throw new InvalidOperationException("Nothing to show!");
            }
            return _list.First.Value;
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int Count
        {
            get
            { 
                return _list.Count; 
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            _list
                .Reverse()
                .Skip(index)
                .Reverse()
                .ToList()
                .CopyTo(array as T[], 0);
        }

        public bool IsSynchronized
        {
            get { return true; }
        }

        public object SyncRoot
        {
            get { return this; }
        }
    }
}

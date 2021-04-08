using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    // My own implementation of PriorityQueue with generic capability
    public class PriorityQueue<T>
    {
        private readonly IList<T> _list;
        private readonly IComparer<T> _comparer;

        public PriorityQueue()
        {
            _list = new List<T>();
            _list.Add(default);
            _comparer = Comparer<T>.Default;
        }

        public PriorityQueue(IComparer<T> comparer)
        {
            _list = new List<T>();
            _list.Add(default);
            _comparer = comparer;
        }

        public int Count { get { return _list.Count - 1; } }

        public void Push(T value)
        {
            var newIndex = _list.Count;
            _list.Add(value);

            Swim(newIndex);
        }

        private void Swim(int index)
        {
            while (index > 1 && _comparer.Compare(_list[index], _list[index / 2]) < 0)
            {
                Swap(index / 2, index);
                index /= 2;
            }
        }

        private void Swap(int i, int j)
        {
            var temp = _list[i];
            _list[i] = _list[j];
            _list[j] = temp;
        }

        public T Peek()
        {
            if (_list.Count < 2)
                throw new InvalidOperationException();

            return _list[1];
        }

        public T Pop()
        {
            if (_list.Count < 2)
                throw new InvalidOperationException();

            T result = _list[1];
            _list[1] = _list[^1];
            _list.RemoveAt(_list.Count - 1);
            Heapify(1);

            return result;
        }

        private void Heapify(int index)
        {
            var smallest = index;
            var left = index * 2;
            var right = index * 2 + 1;

            if (left < _list.Count && _comparer.Compare(_list[left], _list[smallest]) < 0)
            {
                smallest = left;
            }
            if (right < _list.Count && _comparer.Compare(_list[right], _list[smallest]) < 0)
            {
                smallest = right;
            }
            if (smallest != index)
            {
                Swap(index, smallest);
                Heapify(smallest);
            }
        }
    }
}

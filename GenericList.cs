using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _19Tema1
{
    public class GenericList<T> where T : IComparable<T>
    {
        private T[] _elements;
        private int _maxAllowed;

        public GenericList(int capacity = 1)
        {
            _elements = new T[capacity];
            _maxAllowed = capacity;
            Length = 0;
        }

        public int Length { get; private set; }

        public List<T> Elements => _elements.ToList();

        public void Add(T el)
        {
            AddToCount();
            _elements[Length - 1] = el;
        }

        // Indexer
        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _elements[index];
            }

            set
            {
                ValidateIndex(index);
                _elements[index] = value;
            }
        }

        public void RemoveByIndex(int idx)
        {
            ValidateIndex(idx);
            for (var i = idx; i < Length - 1; i++)
            {
                _elements[i] = _elements[i + 1];
            }

            Length--;
        }

        public void AddAtIndex(int idx, T el)
        {
            ValidateNewIndex(idx);
            AddToCount();
            for (var i = _elements.Length - 1; i > idx; i--)
            {
                _elements[i] = _elements[i - 1];
            }

            _elements[idx] = el;
        }

        public void Clear()
        {
            Array.Resize(ref _elements, 0);
            Length = 0;
        }

        public int Find(T el)
        {
            return Array.IndexOf(_elements, el);
        }

        public T Min()
        {
            var min = _elements[0];
            for (var i = 1; i < Length; i++)
                if (_elements[i].CompareTo(min) < 0) min = _elements[i];
            return min;
        }

        public T Max()
        {
            var max = _elements[0];
            for (var i = 1; i < Length; i++)
                if (_elements[i].CompareTo(max) > 0) max = _elements[i];
            return max;
        }

        public override string ToString()
        {
            var splitter = ", ";
            var sb = new StringBuilder();

            for (var i = 0; i < Length; i++)
            {
                sb.Append(_elements[i]);
                if (i != Length - 1)
                {
                    sb.Append(splitter);
                }
            }

            return sb.ToString();
        }


        private void AddToCount()
        {
            Length++;
            if (Length <= _elements.Length)
            {
                return;
            }
            _maxAllowed *= 2;
            Array.Resize(ref _elements, _maxAllowed);
        }



        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Length)
            {
                throw new ArgumentOutOfRangeException(OutOfRangeErrorMessage(Length - 1));
            }
        }

        private string OutOfRangeErrorMessage(int length) => $"The index is out of range [0-{length}]";


        private void ValidateNewIndex(int index)
        {
            if (index < 0 || index > Length)
            {
                throw new ArgumentOutOfRangeException(OutOfRangeErrorMessage(Length));
            }
        }

    }
}

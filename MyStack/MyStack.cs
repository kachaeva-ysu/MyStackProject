using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStack
{
    public class MyStack<T>
    {
        public int Capacity;
        private T[] items;
        public int Count { get; private set; }

        public MyStack() : this(4)
        {
        }

        public MyStack(ICollection<T> col)
        {
            if (col != null)
            {
                Capacity = col.Count;
                Count = col.Count;
                items = new T[Capacity];
                col.CopyTo(items, 0);
            }
            else
                throw new ArgumentNullException();
        }

        public MyStack(int initialCapacity)
        {
            if (initialCapacity >= 0)
            {
                Capacity = initialCapacity;
                items = new T[Capacity];
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        private void IncreaseCapacity()
        {
            if (Capacity == Count)
            {
                Capacity *= 2;
                T[] temp = new T[Capacity];
                Array.Copy(items, temp, Count);
                items = temp;
            }
        }

        public void Push(T item)
        {
            IncreaseCapacity();
            items[Count] = item;
            Count++;
        }

        public T Pop()
        {
            if (Count != 0)
            {
                Count--;
                return items[Count];
            }
                throw new InvalidOperationException();
        }

        public T Peek()
        {
            if (Count > 0)
                return items[Count - 1];
            throw new InvalidOperationException();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Count; i++)
                result.Append(items[i].ToString() + " ");
            result.Append(Count + " ");
            result.Append(Capacity);
            return result.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }
    }
}

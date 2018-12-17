using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListt
{
    class MyList<T> : IEnumerable
    {
        private T[] MyArray { get; set; }
        public int Length { get; private set; }
        private int Count { get; set; }

        public MyList(int count = 10)
        {
            MyArray = new T[count];
            Count = count;
        }

        public void Insert(T data, int index)
        {
            if (index > Length - 1)
            {
                throw new System.IndexOutOfRangeException();
            }
            if (index == Length - 1 || Count == Length)
            {
                IncreaseCapacity();
            }

            for (var i = Length; i > index; i--)
            {
                MyArray[i] = MyArray[i - 1];
            }

            MyArray[index] = data;
            Length++;

        }

        public void DeleteAt(int index)
        {
            if (index > Length - 1)
            {
                throw new System.IndexOutOfRangeException();
            }
            if (index == Length - 1)
            {
                MyArray[index] = default(T);
                Length--;
            }
            else
            {
                for (var i = index; i < Length - 1; i++)
                {
                    MyArray[i] = MyArray[i + 1];
                }
                MyArray[Length - 1] = default(T);
                Length--;
            }
        }

        public void Delete(T data)
        {
            for (var i = 0; i < Length; i++)
            {
                if (MyArray[i].Equals(data))
                {
                    DeleteAt(i);
                    i--;
                    //    break;
                }
            }
        }

        public void Clear()
        {
            MyArray = new T[100];
            Length = 0;
            Count = 100;
        }

        public void Add(T data)
        {
            if (Length == Count)
            {
                IncreaseCapacity();
            }
            MyArray[Length] = data;
            Length++;
        }

        private void IncreaseCapacity()
        {
            T[] tmp = new T[Count * 2];
            for (var i = 0; i < Count; i++)
            {
                tmp[i] = MyArray[i];
            }
            MyArray = tmp;
            Count *= 2;
        }

        public IEnumerator Enumerator()
        {
            //var current = HeadNode;
            //while (current != null)
            //{
            //    yield return current.Data;
            //    current = current.Next;
            //}
            return null;
        }

        public IEnumerator GetEnumerator()
        {
            return Enumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}

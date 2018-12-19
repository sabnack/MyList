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
        private T[] _data { get; set; }
        public int Length { get; private set; }
        private const int _defaultSize = 100;

        public MyList(int count = _defaultSize)
        {
            _data = new T[count];
        }

        public void Insert(T data, int index)
        {
            if (index > Length - 1)
            {
                throw new System.IndexOutOfRangeException();
            }
            if (_data.Length == Length)
            {
                IncreaseCapacity();
            }

            for (var i = Length; i > index; i--)
            {
                _data[i] = _data[i - 1];
            }

            _data[index] = data;
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
                _data[index] = default(T);
                Length--;
            }
            else
            {
                for (var i = index; i < Length - 1; i++)
                {
                    _data[i] = _data[i + 1];
                }
                _data[Length - 1] = default(T);
                Length--;
            }
        }

        public void Delete(T data)
        {
            for (var i = 0; i < Length; i++)
            {
                if (_data[i].Equals(data))
                {
                    DeleteAt(i);
                    break;
                }
            }
        }

        public void Clear()
        {
            _data = new T[_defaultSize];
            Length = 0;
        }

        public void Add(T data)
        {
            if (Length == _data.Length)
            {
                IncreaseCapacity();
            }
            _data[Length] = data;
            Length++;
        }

        private void IncreaseCapacity()
        {
            T[] tmp = new T[_defaultSize * 2];
            for (var i = 0; i < _defaultSize; i++)
            {
                tmp[i] = _data[i];
            }
            _data = tmp;
        }

        public IEnumerator Enumerator()
        {
            for(var i=0; i< Length;i++)
            {
                yield return _data[i];
            }
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

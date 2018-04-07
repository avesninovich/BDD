using System;
using System.Collections.Generic;

namespace DataStructs
{
    public class HashTable
    {
        private class KeyValuePair
        {
            public readonly object Key;
            public object Value;

            public KeyValuePair(object key, object value)
            {
                Key = key;
                Value = value;
            }
        }

        public int Size { get; private set; }
        public int Count { get; private set; }

        // Разрешение коллизий методом цепочек
        // только вместо цепочек List<T>
        private List<KeyValuePair>[] table;

        public HashTable(int size)
        {
            Size = size;
            Count = 0;
            table = new List<KeyValuePair>[Size];
            for (int i = 0; i < Size; i++)
            {
                table[i] = new List<KeyValuePair>();
            }
        }
        
        public void Add(object key, object value)
        {
            var pair = GetPair(key);
            if (pair != null)
            {
                pair.Value = value;
            }
            else
            {
                table[Hash(key)].Add(new KeyValuePair(key, value));
                Count++;
            }
        }

        private KeyValuePair GetPair(object key)
        {
            var i = Hash(key);
            foreach (var keyValuePair in table[i])
            {
                if (keyValuePair.Key.Equals(key))
                {
                    return keyValuePair;
                }
            }

            return null;
        }
        
        public object GetValueByKey(object key)
        {
            var i = Hash(key);
            if (table[i] == null)
            {
                return null;
            }

            foreach (var keyValuePair in table[i])
            {
                if (keyValuePair.Key.Equals(key))
                {
                    return keyValuePair.Value;
                }
            }

            return null;
        }

        // Чтобы как в стандартной библиотеке
        public object this[object key]
        {
            get { return GetValueByKey(key); }
            set { Add(key, value); }
        }

        private int Hash(object key)
        {
            var hash = (double)key.GetHashCode();
            hash *= hash < 0 ? -1 : 1;
            return Convert.ToInt32(Size * (hash * MultiplicationConst % 1));
        }

        // Оптимальное значение, выведенное Д. Кнутом
        private const double MultiplicationConst = 0.618;
    }
}


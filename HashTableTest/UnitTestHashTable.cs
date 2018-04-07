using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructs;

namespace HashTableTest
{
    [TestClass]
    public class UnitTestHashTable
    {
        [TestMethod]
        public void HashTableTestThreeElements()
        {
            var hashTable = new HashTable(10);
            string key1 = "key 1";
            string key2 = "key 2";
            string key3 = "key 3";
            string value1 = "value 1";
            string value2 = "value 2";
            string value3 = "value 3";
            hashTable[key1] = value1;
            hashTable[key2] = value2;
            hashTable[key3] = value3;
            Assert.AreEqual(value1, hashTable[key1]);
            Assert.AreEqual(value2, hashTable[key2]);
            Assert.AreEqual(value3, hashTable[key3]);
        }

        [TestMethod]
        public void HashTableOverwrite()
        {
            var hashTable = new HashTable(1);
            var key = "key";
            var value = "value";
            hashTable[key] = "valueToOverwrite";
            hashTable[key] = value;
            Assert.AreEqual(value, hashTable.GetValueByKey(key));
        }

        [TestMethod]
        public void HashTableAddManyFindOne()
        {
            int amount = 10000;
            var hashTable = new HashTable(amount * 10);
            var rand = new Random();
            var key = rand.Next(amount);
            var valueToFind = 0;
            for (int i = 0; i < amount; i++)
            {
                var value = rand.Next();
                if (i == key) valueToFind = value;
                hashTable[i] = value;
            }
            Assert.AreEqual(valueToFind, hashTable[key]);
        }

        [TestMethod]
        public void HashTableAddManyFindNulls()
        {
            int amount = 10000;
            int nullsAmount = 1000;
            var hashTable = new HashTable(amount);
            var rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                hashTable[i + nullsAmount] = rand.Next();
            }

            for (int i = 0; i < nullsAmount; i++)
            {
                Assert.IsNull(hashTable[i]);
            }
        }
    }
}

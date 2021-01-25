using LeetCode;
using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode
{
    public class Question0706
    {
        /*
         * 不使用任何内建的哈希表库设计一个哈希映射
         * 具体地说，你的设计应该包含以下的功能
         * put(key, value)：向哈希映射中插入(键,值)的数值对。如果键对应的值已经存在，更新这个值
         * get(key)：返回给定的键所对应的值，如果映射中不包含这个键，返回-1。
         * remove(key)：如果映射中存在这个键，删除这个数值对。
         */

        [Fact]
        public void Test()
        {
            MyHashMap hashMap = new MyHashMap();
            hashMap.Put(1, 1);
            hashMap.Put(2, 2);
            Assert.Equal(1, hashMap.Get(1));    // 返回 1
            Assert.Equal(-1, hashMap.Get(3));    // 返回 -1 (未找到)
            hashMap.Put(2, 1);                  // 更新已有的值
            Assert.Equal(1, hashMap.Get(2));    // 返回 1
            hashMap.Remove(2);         // 删除键为2的数据
            Assert.Equal(-1, hashMap.Get(2));    // 返回 -1 (未找到) 
        }
    }

    public class MyHashMap
    {
        private int[] list;

        /** Initialize your data structure here. */
        public MyHashMap()
        {
            list = new int[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                list[i] = -1;
            }
        }

        /** value will always be non-negative. */
        public void Put(int key, int value)
        {
            list[key] = value;
        }

        /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
        public int Get(int key)
        {
            return list[key];
        }

        /** Removes the mapping of the specified value key if this map contains a mapping for the key */
        public void Remove(int key)
        {
            list[key] = -1;
        }
    }

    public class MyHashMapPlus
    {
        static private int speace = 2069;
        private LinkedList<int[]>[] list;

        public MyHashMapPlus()
        {
            list = new LinkedList<int[]>[speace];
            for (int i = 0; i < speace; i++)
            {
                list[i] = new LinkedList<int[]>();
            }
        }

        public void Put(int key, int value)
        {
            bool flag = true;
            foreach (int[] i in list[key % speace])
            {
                if (i[0] == key)
                {
                    i[1] = value;
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                int[] temp = new int[2] { key, value };
                list[key % speace].AddLast(temp);
            }
        }

        public int Get(int key)
        {
            foreach (int[] i in list[key % speace])
            {
                if (i[0] == key)
                {
                    return i[1];
                }
            }
            return -1;
        }

        public void Remove(int key)
        {
            foreach (int[] i in list[key % speace])
            {
                if (i[0] == key)
                {
                    list[key % speace].Remove(i);
                    return;
                }
            }

        }
    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0692
    {
        /*
         * 给一非空的单词列表，返回前 k 个出现次数最多的单词。
         *
         * 返回的答案应该按单词出现频率由高到低排序。如果不同的单词有相同出现频率，按字母顺序排序。
         */

        [Theory]
        [Q0692TestData]
        public void Test(string[] input1, int input2, IList<string> output)
        {
            Assert.Equal(output, TopKFrequent(input1,input2));
        }

        public IList<string> TopKFrequent(string[] words, int k)
        {
            Hashtable table = new Hashtable();
            IList<string> res = new List<string>();

            foreach (string word in words)
            {
                if(table.Contains(word))
                {
                    int count = (int)table[word];
                    count++;
                    table.Remove(word);
                    table.Add(word,count);
                    continue;
                }
                table.Add(word,1);
            }

            string[] keyStrings = new string[table.Count];
            int[] valStrings = new int[table.Count];

            table.Keys.CopyTo(keyStrings, 0);
            table.Values.CopyTo(valStrings, 0);

            Array.Sort(keyStrings, valStrings);

            for (int i = 0; i < k;)
            {
                int max = valStrings.Max();
                for(int j = 0;j<keyStrings.Length;j++)
                {
                    if(valStrings[j] == max)
                    {
                        res.Add(keyStrings[j]);
                        valStrings[j] = 0;
                        i++;
                        if (i == k)
                            break;
                    }
                }

                
            }

            return res;

        }

    }

    public class Q0692TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[]
                {new object[] {"i", "love", "leetcode", "i", "love", "coding"}, 2, new List<string>() {"i", "love"}};
            yield return new object[]
                {new object[] {"i", "love", "leetcode", "i", "love", "coding"}, 1, new List<string>() {"i"}};
            yield return new object[]
            {
                new object[] {"the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is"}, 4,
                new List<string>() {"the", "is", "sunny", "day"}
            };
        }
    }
}

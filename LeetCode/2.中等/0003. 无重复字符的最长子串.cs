using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0003
    {
        /*
         * 给定一个字符串，请你找出其中不含有重复字符的 最长子串 的长度。
         */

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData("dvdf", 3)]
        [InlineData("", 0)]
        public void Test(string input, int output)
        {
            Assert.Equal(output, LengthOfLongestSubstring(input));
        }

        public int LengthOfLongestSubstring(string s)
        {
            int window = 0;
            int max = 0;
            Hashtable table = new Hashtable();
            //HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!table.ContainsKey(s[i]))
                {
                    window++;
                }
                else
                {
                    max = max > window ? max : window;
                    table.Remove(s[i - window]);
                    while (table.ContainsKey(s[i]))
                    {
                        window--;
                        table.Remove(s[i - window]);
                    }
                }

                table.Add(s[i],i);
            }

            return max > window ? max : window;
        }

    }
}

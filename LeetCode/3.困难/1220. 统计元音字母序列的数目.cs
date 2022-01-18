using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1220
    {
        /*
         * 给你一个整数 n，请你帮忙统计一下我们可以按下述规则形成多少个长度为 n 的字符串：
         * 字符串中的每个字符都应当是小写元音字母（'a', 'e', 'i', 'o', 'u'）
         * 每个元音 'a' 后面都只能跟着 'e'
         * 每个元音 'e' 后面只能跟着 'a' 或者是 'i'
         * 每个元音 'i' 后面 不能 再跟着另一个 'i'
         * 每个元音 'o' 后面只能跟着 'i' 或者是 'u'
         * 每个元音 'u' 后面只能跟着 'a'
         * 由于答案可能会很大，所以请你返回 模 10^9 + 7 之后的结果。。
         */

        [Theory]
        [Q1220TestData]
        public void Test(int input, int output)
        {
            Assert.Equal(output, CountVowelPermutation(input));
        }

        public int CountVowelPermutation(int n)
        {
            long mod = (long)Math.Pow(10, 9) + 7;

            long[] list = new long[5];
            long[] newlist = new long[5];

            long res = 0;

            for (int i = 0;i<5;i++)
                list[i] = 1;

            for (int j = 1;j<n;j++)
            {
                newlist[0] = (list[1] + list[2] + list[4]) % mod;
                newlist[1] = (list[0] + list[2]) % mod;
                newlist[2] = (list[1] + list[3]) % mod;
                newlist[3] = (list[2]) % mod;
                newlist[4] = (list[2] + list[3]) % mod;

                list[0] = newlist[0];
                list[1] = newlist[1];
                list[2] = newlist[2];
                list[3] = newlist[3];
                list[4] = newlist[4];
            }

            for(int i = 0;i<5; i++)
            {
                res += list[i];
                res %= mod;
            }

            return (int)res;
        }

    }

    public class Q1220TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { 1, 5 };
            yield return new object[] { 2, 10 };
            yield return new object[] { 5, 68 };
            yield return new object[] { 144, 18208803 };
        }
    }
}

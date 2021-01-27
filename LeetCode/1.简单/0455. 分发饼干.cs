using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0455
    {
        /*
         * 假设你是一位很棒的家长，想要给你的孩子们一些小饼干。但是，每个孩子最多只能给一块饼干。
         *
         * 对每个孩子 i，都有一个胃口值 g[i]，这是能让孩子们满足胃口的饼干的最小尺寸；并且每块饼干 j，都有一个尺寸 s[j] 。如果 s[j] >= g[i]，我们可以将这个饼干 j 分配给孩子 i ，这个孩子会得到满足。你的目标是尽可能满足越多数量的孩子，并输出这个最大数值。
         *
         */

        [Theory]
        [Q0455TestData]
        public void Test(int[] input1, int[] input2, int output)
        {
            Assert.Equal(output, FindContentChildren(input1, input2));
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Reverse(g);
            Array.Sort(s);
            Array.Reverse(s);
            int i = 0;
            int j = 0;
            while (i < g.Length && j < s.Length)
            {
                if (g[i] > s[j])
                {
                    i++;
                    continue;
                }
                else if (g[i] <= s[j])
                {
                    i++;
                    j++;
                    continue;
                }
            }
            return j;
        }

    }

    public class Q0455TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 2, 3 }, new object[] { 1, 1 }, 1 };
            yield return new object[] { new object[] { 1, 2 }, new object[] { 1, 2, 3 }, 2 };
        }
    }
}

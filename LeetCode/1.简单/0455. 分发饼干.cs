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

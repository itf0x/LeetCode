using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1672
    {
        /*
         * 
         */

        [Theory]
        [Q1672TestData]
        public void Test(int[][] input, int output)
        {
            Assert.Equal(output, MaximumWealth(input));
        }

        public int MaximumWealth(int[][] accounts)
        {
            int res = 0;
            foreach (int[] account in accounts)
            {
                var temp = 0;
                foreach (int i in account)
                {
                    temp += i;
                }

                res = res > temp ? res : temp;
            }

            return res;
        }

    }

    public class Q1672TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new int[][] {new int[]{1, 2, 3 },new int[]{3, 2, 1 } }, 6 };
            yield return new object[] { new int[][] { new int[] { 1, 5 }, new int[] { 7, 3 }, new int[] { 3, 5 } }, 10 };
            yield return new object[] { new int[][] { new int[] { 2, 8, 7 }, new int[] { 7, 1, 3 }, new int[] { 1, 9, 5 } }, 17 };
        }
    }
}

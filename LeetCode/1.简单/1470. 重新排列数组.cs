using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1470
    {
        /*
         * 给你一个数组 nums ，数组中有 2n 个元素，按 [x1,x2,...,xn,y1,y2,...,yn] 的格式排列。
         * 
         * 请你将数组按 [x1,y1,x2,y2,...,xn,yn] 格式重新排列，返回重排后的数组。
         * 
         */

        [Theory]
        [Q1470TestData]
        public void Test(int[] input1, int input2, int[] output)
        {
            Assert.Equal(output, Shuffle(input1, input2));
        }

        public int[] Shuffle(int[] nums, int n)
        {
            int[] res = new int[2 * n];

            for (int i = 0; i < n; i++)
            {
                res[2 * i] = nums[i];
                res[2 * i + 1] = nums[n + i];
            }

            return res;

        }

    }

    public class Q1470TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 2, 5, 1, 3, 4, 7 }, 3, new object[] { 2, 3, 5, 4, 1, 7 } };
            yield return new object[] { new object[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new object[] { 1, 4, 2, 3, 3, 2, 4, 1 } };
            yield return new object[] { new object[] { 1, 1, 2, 2 }, 2, new object[] { 1, 2, 1, 2 } };
        }
    }
}

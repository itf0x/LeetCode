using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1480
    {
        /*
         * 给你一个数组 nums 。数组「动态和」的计算公式为：runningSum[i] = sum(nums[0]…nums[i]) 。
         *
         * 请返回 nums 的动态和。
         *
         */

        [Theory]
        [Q1480TestData]
        public void Test(int[] input, int[] output)
        {
            Assert.Equal(output, RunningSum(input));
        }

        public int[] RunningSum(int[] nums)
        {
            int[] res = new int[nums.Length];

            int temp = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                temp += nums[i];
                res[i] = temp;
            }

            return res;

        }

    }

    public class Q1480TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 2, 3, 4 }, new object[] { 1, 3, 6, 10 } };
            yield return new object[] { new object[] { 1, 1, 1, 1, 1 }, new object[] { 1, 2, 3, 4, 5 } };
            yield return new object[] { new object[] { 3, 1, 2, 10, 1 }, new object[] { 3, 4, 6, 16, 17 } };
        }
    }
}

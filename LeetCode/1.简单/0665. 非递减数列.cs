using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0665
    {
        /*
         * 给你一个长度为 n 的整数数组，请你判断在 最多 改变 1 个元素的情况下，该数组能否变成一个非递减数列。
         *
         * 我们是这样定义一个非递减数列的： 对于数组中所有的 i (0 <= i <= n-2)，总满足 nums[i] <= nums[i + 1]。
         */

        [Theory]
        [Q0665TestData]
        public void Test(int[] input, bool output)
        {
            Assert.Equal(output, CheckPossibility(input));
        }

        public bool CheckPossibility(int[] nums)
        {
            int flag = 0;

            for (int i = 0; i < nums.Length-1; i++)
            {
                if(nums[i]>nums[i+1])
                {
                    flag++;
                    if (flag > 1)
                    {
                        return false;
                    }

                    if (i > 0 && nums[i - 1] > nums[i + 1])
                    {
                        nums[i + 1] = nums[i];
                    }
                }
            }

            return true;
        }
    }

    public class Q0665TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 4, 2, 3 }, true };
            yield return new object[] { new object[] { 4, 2, 1 }, false };
            yield return new object[] { new object[] { 3, 4, 2, 3 }, false };
            yield return new object[] { new object[] { 5, 7, 1, 8 }, true };
        }
    }
}

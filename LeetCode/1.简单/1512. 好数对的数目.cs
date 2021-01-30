using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1512
    {
        /*
         * 给你一个整数数组 nums 。
         *
         * 如果一组数字 (i,j) 满足 nums[i] == nums[j] 且 i < j ，就可以认为这是一组 好数对 。
         *
         * 返回好数对的数目
         *
         */

        [Theory]
        [Q1512TestData]
        public void Test(int[] input, int output)
        {
            Assert.Equal(output, NumIdenticalPairs(input));
        }

        public int NumIdenticalPairs(int[] nums)
        {
            int res = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        res++;
                }
            }

            return res;
        }

    }

    public class Q1512TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 2, 3, 1, 1, 3 }, 4 };
            yield return new object[] { new object[] { 1, 1, 1, 1 }, 6 };
            yield return new object[] { new object[] { 1, 2, 3 }, 0 };
        }
    }
}

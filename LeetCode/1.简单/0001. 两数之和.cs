using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0001
    {
        /*
         * 给定一个整数数组 nums 和一个整数目标值 target，请你在该数组中找出 和为目标值 的那 两个 整数，并返回它们的数组下标。
         *
         * 你可以假设每种输入只会对应一个答案。但是，数组中同一个元素不能使用两遍。
         *
         * 你可以按任意顺序返回答案。
         *
         */

        [Theory]
        [Q0001TestData]
        public void Test(int[] input1,int input2, int[] output)
        {
            Assert.Equal(output, TwoSum(input1,input2));
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i]+nums[j]==target)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return null;
        }

    }

    public class Q0001TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 2, 7, 11, 15 }, 9, new object[] { 0, 1 } };
            yield return new object[] { new object[] { 3, 2, 4 }, 6, new object[] { 1, 2 } };
            yield return new object[] { new object[] { 3, 3 }, 6, new object[] { 0, 1 } };
        }
    }
}

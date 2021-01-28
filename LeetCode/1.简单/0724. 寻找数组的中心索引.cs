using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0724
    {
        /*
         * 给定一个整数类型的数组 nums，请编写一个能够返回数组 “中心索引” 的方法。
         *
         * 我们是这样定义数组 中心索引 的：数组中心索引的左侧所有元素相加的和等于右侧所有元素相加的和。
         *
         * 如果数组不存在中心索引，那么我们应该返回 -1。如果数组有多个中心索引，那么我们应该返回最靠近左边的那一个。
         *
         */

        [Theory]
        [Q0724TestData]
        public void Test(int[] input, int output)
        {
            Assert.Equal(output, PivotIndex(input));
        }

        public int PivotIndex(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = 0;
                for (int j = 0; j < i; j++)
                {
                    temp += nums[j];
                }

                for (int j = i+1; j < nums.Length; j++)
                {
                    temp -= nums[j];
                }

                if (temp == 0)
                {
                    return i;
                }
            }

            return -1;
        }

    }

    public class Q0724TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 7, 3, 6, 5, 6 }, 3 };
            yield return new object[] { new object[] { 1, 2, 3 }, -1 };
        }
    }
}

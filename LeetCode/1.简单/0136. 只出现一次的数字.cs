using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;


namespace LeetCode
{
    public class Question0136
    {
        /*
         * 给定一个非空整数数组，除了某个元素只出现一次以外，其余每个元素均出现两次。找出那个只出现了一次的元素。
         *
         * 说明：
         *
         * 你的算法应该具有线性时间复杂度。 你可以不使用额外空间来实现吗？
         *
         */

        [Theory]
        [Q0136TestData]
        public void Test(int[] input, int output)
        {
            Assert.Equal(output, SingleNumber(input));
        }

        public int SingleNumber(int[] nums)
        {
            int res = 0;
            foreach (var item in nums)
            {
                res ^= item;
            }
            return res;
        }

    }

    public class Q0136TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] {2, 2, 1 }, 1 };
            yield return new object[] { new object[] { 4, 1, 2, 1, 2 }, 4 };
        }
    }
}

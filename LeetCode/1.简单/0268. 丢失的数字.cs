using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0268
    {
        /*
         * 给定一个包含 [0, n] 中 n 个数的数组 nums ，找出 [0, n] 这个范围内没有出现在数组中的那个数。
         */

        [Theory]
        [Q0268TestData]
        public void Test(int[] input, int output)
        {
            Assert.Equal(output, MissingNumberPlus(input));
        }

        public int MissingNumber(int[] nums)
        {
            int size = nums.Length;
            int Res = 0;

            for (int i = 0; i <= size; i++)
            {
                Res ^= i;
            }

            return nums.Aggregate(Res, (current, num) => current ^ num);
        }

        public int MissingNumberPlus(int[] nums)
        {
            int size = nums.Length;
            var Res = 0;

            for (int i = 0; i < size; i++)
            {
                Res ^= i ^ nums[i];
            }

            Res ^= size;

            return Res;
        }

    }

    public class Q0268TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 3, 0, 1 }, 2 };
            yield return new object[] { new object[] { 0, 1 }, 2 };
            yield return new object[] { new object[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8 };
            yield return new object[] { new object[] { 0 }, 1 };
        }
    }
}

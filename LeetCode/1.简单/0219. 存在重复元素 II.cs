using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0219
    {
        /*
         * 给你一个整数数组 nums 和一个整数 k ，判断数组中是否存在两个 不同的索引 i 和 j ，满足 nums[i] == nums[j] 且 abs(i - j) <= k 。如果存在，返回 true ；否则，返回 false 。
         */

        [Theory]
        [Q0219TestData]
        public void Test(int[] input1,int input2, bool output)
        {
            Assert.Equal(output, ContainsNearbyDuplicate(input1,input2));
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            for (int i = 0; i < nums.Length; i++)
                for( int j = i + 1;j<nums.Length && j <= i + k ; j++)
                    if(nums[i] == nums[j])
                        return true;
            return false;
        }


    }

    public class Q0219TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 2, 3, 1 }, 3 , true };
            yield return new object[] { new object[] { 1, 0, 1, 1 }, 1, true };
            yield return new object[] { new object[] { 1, 2, 3, 1, 2, 3 }, 2, false };
        }
    }
}

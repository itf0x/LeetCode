using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;
using System;
using System.Collections;


namespace LeetCode
{
    public class Question0136
    {
        /*
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

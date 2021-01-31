using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1486
    {
        /*
         * 给你两个整数，n 和 start 。
         * 
         * 数组 nums 定义为：nums[i] = start + 2*i（下标从 0 开始）且 n == nums.length 。
         * 
         * 请返回 nums 中所有元素按位异或（XOR）后得到的结果。
         * 
         */

        [Theory]
        [InlineData(5, 0, 8)]
        [InlineData(4, 3, 8)]
        [InlineData(1, 7, 7)]
        [InlineData(10, 5, 2)]
        public void Test(int input1, int input2, int output)
        {
            Assert.Equal(output, XorOperation(input1, input2));
        }

        public int XorOperation(int n, int start)
        {
            int res = start;
            for (int i = 1; i < n; i++)
            {
                res = res ^ (start + 2 * i);
            }
            return res;
        }

    }
}

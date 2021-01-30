using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1281
    {
        /*
         * 给你一个整数 n，请你帮忙计算并返回该整数「各位数字之积」与「各位数字之和」的差。
         */

        [Theory]
        [InlineData(234, 15)]
        [InlineData(4421, 21)]
        public void Test(int input, int output)
        {
            Assert.Equal(output, SubtractProductAndSum(input));
        }

        public int SubtractProductAndSum(int n)
        {
            int add = 0;
            int pro = 1;
            while (n != 0)
            {
                int temp = n % 10;
                n /= 10;
                add += temp;
                pro *= temp;
            }

            return pro - add;
        }

    }
}

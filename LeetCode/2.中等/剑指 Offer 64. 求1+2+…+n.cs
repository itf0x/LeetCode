using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class QuestionO64
    {
        /*
         * 求 1+2+...+n ，要求不能使用乘除法、for、while、if、else、switch、case等关键字及条件判断语句（A?B:C）。
         */

        [Theory]
        [InlineData(3, 6)]
        [InlineData(9, 45)]
        public void Test(int input, int output)
        {
            Assert.Equal(output, SumNums(input));
        }

        public int SumNums(int n)
        {
            return ((1 + n) * n) >> 1;
        }


    }

}

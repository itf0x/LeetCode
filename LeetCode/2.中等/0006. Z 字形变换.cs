using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0006
    {
        /*
         * 将一个给定字符串 s 根据给定的行数 numRows ，以从上往下、从左到右进行 Z 字形排列。
         *
         * 比如输入字符串为 "PAYPALISHIRING" 行数为 3 时，排列如下：
         *
         * P   A   H   N
         * A P L S I I G
         * Y   I   R
         *
         * 之后，你的输出需要从左往右逐行读取，产生出一个新的字符串，比如："PAHNAPLSIIGYIR"。
         *
         * 请你实现这个将字符串进行指定行数变换的函数：
         *
         */

        [Theory]
        [Q0006TestData]
        public void Test(string input1, int input2, string output)
        {
            Assert.Equal(output, Convert(input1, input2));
        }

        public string Convert(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            string[] temp = new string[numRows];
            int count = 0;
            int step = -1;

            foreach (char c in s)
            {
                if (count == 0 || count == numRows - 1)
                {
                    step *= -1;
                }

                temp[count] += c;
                count += step;
            }

            return temp.Aggregate<string, string>(null, (current, s1) => current + s1);
        }

    }

    public class Q0006TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "PAYPALISHIRING", 3, "PAHNAPLSIIGYIR" };
            yield return new object[] { "PAYPALISHIRING", 4, "PINALSIGYAHRPI" };
            yield return new object[] { "A", 1, "A" };
            yield return new object[] { "AB", 1, "AB" };
        }
    }
}

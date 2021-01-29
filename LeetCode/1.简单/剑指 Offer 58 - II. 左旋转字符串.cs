using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class QuestionO58_2
    {
        /*
         * 字符串的左旋转操作是把字符串前面的若干个字符转移到字符串的尾部。请定义一个函数实现字符串左旋转操作的功能。比如，输入字符串"abcdefg"和数字2，该函数将返回左旋转两位得到的结果"cdefgab"。
         */

        [Theory]
        [QO58_2TestData]
        public void Test(string input1, int input2, string output)
        {
            Assert.Equal(output, ReverseLeftWords(input1, input2));
        }

        public string ReverseLeftWords(string s, int n)
        {
            return s.Substring(n) + s.Substring(0, n);
        }

    }

    public class QO58_2TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "abcdefg", 2, "cdefgab" };
            yield return new object[] { "lrloseumgh", 6, "umghlrlose" };
        }
    }
}

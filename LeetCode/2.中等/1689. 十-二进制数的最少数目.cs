using System.Linq;
using Xunit;

namespace LeetCode
{
    public class Question1689
    {
        /*
         * 如果一个十进制数字不含任何前导零，且每一位上的数字不是 0 就是 1 ，那么该数字就是一个 十-二进制数 。例如，101 和 1100 都是 十-二进制数，而 112 和 3001 不是。
         *
         * 给你一个表示十进制整数的字符串 n ，返回和为 n 的 十-二进制数 的最少数目。
         *
         */

        [Theory]
        [InlineData("32", 3)]
        [InlineData("82734",8)]
        [InlineData("27346209830709182346", 9)]
        public void Test(string input, int output)
        {
            Assert.Equal(output, MinPartitions(input));
        }

        public int MinPartitions(string n)
        {
            return n.Max() - '0';
        }

    }

}

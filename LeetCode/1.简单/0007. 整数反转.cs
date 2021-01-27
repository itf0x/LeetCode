using System;
using Xunit;

namespace LeetCode
{
    public class Question0007
    {
        /*
         * 给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。
         *
         * 注意：假设我们的环境只能存储得下 32 位的有符号整数，则其数值范围为 [−231,  231 − 1]。请根据这个假设，如果反转后整数溢出那么就返回 0。
         */

        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(120, 21)]
        [InlineData(0, 0)]
        [InlineData(1534236469, 0)]
        [InlineData(-2147483412, -2143847412)]
        [InlineData(-2147483648, 0)]
        public void Test(int input, int output)
        {
            Assert.Equal(output, Reverse(input));
            //Assert.Equal(output, OfficialReverse(input));
        }

        public int Reverse(int x)
        {
            bool flag = x < 0 ? true : false;

            int a = x;
            int res = 0;
            int size = 0;

            while (x != 0)
            {
                if (res > 214748364)
                    return 0;
                else if (res == 214748364)
                {
                    size = flag ? 8 : 7;
                    if (x % 10 > size)
                    {
                        return 0;
                    }
                }
                res *= 10;
                res += Math.Abs(x % 10);
                x /= 10;
            }

            if (flag && res > 0)
            {
                res *= -1;
            }

            return res;
        }

        public int OfficialReverse(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;

        }
    }
}

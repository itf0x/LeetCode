using Xunit;

namespace LeetCode
{
    public class Question0009
    {
        /*
         * 判断一个整数是否是回文数。回文数是指正序（从左向右）和倒序（从右向左）读都是一样的整数。
         */

        [Theory]
        [InlineData(121, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        public void Test(int input, bool output)
        {
            Assert.Equal(output, IsPalindrome(input));
        }

        public bool IsPalindrome(int x)
        {
            int a = x;
            if (x < 0)
                return false;
            int temp = 0;
            while (x != 0)
            {
                temp *= 10;
                temp += x % 10;
                x /= 10;
            }
            return temp == a ? true : false;

        }

    }
}



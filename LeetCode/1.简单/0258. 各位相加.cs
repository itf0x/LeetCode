using Xunit;

namespace LeetCode
{
    public class Question0258
    {
        /*
         * 给定一个非负整数 num，反复将各个位上的数字相加，直到结果为一位数。
         */

        [Theory]
        [InlineData(38, 2)]
        [InlineData(10,1)]
        public void Test(int input, int output)
        {
            Assert.Equal(output, AddDigits(input));
        }

        public int AddDigits(int num)
        {
            int temp;
            while(num >= 10)
            {
                temp = 0;
                while(num != 0)
                {
                    temp += num % 10;
                    num /= 10;
                }
                num = temp;
            }
            return num;
        }
    }
}

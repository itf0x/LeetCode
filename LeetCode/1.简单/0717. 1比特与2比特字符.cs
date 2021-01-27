using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0717
    {
        /*
         * 有两种特殊字符。第一种字符可以用一比特0来表示。第二种字符可以用两比特(10 或 11)来表示。
         * 
         * 现给一个由若干比特组成的字符串。问最后一个字符是否必定为一个一比特字符。给定的字符串总是由0结束。
         */

        [Theory]
        [Q0717TestData]
        public void Test(int[] input, bool output)
        {
            Assert.Equal(output, IsOneBitCharacter(input));
        }

        public bool IsOneBitCharacter(int[] bits)
        {
            int size = bits.Length - 1;
            for (int i = 0; i <= size; i++)
            {
                if (bits[i] == 0)
                {
                    if (i == size)
                        return true;
                    continue;
                }
                else if (bits[i] == 1)
                {
                    if (i == size - 1)
                        return false;
                    i++;
                    continue;
                }
            }
            return false;
        }


    }

    public class Q0717TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 0, 0 }, true };
            yield return new object[] { new object[] { 1, 1, 1, 0 }, false };
        }
    }
}

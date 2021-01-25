using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1005
    {
        /*
         * 给定一个整数数组 A，我们只能用以下方法修改该数组：我们选择某个索引 i 并将 A[i] 替换为 -A[i]，
         * 然后总共重复这个过程 K 次。（我们可以多次选择同一个索引 i。）
         * 以这种方式修改数组后，返回数组可能的最大和。
         */

        [Theory]
        [Q1005TestData]
        public void Test(int[] input1, int input2, int output)
        {
            Assert.Equal(output, LargestSumAfterKNegations(input1, input2));
        }

        public int LargestSumAfterKNegations(int[] A, int K)
        {
            int sum = 0;
            int Biggest = 0;
            for (int i = K; i > 0; i--)
            {
                for(int j = 0;j<A.Length;j++)
                {
                    if (A[j] < A[Biggest])
                        Biggest = j;
                }
                A[Biggest] *= -1;
            }
            foreach (int temp in A)
            {
                sum += temp;
            }
            return sum;

        }

    }

    public class Q1005TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 4, 2, 3 }, 1, 5 };
            yield return new object[] { new object[] { 3, -1, 0, 2 }, 3, 6 };
            yield return new object[] { new object[] { 2, -3, -1, 5, -4 }, 2, 13 };
        }
    }
}

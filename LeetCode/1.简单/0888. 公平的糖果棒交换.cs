using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0888
    {
        /*
         * 爱丽丝和鲍勃有不同大小的糖果棒：A[i] 是爱丽丝拥有的第 i 根糖果棒的大小，B[j] 是鲍勃拥有的第 j 根糖果棒的大小。
         * 
         * 因为他们是朋友，所以他们想交换一根糖果棒，这样交换后，他们都有相同的糖果总量。（一个人拥有的糖果总量是他们拥有的糖果棒大小的总和。）
         * 
         * 返回一个整数数组 ans，其中 ans[0] 是爱丽丝必须交换的糖果棒的大小，ans[1] 是 Bob 必须交换的糖果棒的大小。
         * 
         * 如果有多个答案，你可以返回其中任何一个。保证答案存在。
         * 
         */

        [Theory]
        [Q0888TestData]
        public void Test(int[] input1, int[] input2, int[] output)
        {
            Assert.Equal(output, FairCandySwap(input1, input2));
        }

        public int[] FairCandySwap(int[] A, int[] B)
        {
            int sumA = 0;
            int sumB = 0;
            foreach (var item in A)
            {
                sumA += item;
            }
            foreach (var item in B)
            {
                sumB += item;
            }

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (sumB - B[j] + A[i] == sumA - A[i] + B[j])
                    {
                        return new int[] { A[i], B[j] };
                    }
                }
            }
            return null;
        }

    }

    public class Q0888TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new int[] { 1, 1 }, new int[] { 2, 2 }, new int[] { 1, 2 } };
            yield return new object[] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 1, 2 } };
            yield return new object[] { new int[] { 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } };
            yield return new object[] { new int[] { 1, 2, 5 }, new int[] { 2, 4 }, new int[] { 5, 4 } };

        }
    }
}

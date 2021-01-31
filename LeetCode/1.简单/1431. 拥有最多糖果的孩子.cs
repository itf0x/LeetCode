using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question1431
    {
        /*
         * 给你一个数组 candies 和一个整数 extraCandies ，其中 candies[i] 代表第 i 个孩子拥有的糖果数目。
         * 
         * 对每一个孩子，检查是否存在一种方案，将额外的 extraCandies 个糖果分配给孩子们之后，此孩子有 最多 的糖果。注意，允许有多个孩子同时拥有 最多 的糖果数目。
         * 
         */

        [Theory]
        [Q1431TestData]
        public void Test(int[] input1,int input2, IList<bool> output)
        {
            Assert.Equal(output, KidsWithCandies(input1,input2));
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            IList<bool> res = new List<bool>();

            int max = 0;

            foreach (var candie in candies)
            {
                max = max > candie ? max : candie;
            }

            foreach (var candie in candies)
            {
                if (candie + extraCandies >= max)
                {
                    res.Add(true);
                }
                else
                {
                    res.Add(false);
                }
            }

            return res;
        }

    }

    public class Q1431TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 2, 3, 5, 1, 3 }, 3, new List<bool>() { true, true, true, false, true } };
            yield return new object[] { new object[] { 12, 1, 12 }, 10, new List<bool>() { true, false, true } };
            yield return new object[] { new object[] { 4, 2, 1, 1, 2 }, 1, new List<bool>() { true, false, false, false, false } };
        }
    }
}

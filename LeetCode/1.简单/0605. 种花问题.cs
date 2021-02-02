using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0605
    {
        /*
         * 假设有一个很长的花坛，一部分地块种植了花，另一部分却没有。可是，花不能种植在相邻的地块上，它们会争夺水源，两者都会死去。
         * 
         * 给你一个整数数组  flowerbed 表示花坛，由若干 0 和 1 组成，其中 0 表示没种植花，1 表示种植了花。另有一个数 n ，能否在不打破种植规则的情况下种入 n 朵花？能则返回 true ，不能则返回 false。
         * 
         */

        [Theory]
        [QT0605estData]
        public void Test(int[] input1, int input2, bool output)
        {
            Assert.Equal(output, CanPlaceFlowers(input1, input2));
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            for (int i = 0; i < flowerbed.Length; i++)
            {
                bool leftFlag = true, rightFlag = true;
                if (i != 0 && flowerbed[i - 1] != 0)
                {
                    leftFlag = false;
                }

                if (i != flowerbed.Length - 1 && flowerbed[i + 1] != 0)
                {
                    rightFlag = false;
                }

                if (flowerbed[i] == 0 && leftFlag && rightFlag)
                {
                    if (n == 0)
                    {
                        break;
                    }
                    flowerbed[i]++;
                    n--;
                }
            }

            return n == 0;
        }

    }

    public class QT0605estData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 0, 0, 0, 1 }, 1, true };
            yield return new object[] { new object[] { 1, 0, 0, 0, 1 }, 2, false };
            yield return new object[] { new object[] { 1, 0, 0, 0, 0, 1 }, 2, false };
            yield return new object[] { new object[] { 1, 0, 1, 0, 1, 0, 1 }, 1, false };
            yield return new object[] { new object[] { 0, 0, 1, 0, 1 }, 1, true };
            yield return new object[] { new object[] { 1, 0, 1, 0, 0 }, 1, true };
            yield return new object[] { new object[] { 0 }, 1, true };
            yield return new object[] { new object[] { 1 }, 0, true };
            yield return new object[] { new object[] { 0, 0, 1, 0, 0 }, 1, true };

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0480
    {
        /*
         * 中位数是有序序列最中间的那个数。如果序列的大小是偶数，则没有最中间的数；此时中位数是最中间的两个数的平均数。
         *
         * 例如：
         *
         * [2,3,4]，中位数是 3
         * [2,3]，中位数是 (2 + 3) / 2 = 2.5
         *
         * 给你一个数组 nums，有一个大小为 k 的窗口从最左端滑动到最右端。窗口中有 k 个数，每次窗口向右移动 1 位。你的任务是找出每次窗口移动后得到的新窗口中元素的中位数，并输出由它们组成的数组。
         *
         */

        [Theory]
        [Q0480TestData]
        public void Test(int[] input1, int input2, double[] output)
        {
            Assert.Equal(output, MedianSlidingWindow(input1, input2));
        }

        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            double[] res = new double[nums.Length - k + 1];
            int[] window = new int[k];

            for (int i = 0; i < k; i++)
            {
                window[i] = nums[i];
            }

            Array.Sort(window);

            for (int i = k; i <= nums.Length; i++)
            {
                if (k % 2 == 0)
                {
                    res[i - k] = ((double)window[k / 2] + (double)window[k / 2 - 1]) / 2;
                }
                else
                {
                    res[i - k] = window[k / 2];
                }

                if (i == nums.Length)
                    break;

                for (int j = 0; j < k - 1; j++)
                {
                    if (window[j] != nums[i - k]) continue;

                    for (int l = j; l < k - 1; l++)
                    {
                        window[l] = window[l + 1];
                    }

                    break;
                }
                int temp = nums[i];
                int count = k - 2;
                for (; count >= 0; count--)
                {
                    if (window[count] > temp)
                    {
                        window[count + 1] = window[count];
                        continue;
                    }
                    break;
                }
                window[count + 1] = temp;

            }

            return res;
        }

    }


    public class Q0480TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3, new double[] { 1, -1, -1, 3, 5, 6 } };
            yield return new object[] { new int[] { 1, 4, 2, 3 }, 4, new double[] { 2.5 } };
            yield return new object[] { new int[] { 2147483647, 2147483647 }, 2, new double[] { 2147483647.0 } };
            yield return new object[] { new int[] { 4, 1, 7, 1, 8, 7, 8, 7, 7, 4 }, 4, new double[] { 2.5, 4.0, 7.0, 7.5, 7.5, 7.0, 7.0 } };
        }
    }
}

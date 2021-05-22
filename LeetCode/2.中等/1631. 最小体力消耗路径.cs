//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using Xunit;
//using Xunit.Sdk;

//namespace LeetCode
//{
//    public class Question1631
//    {
//        /*
//         * 你准备参加一场远足活动。给你一个二维 rows x columns 的地图 heights ，其中 heights[row][col] 表示格子 (row, col) 的高度。一开始你在最左上角的格子 (0, 0) ，且你希望去最右下角的格子 (rows-1, columns-1) （注意下标从 0 开始编号）。你每次可以往 上，下，左，右 四个方向之一移动，你想要找到耗费 体力 最小的一条路径。
//         *
//         * 一条路径耗费的 体力值 是路径上相邻格子之间 高度差绝对值 的 最大值 决定的。
//         *
//         * 请你返回从左上角走到右下角的最小 体力消耗值 。
//         *
//         */

//        [Theory]
//        [Q1631TestData]
//        public void Test(int[][] input, int output)
//        {
//            Assert.Equal(output, MinimumEffortPath(input));
//        }

//        public int MinimumEffortPath(int[][] heights)
//        {
//            return (int)Find(heights,0, 0);
//        }

//        public int? Find(int[][] heights, int x, int y)
//        {
//            int i = x, j = y;
//            int? res = 0;
//            while (i != heights.Length && i != heights[0].Length)
//            {
//                int? left = j < heights[0].Length - 1 ? heights[i][j + 1] - heights[i][j] : null;
//                int? right = j != 0 ? heights[i][j - 1] - heights[i][j] : null;
//                int? up = i != 0 ? heights[i - 1][j] - heights[i][j] : null;
//                int? down = i < heights.Length - 1 ? heights[i + 1][j] - heights[i][j] : null;

//                heights[i][j] = Int32.MaxValue;

//                while (true)
//                {
//                    if (left > right && left > up && left > down)
//                    {
//                        res = res > left ? res : left;
//                        j++;
//                        if(res > Find(heights, i, j))
//                    }
//                    else if (right > up && right > down)
//                    {
//                        res = res > right ? res : right;
//                        j--;
//                        Find(heights, i, j);
//                    }
//                    else if (up > down)
//                    {
//                        res = res > up ? res : up;
//                        i--;
//                        Find(heights, i, j);
//                    }
//                    else
//                    {
//                        res = res > down ? res : down;
//                        i++;
//                        Find(heights, i, j);
//                    }
//                }

                

//            }

//            return (int)res;

//        }

//    }

//    public class Q1631TestData : DataAttribute
//    {
//        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
//        {
//            yield return new object[] { new int[][] { new int[] { 1, 2, 2 }, new int[] { 3, 8, 2 }, new int[] { 5, 3, 5 } }, 2 };
//            yield return new object[] { new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 8, 4 }, new int[] { 5, 3, 5 } }, 1 };
//            yield return new object[] { new int[][] { new int[] { 1, 2, 1, 1, 1 }, new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 2, 1, 2, 1 }, new int[] { 1, 1, 1, 2, 1 } }, 0 };
//        }
//    }
//}

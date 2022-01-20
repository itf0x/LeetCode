using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question2029
    {
        /*
         * Alice 和 Bob 再次设计了一款新的石子游戏。现有一行 n 个石子，每个石子都有一个关联的数字表示它的价值。给你一个整数数组 stones ，其中 stones[i] 是第 i 个石子的价值。
         * 
         * Alice 和 Bob 轮流进行自己的回合，Alice 先手。每一回合，玩家需要从 stones 中移除任一石子。
         * 
         * 如果玩家移除石子后，导致 所有已移除石子 的价值 总和 可以被 3 整除，那么该玩家就 输掉游戏 。
         * 
         * 如果不满足上一条，且移除后没有任何剩余的石子，那么 Bob 将会直接获胜（即便是在 Alice 的回合）。
         * 
         * 假设两位玩家均采用 最佳 决策。如果 Alice 获胜，返回 true ；如果 Bob 获胜，返回 false 。
         * 
         */

        [Theory]
        [Q2029TestData]
        public void Test(int[] input, bool output)
        {
            Assert.Equal(output, StoneGameIX(input));
        }

        public bool StoneGameIX(int[] stones)
        {
            int[] num = { 0, 0, 0 };
            for (int i = 0; i < stones.Length; i++)
            {
                //将石头转换为0，1，2三种类型
                num[stones[i] % 3] += 1;
            }
            if (num[0] % 2 == 0)
            {
                return num[1] >= 1 && num[2] >= 1;
            }
            return num[1] - num[2] > 2 || num[2] - num[1] > 2;
        }

    }

    public class Q2029TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 2, 1 }, true };
            yield return new object[] { new object[] { 2 }, false };
            yield return new object[] { new object[] { 5, 1, 2, 4, 3 }, false };
        }
    }
}

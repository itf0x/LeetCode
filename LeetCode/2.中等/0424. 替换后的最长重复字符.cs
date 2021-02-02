using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0424
    {
        /*
         * 
         */

        [Theory]
        [InlineData("ABAB", 2, 4)]
        [InlineData("AABABBA", 1, 4)]
        [InlineData("ABBB", 2, 4)]
        [InlineData("BAAAB", 2, 5)]
        public void Test(string input1, int input2, int output)
        {
            Assert.Equal(output, CharacterReplacement(input1, input2));
        }

        public int CharacterReplacement(string s, int k)
        {
            int[] nums = new int[26];
            int left = 0;
            int right = 0;
            int count = k;
            int maxn = 0;

            while (right < s.Length)
            {
                nums[s[right] - 'A']++;
                maxn = maxn > nums[s[right] - 'A'] ? maxn : nums[s[right] - 'A'];
                if (right - left + 1 - maxn > k)
                {
                    nums[s[left] - 'A']--;
                    left++;
                }

                right++;
            }

            return right-left;
        }
    }

    public class QNTestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 0, 0 }, true };
        }
    }
}

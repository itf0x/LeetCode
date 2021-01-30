using Xunit;

namespace LeetCode
{
    public class Question0771
    {
        /*
         * 给定字符串J 代表石头中宝石的类型，和字符串 S代表你拥有的石头。 S 中每个字符代表了一种你拥有的石头的类型，你想知道你拥有的石头中有多少是宝石。
         *
         * J 中的字母不重复，J 和 S中的所有字符都是字母。字母区分大小写，因此"a"和"A"是不同类型的石头。
         *
         */

        [Theory]
        [InlineData("aA", "aAAbbbb", 3)]
        [InlineData("z", "ZZ", 0)]
        public void Test(string input1, string input2, int output)
        {
            Assert.Equal(output, NumJewelsInStones(input1,input2));
        }

        public int NumJewelsInStones(string jewels, string stones)
        {
            int res = 0;
            foreach (char stone in stones)
            {
                if (jewels.Contains(stone))
                {
                    res += 1;
                }
            }

            return res;
        }

    }
}

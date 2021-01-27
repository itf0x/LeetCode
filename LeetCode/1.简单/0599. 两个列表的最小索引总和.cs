using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0599
    {
        /*
         * 假设Andy和Doris想在晚餐时选择一家餐厅，并且他们都有一个表示最喜爱餐厅的列表，每个餐厅的名字用字符串表示。
         *
         * 你需要帮助他们用最少的索引和找出他们共同喜爱的餐厅。 如果答案不止一个，则输出所有答案并且不考虑顺序。 你可以假设总是存在一个答案。
         *
         */

        [Theory]
        [Q0599TestData]
        public void Test(string[] input1, string[] input2, string[] output)
        {
            Assert.Equal(output, FindRestaurant(input1, input2));
        }

        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            string[] list = null;
            int indexSum = list1.Length + list2.Length;
            for (int i = 0; i < list1.Length; i++)
            {
                int temp = Array.IndexOf(list2, list1[i]);
                if (temp != -1 && temp + i == indexSum)
                {
                    Array.Resize(ref list, list.Length + 1);
                    list[list.Length - 1] = list1[i];
                }
                if (temp != -1 && temp + i < indexSum)
                {
                    indexSum = temp + i;
                    list = new string[1];
                    list[0] = list1[i];
                }
            }

            return list;
        }

    }

    public class Q0599TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new object[] { "Piatti", "The Grill at Torrey Pines", "Hungry Hunter Steakhouse", "Shogun" }, new object[] { "Shogun" } };
            yield return new object[] { new object[] { "Shogun", "Tapioca Express", "Burger King", "KFC" }, new object[] { "KFC", "Shogun", "Burger King" }, new object[] { "Shogun" } };
        }
    }
}

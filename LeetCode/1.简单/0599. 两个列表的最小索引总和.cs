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

using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Question0002
    {
        /*
         * 给你两个 非空 的链表，表示两个非负的整数。它们每位数字都是按照 逆序 的方式存储的，并且每个节点只能存储 一位 数字。
         *
         * 请你将两个数相加，并以相同形式返回一个表示和的链表。
         *
         * 你可以假设除了数字 0 之外，这两个数都不会以 0 开头。
         *
         */

        [Theory]
        [InlineData(1,1)]
        public void Test(int input, int output)
        {
            Assert.Equal(output, input);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode res = new ListNode();
            ListNode temp = res;
            bool flag = false;

            while (true)
            {
                if (l1 == null && l2 == null)
                {
                    break;
                }

                temp.next = new ListNode();
                temp = temp.next;

                temp.val = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + (flag ? 1 : 0);
                flag = false;
                if (temp.val >= 10)
                {
                    temp.val -= 10;
                    flag = true;
                }

                l1 = l1 == null ? null : l1.next;
                l2 = l2 == null ? null : l2.next;

            }

            if (flag)
            {
                temp.next = new ListNode();
                temp = temp.next;
                temp.val = 1;
            }

            return res.next;
        }
    }

    public class Q0002TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new object[] { 1, 0, 0 }, true };
        }
    }
}

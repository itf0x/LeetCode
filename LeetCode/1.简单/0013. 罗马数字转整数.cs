using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0013
    {
        /*
         * 给定一个罗马数字，将其转换成整数。输入确保在 1 到 3999 的范围内。
         */

        [Theory]
        [Q0013TestData]
        public void Test(string input, int output)
        {
            Assert.Equal(output, RomanToInt(input));
        }

        public int RomanToInt(string s)
        {
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool flag = i != s.Length - 1;
                switch (s[i])
                {
                    case 'I' when flag && s[i + 1] == 'V':
                        i++;
                        res += 4;
                        break;
                    case 'I' when flag && s[i + 1] == 'X':
                        i++;
                        res += 9;
                        break;
                    case 'I':
                        res += 1;
                        break;
                    case 'V':
                        res += 5;
                        break;
                    case 'X' when flag && s[i + 1] == 'L':
                        i++;
                        res += 40;
                        break;
                    case 'X' when flag && s[i + 1] == 'C':
                        i++;
                        res += 90;
                        break;
                    case 'X':
                        res += 10;
                        break;
                    case 'L':
                        res += 50;
                        break;
                    case 'C' when flag && s[i + 1] == 'D':
                        i++;
                        res += 400;
                        break;
                    case 'C' when flag && s[i + 1] == 'M':
                        i++;
                        res += 900;
                        break;
                    case 'C':
                        res += 100;
                        break;
                    case 'D':
                        res += 500;
                        break;
                    case 'M':
                        res += 1000;
                        break;
                }
            }

            return res;

        }

    }

    public class Q0013TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { "III", 3 };
            yield return new object[] { "IV", 4 };
            yield return new object[] { "IX", 9 };
            yield return new object[] { "LVIII", 58 };
            yield return new object[] { "MCMXCIV", 1994 };

        }
    }
}

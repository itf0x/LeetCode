using System;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace LeetCode
{
    public class Question0539
    {
        /*
         * 给定一个 24 小时制（小时:分钟 "HH:MM"）的时间列表，找出列表中任意两个时间的最小时间差并以分钟数表示。
         */

        [Theory]
        [Q0539TestData]
        public void Test(IList<string> input, int output)
        {
            Assert.Equal(output, FindMinDifference(input));
        }

        public int FindMinDifference(IList<string> timePoints)
        {
            if (timePoints.Count > 1440)
                return 0;//鸽巢原理

            int min = 99999999;
            for(int i = 0; i < timePoints.Count; i++)
            {
                string[] time1 = timePoints[i].Split(':');
                for (int j = i + 1; j < timePoints.Count; j++)
                {
                    string[] time2 = timePoints[j].Split(':');
                    int hour1 = int.Parse(time1[0]);
                    int hour2 = int.Parse(time2[0]);
                    int minutes1= int.Parse(time1[1]);
                    int minutes2 = int.Parse(time2[1]);
                    for (int k = 0; k < 2; k++)
                    {
                        if (hour1 < hour2 ||( hour1==hour2 && minutes1 < minutes2))
                        {
                            int temp = hour1;
                            hour1 = hour2;
                            hour2 = temp;
                            temp = minutes1;
                            minutes1 = minutes2;
                            minutes2 = temp;
                        }

                        //计算时间差
                        if (minutes1 < minutes2)
                        {
                            hour1 -= 1;
                            minutes1 += 60;
                        }
                        int minutes = minutes1 - minutes2;
                        minutes += (hour1 - hour2) * 60;
                        if (min > minutes)
                        {
                            min = minutes;
                        }

                        if (k == 0)
                        {
                            hour2 += 24;
                        }
                        else
                            break;
                    }
                }
            }

            return min;
        }

    }

    public class Q0539TestData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            yield return new object[] { new List<string>() { "23:59", "00:00" }, 1 };
            yield return new object[] { new List<string>() { "00:00", "23:59", "00:00" }, 0 };
        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using Xunit;
//using Xunit.Sdk;

//namespace LeetCode
//{
//    public class QuestionN
//    {
//        /*
//         * 
//         */

//        [Theory]
//        [InlineData(1, 2)]
//        public void Test(int input, int output)
//        {
//            Assert.Equal(output, input);
//        }


//    }

//    public class QNTestData : DataAttribute
//    {
//        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
//        {
//            yield return new object[] { new object[] { 1, 0, 0 }, true };
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExample1;

namespace TestExample.Test
{
    public class MathTest
    {
        [Fact]
        public void SubTest()
        {
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
            Mathematics_arithmetics mathematics = new Mathematics_arithmetics();

            int result = Mathematics_arithmetics.Subtract(number1, number2);

            Assert.Equal(expected, result);

        }

        public static IEnumerable<object[]> sumDatas => new List<object[]> {
            new object[]{ 3, 5, 8 },
            new object[]{ 11, 5, 16 },
            new object[]{ 23, 2, 25 },
            new object[]{ 33, 44, 87 }
        };

        [Theory]
        [MemberData(nameof(sumDatas))]
        public void SumTest(int number1, int number2, int expected)
        {
            Mathematics_arithmetics mathematics = new Mathematics_arithmetics();

            int result = Mathematics_arithmetics.Sum(number1, number2);
           
            Assert.Equal(expected, result);
          
        }
    }
}

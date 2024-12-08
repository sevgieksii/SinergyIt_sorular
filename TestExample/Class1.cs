using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestExample1;

namespace TestExample.Test
{
    public class TypeSafeData : TheoryData<int, int, int>
    {
        public TypeSafeData()
        {
            Add(3, 5, 8);
            Add(11, 5, 16);
            Add(23, 2, 25);
            Add(33, 44, 87);
        }
    }
    public class MathematicsTest
    {
        public Mathematics_arithmetics _mathematics;
        public MathematicsTest()
        {
            _mathematics = new();
        }
        [Theory]
        [ClassData(typeof(TypeSafeData))]
        public void SumTest(int number1, int number2, int expected)
        {
   
            int result = Mathematics_arithmetics.Sum(number1, number2);
            
            Assert.Equal(expected, result);
           
        }
        [Fact]
        public void SubtractTest()
        {
            
            int number1 = 10;
            int number2 = 20;
            int expected = -10;
           
            int result = Mathematics_arithmetics.Subtract(number1, number2);
           
            Assert.Equal(expected, result);

        }
        [Theory, InlineData(3, 5)]
        public void MultiplyTest(int number1, int number2)
        {
            int result = Mathematics_arithmetics.Multiply(number1, number2);
           
            Assert.Equal(15, result);
            
        }
        [Theory, InlineData(30, 5, 6)]
        public void DivideTest(int number1, int number2, int expected)
        {
           
            int result = Mathematics_arithmetics.Divide(number1, number2);
           
            Assert.Equal(expected, result);
            
        }
    }
}

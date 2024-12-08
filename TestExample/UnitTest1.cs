using Moq;
using TestExample1;

namespace TestExample.Test
{
    public class UnitTest1
    {
        public interface IMathematics
        {
            int Sum(int a, int b);
        }

        [Fact]
        public void SumTestnew()
        {
            var mathematics = new Mock<IMathematics>();
            mathematics.Setup(m => m.Sum(1, 2)) .Returns(3);
            int result = mathematics.Object.Sum(1, 2);
            Assert.Equal(3, result);
        }
    }
}
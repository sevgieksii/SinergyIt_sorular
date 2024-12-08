using System;

namespace TestExample1
{
    public interface IMathematics
    {
        int Sum(int number1, int number2);
    }
    public class Mathematics : IMathematics
    {
        public int Sum(int number1, int number2)
        {
            Thread.Sleep(5000);
            return number1 + number2;
        }

    }


}

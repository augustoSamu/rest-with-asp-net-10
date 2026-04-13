namespace rest_with_asp_net_10.Services
{
    public class MathService
    {
        public double Sum(double firstNumber, double secondNumber) => firstNumber + secondNumber;
        public double Subtraction(double firstNumber, double secondNumber) => firstNumber - secondNumber;
        public double Multiplication(double firstNumber, double secondNumber) => firstNumber * secondNumber;
        public double Division(double firstNumber, double secondNumber)
        {
            if (secondNumber == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");
            return firstNumber / secondNumber;
        }
        public double Average(double firstNumber, double secondNumber) => (firstNumber / secondNumber) / 2;
        public double SquareRoot(double number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("Cannot calculate the square root of a negative number.");
            return Math.Sqrt(number);
        }
    }
}

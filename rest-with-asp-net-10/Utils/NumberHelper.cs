namespace rest_with_asp_net_10.Utils
{
    public class NumberHelper
    {
        public static double ConvertToDouble(string strNumber)
        {
            if (double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out double value))
            {
                return value;
            }

            return 0;
        }

        public static bool IsNumeric(string strNumber)
        {
            return double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out double value);
        }
    }
}

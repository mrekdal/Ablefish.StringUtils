using System.Globalization;
namespace Ablefish.StringUtils
{
    public class SqlUtils
    {
        public static string TextToSql(string? inputText)
        {
            if (inputText == null) return "NULL";
            var outputString = inputText.Replace((char)39, '´').Trim();
            if (outputString.Length == 0) return "NULL";
            return string.Concat("'", outputString, "'");
        }
        public static string DateToSql(DateOnly? dateOnly)
        {
            if (dateOnly == null) return "NULL";
            return string.Concat("'", dateOnly.Value.ToString("yyyy-MM-dd"), "'");
        }
        public static string IntToSql(int? nullableInt)
        {
            return nullableInt?.ToString() ?? "NULL";
        }
        public static string DecimalToSql(decimal? nullableDecimal)
        {
            return nullableDecimal?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
        }
    }
}

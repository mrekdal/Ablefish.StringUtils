using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Ablefish.StringUtils
{
    public class SqlUtils
    {
        public static string TextToSql(string? inputText)
        {
            if (inputText == null) return "NULL";
            // Remove leading and trailing quotes (both single and double)
            var trimmed = inputText.Trim('\'', '"');
            if (trimmed.Length == 0) return "NULL";
            // Escape single quotes by doubling them
            var escapedText = trimmed.Replace("'", "''");
            // Wrap in single quotes
            return $"'{escapedText}'";
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
        public static string IntToSql(string? nullableInt)
        {
            if (string.IsNullOrEmpty(nullableInt))
                return "NULL";
            else
                return nullableInt;
        }
        public static string DecimalToSql(decimal? nullableDecimal)
        {
            return nullableDecimal?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
        }
        public static string FloatToSql(float? nullableFloat)
        {
            return nullableFloat?.ToString(CultureInfo.InvariantCulture) ?? "NULL";
        }
        public static string ComputeHash(int sourceId, string uncleanedDrugName)
        {
            string rawData = $"{sourceId}{uncleanedDrugName}";
            byte[] bytes = MD5.HashData(Encoding.Unicode.GetBytes(rawData));
            // Convert byte array to hex string
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }

    }
}
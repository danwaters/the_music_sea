using System.Runtime.CompilerServices;

namespace TheMusicSea.Helpers
{
    public static class ExtensionMethods
    {
        public static string ToMySqlDatetime(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string ToMySqlDatetime(this DateTime? dt)
        {
            if (dt.HasValue)
                return dt.Value.ToMySqlDatetime();
            else
                return "";
        }
    }
}

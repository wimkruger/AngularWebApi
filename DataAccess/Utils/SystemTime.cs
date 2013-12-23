using System;
namespace DataAccess.Utils
{
    public class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;
    }
}

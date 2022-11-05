using System.ComponentModel;
using System.Reflection;

namespace GrafanaJsonWebApiCardanoPool.Helpers
{
    public static class EnumHelper
    {
        public static string Description<TEnum>(this TEnum value)
            where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Type must be Enum");

            var description = typeof(TEnum).GetMember(value.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>();
            return description != null ? description.Description : string.Empty;
        }
    }
}

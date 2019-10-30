using System.Globalization;

namespace Common.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo cultureInfo);
    }
}

using Common.Localization;
using System;
using System.Globalization;
using System.Threading;

namespace DevAssessment.Droid.Localization
{
    public class Localize : ILocalize
    {
        public void SetLocale(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine("CurrentCulture set: " + ci.Name);
        }

        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "en";
            var androidLocale = Java.Util.Locale.Default;
            netLanguage = AndroidToDotnetLanguage(androidLocale.ToString().Replace("_", "-"));

            CultureInfo ci = null;
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch (CultureNotFoundException e1)
            {
                try
                {
                    var fallback = ToDotnetFallbackLanguage(new PlatformCulture(netLanguage));
                    Console.WriteLine(netLanguage + " failed, trying " + fallback + " (" + e1.Message + ")");
                    ci = new CultureInfo(fallback);
                }
                catch (CultureNotFoundException e2)
                {
                    Console.WriteLine(netLanguage + " couldn't be set, using 'en' (" + e2.Message + ")");
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        private string AndroidToDotnetLanguage(string androidLanguage)
        {
            Console.WriteLine("Android Language:" + androidLanguage);
            var netLanguage = androidLanguage;

            switch (androidLanguage)
            {
                case "in-ID":
                    netLanguage = "id-ID";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }

            Console.WriteLine(".NET Language/Locale:" + netLanguage);
            return netLanguage;
        }

        private string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            Console.WriteLine(".NET Fallback Language:" + platCulture.LanguageCode);
            var netLanguage = platCulture.LanguageCode;

            switch (platCulture.LanguageCode)
            {
                case "gsw":
                    netLanguage = "de-CH";
                    break;
            }

            Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return netLanguage;
        }
    }
}
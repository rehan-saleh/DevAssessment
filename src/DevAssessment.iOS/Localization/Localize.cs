using Common.Localization;
using Foundation;
using System;
using System.Globalization;
using System.Threading;

namespace DevAssessment.iOS.Localization
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
            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];

                netLanguage = iOSToDotnetLanguage(pref);
            }

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
                    // iOS language not valid .NET culture, falling back to English
                    Console.WriteLine(netLanguage + " couldn't be set, using 'en' (" + e2.Message + ")");
                    ci = new CultureInfo("en");
                }
            }

            return ci;
        }

        string iOSToDotnetLanguage(string iOSLanguage)
        {
            Console.WriteLine("iOS Language:" + iOSLanguage);
            string netLanguage = iOSLanguage.Replace("_", "-");

            switch (iOSLanguage)
            {
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }

            Console.WriteLine(".NET Language/Locale:" + netLanguage);
            return netLanguage;
        }

        string ToDotnetFallbackLanguage(PlatformCulture platCulture)
        {
            Console.WriteLine(".NET Fallback Language:" + platCulture.LanguageCode);
            var netLanguage = platCulture.LanguageCode;

            switch (platCulture.LanguageCode)
            {
                case "pt":
                    netLanguage = "pt-PT"; 
                    break;
                case "gsw":
                    netLanguage = "de-CH"; 
                    break;
            }

            Console.WriteLine(".NET Fallback Language/Locale:" + netLanguage + " (application-specific)");
            return netLanguage;
        }
    }
}
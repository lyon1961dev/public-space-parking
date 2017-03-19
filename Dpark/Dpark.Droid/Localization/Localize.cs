using Xamarin.Forms;
using Dpark.Localization;
using Dpark.Droid.Localization;
using System.Globalization;

[assembly: Dependency(typeof(Localize))]

namespace Dpark.Droid.Localization
{
    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-"); // turns pt_BR into pt-BR
            return new CultureInfo(netLanguage);
        }
    }
}
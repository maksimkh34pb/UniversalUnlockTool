using System.Globalization;
using System.Windows;

namespace UniversalUnlockTool.WPF.WindowUI.LocalModels
{
    internal class LanguageSystem
    {
        private static readonly List<CultureInfo> _Languages = new();


        public static List<CultureInfo> Languages
        {
            get
            {
                return _Languages;
            }
        }

        public static void Startup()
        {
            Languages.Clear();
            Languages.Add(new CultureInfo("en-US")); // neutral
            Languages.Add(new CultureInfo("ru-RU"));
        }

        public static CultureInfo Language
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture;
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                if (value == Thread.CurrentThread.CurrentUICulture) return;

                Thread.CurrentThread.CurrentUICulture = value;

                ResourceDictionary dict = new()
                {
                    Source = value.Name switch
                    {
                        "ru-RU" => new Uri(string.Format("Resources/lang.{0}.xaml", value.Name), UriKind.Relative),
                        _ => new Uri("Resources/lang.xaml", UriKind.Relative),
                    }
                };

                ResourceDictionary? oldDict = null;

                foreach (var _dict in Application.Current.Resources.MergedDictionaries)
                {
                    if (_dict.Source.ToString().StartsWith("/Resources/Lang."))
                    {
                        oldDict = _dict;
                        break;
                    }
                }

                if (oldDict is not null)
                {
                    int ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                    Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                    Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
                }
            }
        }
    }
}

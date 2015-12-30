using System.Configuration;

namespace Web.Core.Utils.Helpers
{
    public static class BrandManager
    {
        private static readonly string AppName = "branding:app-name";

        public static string GetBrandName()
        {
            return ConfigurationManager.AppSettings[AppName];
        }
    }
}
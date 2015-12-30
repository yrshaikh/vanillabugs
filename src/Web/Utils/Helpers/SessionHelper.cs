using System;

namespace Web.Utils
{
    public static class SessionHelper
    {
        public static void Add<T>(string key, T value)
        {
            if(string.IsNullOrEmpty(key))
                throw new ArgumentNullException(key);

            if(value == null)
                throw new ArgumentNullException();

            System.Web.HttpContext.Current.Session[key] = value;
        }

        public static T Get<T>(string key)
        {
            return (T)System.Web.HttpContext.Current.Session[key];
        }
    }
}
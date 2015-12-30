using System.Web.Mvc;
using Ninject;

namespace Web.Utils
{
    public abstract class InjectedWebViewPage<T> : WebViewPage<T>
    {
        [Inject]
        public WebHelper WebHelper { get; set; }
    }
}
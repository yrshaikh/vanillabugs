using System.Web.Mvc;
using Ninject.Modules;

namespace Web.Utils
{
    public class WebInterfaceBindModule : NinjectModule
    {
        public override void Load()
        {
            Bind<WebViewPage>().To<InjectedWebViewPage<dynamic>>();
        }
    }
}
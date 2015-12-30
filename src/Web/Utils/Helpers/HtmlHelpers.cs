using System;
using System.Web.Mvc;

namespace Web.Utils
{
    public static class HtmlHelpers
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null)
        {
            const string cssClass = "active";
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller.ToLower() == currentController.ToLower() && action.ToLower() == currentAction.ToLower() ?
                cssClass : String.Empty;
        }
    }
}
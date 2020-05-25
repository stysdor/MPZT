using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPZT.GUI.CustomAuthentication
{
    public class CustomAuthorizeAttribute: AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return ((CurrentUser != null && !CurrentUser.IsInRole(Roles)) || CurrentUser == null) ? false : true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            RedirectToRouteResult routeData = null;

            var request = filterContext.HttpContext.Request;
            string returnUrl ="";

            // Get return url if it exist
            if (request.HttpMethod.Equals("GET", System.StringComparison.CurrentCultureIgnoreCase))
                returnUrl = request.RawUrl;

            if (CurrentUser == null)
            {
                routeData = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller = "Account",
                        action = "Login",
                        ReturnUrl = returnUrl
                    }
                    ));
            }
            else
            {
                routeData = new RedirectToRouteResult
                    (new System.Web.Routing.RouteValueDictionary
                    (new
                    {
                        controller="Error",
                        action = "AccessDenied"
                    }));
            }
            filterContext.Result = routeData;
        }
    }
}
using MPZT.GUI.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MPZT.GUI.Controllers
{

    /// <summary>
    /// Base controller for accessing User data in all controllers.
    /// </summary>
    public class BaseController : Controller
    {
        protected virtual new CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
    }
}
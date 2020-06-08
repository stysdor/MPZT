using MPZT.GUI.CustomAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MPZT.GUI.Controllers
{
    public class OfficeController : Controller
    {
        [CustomAuthorize(Roles = "OfficeMember")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
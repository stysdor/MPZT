using MPZT.GUI.CustomAuthentication;
using MPZT.GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Text.Json;
using System.Text.Json.Serialization;
using MPZT.GUI.Logic;
using AutoMapper;
using MPZT.Infrustructure.ModelDto;

namespace MPZT.GUI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private IMapper _mapper;

        public AccountController(IMapper mapper)
        {
            _mapper = mapper;
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.UserName, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.UserName, false);
                    if(user != null)
                    {
                        CustomSerializeModel userModel = new Models.CustomSerializeModel()
                        {
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            RoleName = user.Roles.Select(r => r.RoleName).ToList()
                        };

                        string userData =  JsonSerializer.Serialize(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1,loginView.UserName,DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );
                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                    }

                    return RedirectToLocal(ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Login lub hasło nieprawidłowe");
            return View("Login", loginView);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(Registration registrationView)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                // Email Verification  
                string userName = Membership.GetUserNameByEmail(registrationView.Email);
                if (!string.IsNullOrEmpty(userName))
                {
                    ModelState.AddModelError("Email", "Użytkownik z podanym adresem email już istnieje.");
                    return View(registrationView);
                }

                // UserName Verification
                var user = Membership.GetUser(registrationView.Login, false);
                if (user != null)
                {
                    ModelState.AddModelError("Login", "Użytkownik z podanym loginem już istnieje.");
                    return View(registrationView);
                }

                //Hash the password
                registrationView.Password = new UserPasswordManager().GetHash(registrationView.Password);
                //Save User Data
                var data = new ApiClient().PostData($"api/account/PostUser",_mapper.Map<UserDto>(registrationView));

                if(data)
                {
                    statusRegistration = true;
                    return RedirectToAction("Login", "Account", null);
                }
                    
            }

            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;
            return View(registrationView);
        }
         
    }
}
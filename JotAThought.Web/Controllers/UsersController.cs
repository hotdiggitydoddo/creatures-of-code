using JotAThought.Domain.Contracts;
using JotAThought.Model;
using JotAThought.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Net;

namespace JotAThought.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IFormsAuthentication _formsAuth;
        private readonly IUserService _userService;

        public UsersController(IUserService service, IFormsAuthentication formsAuth)
        {
            _userService = service;
            _formsAuth = formsAuth;
        }

        //
        // GET: /Users/

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            User user;

            if (ModelState.IsValid)
            {
                user = _userService.GetUser(model.UserName, model.Password);

                if (user != null)
                {
                    _formsAuth.SignIn(user.UserName, model.RememberMe, new List<string>() {"none"});
                    return RedirectToAction("index", "posts");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect");
                return View(model);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect");
            return View(model);
        }

        public ActionResult Logout()
        {
            _formsAuth.SignOut();
            return RedirectToAction("Index", "posts");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                string confirmationToken;

                if (_userService.CreateUser(model.UserName, model.Password, model.EmailAddress, out confirmationToken))
                {
                    var hostUrl = Url.Action("ConfirmUser", "Users", new { token = confirmationToken }, "http");
                    var text = "Hello, " + model.UserName + "!  Welcome to Creatures of Code!  To start blogging, click the link below to verify your account.\r\n\r\n";
                    var confirmationLink = string.Format("<a href=\"{0}\">Click to confirm your account.", hostUrl);

                    var message = new MailMessage("hotdiggitydoddo@gmail.com", model.EmailAddress) 
                    {
                        Subject = "Please Confirm Your Email", 
                        Body = text + confirmationLink 
                    };

                    message.IsBodyHtml = true;

                    var client = new SmtpClient()
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true
                        
                    };
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential("hotdiggitydoddo@gmail.com", "kewlio16");
                    client.Send(message);
                   
                    return RedirectToAction("Index", "posts");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error creating user.");
                return View(model);
            }
            ModelState.AddModelError("", "Error creating user.");
            return View(model);
        }

        [AllowAnonymous]
        public string ConfirmUser(string token)
        {
            string userName = string.Empty;

            if (_userService.VerifyUser(token, out userName))
                Response.Write("Thank you, " + userName + ".  You are now registered!");
            else
                Response.Write("You could not be validated.");
            return null;
        }
    }
}

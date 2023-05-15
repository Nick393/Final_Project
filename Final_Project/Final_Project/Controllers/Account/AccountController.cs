using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Final_Project.Models.DomainModels;
using Final_Project.Models.ViewModels;
using Final_Project.Models;
using System.Net.Mail;
using System.Net;
using Final_Project.Areas.EmailSubsystem.Models.DomainModels;

namespace Final_Project.Controllers.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Account> userManager;
        private SignInManager<Account> signInManager;
        private SiteContext _SiteContext;

        public AccountController(UserManager<Account> userMngr,
            SignInManager<Account> signInMngr,SiteContext siteContext)
        {
            userManager = userMngr;
            _SiteContext = siteContext;
            signInManager = signInMngr;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Account
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.Firstname,
                    LastName = model.Lastname
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL)
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, isPersistent: model.RememberMe,
                    lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                        Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                Account user = await userManager.FindByNameAsync(model.Username);
                var result = await userManager.ChangePasswordAsync(user,
                    model.OldPassword, model.NewPassword);

                if (result.Succeeded)
                {
                    TempData["message"] = "Password changed successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult MyAccount()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UserNameGet()
        {
            var get = new UserNameGet();
            return View(get);
        }
        [HttpPost]
        public IActionResult UserNameGet(UserNameGet model)
        {
            if (ModelState.IsValid)
            {
                return View("ResetPassword", model);
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(UserNameGet get)

        {

            Account account = new Account();
            foreach (Account acct in userManager.Users)
            {
                if (acct.UserName == get.UserName)
                {
                    account = acct;
                }
            }
            SmtpConfig config = new SmtpConfig();
            foreach (SmtpConfig cfg in _SiteContext.SMTPConfig)
            {
                config = cfg;
            }
            string Key = await userManager.GeneratePasswordResetTokenAsync(account);
            var smtpClient = new SmtpClient(config.provider)//provider=smtp.gmail.com
            {
                Port = config.port,//587 gmail//kgbfwawmqhernvmm//zllfebczaqewfqdx
                                   //vmgadsqskmtwnvjp

                //kgbfwawmqhernvmm
                Credentials = new NetworkCredential(config.emailAddress, config.smtpKey),//keyMailService@gmail.com//vmgadsqskmtwnvjp
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(config.emailAddress),
                Subject = "Reset Password",
                Body = "<p>" + "Your password reset token is: " + Key + "  Do not share it with anyone" + "</p>",
                IsBodyHtml = true,

            };
            mailMessage.To.Add(config.emailAddress);
            mailMessage.Bcc.Add(account.Email);
            try
            {
                smtpClient.Send(mailMessage);
                mailMessage.Bcc.Clear();
            }
            catch (Exception ex)
            {
                return View("Unable");
            }
            ResetPassword rs = new ResetPassword();
            rs.Username = account.UserName;
            return View("ResetPassword", rs);
        }
        [HttpGet]
        public IActionResult ResetPassword(ResetPassword ps)
        {
            if (ModelState.IsValid)
            {

                return (RedirectToAction("Index"));
            }
            return View(ps);
        }

    }
}
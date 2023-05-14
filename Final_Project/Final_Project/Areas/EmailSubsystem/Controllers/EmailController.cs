//using AspNetCore;
using Final_Project.Areas.EmailSubsystem.Models;
using Final_Project.Areas.EmailSubsystem.Models.DomainModels;
using Final_Project.Models;
using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Net.Mail;

namespace Final_Project.Areas.EmailSubsystem.Controllers
{
    [Area("EmailSubsystem")]
    public class EmailController : Controller
    {

        private SiteContext _siteContext;
        private UserManager<Account> userManager;
        private RoleManager<IdentityRole> roleManager;
        public EmailController(UserManager<Account> userMngr,
            RoleManager<IdentityRole> roleMngr, SiteContext siteContext)
        {
            _siteContext = siteContext;
            userManager = userMngr;
            roleManager = roleMngr;
        }
        [HttpGet]
        public IActionResult Form()
        {
            EmailModel model = new EmailModel();
            model.Users = userManager.Users.ToList();
            model.EmailAddresses = new List<string>();

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Form(EmailModel model)
        {
            List<string> Usernames = new List<string>();
            model.Users = userManager.Users.ToList();
            model.EmailAddresses = new List<string>();

            Email email = new Email();
            email.EmailAddresses = new List<string>();
            if (ModelState.ErrorCount < 3)
            {
                SmtpConfig sm = new SmtpConfig();
                if (_siteContext.SMTPConfig == null || _siteContext.SMTPConfig.Count() == 0)
                {
                    return RedirectToAction("SmtpConfig");
                }
                if (_siteContext.SMTPConfig.Count() > 0)
                {
                    foreach (SmtpConfig sMTPConfig in _siteContext.SMTPConfig)
                    {
                        if (sMTPConfig.smtpKey != null)
                        {
                            sm = sMTPConfig;
                        }
                    }
                }
                var smtpClient = new SmtpClient(sm.provider)//provider=smtp.gmail.com
                {
                    Port = sm.port,//587 gmail//kgbfwawmqhernvmm//zllfebczaqewfqdx
                    //vmgadsqskmtwnvjp

                    //kgbfwawmqhernvmm
                    Credentials = new NetworkCredential(sm.emailAddress, sm.smtpKey),//keyMailService@gmail.com//vmgadsqskmtwnvjp
                    EnableSsl = true,
                };
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(sm.emailAddress),
                    Subject = model.Subject,
                    Body = "<p>" + model.Body + "</p>",
                    IsBodyHtml = true,

                };
                mailMessage.To.Add(sm.emailAddress);
                if (model.UserName.Contains("Group"))
                {
                    string groupName = model.UserName.Substring(model.UserName.IndexOf(":") + 2);
                    if (groupName == "All")
                    {
                        foreach (Account acct in userManager.Users)
                        {
                            acct.RoleNames = await userManager.GetRolesAsync(acct);
                            if (acct.Email != null)
                            {
                                Usernames.Add(acct.UserName);
                                model.EmailAddresses.Add(acct.Email);
                                mailMessage.Bcc.Add(acct.Email);
                            }
                        }
                    }
                    else if (groupName == "Students")
                    {
                        foreach (Account acct in userManager.Users)
                        {
                            acct.RoleNames = await userManager.GetRolesAsync(acct);
                            if (!(acct.RoleNames == null))
                            {
                                if (acct.Email != null && acct.isRole("Student"))
                                {
                                    Usernames.Add(acct.UserName);
                                    model.EmailAddresses.Add(acct.Email);
                                    mailMessage.Bcc.Add(acct.Email);
                                }
                            }
                        }
                    }
                    else if (groupName == "Mentors")
                    {
                        foreach (Account acct in userManager.Users)
                        {
                            acct.RoleNames = await userManager.GetRolesAsync(acct);
                            if (!(acct.RoleNames == null))
                            {
                                if (acct.Email != null && acct.isRole("Admin"))
                                {
                                    Usernames.Add(acct.UserName);
                                    model.EmailAddresses.Add(acct.Email);
                                    mailMessage.Bcc.Add(acct.Email);
                                }
                            }

                        }
                    }
                }
                else
                {
                    string recipient = model.UserName.Substring(model.UserName.IndexOf(":") + 2);
                    foreach (Account acct in userManager.Users)
                    {
                        acct.RoleNames = await userManager.GetRolesAsync(acct);
                        if (acct.Email != null && acct.UserName == recipient)
                        {
                            Usernames.Add(acct.UserName);
                            model.EmailAddresses.Add(acct.Email);
                            mailMessage.Bcc.Add(acct.Email);
                        }
                    }
                }
                string usernames = "";
                foreach (string s in Usernames)
                {
                    if (usernames == "")
                    { usernames = s; }
                    else
                    {
                        usernames += "," + s;
                    }

                }
                email.usernames = usernames;
                email.Subject = model.Subject; email.Body = model.Body;
                email.EmailAddresses = model.EmailAddresses;
                //email.EmailAddresses=model.EmailAddresses;


                try
                {
                    smtpClient.Send(mailMessage);
                    mailMessage.Bcc.Clear();
                    email.success = true;
                }

                catch (Exception ex)
                {
                    email.success = false;
                    email.error = ex.Message;
                }
                foreach (string s in email.EmailAddresses)
                {
                    if (email.emailsCSV == string.Empty)
                    {
                        email.emailsCSV = s;
                    }
                    else
                    {
                        email.emailsCSV = email.emailsCSV + "," + s;
                    }
                }
                _siteContext.Emails.Add(email);
                _siteContext.SaveChanges();
                if (email.success)
                {
                    return RedirectToAction("success");
                }
                else
                {
                    return RedirectToAction("fail");
                }


            }

            return View(model);
        }
        public IActionResult Success()
        {
            return View();
        }
        public IActionResult Fail()
        {
            return View();
        }
        public IActionResult Index()
        {
            List<Email> emails;
            emails = _siteContext.Emails.ToList();
            EmailsModel model = new EmailsModel();
            model.emails = emails;


            return View(model);
        }
        public IActionResult Email(int id)
        {
            foreach (Email email in _siteContext.Emails)
            {
                if (email.id == id)
                {
                    return View(email);
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            foreach (Email email in _siteContext.Emails)
            {
                if (email.id == id)
                {
                    _siteContext.Remove(email);
                    _siteContext.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SmtpConfig()
        {
            SmtpConfig config = new SmtpConfig();
            if (_siteContext.SMTPConfig != null)
            {
                foreach (SmtpConfig s in _siteContext.SMTPConfig)
                {
                    config = s;
                }
            }
            else
            {
                config = new SmtpConfig();
            }
            SmtpConfigModel model = new SmtpConfigModel();
            model.port = config.port;
            model.emailAddress = config.emailAddress;
            model.provider = config.provider;
            model.smtpKey = config.smtpKey;
            return View(model);
        }
        [HttpPost]
        public IActionResult SmtpConfig(SmtpConfigModel model)
        {
            if(ModelState.IsValid)
            {
                SmtpConfig smtpConfig = new SmtpConfig();
                smtpConfig.smtpKey = model.smtpKey;
                smtpConfig.emailAddress = model.emailAddress;
                smtpConfig.provider = model.provider;
                smtpConfig.port = model.port;
                if (_siteContext.SMTPConfig.Count() == 0 || _siteContext.SMTPConfig == null)
                {
                    _siteContext.SMTPConfig.Add(smtpConfig);
                }
                else
                {
                    foreach(SmtpConfig cfg in _siteContext.SMTPConfig)
                    {
                        _siteContext.SMTPConfig.Remove(cfg);
                    }
                    _siteContext.SMTPConfig.Add(smtpConfig);
                }
                _siteContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
    }
}

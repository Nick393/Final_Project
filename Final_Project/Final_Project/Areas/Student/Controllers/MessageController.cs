﻿//using AspNetCore;
using Final_Project.Areas.Student.Models.DomainModels;
using Final_Project.Areas.Student.Models.ViewModels;

//using migrations
using Final_Project.Models;
using Final_Project.Models.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.VisualBasic;
using System.Data;
using System.Net.Mail;
using System.Net;
using Final_Project.Areas.EmailSubsystem.Models.DomainModels;
using Final_Project.Migrations;

namespace Final_Project.Areas.Student.Controllers
{
    [Area("Student")]

    [Authorize(Roles = "Student, Admin")]
    public class MessageController : Controller
    {
        private SiteContext _siteContext;
        private UserManager<Account> userManager;
        private RoleManager<IdentityRole> roleManager;
        private List<Models.DomainModels.Message> messages = new List<Models.DomainModels.Message>();
        //private Repository<Message> data { get; set; }
        public MessageController(SiteContext ctx, UserManager<Account> userMngr,
            RoleManager<IdentityRole> roleMngr)
        {
            _siteContext = ctx;
            messages = _siteContext.Messages
                    .OrderBy(c => c.id)
                    .ToList();
            userManager = userMngr;
            roleManager = roleMngr;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("MessageBoard");
        }
        [HttpGet]
        public IActionResult PostMessage()
        {
            PostMessageModel model = new PostMessageModel();
            model.Users=userManager.Users.ToList();
            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult> PostMessage(PostMessageModel model)
        {
            model.Users= userManager.Users.ToList();
            /*List<Message> messages;

            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();
            MessageViewModel viewModel = new MessageViewModel();
            viewModel.Messages = messages;*/
            
            if (ModelState.ErrorCount<2)
            {
                Models.DomainModels.Message message = new Models.DomainModels.Message();//This works
                message.Title = model.Title;
                message.isReply = false;
                message.id = model.id;
                message.ParentID = 0;
                message.UserName = User.Identity?.Name ?? "";
                message.Body = model.Body;
                
                message.Recip=model.Recip;
                message.Replies = model.Replies;
               /* if (model.isPM == false)
                {
                    message.isPM = model.isPM;
                    message.Recip = string.Empty;
                }*/
                 if(message.Recip=="All")
                {
                    message.isPM = false;
                    message.Recip = string.Empty;
                }
                else
                {
                    Final_Project.Areas.EmailSubsystem.Models.DomainModels.SmtpConfig  sm= new Final_Project.Areas.EmailSubsystem.Models.DomainModels.SmtpConfig();
                    message.isPM = true; message.Recip = model.Recip;
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
                        Subject = model.Recip+ " sent you a message!",
                        Body = "<p>View online</p>",
                        IsBodyHtml = true,

                    };
                    mailMessage.To.Add(sm.emailAddress);
                   Account recip=await userManager.FindByNameAsync(model.Recip);
                    mailMessage.Bcc.Add(recip.Email);
                    try
                    {
                        smtpClient.Send(mailMessage);
                        mailMessage.Bcc.Clear();
                        
                    }

                    catch (Exception ex)
                    {
                    }
                    }
                
                
                _siteContext.Messages.Add(message);
                _siteContext.SaveChanges();
                return RedirectToAction("MessageBoard");
            }
            else
            {
                return View(model);
            }

            
        }
         [HttpGet]
        public IActionResult MessageBoard()
        {
            List<Models.DomainModels.Message> messages;
            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();
            MessageViewModel viewModel = new MessageViewModel();
            viewModel.Messages = messages;
            viewModel.Users = userManager.Users;
            return View(viewModel);
            //return View(model);
        }
        /*[HttpPost]
        public ViewResult Delete(int id)
        {
            foreach (Message message in _siteContext.Messages)
            {
                if(message.id==id)
                {
                    _siteContext.Remove(message);
                    _siteContext.SaveChanges();
                }
            }
            
            return View("MessageBoard");
        }*/

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            foreach (Models.DomainModels.Message message in _siteContext.Messages)
            {
                if(message.id == id)
                {
                    _siteContext.Messages.Remove(message);
                }
            }


            //_siteContext.Messages.Remove(message); 
            try
            {


                _siteContext.SaveChanges();
            }
            catch
            {
                foreach (Message message in _siteContext.Messages)
                {
                    message.isReply = true;
                    message.isPM = true;
                    message.obscure= true;
                }
                return RedirectToAction("MessageBoard");
            }
            return RedirectToAction("MessageBoard");  
        }
        public IActionResult Message(int id)
        {
            foreach (Final_Project.Areas.Student.Models.DomainModels.Message message in _siteContext.Messages)
            {

                if (message.id == id)
                {
                    return View(message);
                }
            }
            return RedirectToAction("MessageBoard");
        }
        [HttpGet]
        public IActionResult ReplyMessage(int parentId)
        {
            ReplyMessageModel model = new ReplyMessageModel();
           // model.ParentId= parentId;
            return View(model);
        }
        [HttpPost]
        public IActionResult ReplyMessage(ReplyMessageModel model)
        {
            /*List<Message> messages;

            messages = _siteContext.Messages
                   .OrderBy(p => p.id).ToList();
            MessageViewModel viewModel = new MessageViewModel();
            viewModel.Messages = messages;*/

            if (ModelState.IsValid)
            {
                Models.DomainModels.Message message = new Models.DomainModels.Message();
                message.Title = model.Title;
                //message.id = model.id;
                message.UserName = User.Identity?.Name ?? "";
                message.Body = "";
                message.Replies = model.Replies;
                message.isReply = true;
                foreach (Models.DomainModels.Message msg in _siteContext.Messages)
                {
                    if(msg.id==model.id)
                    {
                        message.ParentID= msg.id;
                        msg.Replies.Add(message);
                        
                    }
                }
                
                _siteContext.SaveChanges();
                return RedirectToAction("MessageBoard");
            }
            else
            {
                return View(model);
            }


        }
        public IActionResult returnToLast(int id)
        {
            foreach (Message msg in _siteContext.Messages)
            {
                if(msg.id==id)
                {
                    return View("Message", msg);
                }
            }
            return RedirectToAction("MessageBoard");
        }
        [HttpGet]
        public IActionResult Reset()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetBoard()
        {
            foreach (Message msg in _siteContext.Messages)
            {

                //msg.Replies =new List<Message>();
                //msg.Users = new List<Account>();
                //msg.isReply = false;
                //msg.isPM = false;
                //msg.Recip = string.Empty;
                //msg.UserName = string.Empty;
                //msg.Body = string.Empty;
                //msg.ParentID = 0;
                //msg.Title = string.Empty;
                

            }
            
           
            _siteContext.SaveChanges();
            foreach (Message msg in _siteContext.Messages)
            {
                //msg.Users=new List<Account>();
                _siteContext.Messages.Remove(msg);
            }
            try
            {
                _siteContext.SaveChanges();
            }
            catch (Exception ex)
            {
                foreach(Message msg in _siteContext.Messages)
                {
                    msg.isReply = true;
                    msg.obscure = true;
                    
                }
            }

                return RedirectToAction("MessageBoard");
        }
    }
}

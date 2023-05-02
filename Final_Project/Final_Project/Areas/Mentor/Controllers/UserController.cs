using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Final_Project.Models;
using Final_Project.Models.DomainModels;

using Final_Project.Models.ViewModels;
using Final_Project.Areas.Mentor.Models;
using Final_Project.Areas.Mentor.Models.ViewModels;
using System.Reflection.Metadata.Ecma335;

namespace Final_Project.Areas.Mentor.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Mentor")]
    public class UserController : Controller
    {
        private UserManager<Account> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SiteContext siteContext;
        private List<Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request> requests = new List<Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request>();
        
        public UserController(UserManager<Account> userMngr, 
            RoleManager<IdentityRole> roleMngr,SiteContext ctx)
        {
            userManager = userMngr;
            roleManager = roleMngr;
            siteContext = ctx;
            requests = siteContext.VolReqs
                    .OrderBy(c => c.id)
                    .ToList();
        }

        public async Task<IActionResult> Approval()
        {
            List<Account> users = new List<Account>();
            foreach (Account user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            List <Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request>reqs= new List<Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request>();
            foreach (Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request r in siteContext.VolReqs)
            {
                reqs.Add(r);
            }
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles,
                requests= reqs
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            Account user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded) // if failed
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Approval");
        }
        [HttpPost]
        public RedirectToActionResult Resolve(int id)
        {
            foreach (Final_Project.Areas.VolunteerRequest.Models.DomainModels.Request req in siteContext.VolReqs)
            {
                if(req.id==id)
                {
                    siteContext.VolReqs.Remove(req);
                }
            }
   

            siteContext.SaveChanges();

            return RedirectToAction("Approval");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new Account { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Approval");
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
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist. "
                    + "Click 'Create Admin Role' button to create it.";
            }
            else
            {
                Account user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("Approval");
        }
        [HttpPost]
        public async Task<IActionResult> AddToStudent(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Student");
            if (adminRole == null)
            {
                TempData["message"] = "Student role does not exist. "
                    + "Click 'Create Student Role' button to create it.";
            }
            else
            {
                Account user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("Approval");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            Account user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, "Admin");
            if (result.Succeeded) { }
            return RedirectToAction("Approval");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromStudent(string id)
        {
            Account user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, "Student");
            if (result.Succeeded) { }
            return RedirectToAction("Approval");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded) { }
            return RedirectToAction("Approval");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded) { }
            return RedirectToAction("Approval");
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudentRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Student"));
            if (result.Succeeded) { }
            return RedirectToAction("Approval");
        }
        /*[HttpGet]
        public RedirectToActionResult ChangePassword(string id)
        {
            foreach (Account Acct in userManager.Users)
            {
                if (Acct.Id == id)
                {
                    Acct.PasswordHash = null ;
                    
                        Acct.RoleNames = null ;
                    
                }
            }
            return RedirectToAction("Approval");
        }*/
        [HttpGet]
        public async Task <IActionResult> ResetPassword(string Id)
        {
            if(Id== null)
            {
                return RedirectToAction("FFFFFF");
            }
            var acc=await userManager.FindByIdAsync(Id);
            if(acc.Id == null) {
                return RedirectToAction("error");
            }
            //AHHHHHHHH its broken 

            /* Account ac=await userManager.FindByNameAsync(userName);
             Account user = new Account();
             user.UserName= User.UserName;
             Account[] users = userManager.Users.ToArray() ;
             IQueryable queryable = userManager.Users;
             foreach (Account account in queryable)
             {
                 if (account.UserName == userName)
                 {
                     user=account; break;
                 }
             }*/

            /*foreach (Account userNumber in users)
            {
                if (userNumber.UserName == userName)
                {
                    user = userNumber;
                }
            }*/

            var model = new Final_Project.Areas.Mentor.Models.ViewModels.ResetPasswordViewModel
            {

                id = acc.Id,
                 Username= acc.UserName,
                 user=acc
                 

                //Username = User.Identity?.Name ?? ""

                //Massive Bugger! accounts must still be signed in for this to work properly/text for details

            };
            //model.user = acc;
            return View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            // Account acct = new Account();
            /* acct.UserName = model.Username;
             acct.Id = model.id;
            var pass = model.NewPassword;
             model.NewPassword = pass;
             model.Username=acct.UserName;
             model.id = acct.Id;
             model.user=acct;*/
            model.user = await userManager.FindByIdAsync(model.id);
            
            
                if (ModelState.ErrorCount<2)//Modelstate appears to be evaluated upon button click.
                                            //one error is expected
                //due to setting of user property above in this method
                {
                    //this works  
                    string resetToken = await userManager.GeneratePasswordResetTokenAsync(model.user);
                    IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(model.user, resetToken, model.NewPassword);
                    TempData["message"] = "Password changed successfully";
                    return RedirectToAction("Approval");
                }
            
            /*if(model.Username==null)
            {
                return RedirectToAction("false");
            }*/
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPass(ResetPasswordViewModel model)
        {

            string err = "errors: ";
            if (ModelState.IsValid)
            {
            
                var user = await userManager.FindByIdAsync(model.id);
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(model.user);
                var result = await userManager.ResetPasswordAsync(model.user, resetToken,model.NewPassword);

                if (result.Succeeded)
                {
                    TempData["message"] = "Password changed successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    string errList = "ERRs: ";
                    foreach (IdentityError error in result.Errors)
                    {
                        errList += error.Description;
                        err += error.Description;
                        ModelState.AddModelError("", error.Description);
                        return View(error.Description);
                    }
                    return View(errList);
                }
            }
            return View(err);
            /*Account account = new Account();
            
            model.user = account;
            if (ModelState.IsValid)
            {
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(model.user);
                IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(model.user, resetToken, model.NewPassword);
                TempData["message"] = "Password changed successfully";
                return RedirectToAction("Approval");
            }
            else
            {
                
            }
            return RedirectToAction(model.Username);*/
        }
    }
}
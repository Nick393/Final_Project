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

        public UserController(UserManager<Account> userMngr, 
            RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            roleManager = roleMngr;
        }

        public async Task<IActionResult> Approval()
        {
            List<Account> users = new List<Account>();
            foreach (Account user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
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

                id = Id,
                 Username= acc.UserName,
                 user=acc
                 

                //Username = User.Identity?.Name ?? ""

                //Massive Bugger! accounts must still be signed in for this to work properly/text for details

            };
            model.user = acc;
            return View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
             if (ModelState.IsValid)//Modelstate is not valid beacuse user is null
             {
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(model.user);
                IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(model.user, resetToken, model.NewPassword);
                TempData["message"] = "Password changed successfully";
                return RedirectToAction("Approval");
            }
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPass(ResetPasswordViewModel model)
        {

            string err = "errors: ";
            if (ModelState.IsValid)
            {
            
                var user = await userManager.FindByIdAsync(model.id);
                string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var result = await userManager.ResetPasswordAsync(user, resetToken,model.NewPassword);

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
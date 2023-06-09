﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Final_Project.Models;
using Final_Project.Models.DomainModels;

using Final_Project.Models.ViewModels;
using Final_Project.Areas.Mentor.Models;

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
    }
}
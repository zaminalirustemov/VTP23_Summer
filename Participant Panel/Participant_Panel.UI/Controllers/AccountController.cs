using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Participant_Panel.Business.Interfaces;
using Participant_Panel.Dtos.MemberDtos;
using Participant_Panel.Entites.Domains;

namespace Participant_Panel.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IDepartmentService _departmentService;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IDepartmentService departmentService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _departmentService = departmentService;
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
        //    return Json("ok");
        //}


        //Register-----------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Register()
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(MemberRegisterDto memberRegisterDto)
        {
            ViewBag.Departments = await _departmentService.GetAllAsync();
            if (!ModelState.IsValid) return View();
            
            AppUser appUser = null;

            appUser = await _userManager.FindByNameAsync(memberRegisterDto.Username);
            if (appUser is not null)
            {
                ModelState.AddModelError("Username", "Already exist!");
                return View();
            }


            appUser = new AppUser
            {
                Name = memberRegisterDto.Name,
                Surname=memberRegisterDto.Surname,
                UserName=memberRegisterDto.Username,
                DateOfBirth=memberRegisterDto.DateOfBith,
                DepartmentId=memberRegisterDto.DepartmentId,
                University=memberRegisterDto.University,
                Specialty=memberRegisterDto.Specialty,
                Class=memberRegisterDto.Class,
            };


            var result = await _userManager.CreateAsync(appUser, memberRegisterDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            await _userManager.AddToRoleAsync(appUser, "Member");

            return RedirectToAction("index", "home");
        }

        //Log in-------------------------------------------------------------------------------------------------------
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(MemberLoginDto memberLoginDto)
        {
            if (!ModelState.IsValid) return View();
            AppUser user = await _userManager.FindByNameAsync(memberLoginDto.UserName);
            if (user is null)
            {
                ModelState.AddModelError("", "Username or password is false");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, memberLoginDto.Password, false, false);

            if (!result.Succeeded)
            {
                if (!user.EmailConfirmed)
                {
                    ModelState.AddModelError("", "Please verify email");
                    return View();

                }
                ModelState.AddModelError("", "Username or password is false");
                return View();
            }

            return RedirectToAction("index", "home");
        }
        //Log out------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }
    }
}

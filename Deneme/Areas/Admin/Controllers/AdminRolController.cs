using Deneme.Areas.Admin.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Deneme.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[Controller]/[Action]/{id?}")]
    [Authorize(Roles ="Admin")]
    public class AdminRolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var result = _roleManager.Roles.ToList();
            return View(result);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel p)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = p.Name,
                };
                var result = await _roleManager.CreateAsync(role);
                if(result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();

        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name
            };

            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel p)
        {
            var result = _roleManager.Roles.FirstOrDefault(x => x.Id == p.Id);
            result.Name = p.Name;
            var value=await _roleManager.UpdateAsync(result);
            if (value.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View(value);
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(value);
            if (result.Succeeded)
                return RedirectToAction("Index");
            return View();
        }

        public IActionResult UserRoleList()
        {
            var result = _userManager.Users.ToList();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            var userRole = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();

            TempData["userId"] = user.Id;

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();
            foreach (var item in roles)
            {
                RoleAssignViewModel m = new RoleAssignViewModel();
                m.RoleID = item.Id;
                m.Name = item.Name;
                m.Exists = userRole.Contains(item.Name);
                model.Add(m);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = (int)TempData["userId"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in model)
            {
                if (item.Exists)
                    await _userManager.AddToRoleAsync(user,item.Name);
                else
                    await _userManager.RemoveFromRoleAsync(user,item.Name);
            }

            return RedirectToAction("UserRoleList");
        }

    }
}

using DtoLayer.Dtos.UserDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.Controllers
{
    public class UserSettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserSettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto();
            userEditDto.Name = value.Name;
            userEditDto.Surname = value.LastName;
            userEditDto.UserName = value.UserName;
            userEditDto.Mail = value.Email;

            return View(userEditDto);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
           
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.LastName = userEditDto.Surname;
                user.UserName = userEditDto.Mail;
                user.Email = userEditDto.Mail;
                user.PasswordHash = _userManager
                    .PasswordHasher
                    .HashPassword(user, userEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                Console.Write(result.Errors.ToString());
                return Redirect("/Home/Index");
            
            

        }
    }
}

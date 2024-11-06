using DtoLayer.Dtos.UserDtos;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    [Authorize]
    public class HomeSidebarProfileViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public HomeSidebarProfileViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _userManager.FindByEmailAsync(User.Identity.Name);
            UserViewDto userViewDto = new UserViewDto();
            userViewDto.Name = value.Name;
            userViewDto.LastName = value.LastName;
            return View(userViewDto);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class HomeSidebarViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
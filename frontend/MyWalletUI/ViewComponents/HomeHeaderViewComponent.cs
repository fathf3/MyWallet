using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class HomeHeaderViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

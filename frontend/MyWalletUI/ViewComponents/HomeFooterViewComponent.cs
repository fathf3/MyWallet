using Microsoft.AspNetCore.Mvc;

namespace MyWalletUI.ViewComponents
{
    public class HomeFooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
